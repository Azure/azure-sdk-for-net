# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
tag: release_1_1
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/5e3597f1dde2da7f3abd8c956eb652c38338633d/specification/cognitiveservices/data-plane/AnomalyDetector/stable/v1.1/MultivariateAnomalyDetector.json
- https://github.com/Azure/azure-rest-api-specs/blob/5e3597f1dde2da7f3abd8c956eb652c38338633d/specification/cognitiveservices/data-plane/AnomalyDetector/stable/v1.1/UnivariateAnomalyDetector.json
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

