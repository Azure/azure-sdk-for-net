# Azure.Template.LLC Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-sdk-for-net/blob/dd410c32cee19e300245e11149c28c2ea7fb169e/sdk/template-LLC/Azure.Template.LLC/src/swagger/swagger.json
namespace: Azure.Template.LLC
public-clients: true
low-level-client: true
security: AADToken
security-scopes: https://dev.LLCtemplate.net/.default
```
