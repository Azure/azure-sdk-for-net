# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/2d632618a46e6173fd51dc12dfbf3a260651d9b3/specification/cognitiveservices/data-plane/AnomalyDetector/preview/v1.1-preview/AnomalyDetector.json?token=AKY7HQBGMYCUTCJE5VIGUWTAMTDEM
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/2d632618a46e6173fd51dc12dfbf3a260651d9b3/specification/cognitiveservices/data-plane/AnomalyDetector/preview/v1.1-preview/MultivariateAnomalyDetector.json?token=AKY7HQANFB5GTYIURVQCYFLAMTDGW
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