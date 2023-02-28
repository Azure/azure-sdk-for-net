# Get Languages

This sample demonstrates how to get languages that are supported by other operations.

## Create a `TranslatorClient`

For this operation you can create a new `TranslatorClient` without any authentication. You will only need your endpoint:

```C# Snippet:CreateTranslatorClient
Uri endpoint = new("<endpoint>");
TranslatorClient client = new(endpoint);
```

The values of the `endpoint` variable can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Get Supported Languages for ALL other operations
This will return language metadata from all supported scopes.

```C# Snippet:Sample1_GetLanguages
try
{
    Response<GetLanguagesResult> response = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
    GetLanguagesResult languages = response.Value;

    Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

    Console.WriteLine("Translation Languages:");
    foreach (var translationLanguage in languages.Translation)
    {
        Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
    }

    Console.WriteLine("Transliteration Languages:");
    foreach (var transliterationLanguage in languages.Transliteration)
    {
        Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
    }

    Console.WriteLine("Dictionary Languages:");
    foreach (var dictionaryLanguage in languages.Dictionary)
    {
        Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Get Supported Languages for a given scope
You can limit the scope of the response of the languages API by providing the optional paramter `scope`. A comma-separated list of names defining the group of languages to return. Allowed group names are: `translation`, `transliteration` and `dictionary`. If no scope is given, then all groups are returned, which is equivalent to passing `translation,transliteration,dictionary`.

```C# Snippet:Sample1_GetLanguagesScope
try
{
    string scope = "translation";
    Response<GetLanguagesResult> response = await client.GetLanguagesAsync(scope: scope, cancellationToken: CancellationToken.None).ConfigureAwait(false);
    GetLanguagesResult languages = response.Value;

    Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

    Console.WriteLine("Translation Languages:");
    foreach (var translationLanguage in languages.Translation)
    {
        Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
    }

    Console.WriteLine("Transliteration Languages:");
    foreach (var transliterationLanguage in languages.Transliteration)
    {
        Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
    }

    Console.WriteLine("Dictionary Languages:");
    foreach (var dictionaryLanguage in languages.Dictionary)
    {
        Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Get Languages in a given culture
You can select the language to use for user interface strings. Some of the fields in the response are names of languages or names of regions. Use this parameter to define the language in which these names are returned. The language is specified by providing a well-formed BCP 47 language tag. For instance, use the value `fr` to request names in French or use the value `zh-Hant` to request names in Chinese Traditional.
Names are provided in the English language when a target language is not specified or when localization is not available.

```C# Snippet:Sample1_GetLanguagesAcceptLanguage
try
{
    string acceptLanguage = "es";
    Response<GetLanguagesResult> response = await client.GetLanguagesAsync(acceptLanguage: acceptLanguage, cancellationToken: CancellationToken.None).ConfigureAwait(false);
    GetLanguagesResult languages = response.Value;

    Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
    Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

    Console.WriteLine("Translation Languages:");
    foreach (var translationLanguage in languages.Translation)
    {
        Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
    }

    Console.WriteLine("Transliteration Languages:");
    foreach (var transliterationLanguage in languages.Transliteration)
    {
        Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
    }

    Console.WriteLine("Dictionary Languages:");
    foreach (var dictionaryLanguage in languages.Dictionary)
    {
        Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/texttranslator/Azure.AI.TextTranslator/README.md
