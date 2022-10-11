# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
openapi-type: data-plane
azure-arm: false
tag: v2022-03-01-preview
eol: crlf
license-header: MICROSOFT_MIT_NO_VERSION
public-clients: true

input-file:
  - ~\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\devcenter.json
  - ~\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\devbox.json
  - ~\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\environments.json

namespace: Azure.Developer.DevCenter
security: AADToken
security-scopes: https://devcenter.azure.com/.default

```
