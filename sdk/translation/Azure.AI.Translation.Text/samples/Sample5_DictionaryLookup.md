# Dictionary Lookup

## Create a `TextTranslationClient`

To create a new `TextTranslationClient`, you will need the service endpoint and credentials of your Translator resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C# Snippet:CreateTextTranslationClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(endpoint, credential, "<region>");
```

The values of the `endpoint`, `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

### Dictionary Lookup

Returns equivalent words for the source term in the target language.

```C# Snippet:Sample5_DictionaryLookup
try
{
    string sourceLanguage = "en";
    string targetLanguage = "es";
    IEnumerable<InputText> inputTextElements = new[]
    {
        new InputText { Text = "fly" }
    };

    Response<IReadOnlyList<DictionaryLookupElement>> response = await client.LookupDictionaryEntriesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
    IReadOnlyList<DictionaryLookupElement> dictionaryEntries = response.Value;
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
