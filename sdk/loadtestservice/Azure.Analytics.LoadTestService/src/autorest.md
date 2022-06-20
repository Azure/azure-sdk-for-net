# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- D:\Project\loadtestservice.json
namespace: Azure.Analytics.LoadTestService
security: AADToken
security-scopes: https://loadtest.azure-dev.com/.default
 
```
