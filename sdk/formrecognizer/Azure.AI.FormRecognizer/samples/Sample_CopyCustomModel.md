# Copy a custom model between Form Recognizer resources

This sample demonstrates how to copy a custom model between Form Recognizer resources.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Copy a custom model
There are several scenarios that require the models to be copied between Form Recognizer resources, like for example, to keep a backup of the created models.
Copies can be made:
- Within the same Form Recognizer resource.
- Across other Form Recognizer resources that exist in any other supported region.

For this sample, you will copy a model across Form Recognizer resources. It assumes you have the credentials for both the source and the target Form Recognizer resources.

## Creating the source and target `DocumentModelAdministrationClient`

To create a new `DocumentModelAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object.
You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

### Source client
The source client that contains the custom model we want to copy.

```C# Snippet:FormRecognizerSampleCreateCopySourceClient
string sourceEndpoint = "<source_endpoint>";
string sourceApiKey = "<source_apiKey>";
var sourcecredential = new AzureKeyCredential(sourceApiKey);
var sourceClient = new DocumentModelAdministrationClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));
```

### Target client
The target client where we want to copy the custom model to.

```C# Snippet:FormRecognizerSampleCreateCopyTargetClient
string targetEndpoint = "<target_endpoint>";
string targetApiKey = "<target_apiKey>";
var targetCredential = new AzureKeyCredential(targetApiKey);
var targetClient = new DocumentModelAdministrationClient(new Uri(targetEndpoint), new AzureKeyCredential(targetApiKey));
```

### Authorize the copy
Before starting the copy, we need to get a `CopyAuthorization` from the target Form Recognizer resource that will give us permission to execute the copy.
```C# Snippet:FormRecognizerSampleGetCopyAuthorization
DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync();
```

### Execute the copy
Now that we have authorization from the target Form Recognizer resource, we execute the copy from the `sourceClient` where the model to copy lives.

```C# Snippet:FormRecognizerSampleCreateCopyModel
string modelId = "<source_modelId>";
CopyDocumentModelToOperation newModelOperation = await sourceClient.CopyDocumentModelToAsync(WaitUntil.Completed, modelId, targetAuth);
DocumentModelDetails newModel = newModelOperation.Value;

Console.WriteLine($"Original model ID => {modelId}");
Console.WriteLine($"Copied model ID => {newModel.ModelId}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
