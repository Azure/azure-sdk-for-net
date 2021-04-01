# Polling Documents Status
This sample demonstrates how to poll the status of individual document in a translation operation. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Polling the status of documents in an operation

To poll the status of documents in an operation you use the `DocumentTranslationOperation` class which contains two functions `GetAllDocumentsStatusAsync` which returns the status of all documents in the operation and `GetDocumentStatusAsync` which returns the status of a specific document given its ID.

```C# Snippet:PollIndividualDocumentsAsync
Uri sourceUri = <source SAS URI>;
Uri targetUri = <target SAS URI>;

var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

TimeSpan pollingInterval = new TimeSpan(1000);

AsyncPageable<DocumentStatusResult> documents = operation.GetAllDocumentStatusesAsync();
await foreach (DocumentStatusResult document in documents)
{
    Console.WriteLine($"Polling Status for document{document.TranslatedDocumentUri}");

    Response<DocumentStatusResult> status = await operation.GetDocumentStatusAsync(document.DocumentId);

    while (!status.Value.HasCompleted)
    {
        await Task.Delay(pollingInterval);
        status = await operation.GetDocumentStatusAsync(document.DocumentId);
    }

    if (status.Value.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

To see the full example source files, see:

* [Synchronously PollIndividualDocuments ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_PollIndividualDocuments.cs)
* [Asynchronously PollIndividualDocuments ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_PollIndividualDocumentsAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/README.md