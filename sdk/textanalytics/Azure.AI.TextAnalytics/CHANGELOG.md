# Release History

## 1.0.0-preview.1 (2020-01-09)
This is the first preview of the `Azure.AI.TextAnalytics` client library. It is not a direct replacement for `Microsoft.Azure.CognitiveServices.Language.TextAnalytics`, as applications currently using that library would require code changes to use `Azure.AI.TextAnalytics`.

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples) demonstrate the new API.


### Major changes from `Microsoft.Azure.CognitiveServices.Language.TextAnalytics`
- This library supports only the Text Analytics Service v3.0-preview.1 API, whereas the previous library supports only earlier versions.
- The namespace/package name for Azure Text Analytics client library has changed from 
    `Microsoft.Azure.CognitiveServices.Language.TextAnalytics` to `Azure.AI.TextAnalytics`
- Added support for:
  - Subscription key and AAD authentication for both synchronous and asynchronous clients.
  - Detect Language.
  - Separation of Entity Recognition and Entity Linking.
  - Identification of Personally Identifiable Information.
  - Analyze Sentiment APIs including analysis for mixed sentiment.