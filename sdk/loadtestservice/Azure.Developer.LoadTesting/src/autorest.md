# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: https://github.com/NiveditJain/azure-rest-api-specs/blob/d958478389ef0d10c4ed0e1f41a953a5889bcb0f/specification/loadtestservice/data-plane/Microsoft.LoadTestService/stable/2022-11-01/loadtestservice.json
namespace: Azure.Developer.LoadTesting
security: AADToken
security-scopes: https://cnt-prod.loadtesting.azure.com/.default
skip-csproj-packagereference: true
```
