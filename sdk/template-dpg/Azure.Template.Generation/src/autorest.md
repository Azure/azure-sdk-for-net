# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- $(this-folder)/swagger/swagger.json
namespace: Azure.Template.Generated
public-clients: true
low-level-client: true
security: AADToken
security-scopes: https://dev.azuresdkgenerated.net/.default
```
