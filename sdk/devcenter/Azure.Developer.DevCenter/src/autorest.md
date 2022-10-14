# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml

input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/75a8d8dcc9f6d0ec626bdeb32f5154f20c8c61cd/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/devcenter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/75a8d8dcc9f6d0ec626bdeb32f5154f20c8c61cd/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/devbox.json
  - https://github.com/Azure/azure-rest-api-specs/blob/75a8d8dcc9f6d0ec626bdeb32f5154f20c8c61cd/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/environments.json

namespace: Azure.Developer.DevCenter
security: AADToken
security-scopes: https://devcenter.azure.com/.default

```
