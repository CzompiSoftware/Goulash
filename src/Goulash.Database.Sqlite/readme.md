# Goulash's SQLite Database Provider

This project contains Goulash's SQLite database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context SqliteContext --output-dir Migrations --startup-project ..\Goulash\Goulash.csproj

dotnet ef database update --context SqliteContext
```
