# Release History

## 1.0.0-preview.1 (2020-01-09)
This is the first preview of the Azure.AI.TextAnalytics client library. 

- It uses the Text Analytics Service v3.0-preview.1 API.
- The namespace/package name for Azure Text Analytics client library has changed from 
    `Microsoft.Azure.CognitiveServices.Language.TextAnalytics` to `Azure.AI.TextAnalytics`
- Added support for:
  - Subscription key and AAD authentication for both synchronous and asynchronous clients.
  - Detect Language.
  - Separation of Entity Recognition and Entity Linking.
  - Identification of Personally Identifiable Information.
  - Analyze Sentiment APIs including analysis for mixed sentiment.
