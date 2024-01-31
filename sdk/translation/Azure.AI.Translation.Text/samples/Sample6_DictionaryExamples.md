# Dictionary Examples

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Lookup Dictionary Examples

Returns grammatical structure and context examples for the source term and target term pair.

```C# Snippet:GetGrammaticalStructure
try
{
    string sourceLanguage = "en";
    string targetLanguage = "es";
    IEnumerable<InputTextWithTranslation> inputTextElements = new[]
    {
        new InputTextWithTranslation("fly", "volar")
    };

    Response<IReadOnlyList<DictionaryExampleItem>> response = client.LookupDictionaryExamples(sourceLanguage, targetLanguage, inputTextElements);
    IReadOnlyList<DictionaryExampleItem> dictionaryEntries = response.Value;
    DictionaryExampleItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

    Console.WriteLine($"For the given input {dictionaryEntry?.Examples?.Count} examples were found in the dictionary.");
    DictionaryExample firstExample = dictionaryEntry?.Examples?.FirstOrDefault();
    Console.WriteLine($"Example: '{string.Concat(firstExample.TargetPrefix, firstExample.TargetTerm, firstExample.TargetSuffix)}'.");
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
