# Dictionary Lookup

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Lookup Dictionary Entries

Returns equivalent words for the source term in the target language.

```C# Snippet:LookupDictionaryEntriesAsync
try
{
    string sourceLanguage = "en";
    string targetLanguage = "es";
    string inputText = "fly";

    Response<IReadOnlyList<DictionaryLookupItem>> response = await client.LookupDictionaryEntriesAsync(sourceLanguage, targetLanguage, inputText).ConfigureAwait(false);
    IReadOnlyList<DictionaryLookupItem> dictionaryEntries = response.Value;
    DictionaryLookupItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

    Console.WriteLine($"For the given input {dictionaryEntry?.Translations?.Count} entries were found in the dictionary.");
    Console.WriteLine($"First entry: '{dictionaryEntry?.Translations?.FirstOrDefault()?.DisplayTarget}', confidence: {dictionaryEntry?.Translations?.FirstOrDefault()?.Confidence}.");
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
