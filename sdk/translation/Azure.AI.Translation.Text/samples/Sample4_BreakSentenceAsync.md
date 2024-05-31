# Break Sentence

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Break Sentence with language and script parameters

When the input language is known, you can provide those to the service call.

```C# Snippet:GetTextTranslationSentencesSourceAsync
try
{
    string sourceLanguage = "zh-Hans";
    string sourceScript = "Latn";
    IEnumerable<string> inputTextElements = new[]
    {
        "zhè shì gè cè shì。"
    };

    Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements, language: sourceLanguage, script: sourceScript).ConfigureAwait(false);
    IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
    BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Confidence}.");
    Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentencesLengths)}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Break Sentence with auto-detection

You can ommit source languge of the input text. In this case, API will try to auto-detect the language.

```C# Snippet:GetTextTranslationSentencesAutoAsync
try
{
    IEnumerable<string> inputTextElements = new[]
    {
        "How are you? I am fine. What did you do today?"
    };

    Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements).ConfigureAwait(false);
    IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
    BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Confidence}.");
    Console.WriteLine($"The detected sentence boundaries: '{string.Join(",", brokenSentence?.SentencesLengths)}'.");
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
