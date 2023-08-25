# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- $(this-folder)/widgets.json
namespace: Azure.Core.Samples
security: AADToken
security-scopes: https://example.azure.com/.default
```
