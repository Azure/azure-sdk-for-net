# Detecting the Language of Documents

This sample demonstrates how to detect the language that one or more documents are written in. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to detect the language a document is written in, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Detecting a language for a single document

To detect the language of a single document, use the `DetectLanguage` method.  The detected language the document is written in will be returned in the `DetectedLanguage` object, which contains the language and the confidence that the service's prediction is correct.

```C# Snippet:DetectLanguage
string document = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar
                    cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
                    También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil
                    para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
                    La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes,
                    dialectos y algunos idiomas regionales o culturales.";

try
{
    Response<DetectedLanguage> response = client.DetectLanguage(document);

    DetectedLanguage language = response.Value;
    Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Detecting the language of multiple documents

To detect the language of a collection of documents in the same language, use `DetectLanguageBatch` on an `IEnumerable` of strings.  The results are returned as a `DetectLanguageResultCollection`.

```C# Snippet:TextAnalyticsSample1DetectLanguagesConvenience
string documentA = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar
                    cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
                    También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil
                    para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
                    La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes,
                    dialectos y algunos idiomas regionales o culturales.";

string documentB = @"This document is written in a language different than Spanish. It's objective is to demonstrate
                    how to call the Detect Language method from the Microsoft Azure Text Analytics service.
                    It also shows how to access the information returned from the service. This capability is useful
                    for content stores that collect arbitrary text, where language is unknown.
                    The Language Detection feature can detect a wide range of languages, variants, dialects, and some
                    regional or cultural languages.";

string documentC = @"Ce document est rédigé dans une langue différente de l'espagnol. Son objectif est de montrer comment
                    appeler la méthode Detect Language à partir du service Microsoft Azure Text Analytics.
                    Il montre également comment accéder aux informations renvoyées par le service. Cette capacité est
                    utile pour les magasins de contenu qui collectent du texte arbitraire dont la langue est inconnue.
                    La fonctionnalité Détection de langue peut détecter une grande variété de langues, de variantes,
                    de dialectes, et certaines langues régionales ou de culture.";

string documentD = string.Empty;

var documents = new List<string>
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<DetectLanguageResultCollection> response = client.DetectLanguageBatch(documents);
DetectLanguageResultCollection documentsLanguage = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{documentsLanguage.ModelVersion}\"");
Console.WriteLine("");

foreach (DetectLanguageResult documentLanguage in documentsLanguage)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine("");
    if (documentLanguage.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {documentLanguage.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {documentLanguage.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Detected language: {documentLanguage.PrimaryLanguage.Name}");
        Console.WriteLine($"  Confidence score: {documentLanguage.PrimaryLanguage.ConfidenceScore}");
    }
    Console.WriteLine("");
}
```

To detect the languages of a collection of documents in different language, call `DetectLanguages` on an `IEnumerable` of `DetectLanguageInput` objects, setting the `CountryHint` on each document.

```C# Snippet:TextAnalyticsSample1DetectLanguageBatch
string documentA = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar
                    cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
                    También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil
                    para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
                    La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes,
                    dialectos y algunos idiomas regionales o culturales.";

string documentB = @"This document is written in a language different than Spanish. It's objective is to demonstrate
                    how to call the Detect Language method from the Microsoft Azure Text Analytics service.
                    It also shows how to access the information returned from the service. This capability is useful
                    for content stores that collect arbitrary text, where language is unknown.
                    The Language Detection feature can detect a wide range of languages, variants, dialects, and some
                    regional or cultural languages.";

string documentC = @"Ce document est rédigé dans une langue différente de l'espagnol. Son objectif est de montrer comment
                    appeler la méthode Detect Language à partir du service Microsoft Azure Text Analytics.
                    Il montre également comment accéder aux informations renvoyées par le service. Cette capacité est
                    utile pour les magasins de contenu qui collectent du texte arbitraire dont la langue est inconnue.
                    La fonctionnalité Détection de langue peut détecter une grande variété de langues, de variantes,
                    de dialectes, et certaines langues régionales ou de culture.";

var documents = new List<DetectLanguageInput>
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
    new DetectLanguageInput("4", ":) :( :D")
    {
         CountryHint = DetectLanguageInput.None,
    },
    new DetectLanguageInput("5", "")
};

var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };

Response<DetectLanguageResultCollection> response = client.DetectLanguageBatch(documents, options);
DetectLanguageResultCollection documentsLanguage = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{documentsLanguage.ModelVersion}\"");
Console.WriteLine("");

foreach (DetectLanguageResult documentLanguage in documentsLanguage)
{
    DetectLanguageInput document = documents[i++];

    Console.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\"):");

    if (documentLanguage.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {documentLanguage.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {documentLanguage.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Detected language: {documentLanguage.PrimaryLanguage.Name}");
        Console.WriteLine($"  Confidence score: {documentLanguage.PrimaryLanguage.ConfidenceScore}");

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {documentLanguage.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {documentLanguage.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {documentsLanguage.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {documentsLanguage.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {documentsLanguage.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {documentsLanguage.Statistics.TransactionCount}");
```

To see the full example source files, see:

* [Synchronous DetectLanguage](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics//tests/samples/Sample1_DetectLanguage.cs)
* [Asynchronous DetectLanguage](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample1_DetectLanguageAsync.cs)
* [Synchronous DetectLanguageBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample1_DetectLanguageBatch.cs)
* [Asynchronous DetectLanguageBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample1_DetectLanguageBatchAsync.cs)
* [Synchronous DetectLanguageBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample1_DetectLanguageBatchConvenience.cs)
* [Asynchronous DetectLanguageBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample1_DetectLanguageBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md