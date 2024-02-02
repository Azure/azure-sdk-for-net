# Detecting the language of documents

This sample demonstrates how to detect the language of one or more documents.

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Detect the language of documents

To detect the language of a document, call `AnalyzeText` on the `AnalyzeTextClient`, which returns a `LanguageDetectionTaskResult` object with the name of the language, a confidence score, and more.

```C# Snippet:Sample1_AnalyzeText_LanguageDetection
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

try
{
    AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
    {
        AnalysisInput = new LanguageDetectionAnalysisInput()
        {
            Documents =
            {
                new LanguageInput("A", documentA),
                new LanguageInput("B", documentB),
                new LanguageInput("C", documentC),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
    LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
    {
        Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

To detect the language of a document, call `AnalyzeText` on the `AnalyzeTextClient`, which returns a `LanguageDetectionTaskResult` object with the name of the language, a confidence score, and more.

If the country where a document originates from is known, you can aid the language detection model if you call `AnalyzeText` on the `AnalyzeTextClient` while passing the documents as an `IEnumerable<LanguageInput>` parameter, having set the `CountryHint` property on each `LanguageInput` object accordingly.

```C# Snippet:Sample1_AnalyzeText_LanguageDetection
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

try
{
    AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
    {
        AnalysisInput = new LanguageDetectionAnalysisInput()
        {
            Documents =
            {
                new LanguageInput("A", documentA, "es"),
                new LanguageInput("B", documentB, "us")
                new LanguageInput("C", documentC, "fr"),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
    LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
    {
        Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```
