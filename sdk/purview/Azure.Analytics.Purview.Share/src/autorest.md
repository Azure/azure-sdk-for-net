# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- C:\Users\faisalaltell\source\repos\Share\src\Tools\SwaggerValidator\data-plane\Azure.Analytics.Purview.Share\preview\2022-06-30-preview\share.json
namespace: Azure.Analytics.Purview.Share
security: AADToken
security-scopes: https://purview.azure.net/.default
 
```

