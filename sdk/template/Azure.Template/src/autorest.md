# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/05c4049bc22f0ec65acc18f9835132397049cb9e/specification/cdn/resource-manager/Microsoft.Cdn/stable/2023-05-01/cdn.json
namespace: Azure.Template
security: AADToken
security-scopes: https://vault.azure.net/.default
```
