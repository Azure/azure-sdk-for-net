# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ca95eb5342d848ab71387be54048c509f9c63b70/specification/maps/data-plane/Render/stable/2022-08-01/render.json
title: MapsRenderingClient
openapi-type: data-plane
tag: 2.0
add-credentials: true
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default
generation1-convenience-client: true
model-namespace: false
sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Rendering
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true
```

```yaml
directive:
- from: swagger-document
  where: $.securityDefinitions
  transform: |
    $["azure_auth"] = $["AADToken"];
    delete $["AADToken"];
- from: swagger-document
  where: '$.security[0]'
  transform: |
    $["azure_auth"] = $["AADToken"];
    delete $["AADToken"];
- from: swagger-document
  where: $.securityDefinitions
  transform: |
    $["SharedKey"]["in"] = "header";
```
