# Analyze Image

This sample shows how to analyze image using Azure AI Content Safety.
To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create a ContentSafetyClient

To create a new `ContentSafetyClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Content Safety API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `key` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_AI_ContentSafety_CreateClient
string endpoint = TestEnvironment.Endpoint;
string key = TestEnvironment.Key;

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));
```

## Load image and analyze image

You can download our [sample data](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentsafety/Azure.AI.ContentSafety/tests/Samples/sample_data), read in the image and initialize `AnalyzeImageOptions` with it. Then call `AnalyzeImage` to get analysis result.

```C# Snippet:Azure_AI_ContentSafety_AnalyzeImage
string datapath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Samples", "sample_data", "image.jpg");
ContentSafetyImageData image = new ContentSafetyImageData(BinaryData.FromBytes(File.ReadAllBytes(datapath)));

var request = new AnalyzeImageOptions(image);

Response<AnalyzeImageResult> response;
try
{
    response = client.AnalyzeImage(request);
}
catch (RequestFailedException ex)
{
    Console.WriteLine("Analyze image failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
    throw;
}

Console.WriteLine("Hate severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Hate)?.Severity ?? 0);
Console.WriteLine("SelfHarm severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.SelfHarm)?.Severity ?? 0);
Console.WriteLine("Sexual severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Sexual)?.Severity ?? 0);
Console.WriteLine("Violence severity: {0}", response.Value.CategoriesAnalysis.FirstOrDefault(a => a.Category == ImageCategory.Violence)?.Severity ?? 0);
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentsafety/Azure.AI.ContentSafety/README.md
