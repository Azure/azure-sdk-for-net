# Translate

All samples are using `client` created in [Create a `TextTranslationClient`][create_client_sample] samples.

## Translate text

Translate text from known source language to target language.

```C# Snippet:GetTextTranslationBySource
try
{
    string sourceLanguage = "en";
    string targetLanguage = "cs";
    string inputText = "This is a test.";

    Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText, sourceLanguage);
    IReadOnlyList<TranslatedTextItem> translations = response.Value;
    TranslatedTextItem translation = translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate with auto-detection

You can ommit source languge of the input text. In this case, API will try to auto-detect the language.

> Note that you must provide the source language rather than autodetection when using the dynamic dictionary feature.
> Note you can use `suggestedFrom` paramter that specifies a fallback language if the language of the input text can't be identified. Language autodetection is applied when the from parameter is omitted. If detection fails, the suggestedFrom language will be assumed.

```C# Snippet:GetTextTranslationAutoDetect
try
{
    string targetLanguage = "cs";
    string inputText = "This is a test.";

    Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputText);
    IReadOnlyList<TranslatedTextItem> translations = response.Value;
    TranslatedTextItem translation = translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate with Transliteration

You can combine both Translation and Transliteration in one Translate call. Your source Text can be in non-standard Script of a language as well as you can ask for non-standard Script of a target language.

```C# Snippet:GetTranslationTextTransliterated
try
{
    string fromScript = "Latn";
    string fromLanguage = "ar";
    string toScript = "Latn";
    string toLanguage = "zh-Hans";
    string inputText = "hudha akhtabar.";

    TranslationTarget target = new TranslationTarget(toLanguage, script: toScript);
    TranslateInputItem inputItem = new TranslateInputItem(inputText, target, language: fromLanguage, script: fromScript);

    Response<TranslatedTextItem> response = client.Translate(inputItem);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Translation: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
    Console.WriteLine($"Transliterated text ({translated.Language}): {translated.Text}");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate multiple input texts

You can translate multiple text elements. Each input element can be in different language (source language parameter needs to be omitted and language auto-detection is used). Refer to [Request limits for Translator](https://learn.microsoft.com/azure/cognitive-services/translator/request-limits) for current limits.

```C# Snippet:GetMultipleTextTranslations
try
{
    string targetLanguage = "cs";
    IEnumerable<string> inputTextElements = new[]
    {
        "This is a test.",
        "Esto es una prueba.",
        "Dies ist ein Test."
    };

    Response<IReadOnlyList<TranslatedTextItem>> response = client.Translate(targetLanguage, inputTextElements);
    IReadOnlyList<TranslatedTextItem> translations = response.Value;

    foreach (TranslatedTextItem translation in translations)
    {
        Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
        Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate multiple target languages

You can provide multiple target languages which results in each input element being translated to all target languages.

```C# Snippet:GetTextTranslationMatrix
try
{
    IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
    string inputText = "This is a test.";

    TranslateInputItem input = new TranslateInputItem(inputText, targetLanguages.Select(lang => new TranslationTarget(lang)));
    Response<TranslatedTextItem> response = client.Translate(input);
    IReadOnlyList<TranslationText> translations = response.Value.Translations;

    foreach (TranslationText translation in translations)
    {
        Console.WriteLine($"Text was translated to: '{translation?.Language}' and the result is: '{translation?.Text}'.");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate different text types

You can select whether the translated text is plain text or HTML text. Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.

```C# Snippet:GetTextTranslationFormat
try
{
    string targetLanguage = "cs";
    string inputText = "<html><body>This <b>is</b> a test.</body></html>";

    TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), textType: TextType.Html);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Don’t translate specific entity name in a text

It's sometimes useful to exclude specific content from translation. You can use the attribute class=notranslate to specify content that should remain in its original language. In the following example, the content inside the first div element won't be translated, while the content in the second div element will be translated.

```C# Snippet:GetTextTranslationFilter
try
{
    string sourceLanguage = "en";
    string targetLanguage = "cs";
    string inputText = "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>";

    TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), language: sourceLanguage, textType: TextType.Html);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translate specific entity name in a text applying a dictionary

If you already know the translation you want to apply to a word or a phrase, you can supply it as markup within the request. The dynamic dictionary is safe only for compound nouns like proper names and product names.

> Note You must include the From parameter in your API translation request instead of using the autodetect feature.

```C# Snippet:GetTextTranslationMarkup
try
{
    string sourceLanguage = "en";
    string targetLanguage = "cs";
    string inputText = "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry.";

    TranslateInputItem input = new TranslateInputItem(inputText, new TranslationTarget(targetLanguage), language: sourceLanguage, textType: TextType.Html);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Profanity handling

Normally the Translator service will retain profanity that is present in the source in the translation. The degree of profanity and the context that makes words profane differ between cultures, and as a result the degree of profanity in the target language may be amplified or reduced.

If you want to avoid getting profanity in the translation, regardless of the presence of profanity in the source text, you can use the profanity filtering option. The option allows you to choose whether you want to see profanity deleted, whether you want to mark profanities with appropriate tags (giving you the option to add your own post-processing), or you want no action taken. The accepted values of `ProfanityAction` are `Deleted`, `Marked` and `NoAction` (default).

```C# Snippet:GetTextTranslationProfanity
try
{
    ProfanityAction profanityAction = ProfanityAction.Marked;
    ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

    string targetLanguage = "cs";
    string inputText = "This is ***.";

    TranslationTarget target = new TranslationTarget(targetLanguage, profanityAction: profanityAction, profanityMarker: profanityMarkers);
    TranslateInputItem input = new TranslateInputItem(inputText, target);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Custom Translator

You can get translations from a customized system built with [Custom Translator](https://learn.microsoft.com/azure/cognitive-services/translator/customization). Add the Category ID from your Custom Translator [project details](https://learn.microsoft.com/azure/cognitive-services/translator/custom-translator/how-to-create-project#view-project-details) to this parameter to use your deployed customized system.

It is possible to set `allowFalback` paramter. It specifies that the service is allowed to fall back to a general system when a custom system doesn't exist. Possible values are: `true` (default) or `false`.

`allowFallback=false` specifies that the translation should only use systems trained for the category specified by the request. If a translation for language X to language Y requires chaining through a pivot language E, then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category. If no system is found with the specific category, the request will return a 400 status code. `allowFallback=true` specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.

```C# Snippet:GetTextTranslationFallback
try
{
    string category = "<<Category ID>>";
    string targetLanguage = "cs";
    string inputText = "This is a test.";

    TranslationTarget target = new TranslationTarget(targetLanguage, deploymentName: category, allowFallback: true);
    TranslateInputItem input = new TranslateInputItem(inputText, target);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;
    TranslationText translated = translation.Translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translated?.Language}' and the result is: '{translated?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Translation using LLM

You can get translations from Large Language Model (LLM) models in addition to default neural Machine Translation (NMT). [Azure resources for Azure AI translation](https://learn.microsoft.com/azure/ai-services/translator/how-to/create-translator-resource?tabs=foundry)

```C# Snippet:GetTextTranslationLlm
try
{
    string targetLanguage = "cs";
    string llmModelname = "gpt-4o-mini";
    string inputText = "This is a test.";

    TranslationTarget target = new TranslationTarget(targetLanguage, deploymentName: llmModelname);
    TranslateInputItem input = new TranslateInputItem(inputText, target);

    Response<TranslatedTextItem> response = client.Translate(input);
    TranslatedTextItem translation = response.Value;

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().Language}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
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
