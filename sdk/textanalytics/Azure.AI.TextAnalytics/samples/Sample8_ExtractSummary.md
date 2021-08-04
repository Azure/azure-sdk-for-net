# Perform Extractive Text Summarization in Documents
This sample demonstrates how to run an Extractive Text Summarization action in one or more documents. To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize healthcare entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing extractive text summarization in one or multiple documents

To perform extractive text summarization in one or multiple documents, set up an `ExtractSummaryAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsExtractSummaryAsync
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsExtractSummaryOperationStatus
```

To view the final results of the long-running operation:

```C# Snippet:TextAnalyticsExtractSummaryAsyncViewResults
```

To see the full example source files, see:

* [Synchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/feature/textanalytics/summarization/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummary.cs)
* [Asynchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/feature/textanalytics/summarization/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryAsync.cs)
* [Synchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/feature/textanalytics/summarization/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenience.cs)
* [Asynchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/feature/textanalytics/summarization/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md