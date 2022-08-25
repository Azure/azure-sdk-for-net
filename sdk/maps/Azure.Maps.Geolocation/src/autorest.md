# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/e686ed79e9b0bbc10355fd8d7ba36d1a07e4ba28/specification/maps/data-plane/Geolocation/preview/1.0/geolocation.json
title: MapsGeolocationClient
openapi-type: data-plane
tag: 1.0
add-credentials: false
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default
use-extension:
  "@autorest/modelerfour": "4.22.3"

generation1-convenience-client: true
sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Geolocation
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true
```

```yaml
directive:
    - from: swagger-document
      where: $.security
      transform: >
       $ = [];
```
