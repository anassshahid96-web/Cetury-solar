# Solar Project

Organized project structure for GitHub and deployment.

## Structure

- `frontend/` static website files
  - `index.html` (primary entry page)
  - `services.html`
  - `projects.html`
  - `about.html`
  - `assets/screenshots/` design screenshots
  - `docs/DESIGN.md`
- `backend/` ASP.NET Core API + static hosting
  - serves frontend pages
  - provides `/api/*` endpoints

## Run Full App Locally

```powershell
cd E:\solar\backend
dotnet run
```

Open:

- `http://localhost:5119/`
- `http://localhost:5119/home`

## Static Frontend Entry

If you deploy only frontend static files, use:

- `frontend/index.html`
