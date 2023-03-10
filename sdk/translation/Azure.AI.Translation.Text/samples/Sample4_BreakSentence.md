# Break Sentence

## Create a `TranslatorClient`

To create a new `TranslatorClient`, you will need the service endpoint and credentials of your Translator resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential` and region, which you can create with an API key.

```C# Snippet:CreateTranslatorClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TranslatorClient client = new(endpoint, credential, "<region>");
```

The values of the `endpoint`, `apiKey` and `region` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

### Break Sentence with language and script parameters
When the input language is known, you can provide those to the service call.

```C# Snippet:Sample4_BreakSentence
try
{
    string sourceLanguage = "zh-Hans";
    string sourceScript = "Latn";
    IEnumerable<InputText> inputTextElements = new[]
    {
        new InputText { Text = "zhè shì gè cè shì。" }
    };

    Response<IReadOnlyList<BreakSentenceElement>> response = await client.BreakSentenceAsync(inputTextElements, language: sourceLanguage, script: sourceScript).ConfigureAwait(false);
    IReadOnlyList<BreakSentenceElement> brokenSentences = response.Value;
    BreakSentenceElement brokenSentence = brokenSentences.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
    Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");


}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Break Sentence with auto-detection
You can ommit source languge of the input text. In this case, API will try to auto-detect the language.

```C# Snippet:Sample4_BreakSentenceWithAutoDetection
try
{
    IEnumerable<InputText> inputTextElements = new[]
    {
        new InputText { Text = "How are you? I am fine. What did you do today?" }
    };

    Response<IReadOnlyList<BreakSentenceElement>> response = await client.BreakSentenceAsync(inputTextElements).ConfigureAwait(false);
    IReadOnlyList<BreakSentenceElement> brokenSentences = response.Value;
    BreakSentenceElement brokenSentence = brokenSentences.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
    Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");

}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

See the [README] of the Text Translator client library for more information, including useful links and instructions.

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/README.md
