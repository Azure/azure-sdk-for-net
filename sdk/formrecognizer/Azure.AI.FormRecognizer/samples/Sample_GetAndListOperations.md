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

Note that operation information only persists for 24 hours. If the operation was successful, the document model Id is provided in the `Result` property. This Id can be used with other methods like for example, `GetModel()`.
If the operation failed, the error information can be accessed using the `Error` property.

```C# Snippet:FormRecognizerSampleGetAndListOperations
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Make sure there is at least one operation, so we are going to build a custom model.
Uri trainingFileUri = new Uri("<trainingFileUri>");
BuildModelOperation operation = await client.BuildModelAsync(WaitUntil.Completed, trainingFileUri, DocumentBuildMode.Template);

// List the first ten or fewer operations that have been executed in the last 24h.
AsyncPageable<DocumentModelOperationSummary> operationSummaries = client.GetOperationsAsync();

string operationId = string.Empty;
int count = 0;
await foreach (DocumentModelOperationSummary operationSummary in operationSummaries)
{
    Console.WriteLine($"Model operation summary:");
    Console.WriteLine($"  Id: {operationSummary.OperationId}");
    Console.WriteLine($"  Kind: {operationSummary.Kind}");
    Console.WriteLine($"  Status: {operationSummary.Status}");
    Console.WriteLine($"  Percent completed: {operationSummary.PercentCompleted}");
    Console.WriteLine($"  Created on: {operationSummary.CreatedOn}");
    Console.WriteLine($"  LastUpdated on: {operationSummary.LastUpdatedOn}");
    Console.WriteLine($"  Resource location of successful operation: {operationSummary.ResourceLocation}");

    if (count == 0)
        operationId = operationSummary.OperationId;

    if (++count == 10)
        break;
}

// Get an operation by ID
DocumentModelOperationDetails operationDetails = await client.GetOperationAsync(operationId);

if (operationDetails.Status == DocumentOperationStatus.Succeeded)
{
    Console.WriteLine($"My {operationDetails.Kind} operation is completed.");
    DocumentModelDetails result = operationDetails.Result;
    Console.WriteLine($"Model ID: {result.ModelId}");
}
else if (operationDetails.Status == DocumentOperationStatus.Failed)
{
    Console.WriteLine($"My {operationDetails.Kind} operation failed.");
    ResponseError error = operationDetails.Error;
    Console.WriteLine($"Code: {error.Code}: Message: {error.Message}");
}
else
    Console.WriteLine($"My {operationDetails.Kind} operation status is {operationDetails.Status}");
```

To see the full example source files, see:

* [Get and List document model operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_GetAndListOperationsAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
