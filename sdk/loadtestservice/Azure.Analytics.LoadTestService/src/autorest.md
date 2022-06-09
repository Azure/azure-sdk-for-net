# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
- D:\Project\azure-rest-api-specs\specification\loadtestservice\data-plane\readme.md
- D:\Project\azure-rest-api-specs\specification\loadtestservice\data-plane\readme.csharp.md
csharp: true 
namespace: Azure.Analytics.LoadTestService

 
 
```
