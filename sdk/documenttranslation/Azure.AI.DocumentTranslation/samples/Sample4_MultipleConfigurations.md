# Translating Documents
This sample demonstrates how to translate documents in multiple blob container to different languages simultaneously. To get started you will need a Translator endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `DocumentTranslationClient`

To create a new `DocumentTranslationClient` to run a translation operation for documents, you need a Translator endpoint and credentials. In the sample below, you'll use a Translator API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Translating documents in multiple blob containers

To Start a translation operation for documents in multiple blob containers, call `StartTranslationAsync` with multiple configurations. The result is a Long Running operation of type `DocumentTranslationOperation` which polls for the status of the translation operation from the API.

To call `StartTranslationAsync` you need to initialize a list of `TranslationConfiguration` which contains the information needed to translate the documents. Each `TranslationConfiguration` contains a source container and a list of target containers. The `AddTarget` method is used to add targets to the configuration.

The `sourceUri` is a SAS URI with read access for the blob container holding the documents to be translated.
The `targetUri` is a SAS URI with write access for the blob container to which the translated documents will be written.

More on generating SAS Tokens [here](https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/get-started-with-document-translation?tabs=csharp#create-sas-access-tokens-for-document-translation)

```C# Snippet:MultipleConfigurationsAsync
Uri source1SasUriUri = <source1 SAS URI>;
Uri source2SasUri = <source2 SAS URI>;
Uri frenchTargetSasUri = <french target SAS URI>;
Uri arabicTargetSasUri = <arabic target SAS URI>;
Uri spanishTargetSasUri = <spanish target SAS URI>;
Uri frenchGlossarySasUri = <french glossary SAS URI>;

var configuration1 = new TranslationConfiguration(source1SasUriUri, frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri));
configuration1.AddTarget(spanishTargetSasUri, "es");

var configuration2 = new TranslationConfiguration(source2SasUri, arabicTargetSasUri, "ar");
configuration2.AddTarget(frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri));

var inputs = new List<TranslationConfiguration>()
    {
        configuration1,
        configuration2
    };

DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

TimeSpan pollingInterval = new TimeSpan(1000);

while (!operation.HasCompleted)
{
    await Task.Delay(pollingInterval);
    await operation.UpdateStatusAsync();

    Console.WriteLine($"  Status: {operation.Status}");
    Console.WriteLine($"  Created on: {operation.CreatedOn}");
    Console.WriteLine($"  Last modified: {operation.LastModified}");
    Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
    Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
    Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
    Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
    Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
}

await foreach (DocumentStatusDetail document in operation.GetValuesAsync())
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Location: {document.LocationUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

To see the full example source files, see:

* [Synchronously MultipleConfigurations ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_MultipleConfigurations.cs)
* [Asynchronously MultipleConfigurations ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/tests/samples/Sample_MultipleConfigurationsAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/README.md