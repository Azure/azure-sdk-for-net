# Detecting the language of documents

This sample demonstrates how to detect the language of one or more documents.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Detect the language of documents

To detect the language of a document, call `AnalyzeText` on the `TextAnalysisClient`, which returns a `AnalyzeTextLanguageDetectionResult` object with the name of the language, a confidence score, and more.

```C# Snippet:Sample1_AnalyzeText_LanguageDetection
string textA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string textB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string textC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

try
{
    AnalyzeTextInput body = new TextLanguageDetectionInput()
    {
        TextInput = new LanguageDetectionTextInput()
        {
            LanguageInputs =
            {
                new LanguageInput("A", textA),
                new LanguageInput("B", textB),
                new LanguageInput("C", textC),
            }
        }
    };

    Response<AnalyzeTextResult> response = client.AnalyzeText(body);
    AnalyzeTextLanguageDetectionResult analyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in analyzeTextLanguageDetectionResult.Results.Documents)
    {
        Console.WriteLine($"Result for document with Id = \"{document.Id}\":");
        Console.WriteLine($"    Name: {document.DetectedLanguage.Name}");
        Console.WriteLine($"    Iso6391Name: {document.DetectedLanguage.Iso6391Name}");
        if (document.DetectedLanguage.ScriptName != null)
        {
            Console.WriteLine($"    ScriptName: {document.DetectedLanguage.ScriptName}");
            Console.WriteLine($"    ScriptIso15924Code: {document.DetectedLanguage.ScriptIso15924Code}");
        }
        Console.WriteLine($"    ConfidenceScore: {document.DetectedLanguage.ConfidenceScore}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

To detect the language of a document, call `AnalyzeText` on the `TextAnalysisClient`, which returns a `AnalyzeTextLanguageDetectionResult` object with the name of the language, a confidence score, and more.

If the country where a document originates from is known, you can aid the language detection model if you call `AnalyzeText` on the `TextAnalysisClient` while passing the documents as an `IEnumerable<LanguageInput>` parameter, having set the `CountryHint` property on each `LanguageInput` object accordingly.

```C# Snippet:Sample1_AnalyzeText_LanguageDetection_CountryHint
string textA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string textB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string textC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

try
{
    AnalyzeTextInput body = new TextLanguageDetectionInput()
    {
        TextInput = new LanguageDetectionTextInput()
        {
            LanguageInputs =
            {
                new LanguageInput("A", textA) { CountryHint = "es" },
                new LanguageInput("B", textB) { CountryHint = "us" },
                new LanguageInput("C", textC) { CountryHint = "fr" },
            }
        }
    };

    Response<AnalyzeTextResult> response = client.AnalyzeText(body);
    AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
    {
        Console.WriteLine($"Result for document with Id = \"{document.Id}\":");
        Console.WriteLine($"    Name: {document.DetectedLanguage.Name}");
        Console.WriteLine($"    Iso6391Name: {document.DetectedLanguage.Iso6391Name}");
        if (document.DetectedLanguage.ScriptName != null)
        {
            Console.WriteLine($"    ScriptName: {document.DetectedLanguage.ScriptName}");
            Console.WriteLine($"    ScriptIso15924Code: {document.DetectedLanguage.ScriptIso15924Code}");
        }
        Console.WriteLine($"    ConfidenceScore: {document.DetectedLanguage.ConfidenceScore}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
