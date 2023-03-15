# Dictionary Lookup

## Create a `TextTranslationClient`

To create a new `TextTranslationClient`, you will need the service endpoint and credentials of your Translator resource. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C# Snippet:CreateTextTranslationClient
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential, "<region>");
```

The values of the `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

### Dictionary Lookup

Returns equivalent words for the source term in the target language.

```C# Snippet:Sample5_DictionaryLookup
try
{
    string sourceLanguage = "en";
    string targetLanguage = "es";
    IEnumerable<string> inputTextElements = new[]
    {
        "fly"
    };

    Response<IReadOnlyList<DictionaryLookupItem>> response = await client.LookupDictionaryEntriesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
    IReadOnlyList<DictionaryLookupItem> dictionaryEntries = response.Value;
    DictionaryLookupElement dictionaryEntry = dictionaryEntries.FirstOrDefault();

    Console.WriteLine($"For the given input {dictionaryEntry?.Translations?.Count} entries were found in the dictionary.");
    Console.WriteLine($"First entry: '{dictionaryEntry?.Translations?.FirstOrDefault()?.DisplayTarget}', confidence: {dictionaryEntry?.Translations?.FirstOrDefault()?.Confidence}.");

}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/README.md
