# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- C:\Users\niveditjain\Desktop\loadtesting.json
namespace: Azure.Developer.LoadTesting
security: AADToken
security-scopes: https://loadtest.azure-dev.com/.default
 
```
