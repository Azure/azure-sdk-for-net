# Transliterate

## Create a `TextTranslationClient`

To create a new `TextTranslationClient`, you will need the service endpoint and credentials of your Translator resource. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C#
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(credential, "<region>");
```

The values of the `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

### Transliterate
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

See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://aka.ms/https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/README.md
