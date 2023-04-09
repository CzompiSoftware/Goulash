# Goulash's PostgreSql Database Provider

This project contains Goulash's PostgreSql database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context PostgreSqlContext --output-dir Migrations --startup-project ..\Goulash\Goulash.csproj

dotnet ef database update --context PostgreSqlContext
```
