# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
tag: release_1_1
require:
    -  https://github.com/Azure/azure-rest-api-specs/blob/f47eeea0df3a5a81ea42945ed96290b3fb8e588a/specification/cognitiveservices/data-plane/AnomalyDetector/readme.md
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
