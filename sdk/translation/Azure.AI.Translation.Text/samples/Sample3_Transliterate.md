# Transliterate

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Transliterate Text

Converts characters or letters of a source language to the corresponding characters or letters of a target language.

```C# Snippet:GetTransliteratedText
try
{
    string language = "zh-Hans";
    string fromScript = "Hans";
    string toScript = "Latn";

    string inputText = "这是个测试。";

    Response<IReadOnlyList<TransliteratedText>> response = client.Transliterate(language, fromScript, toScript, inputText);
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

A convenience overload of Transliterate is provided using a single TextTranslationTransliterateOptions parameter.  A modified version of the preceding sample is provided here demonstrating its use.

```C# Snippet:GetTransliteratedTextOptions
try
{
    TextTranslationTransliterateOptions options = new TextTranslationTransliterateOptions(
        language: "zh-Hans",
        fromScript: "Hans",
        toScript: "Latn",
        content: "这是个测试。"
    );

    Response<IReadOnlyList<TransliteratedText>> response = client.Transliterate(options);
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
