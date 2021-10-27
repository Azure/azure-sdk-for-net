# Get and List Document Model Operations

This sample demonstrates how to Get and List all document model operations (succeeded, in-progress, failed) associated with the Form Recognizer resource. Note that operation information only persists for 24 hours.
If the operation was successful, the document model can be accessed using `GetModel()` or `GetModels()` APIs.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentModelAdministrationClient`

To create a new `DocumentModelAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentModelAdministrationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
```

## Get and List Document Model Operations

Note that operation information only persists for 24 hours. If the operation was successful, the document model Id is provided in the `Result` property. This Id can be used with
other methods like for example, `GetModel()`.
If the operation failed, the error information can be accessed using the `Error` property.

```C# Snippet:FormRecognizerSampleGetAndListOperations
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Make sure there is at least one operation, so we are going to build a custom model.
Uri trainingFileUri = <trainingFileUri>;
BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri);
await operation.WaitForCompletionAsync();

// List the first ten or fewer operations that have been executed in the last 24h.
AsyncPageable<ModelOperationInfo> modelOperations = client.GetOperationsAsync();

string operationId = string.Empty;
int count = 0;
await foreach (ModelOperationInfo modelOperationInfo in modelOperations)
{
    Console.WriteLine($"Model operation info:");
    Console.WriteLine($"  Id: {modelOperationInfo.OperationId}");
    Console.WriteLine($"  Kind: {modelOperationInfo.Kind}");
    Console.WriteLine($"  Status: {modelOperationInfo.Status}");
    Console.WriteLine($"  Percent completed: {modelOperationInfo.PercentCompleted}");
    Console.WriteLine($"  Created on: {modelOperationInfo.CreatedOn}");
    Console.WriteLine($"  LastUpdated on: {modelOperationInfo.LastUpdatedOn}");
    Console.WriteLine($"  Resource location of successful operation: {modelOperationInfo.ResourceLocation}");

    if (count == 0)
        operationId = modelOperationInfo.OperationId;

    if (++count == 10)
        break;
}

// Get an operation by ID
ModelOperation specificOperation = await client.GetOperationAsync(operationId);

if (specificOperation.Status == DocumentOperationStatus.Succeeded)
{
    Console.WriteLine($"My {specificOperation.Kind} operation is completed.");
    DocumentModel result = specificOperation.Result;
    Console.WriteLine($"Model ID: {result.ModelId}");
}
else if (specificOperation.Status == DocumentOperationStatus.Failed)
{
    Console.WriteLine($"My {specificOperation.Kind} operation failed.");
    ResponseError error = specificOperation.Error;
    Console.WriteLine($"Code: {error.Code}: Message: {error.Message}");
}
else
    Console.WriteLine($"My {specificOperation.Kind} operation status is {specificOperation.Status}");
```

To see the full example source files, see:

* [Get and List document model operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_GetAndListOperationsAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
