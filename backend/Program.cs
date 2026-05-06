using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.FileProviders;
using SolarBackend.Models;
using SolarBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddSingleton<CatalogRepository>();
builder.Services.AddSingleton<QuoteRepository>();
builder.Services.AddSingleton<QuoteEstimator>();
builder.Services.AddSingleton<QuoteService>();

var app = builder.Build();

app.UseCors("default");

var frontendRoot = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, "..", "frontend"));

if (Directory.Exists(frontendRoot))
{
    var frontendProvider = new PhysicalFileProvider(frontendRoot);
    var defaultFiles = new DefaultFilesOptions
    {
        FileProvider = frontendProvider
    };

    defaultFiles.DefaultFileNames.Clear();
    defaultFiles.DefaultFileNames.Add("index.html");

    app.UseDefaultFiles(defaultFiles);
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = frontendProvider
    });

    app.MapGet("/home", () => Results.Redirect("/index.html"));
    app.MapGet("/services", () => Results.Redirect("/services.html"));
    app.MapGet("/projects", () => Results.Redirect("/projects.html"));
    app.MapGet("/about", () => Results.Redirect("/about.html"));
    app.MapGet("/contact", () => Results.Redirect("/about.html"));
}

app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        serverTimeUtc = DateTime.UtcNow
    });
});

app.MapGet("/api/company", (CatalogRepository catalog) =>
{
    return Results.Ok(catalog.GetCompanyProfile());
});

app.MapGet("/api/services", (CatalogRepository catalog, string? category) =>
{
    var items = catalog.GetServices(category);
    return Results.Ok(new
    {
        count = items.Count,
        items
    });
});

app.MapGet("/api/projects", (CatalogRepository catalog, int page = 1, int pageSize = 6) =>
{
    var safePage = Math.Max(page, 1);
    var safePageSize = Math.Clamp(pageSize, 1, 50);

    var ordered = catalog.GetProjects()
        .OrderByDescending(project => project.Featured)
        .ThenByDescending(project => project.CompletedOn)
        .ToList();

    var totalItems = ordered.Count;
    var totalPages = totalItems == 0 ? 0 : (int)Math.Ceiling(totalItems / (double)safePageSize);

    var pagedItems = ordered
        .Skip((safePage - 1) * safePageSize)
        .Take(safePageSize)
        .ToList();

    var result = new PagedResult<ProjectCaseStudy>
    {
        Items = pagedItems,
        Page = safePage,
        PageSize = safePageSize,
        TotalItems = totalItems,
        TotalPages = totalPages
    };

    return Results.Ok(result);
});

app.MapGet("/api/projects/{id}", (CatalogRepository catalog, string id) =>
{
    var item = catalog.GetProjects()
        .FirstOrDefault(project => string.Equals(project.Id, id, StringComparison.OrdinalIgnoreCase));

    return item is null ? Results.NotFound(new { message = "Project was not found." }) : Results.Ok(item);
});

app.MapPost("/api/quotes", async (QuoteRequest request, QuoteService quoteService, CancellationToken cancellationToken) =>
{
    var errors = ValidateQuoteRequest(request);
    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }

    var createdLead = await quoteService.CreateLeadAsync(request, cancellationToken);
    return Results.Created($"/api/quotes/{createdLead.Id}", createdLead);
});

app.MapGet("/api/quotes", async (QuoteService quoteService, int limit = 50, CancellationToken cancellationToken = default) =>
{
    var leads = await quoteService.GetRecentLeadsAsync(limit, cancellationToken);
    return Results.Ok(new
    {
        count = leads.Count,
        items = leads
    });
});

app.Run();

static Dictionary<string, string[]> ValidateQuoteRequest(QuoteRequest request)
{
    var errors = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

    if (string.IsNullOrWhiteSpace(request.PhoneNumber))
    {
        errors["phoneNumber"] = ["Phone number is required."];
    }
    else
    {
        var isPhoneValid = Regex.IsMatch(request.PhoneNumber, @"^[\d+\-\s]{8,20}$");
        if (!isPhoneValid)
        {
            errors["phoneNumber"] = ["Phone number format is invalid."];
        }
    }

    if (request.MonthlyBillPkr <= 0)
    {
        errors["monthlyBillPkr"] = ["Monthly bill must be greater than zero."];
    }
    else if (request.MonthlyBillPkr < 1000 || request.MonthlyBillPkr > 2000000)
    {
        errors["monthlyBillPkr"] = ["Monthly bill must be between 1,000 and 2,000,000 PKR."];
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
        var isEmailValid = Regex.IsMatch(request.Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        if (!isEmailValid)
        {
            errors["email"] = ["Email format is invalid."];
        }
    }

    return errors;
}
