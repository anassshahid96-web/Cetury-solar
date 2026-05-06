# Solar Backend

ASP.NET Core minimal API backend for the Century Solar frontend.

## What this backend provides

- Static pages from `../frontend`:
  - `/` -> `index.html`
  - `/home` -> `index.html`
  - `/services` -> `services.html`
  - `/projects` -> `projects.html`
  - `/about` -> `about.html`
  - `/contact` -> `about.html`
- APIs:
  - `GET /api/health`
  - `GET /api/company`
  - `GET /api/services?category=Residential`
  - `GET /api/projects?page=1&pageSize=6`
  - `GET /api/projects/{id}`
  - `POST /api/quotes`
  - `GET /api/quotes?limit=50`

## Run

```powershell
cd E:\solar\backend
dotnet run
```

Then open `http://localhost:5119/` or `http://localhost:5119/home`.
