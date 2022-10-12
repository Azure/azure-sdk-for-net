# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml

input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/5a024c0e76424caaca36166ba41cee6f3f1f8add/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/devcenter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5a024c0e76424caaca36166ba41cee6f3f1f8add/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/devbox.json
  - https://github.com/Azure/azure-rest-api-specs/blob/5a024c0e76424caaca36166ba41cee6f3f1f8add/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-03-01-preview/environments.json

namespace: Azure.Developer.DevCenter
security: AADToken
security-scopes: https://devcenter.azure.com/.default

```
