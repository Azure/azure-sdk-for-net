# Azure.Maps.Search Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/45924e49834c4e01c0713e6b7ca21f94be17e396/specification/maps/data-plane/Search/stable/2025-01-01/search.json
title: MapsSearchClient
openapi-type: data-plane
add-credentials: true
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default
generation1-convenience-client: true
sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Search
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true
helper-namespace: Azure.Maps.Common
```

```yaml
directive:
- from: swagger-document
  where: "$.definitions.GeocodingBatchRequestItem.properties.bbox"
  transform: >
    $["x-ms-client-name"] = "boundingBox";
- from: swagger-document
  where: '$.parameters.Bbox'
  transform: >
    $["name"] = "boundingBox";
- from: swagger-document
  where: "$.parameters.Bbox"
  transform: >
    $["x-ms-client-name"] = "BoundingBox";
- from: swagger-document
  where: "$.definitions.FeaturesItem.properties.bbox"
  transform: >
    $["x-ms-client-name"] = "boundingBox";
- from: swagger-document
  where: "$.definitions.GeoJsonObject.properties.bbox"
  transform: >
    $["x-ms-client-name"] = "boundingBox";
```
