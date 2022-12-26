# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
- C:\Users\v-louaiali\Desktop\README.md

namespace: Azure.AI.TextAnalytics.Authoring
security:
- AADToken
- AzureKey
security-scopes: https://cognitiveservices.azure.com/.default
security-header-name: ocp-apim-subscription-key
```

