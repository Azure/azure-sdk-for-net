# Copy a custom model between Form Recognizer resources

This sample demonstrates how to copy a custom model between Form Recognizer resources.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Copy a custom model
There are several scenarios that require the models to be copied between Form Recognizer resources, like for example, to keep a backup of the created models.
Copies can be made:
- Within the same Form Recognizer resource.
- Across other Form Recognizer resources that exist in any other supported region.

For this sample, you will copy a model across Form Recognizer resources. It assumes you have the credentials for both the source and the target Form Recognizer resources.

## Creating the source and target `FormTrainingClient`

To create a new `FormTrainingClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object.
You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

### Source client
The source client that contains the custom model we want to copy.

```C# Snippet:FormRecognizerSampleCreateCopySourceClient
string endpoint = "<source_endpoint>";
string apiKey = "<source_apiKey>";
var sourcecredential = new AzureKeyCredential(apiKey);
var sourceClient = new FormTrainingClient(new Uri(endpoint), sourcecredential);
```

### Target client
The target client where we want to copy the custom model to.

```C# Snippet:FormRecognizerSampleCreateCopyTargetClient
string endpoint = "<target_endpoint>";
string apiKey = "<target_apiKey>";
var targetCredential = new AzureKeyCredential(apiKey);
var targetClient = new FormTrainingClient(new Uri(endpoint), targetCredential);
```

### Authorize the copy
Before starting the copy, we need to get a `CopyAuthorization` from the target Form Recognizer resource that will give us permission to execute the copy.
```C# Snippet:FormRecognizerSampleGetCopyAuthorization
string resourceId = "<resourceId>";
string resourceRegion = "<region>";
CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, resourceRegion);
```

`CopyAuthorization` provides the convenience method `ToJson` that will serialize the authorization properties into a json format string.
```C# Snippet:FormRecognizerSampleToJson
string jsonTargetAuth = targetAuth.ToJson();
```

To deserialize a string that contains authorization information, use the `FromJson` method from `CopyAuthorization`.
```C# Snippet:FormRecognizerSampleFromJson
CopyAuthorization targetCopyAuth = CopyAuthorization.FromJson(jsonTargetAuth);
```

### Execute the copy
Now that we have authorization from the target Form Recognizer resource, we execute the copy from the `sourceClient` where the model to copy lives.

```C# Snippet:FormRecognizerSampleCopyModel
string modelId = "<source_modelId>";
CustomFormModelInfo newModel = await sourceClient.StartCopyModelAsync(modelId, targetCopyAuth).WaitForCompletionAsync();

Console.WriteLine($"Original model ID => {modelId}");
Console.WriteLine($"Copied model ID => {newModel.ModelId}");
```


To see the full example source files, see:
* [Copy custom models](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample8_CopyModel.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started