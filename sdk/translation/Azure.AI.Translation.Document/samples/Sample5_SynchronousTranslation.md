# Translating Documents
Synchronous translation supports immediate-response processing of single-page files. The synchronous translation process doesn't require an Azure Blob storage account. The final response contains the translated document and is returned directly to the calling client.
This sample demonstrates how to synchronously translate a single document. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `SingleDocumentTranslationClient`

To create a new `SingleDocumentTranslationClient` to run a translation operation for a document, you need a Translator endpoint and credentials. You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateSingleDocumentTranslationClient
string endpoint = "<Document Translator Resource Endpoint>";
string apiKey = "<Document Translator Resource API Key>";
SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Translating a single document 

To start a synchronous translation operation for a single document, call `DocumentTranslate`. 

To call `DocumentTranslate` you need to initialize an object of type `MultipartFormFileData` which contains the information needed to translate the documents. You would need to specify the target language to which the document must be translated to.

```C# Snippet:StartSingleDocumentTranslation
try
{
    string filePath = Path.Combine("TestData", "test-input.txt");
    using Stream fileStream = File.OpenRead(filePath);
    var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
    DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);
    var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);

    var requestString = File.ReadAllText(filePath);
    var responseString = Encoding.UTF8.GetString(response.Value.ToArray());

    Console.WriteLine($"Request string for translation: {requestString}");
    Console.WriteLine($"Response string after translation: {responseString}");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md
