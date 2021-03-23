# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
require:
    -  https://github.com/Azure/azure-rest-api-specs/blob/f3ed9637897d9f095a8ec28ed82f59ec85fff954/specification/cognitiveservices/data-plane/AnomalyDetector/readme.md
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