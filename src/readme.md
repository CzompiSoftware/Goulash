# Goulash Source Code

These folders contain the core components of Goulash:

* `Goulash` - The app's entry point that glues everything together.
* `Goulash.Core` - Goulash's core logic and services.
* `Goulash.Web` - The [NuGet server APIs](https://docs.microsoft.com/en-us/nuget/api/overview) and web UI.
* `Goulash.Protocol` - Libraries to interact with [NuGet servers' APIs](https://docs.microsoft.com/en-us/nuget/api/overview).

These folders contain database-specific components of Goulash:

* `Goulash.Database.MySql` - Goulash's MySQL database provider.
* `Goulash.Database.PostgreSql` - Goulash's PostgreSql database provider.
* `Goulash.Database.Sqlite` - Goulash's SQLite database provider.
* `Goulash.Database.SqlServer` - Goulash's Microsoft SQL Server database provider.

These folders contain cloud-specific components of Goulash:

* `Goulash.Aliyun` - Goulash's Alibaba Cloud(Aliyun) provider.
* `Goulash.Aws` - Goulash's Amazon Web Services provider.
* `Goulash.Azure` - Goulash's Azure provider.
* `Goulash.Gcp` - Goulash's Google Cloud Platform provider.

