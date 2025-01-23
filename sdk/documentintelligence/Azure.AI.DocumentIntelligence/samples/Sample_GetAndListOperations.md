# Get and List Document Model Operations

This sample demonstrates how to get and list operations of a Document Intelligence resource. Note that operation information only persists for 24 hours.

To get started you'll need an Azure AI services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll make use of identity-based authentication by creating a `DefaultAzureCredential` object.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceAdministrationClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
```

## Get and List Document Model Operations

The method `GetOperations` returns a list of `DocumentIntelligenceOperationDetails` instances. The instances returned by this method contain general information about the operation, such as its ID, its status, and the `PercentCompleted` property to track progress, but it does not include details about the result or errors that happened during its execution.

The method `GetOperation` can be called to get these extra properties. It returns a single `DocumentIntelligenceOperationDetails` instance, including the result of the operation and errors, if any. However, in order to access the `Result` property, you need to cast it to one of its derived types:
- A `DocumentModelBuildOperationDetails` for `BuildDocumentModel` operations.
- A `DocumentModelCopyToOperationDetails` for `CopyModelTo` operations.
- A `DocumentModelComposeOperationDetails` for `ComposeModel` operations.
- A `DocumentClassifierBuildOperationDetails` for `BuildClassifier` operations.
- A `DocumentClassifierCopyTolOperationDetails` for `CopyClassifierTo` operations.

Note that operation information only persists for 24 hours.

```C# Snippet:DocumentIntelligenceSampleGetAndListOperations
// Get an operation by ID.
string operationId = "<operationId>";
DocumentIntelligenceOperationDetails operationDetails = await client.GetOperationAsync(operationId);

if (operationDetails.Status == DocumentIntelligenceOperationStatus.Succeeded)
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

        case DocumentClassifierCopyToOperationDetails classifierOperation:
            Console.WriteLine($"Classifier ID: {classifierOperation.Result.ClassifierId}");
            break;
    }
}
else if (operationDetails.Status == DocumentIntelligenceOperationStatus.Failed)
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

await foreach (DocumentIntelligenceOperationDetails operationItem in client.GetOperationsAsync())
{
    Console.WriteLine($"Operation details:");
    Console.WriteLine($"  Operation ID: {operationItem.OperationId}");
    Console.WriteLine($"  Status: {operationItem.Status}");
    Console.WriteLine($"  Completion: {operationItem.PercentCompleted}%");
    Console.WriteLine($"  Created on: {operationItem.CreatedOn}");
    Console.WriteLine($"  Last updated on: {operationItem.LastUpdatedOn}");
    Console.WriteLine($"  Resource location: {operationItem.ResourceLocation}");

    if (++count == 10)
    {
        break;
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
