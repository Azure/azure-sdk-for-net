# Get and List Document Model Operations

This sample demonstrates how to Get and List all document model operations (succeeded, in-progress, failed) associated with the Form Recognizer resource. Note that operation information only persists for 24 hours.
If the operation was successful, the document model can be accessed using `GetDocumentModel()` or `GetDocumentModels()` APIs.

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

The method `GetOperations` returns a list of `OperationSummary` instances. `OperationSummary` contains general information about the operation, such as its ID, its status, and the `PercentCompleted` property to track progress, but it does not include details about the result or errors that happened during its execution.

The method `GetOperation` can be called to get these extra properties. It returns a single `OperationDetails` instance, which also contains all information present in `OperationSummary`. However, in order to access the `Result` property, you need to cast it to one of its derived types:
- A `DocumentModelBuildOperationDetails` for "build" operations.
- A `DocumentModelCopyToOperationDetails` for "copy to" operations.
- A `DocumentModelComposeOperationDetails` for "compose" operations.

If the operation was successful, the document model Id is provided in the `Result` property. This Id can be used with other methods such as `GetDocumentModel`.
If the operation failed, the error information can be accessed using the `Error` property.

Note that operation information only persists for 24 hours.

```C# Snippet:FormRecognizerSampleGetAndListOperations
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Make sure there is at least one operation, so we are going to build a custom model.
Uri blobContainerUri = new Uri("<blobContainerUri>");
BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);

// List the first ten or fewer operations that have been executed in the last 24h.
AsyncPageable<OperationSummary> operationSummaries = client.GetOperationsAsync();

string operationId = string.Empty;
int count = 0;
await foreach (OperationSummary operationSummary in operationSummaries)
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
OperationDetails operationDetails = await client.GetOperationAsync(operationId);

if (operationDetails.Status == DocumentOperationStatus.Succeeded)
{
    Console.WriteLine($"My {operationDetails.Kind} operation is complete.");

    // Extract the result based on the kind of operation.
    switch (operationDetails)
    {
        case DocumentModelBuildOperationDetails modelOperation:
            Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
            break;

        case DocumentModelCopyToOperationDetails modelOperation:
            Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
            break;

        case DocumentModelComposeOperationDetails modelOperation:
            Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
            break;

        case DocumentClassifierBuildOperationDetails classifierOperation:
            Console.WriteLine($"Classifier ID: {classifierOperation.Result.ClassifierId}");
            break;
    }
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

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
