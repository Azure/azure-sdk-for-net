# Detecting the language of documents

This sample demonstrates how to detect the language of one or more documents.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential apiKey = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Detect the language of a single document

To detect the language of a document, call `DetectLanguage` on the `TextAnalyticsClient`, which returns a `DetectedLanguage` object with the name of the language, a confidence score, and more.

```C# Snippet:Sample1_DetectLanguage
string document =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de Detección de Lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para los sistemas de contenido que recopilan texto arbitrario, donde el lenguaje no se conoce"
    + " de antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

try
{
    Response<DetectedLanguage> response = client.DetectLanguage(document);
    DetectedLanguage language = response.Value;

    Console.WriteLine($"Detected language is {language.Name} with a confidence score of {language.ConfidenceScore}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Detect the languages of multiple documents

To detect the languages of multiple documents, call `DetectLanguageBatch` on the `TextAnalyticsClient` by passing the documents as an `IEnumerable<string>` parameter. This returns a `DetectLanguageResultCollection`.

```C# Snippet:Sample1_DetectLanguageBatchConvenience
string documentA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string documentB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string documentC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<DetectLanguageResultCollection> response = client.DetectLanguageBatch(batchedDocuments);
DetectLanguageResultCollection documentsLanguage = response.Value;

int i = 0;
Console.WriteLine($"Detect Language, model version: \"{documentsLanguage.ModelVersion}\"");
Console.WriteLine();

foreach (DetectLanguageResult documentResult in documentsLanguage)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Detected language: {documentResult.PrimaryLanguage.Name}");
    Console.WriteLine($"  Confidence score: {documentResult.PrimaryLanguage.ConfidenceScore}");
    Console.WriteLine();
}
```

If the country where a document originates from is known, you can aid the language detection model if you call `DetectLanguageBatch` on the `TextAnalyticsClient` while passing the documents as an `IEnumerable<DetectLanguageInput>` parameter, having set the `CountryHint` property on each `DetectLanguageInput` object accordingly.

```C# Snippet:Sample1_DetectLanguageBatch
string documentA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string documentB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string documentC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

string documentD = "Tumhara naam kya hai?";

string documentE = ":) :( :D";

string documentF = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<DetectLanguageInput> batchedDocuments = new()
{
    new DetectLanguageInput("1", documentA)
    {
         CountryHint = "es",
    },
    new DetectLanguageInput("2", documentB)
    {
         CountryHint = "us",
    },
    new DetectLanguageInput("3", documentC)
    {
         CountryHint = "fr",
    },
    new DetectLanguageInput("4", documentD)
    {
         CountryHint = "in",
    },
    new DetectLanguageInput("5", documentE)
    {
         CountryHint = DetectLanguageInput.None,
    },
    new DetectLanguageInput("6", documentF)
    {
         CountryHint = "us",
    }
};

TextAnalyticsRequestOptions options = new() { IncludeStatistics = true };
Response<DetectLanguageResultCollection> response = client.DetectLanguageBatch(batchedDocuments, options);
DetectLanguageResultCollection documentsLanguage = response.Value;

int i = 0;
Console.WriteLine($"Detect Language, model version: \"{documentsLanguage.ModelVersion}\"");
Console.WriteLine();

foreach (DetectLanguageResult documentLanguage in documentsLanguage)
{
    DetectLanguageInput document = batchedDocuments[i++];

    Console.WriteLine($"Result for document with Id = \"{document.Id}\" and CountryHint = \"{document.CountryHint}\":");

    if (documentLanguage.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentLanguage.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentLanguage.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Detected language: {documentLanguage.PrimaryLanguage.Name}");
    Console.WriteLine($"  Confidence score: {documentLanguage.PrimaryLanguage.ConfidenceScore}");
    if (documentLanguage.PrimaryLanguage.Script is not null)
        Console.WriteLine($"  Script: {documentLanguage.PrimaryLanguage.Script}");

    Console.WriteLine($"  Document statistics:");
    Console.WriteLine($"    Character count: {documentLanguage.Statistics.CharacterCount}");
    Console.WriteLine($"    Transaction count: {documentLanguage.Statistics.TransactionCount}");
    Console.WriteLine();
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {documentsLanguage.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {documentsLanguage.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {documentsLanguage.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {documentsLanguage.Statistics.TransactionCount}");
```

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
