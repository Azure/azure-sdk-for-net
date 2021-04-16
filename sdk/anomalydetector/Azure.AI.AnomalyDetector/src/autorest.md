# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
tag: release_1_1_preview
require:
    -  https://github.com/Azure/azure-rest-api-specs/blob/d5a7f1fbca0fd9b16cc1e1a9016d4a0ea31a5d53/specification/cognitiveservices/data-plane/AnomalyDetector/readme.md
namespace: Azure.AI.AnomalyDetector
public-clients: true
credential-types: TokenCredential;AzureKeyCredential
credential-header-name: Ocp-Apim-Subscription-Key
credential-scopes: https://cognitiveservices.azure.com/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```