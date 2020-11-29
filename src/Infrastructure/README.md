# Infrastructure

## Creating Migrations

In order to create and execute a migration, the following configuration in the appsettings.json file found in WebUI must be set. Not setting this will generate a migration error

```csharp
...
"UseInMemoryDatabase": false
...
```
