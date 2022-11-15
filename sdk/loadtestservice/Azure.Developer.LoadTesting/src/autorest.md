# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
- /mnt/vss/_work/1/s/azure-rest-api-specs/specification/loadtestservice/data-plane/readme.md

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

