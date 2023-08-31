# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/b407b6c6e11d2b9d543408a1cce9050c95ac74de/specification/batch/data-plane/Microsoft.Batch/stable/2023-05-01.17.0/BatchService.json
namespace: Azure.Temp.Batch
security: AADToken
security-scopes: https://batch.core.windows.net/.default
```
