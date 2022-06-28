# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- https://github.com/Azure/azure-rest-api-specs/blob/d7216e49a7b0d5a7e15f77c4bab753208bf7870d/specification/loadtestservice/data-plane/Microsoft.LoadTestService/preview/2022-06-01-preview/loadtestservice.json
namespace: Azure.Analytics.LoadTestService
security: AADToken
security-scopes: https://loadtest.azure-dev.com/.default
 
```
