# Copy a custom model between Document Intelligence resources

This sample demonstrates how to copy a custom model between Document Intelligence resources.

To get started you'll need an Azure AI services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Copy a custom model

There are several scenarios that require the models to be copied between Document Intelligence resources. For example: to keep a backup of the created models.

Copies can be made:
- Within the same Document Intelligence resource.
- Across other Document Intelligence resources that exist in any other supported region.

For this sample, you will copy a model across Document Intelligence resources. It assumes you have the credentials for both the source and the target resources.

## Creating the source and target `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll make use of identity-based authentication by creating a `DefaultAzureCredential` object.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

### Source client

The source client that contains the custom model to copy.

```C# Snippet:DocumentIntelligenceSampleCreateCopySourceClient
string sourceEndpoint = "<sourceEndpoint>";
var sourceResourceCredential = new DefaultAzureCredential();
var sourceClient = new DocumentIntelligenceAdministrationClient(new Uri(sourceEndpoint), sourceResourceCredential);
```

### Target client

The target client to copy the custom model to.

```C# Snippet:DocumentIntelligenceSampleCreateCopyTargetClient
string targetEndpoint = "<targetEndpoint>";
var targetResourceCredential = new DefaultAzureCredential();
var targetClient = new DocumentIntelligenceAdministrationClient(new Uri(targetEndpoint), targetResourceCredential);
```

### Authorize the copy

Before starting, we need to get a `ModelCopyAuthorization` from the target resource that will give us permission to execute the copy.
```C# Snippet:DocumentIntelligenceSampleGetCopyAuthorization
string targetModelId = "<targetModelId>";
var authorizeCopyOptions = new AuthorizeModelCopyOptions(targetModelId);
ModelCopyAuthorization copyAuthorization = await targetClient.AuthorizeModelCopyAsync(authorizeCopyOptions);
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
