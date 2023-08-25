# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/af3f7994582c0cbd61a48b636907ad2ac95d332c/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-11-11-preview/devcenter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/af3f7994582c0cbd61a48b636907ad2ac95d332c/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-11-11-preview/devbox.json
  - https://github.com/Azure/azure-rest-api-specs/blob/af3f7994582c0cbd61a48b636907ad2ac95d332c/specification/devcenter/data-plane/Microsoft.DevCenter/preview/2022-11-11-preview/environments.json

namespace: Azure.Developer.DevCenter
security: AADToken
security-scopes: https://devcenter.azure.com/.default

directive:
  # Ensure we use Uri rather than string in .NET
  - from: swagger-document
    where: "$.parameters.EndpointParameter"
    transform: >-
      $["format"] = "url";
```
