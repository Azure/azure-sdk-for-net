# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- https://github.com/Azure/azure-rest-api-specs/blob/0f9df940977c680c39938c8b8bd5baf893737ed0/specification/purview/data-plane/Azure.Analytics.Purview.Share/preview/2021-09-01-preview/share.json
namespace: Azure.Analytics.Purview.Share
security: AADToken
security-scopes: https://purview.azure.net/.default
 
```
