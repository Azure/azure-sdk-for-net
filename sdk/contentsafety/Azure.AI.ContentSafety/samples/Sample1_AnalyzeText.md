# Analyze Text

This sample shows how to analyze text using Azure AI Content Safety.
To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create a ContentSafetyClient

To create a new `ContentSafetyClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Content Safety API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `key` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_AI_ContentSafety_CreateClient
string endpoint = TestEnvironment.Endpoint;
string key = TestEnvironment.Key;

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));
```

## Load text and analyze text

You can download our [sample data](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentsafety/Azure.AI.ContentSafety/tests/Samples/sample_data), read in the text and initialize `AnalyzeTextOptions` with it. Then call `AnalyzeText` to get analysis result.

```C# Snippet:Azure_AI_ContentSafety_AnalyzeText
string text = "You are an idiot";

var request = new AnalyzeTextOptions(text);

Response<AnalyzeTextResult> response;
try
{
    response = client.AnalyzeText(request);
}
catch (RequestFailedException ex)
{
    Console.WriteLine("Analyze text failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
    throw;
}

Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Hate)?.Severity ?? 0);
Console.WriteLine("SelfHarm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.SelfHarm)?.Severity ?? 0);
Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Sexual)?.Severity ?? 0);
Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == TextCategory.Violence)?.Severity ?? 0);
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentsafety/Azure.AI.ContentSafety/README.md
