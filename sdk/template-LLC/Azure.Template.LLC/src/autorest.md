# Azure.Temp;ate.LLC Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- $(this-folder)/swagger/swagger.json
namespace: Azure.Template.LLC
public-clients: true
low-level-client: true
security: AADToken
security-scopes: https://dev.LLCtemplate.net/.default
```
