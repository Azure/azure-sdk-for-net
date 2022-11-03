# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: https://github.com/Azure/azure-rest-api-specs/blob/89e55fb268544efa964cc09630c960ed326f9056/specification/loadtestservice/data-plane/Microsoft.LoadTestService/stable/2022-11-01/loadtestservice.json
namespace: Azure.Developer.LoadTesting
security: AADToken
security-scopes: https://cnt-prod.loadtesting.azure.com/.default
skip-csproj-packagereference: true
directive:
- from: swagger-document
  where: '$.paths.*[?(@.tags=="AppComponent")]'
  transform: >
    $["operationId"] = $["operationId"].replace("AppComponent_", "LoadTestAdministration_");
- from: swagger-document
  where: '$.paths.*[?(@.tags=="ServerMetrics")]'
  transform: >
    $["operationId"] = $["operationId"].replace("ServerMetrics_", "LoadTestAdministration_");
- from: swagger-document
  where: '$.paths.*[?(@.tags=="Test")]'
  transform: >
    $["operationId"] = $["operationId"].replace("Test_", "LoadTestAdministration_");
```
