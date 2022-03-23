# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require: E:\hpc\azure-rest-api-specs\specification\batch\track2\readme.md
security: AADToken
security-scopes: https://batch.core.windows.net/.default
 
```
