# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
tag: release_1_1_preview
require:
    -  https://github.com/Azure/azure-rest-api-specs/blob/cde7f150e8d3bf3af2418cc347cae0fb2baed6a7/specification/cognitiveservices/data-plane/AnomalyDetector/readme.md
namespace: Azure.AI.AnomalyDetector
public-clients: true
security:
  - AADToken
  - AzureKey
security-header-name: Ocp-Apim-Subscription-Key
security-scopes: https://cognitiveservices.azure.com/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```
