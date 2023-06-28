# Transliterate

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Transliterate Text

Converts characters or letters of a source language to the corresponding characters or letters of a target language.

```C#
try
{
    string language = "zh-Hans";
    string fromScript = "Hans";
    string toScript = "Latn";

    IEnumerable<string> inputTextElements = new[]
    {
        "这是个测试。"
    };

    Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync(language, fromScript, toScript, inputTextElements).ConfigureAwait(false);
    IReadOnlyList<TransliteratedText> transliterations = response.Value;
    TransliteratedText transliteration = transliterations.FirstOrDefault();

    Console.WriteLine($"Input text was transliterated to '{transliteration?.Script}' script. Transliterated text: '{transliteration?.Text}'.");
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
