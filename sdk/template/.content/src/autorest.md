# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: SwaggerFileLink
namespace: Azure.Template
securityTypes
securityScopePrefix: securityScopes
securityHeaderNamePrefix: securityHeaderName
```
