# Multiple Translation operations
This sample demonstrates how to translate documents in multiple blob container to different languages simultaneously. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Translating documents in multiple blob containers

To Start a translation operation for documents in multiple blob containers, call `StartTranslationAsync` with multiple inputs. The result is a Long Running operation of type `DocumentTranslationOperation` which polls for the status of the translation operation from the API.

To call `StartTranslationAsync` you need to initialize a list of `DocumentTranslationInput` which contains the information needed to translate the documents. Each `DocumentTranslationInput` contains a source container and a list of target containers. The `AddTarget` method is used to add targets to the input.

- The `sourceUri` is a SAS URI with read access for the document to be translated or read and list access for the blob container holding the documents to be translated.
- The `targetUri` is a SAS URI with read and write access for the blob container to which the translated documents will be written.

More on generating SAS Tokens [here](https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/get-started-with-document-translation?tabs=csharp#create-sas-access-tokens-for-document-translation)

```C# Snippet:MultipleInputsAsync
Uri source1SasUriUri = new Uri("<source1 SAS URI>");
Uri source2SasUri = new Uri("<source2 SAS URI>");
Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
Uri frenchGlossarySasUri = new Uri("<french glossary SAS URI>");

var glossaryFormat = "TSV";

var input1 = new DocumentTranslationInput(source1SasUriUri, frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));
input1.AddTarget(spanishTargetSasUri, "es");

var input2 = new DocumentTranslationInput(source2SasUri, arabicTargetSasUri, "ar");
input2.AddTarget(frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));

var inputs = new List<DocumentTranslationInput>()
    {
        input1,
        input2
    };

DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

await operation.WaitForCompletionAsync();

await foreach (DocumentStatus document in operation.GetValuesAsync())
{
    Console.WriteLine($"Document with Id: {document.Id}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language: {document.TranslatedTo}.");
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

* [Synchronously MultipleInputs ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/tests/samples/Sample_MultipleInputs.cs)
* [Asynchronously MultipleInputs ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/tests/samples/Sample_MultipleInputsAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/README.md