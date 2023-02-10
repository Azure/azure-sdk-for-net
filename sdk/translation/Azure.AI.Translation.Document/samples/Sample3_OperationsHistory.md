# Translation Operations History
This sample demonstrates how to get the history for submitted translation operations on your Translator resource. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<Document Translator Resource Endpoint>";
string apiKey = "<Document Translator Resource API Key>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Getting submitted translation operations

To get the Translation History, call `GetTranslationsAsync` which returns an AsyncPageable object containing the `TranslationStatusResult` for all submitted translation operations.`GetTranslationsAsync` optionally takes a parameter of type `GetTranslationStatusesOptions`, which can be included to define criteria used to filter the returned translation operations.

The sample below gets the total number of documents translated in operations submitted in the last 7 days while also keeping counts of the total number of documents that have been canceled, succeeded and failed.

```C# Snippet:OperationsHistoryAsync
int operationsCount = 0;
int totalDocs = 0;
int docsCanceled = 0;
int docsSucceeded = 0;
int docsFailed = 0;

DateTimeOffset lastWeekTimestamp = DateTimeOffset.Now.AddDays(-7);

var options = new GetTranslationStatusesOptions
{
    CreatedAfter = lastWeekTimestamp
};

await foreach (TranslationStatusResult translationStatus in client.GetTranslationStatusesAsync(options))
{
    if (translationStatus.Status == DocumentTranslationStatus.NotStarted ||
        translationStatus.Status == DocumentTranslationStatus.Running)
    {
        DocumentTranslationOperation operation = new DocumentTranslationOperation(translationStatus.Id, client);
        await operation.WaitForCompletionAsync();
    }

    operationsCount++;
    totalDocs += translationStatus.DocumentsTotal;
    docsCanceled += translationStatus.DocumentsCanceled;
    docsSucceeded += translationStatus.DocumentsSucceeded;
    docsFailed += translationStatus.DocumentsFailed;
}

Console.WriteLine($"# of operations: {operationsCount}");
Console.WriteLine($"Total Documents: {totalDocs}");
Console.WriteLine($"Succeeded Document: {docsSucceeded}");
Console.WriteLine($"Failed Document: {docsFailed}");
Console.WriteLine($"Canceled Documents: {docsCanceled}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md
