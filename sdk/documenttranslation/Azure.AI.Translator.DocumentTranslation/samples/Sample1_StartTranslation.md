# Translating Documents
This sample demonstrates how to translate one or more documents in a blob container. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Translating a single document or documents in a single container

To Start a translation operation for a single document or documents in a single blob container, call `StartTranslationAsync`. The result is a Long Running operation of type `DocumentTranslationOperation` which polls for the status of the translation operation from the API.

To call `StartTranslationAsync` you need to initialize an object of type `DocumentTranslationInput` which contains the information needed to translate the documents.

- The `sourceUri` is a SAS URI with read access for the document to be translated or read and list access for the blob container holding the documents to be translated.
- The `targetUri` is a SAS URI with read and write access for the blob container to which the translated documents will be written.

More on generating SAS Tokens [here](https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/get-started-with-document-translation?tabs=csharp#create-sas-access-tokens-for-document-translation)

```C# Snippet:StartTranslationAsync
Uri sourceUri = <source SAS URI>;
Uri targetUri = <target SAS URI>;

var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

Response<AsyncPageable<DocumentStatusResult>> operationResult = await operation.WaitForCompletionAsync();

Console.WriteLine($"  Status: {operation.Status}");
Console.WriteLine($"  Created on: {operation.CreatedOn}");
Console.WriteLine($"  Last modified: {operation.LastModified}");
Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

await foreach (DocumentStatusResult document in operationResult.Value)
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

To see the full example source files, see:

* [Synchronously StartTranslation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.Translator.DocumentTranslation/tests/samples/Sample_StartTranslation.cs)
* [Asynchronously StartTranslation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.Translator.DocumentTranslation/tests/samples/Sample_StartTranslationAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.Translator.DocumentTranslation/README.md