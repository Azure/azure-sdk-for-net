# Translation History
This sample demonstrates how to get the history for all submitted translation operations on your Translator resource. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Getting all submitted translation operations

To get the Translation History, call `GetTranslationsAsync` which returns an AsyncPageable object containing the `TranslationStatusDetail` for all submitted translation operations.

The sample below gets the total number of documents translated in all submitted operations as well as the details of the operation contining the largest number of documents.

```C# Snippet:OperationsHistoryAsync
AsyncPageable<TranslationStatusDetail> operationsStatus = client.GetTranslationsAsync();

int operationsCount = 0;
int totalDocs = 0;
int docsCancelled = 0;
int docsSucceeded = 0;
int maxDocs = 0;
TranslationStatusDetail largestOperation = null;

await foreach (TranslationStatusDetail operationStatus in operationsStatus)
{
    operationsCount++;
    totalDocs += operationStatus.DocumentsTotal;
    docsCancelled += operationStatus.DocumentsCancelled;
    docsSucceeded += operationStatus.DocumentsSucceeded;
    if (totalDocs > maxDocs)
    {
        maxDocs = totalDocs;
        largestOperation = operationStatus;
    }
}

Console.WriteLine($"# of operations: {operationsCount}");
Console.WriteLine($"Total Documents: {totalDocs}");
Console.WriteLine($"DocumentsSucceeded: {docsSucceeded}");
Console.WriteLine($"Cancelled Documents: {docsCancelled}");

Console.WriteLine($"Largest operation is {largestOperation} and has the documents:");

DocumentTranslationOperation operation = new DocumentTranslationOperation(largestOperation.TranslationId, client);

AsyncPageable<DocumentStatusDetail> docs = operation.GetAllDocumentsStatusAsync();

await foreach (DocumentStatusDetail docStatus in docs)
{
    Console.WriteLine($"Document {docStatus.LocationUri} has status {docStatus.Status}");
}
```

To see the full example source files, see:

* [Synchronously OperationsHistory ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_OperationsHistory.cs)
* [Asynchronously OperationsHistory ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_OperationsHistoryAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/README.md