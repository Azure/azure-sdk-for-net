# Copy a custom model between Document Intelligence resources

This sample demonstrates how to copy a custom model between Document Intelligence resources.

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Copy a custom model

There are several scenarios that require the models to be copied between Document Intelligence resources. For example: to keep a backup of the created models.

Copies can be made:
- Within the same Document Intelligence resource.
- Across other Document Intelligence resources that exist in any other supported region.

For this sample, you will copy a model across Document Intelligence resources. It assumes you have the credentials for both the source and the target resources.

## Creating the source and target `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

### Source client

The source client that contains the custom model to copy.

```C# Snippet:DocumentIntelligenceSampleCreateCopySourceClient
string sourceEndpoint = "<sourceEndpoint>";
string sourceApiKey = "<sourceApiKey>";
var sourceClient = new DocumentIntelligenceAdministrationClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));
```

### Target client

The target client to copy the custom model to.

```C# Snippet:DocumentIntelligenceSampleCreateCopyTargetClient
string targetEndpoint = "<targetEndpoint>";
string targetApiKey = "<targetApiKey>";
var targetClient = new DocumentIntelligenceAdministrationClient(new Uri(targetEndpoint), new AzureKeyCredential(targetApiKey));
```

### Authorize the copy

Before starting, we need to get a `CopyAuthorization` from the target resource that will give us permission to execute the copy.
```C# Snippet:DocumentIntelligenceSampleGetCopyAuthorization
string targetModelId = "<targetModelId>";
var authorizeCopyContent = new AuthorizeCopyContent(targetModelId);
CopyAuthorization copyAuthorization = await targetClient.AuthorizeModelCopyAsync(authorizeCopyContent);
```

### Execute the copy

Now that we have authorization from the target resource, we execute the copy from the `sourceClient` where the original model lives.

```C# Snippet:DocumentIntelligenceSampleCreateCopyModel
string sourceModelId = "<sourceModelId>";
Operation<DocumentModelDetails> copyOperation = await sourceClient.CopyModelToAsync(WaitUntil.Completed, sourceModelId, copyAuthorization);
DocumentModelDetails copiedModel = copyOperation.Value;

Console.WriteLine($"Original model ID: {sourceModelId}");
Console.WriteLine($"Copied model ID: {copiedModel.ModelId}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
