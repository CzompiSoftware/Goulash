# Goulash's MySQL Database Provider

This project contains Goulash's MySQL database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context MySqlContext --output-dir Migrations --startup-project ..\Goulash\Goulash.csproj

dotnet ef database update --context MySqlContext
```
