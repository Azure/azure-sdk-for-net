# Get and List Document Model Operations

This sample demonstrates how to get and list operations of a Document Intelligence resource. Note that operation information only persists for 24 hours.

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceAdministrationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Get and List Document Model Operations

The method `GetOperations` returns a list of `OperationDetails` instances. The instances returned by this method contain general information about the operation, such as its ID, its status, and the `PercentCompleted` property to track progress, but it does not include details about the result or errors that happened during its execution.

The method `GetOperation` can be called to get these extra properties. It returns a single `OperationDetails` instance, including the result of the operation and errors, if any. However, in order to access the `Result` property, you need to cast it to one of its derived types:
- A `DocumentModelBuildOperationDetails` for `BuildDocumentModel` operations.
- A `DocumentModelCopyToOperationDetails` for `CopyModelTo` operations.
- A `DocumentModelComposeOperationDetails` for `ComposeModel` operations.
- A `DocumentClassifierBuildOperationDetails` for `BuildClassifier` operations.

Note that operation information only persists for 24 hours.

```C# Snippet:DocumentIntelligenceSampleGetAndListOperations
// Get an operation by ID.
string operationId = "<operationId>";
OperationDetails operationDetails = await client.GetOperationAsync(operationId);

if (operationDetails.Status == OperationStatus.Succeeded)
{
    Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has succeeded.");

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
else if (operationDetails.Status == OperationStatus.Failed)
{
    Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has failed.");
    Console.WriteLine($"Error code: {operationDetails.Error.Code}");
    Console.WriteLine($"Error message: {operationDetails.Error.Message}");
}
else
{
    Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has status '{operationDetails.Status}'.");
}

// List up to 10 operations that have been executed in the last 24 hours.
int count = 0;

await foreach (OperationDetails operationItem in client.GetOperationsAsync())
{
    Console.WriteLine($"Operation details:");
    Console.WriteLine($"  Operation ID: {operationItem.OperationId}");
    Console.WriteLine($"  Status: {operationItem.Status}");
    Console.WriteLine($"  Completion: {operationItem.PercentCompleted}%");
    Console.WriteLine($"  Created on: {operationItem.CreatedDateTime}");
    Console.WriteLine($"  Last updated on: {operationItem.LastUpdatedDateTime}");
    Console.WriteLine($"  Resource location: {operationItem.ResourceLocation}");

    if (++count == 10)
    {
        break;
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
