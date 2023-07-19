# Polling Documents Status
This sample demonstrates how to poll the status of individual document in a translation operation. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<Document Translator Resource Endpoint>";
string apiKey = "<Document Translator Resource API Key>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Polling the status of documents in an operation

To poll the status of documents in an operation you use the `DocumentTranslationOperation` class which contains two functions `GetAllDocumentsStatusAsync` which returns the status of all documents in the operation and `GetDocumentStatusAsync` which returns the status of a specific document given its ID.

```C# Snippet:PollIndividualDocumentsAsync
Uri sourceUri = new Uri("<source SAS URI>");
Uri targetUri = new Uri("<target SAS URI>");

var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

TimeSpan pollingInterval = new(1000);

await foreach (DocumentStatusResult document in operation.GetDocumentStatusesAsync())
{
    Console.WriteLine($"Polling Status for document{document.SourceDocumentUri}");

    Response<DocumentStatusResult> responseDocumentStatus = await operation.GetDocumentStatusAsync(document.Id);

    while (responseDocumentStatus.Value.Status != DocumentTranslationStatus.Failed &&
              responseDocumentStatus.Value.Status != DocumentTranslationStatus.Succeeded)
    {
        if (responseDocumentStatus.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
        {
            pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
        }

        await Task.Delay(pollingInterval);
        responseDocumentStatus = await operation.GetDocumentStatusAsync(document.Id);
    }

    if (responseDocumentStatus.Value.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md
