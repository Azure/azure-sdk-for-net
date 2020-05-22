# Detecting the Language of Documents

This sample demonstrates how to detect the language that one or more documents are written in. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to detect the language a document is written in, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample1CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Detecting a language for a single document

To detect the language of a single document, use the `DetectLanguage` method.  The detected language the document is written in will be returned in the `DetectedLanguage` object, which contains the language and the confidence that the service's prediction is correct.

```C# Snippet:DetectLanguage
string document = "Este documento está en español.";

DetectedLanguage language = client.DetectLanguage(document);

Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
```

## Detecting the language of multiple documents

To detect the language of a collection of documents in the same language, use `DetectLanguageBatch` on an `IEnumerable` of strings.  The results are returned as a `DetectLanguageResultCollection`.

```C# Snippet:TextAnalyticsSample1DetectLanguagesConvenience
DetectLanguageResultCollection results = client.DetectLanguageBatch(documents);
```

To detect the languages of a collection of documents in different language, call `DetectLanguages` on an `IEnumerable` of `DetectLanguageInput` objects, setting the `CountryHint` on each document.

```C# Snippet:TextAnalyticsSample1DetectLanguageBatch
var documents = new List<DetectLanguageInput>
{
    new DetectLanguageInput("1", "Hello world")
    {
         CountryHint = "us",
    },
    new DetectLanguageInput("2", "Bonjour tout le monde")
    {
         CountryHint = "fr",
    },
    new DetectLanguageInput("3", "Hola mundo")
    {
         CountryHint = "es",
    },
    new DetectLanguageInput("4", ":) :( :D")
    {
         CountryHint = DetectLanguageInput.None,
    }
};

DetectLanguageResultCollection results = client.DetectLanguageBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
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