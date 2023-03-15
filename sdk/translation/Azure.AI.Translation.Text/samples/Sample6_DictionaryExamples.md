# Dictionary Examples

## Create a `TextTranslationClient`

To create a new `TextTranslationClient`, you will need the service endpoint and credentials of your Translator resource. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C# Snippet:CreateTextTranslationClient
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential, "<region>");
```

The values of the `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Dictionary Examples

Returns grammatical structure and context examples for the source term and target term pair.

```C# Snippet:Sample6_DictionaryExamples
try
{
    string sourceLanguage = "en";
    string targetLanguage = "es";
    IEnumerable<InputTextWithTranslation> inputTextElements = new[]
    {
        new InputTextWithTranslation { Text = "fly", Translation = "volar" }
    };

    Response<IReadOnlyList<DictionaryExampleElement>> response = await client.LookupDictionaryExamplesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
    IReadOnlyList<DictionaryExampleElement> dictionaryEntries = response.Value;
    DictionaryExampleElement dictionaryEntry = dictionaryEntries.FirstOrDefault();

    Console.WriteLine($"For the given input {dictionaryEntry?.Examples?.Count} examples were found in the dictionary.");
    Example firstExample = dictionaryEntry?.Examples?.FirstOrDefault();
    Console.WriteLine($"Example: '{string.Concat(firstExample.TargetPrefix, firstExample.TargetTerm, firstExample.TargetSuffix)}'.");

}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/README.md
