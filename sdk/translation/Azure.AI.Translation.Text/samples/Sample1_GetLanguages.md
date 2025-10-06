# Get Languages

This sample demonstrates how to get languages that are supported by other operations. All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Get Supported Languages for ALL other operations

This will return language metadata from all supported scopes.

```C# Snippet:GetTextTranslationLanguagesMetadata
try
{
    Response<GetSupportedLanguagesResult> response = client.GetSupportedLanguages();
    GetSupportedLanguagesResult languages = response.Value;

    Console.WriteLine($"Number of supported languages for translate operation: {languages.Translation.Count}.");
    Console.WriteLine($"Number of supported languages for transliterate operation: {languages.Transliteration.Count}.");
    Console.WriteLine($"Number of supported languages for dictionary operations: {languages.Dictionary.Count}.");

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

```C# Snippet:GetTextTranslationLanguagesByScope
try
{
    string scope = "translation";
    Response<GetSupportedLanguagesResult> response = client.GetSupportedLanguages(scope: scope);
    GetSupportedLanguagesResult languages = response.Value;

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

```C# Snippet:GetTextTranslationLanguagesByCulture
try
{
    string acceptLanguage = "es";
    Response<GetSupportedLanguagesResult> response = client.GetSupportedLanguages(acceptLanguage: acceptLanguage);
    GetSupportedLanguagesResult languages = response.Value;

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

See the [README] of the Text Translation client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/README.md
[create_client_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample0_CreateClient.md
