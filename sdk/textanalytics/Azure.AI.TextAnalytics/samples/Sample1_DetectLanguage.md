# Detecting the Language of Text Inputs

This sample demonstrates how to detect the language that one or more text inputs are written in using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to detect the language a text input is written in, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample1CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Detecting a language for a single text input

To detect the language of a single text input, pass the input string to the client's `DetectLanguage` method.  The primary language the input is written in will be returned as the result's `PrimaryLanguage` property, and this object contains both the name of the language and the confidence that the service's prediction is correct.

```C# Snippet:DetectLanguage
string input = "Este documento está en español.";

DetectLanguageResult result = client.DetectLanguage(input);
DetectedLanguage language = result.PrimaryLanguage;

Console.WriteLine($"Detected language {language.Name} with confidence {language.Score:0.00}.");
```

## Detecting the language of multiple text inputs

To detect the language of a collection of text inputs in the same language, call `DetectLanguages` on an `IEnumerable` of strings.  The results are returned as a `DetectLanguageResultCollection`.

```C# Snippet:TextAnalyticsSample1DetectLanguagesConvenience
DetectLanguageResultCollection results = client.DetectLanguages(inputs);
```

To detect the languages of a collection of text inputs in different language, call `DetectLanguages` on an `IEnumerable` of `DetectLanguageInput` objects, setting the `CountryHint` on each input.

```C# Snippet:TextAnalyticsSample1DetectLanguagesBatch
var inputs = new List<DetectLanguageInput>
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
         CountryHint = "us",
    }
};

DetectLanguageResultCollection results = client.DetectLanguages(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Synchronous Sample1_DetectLanguage.cs](../tests/samples/Sample1_DetectLanguage.cs)
* [Asynchronous Sample1_DetectLanguage.cs](../tests/samples/Sample1_DetectLanguageAsync.cs)
* [Synchronous Sample1_DetectLanguageBatch.cs](../tests/samples/Sample1_DetectLanguageBatch.cs)
* [Synchronous Sample1_DetectLanguageBatchConvenience.cs](../tests/samples/Sample1_DetectLanguageBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md