# Azure TextTranslator client library for .NET

Text translation is a cloud-based REST API feature of the Translator service that uses neural machine translation technology to enable quick and accurate source-to-target text translation in real time across all supported languages.

Use the TextTranslator client library for .NET to:

* Return a list of languages supported by Translate, Transliterate, and Dictionary operations.

* Render single source-language text to multiple target-language texts with a single request.

* Convert characters or letters of a source language to the corresponding characters or letters of a target language.

* Return equivalent words for the source term in the target language.

* Return grammatical structure and context examples for the source term and target term pair.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.Translation.Text) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the Azure Text Analytics client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Translation.Text --prerelease
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version  |Supported API version of service
|-------------|-----------------------------------------------------|
|1.0.X        | 3.0

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Translator service resource.

#### Create a Cognitive Services resource or a Translator service resource

Text translation supports both [multi-service and single-service access][service_access]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint and API key. To access the features of the Text translation service only, create a Text translation service resource instead.

You can create either resource via the [Azure portal][create_text_resource_azure_portal] or, alternatively, you can follow the steps in [this document][create_text_resource_azure_cli] to create it using the [Azure CLI][azure_cli].

### Authenticate the client

Interaction with the service using the client library begins with creating an instance of the [TextTranslationClient][translator_client_class] class. You will need an **endpoint**, and either an **API key** or ``TokenCredential`` to instantiate a client object for all operations except GET Languages.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Translator Service][translator_auth].

#### Create a `TextTranslationClient` without any authentication
For requests to get supported languages, you can create [TextTranslationClient][translator_client_class] without any authentication.

> Note: only GET Languages operation will work without authentication. All other operations will fail with 401 response.

```C# Snippet:CreateTextTranslationClientAnonymous
Uri endpoint = new("<endpoint>");
TextTranslationClient client = new(endpoint);
```

#### Get an API key

You can get the `endpoint`, `API key` and `Region` from the Cognitive Services resource or Translator service resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Translator service resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create a `TextTranslationClient` using an API key and Region credential

Once you have the value for the API key and Region, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint, `AzureKeyCredential` and a `Region`, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(endpoint, credential, "<region>");
```

#### Create a `TextTranslationClient` using a Token Authentication

Instead of API key and Region authentication you can use JWT token. For information on how to create token refer to [Authenticating with an access token][translator_token].

Once you have the value for the token, create an class that extends `Azure.Core.TokenCredentials`. With the value of the endpoint, `AzureKeyCredential` and your service returning tokens, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientToken
Uri endpoint = new("<endpoint>");
TokenCredential credential = new("<token>");
TextTranslationClient client = new(endpoint, credential);
```

#### Create a `TextTranslationClient` using a Custom Endpoint and Api Key
When Translator service is configured to use [Virtual Network (VNET)][translator_vnet] capability you need to use [custom subdomain][custom_subdomain].

Once you have your resource configured and you have your custom endpoint value and your API key, you can create the [TextTranslationClient][translator_client_class]:

```C# Snippet:CreateTextTranslationClientCustom
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextTranslationClient client = new(endpoint, credential);
```

## Key concepts

### `TextTranslationClient`

A `TextTranslationClient` is the primary interface for developers using the Text Translator client library.  It provides both synchronous and asynchronous operations to access a specific use of text translator, such as get supported languages detection or text translation.

### Input

A **text element**, is a single unit of input to be processed by the translation models in the Translator service. Operations on `TextTranslationClient` may take a single text element or a collection of text elements.
For text element length limits, maximum requests size, and supported text encoding see [here][translator_limits].

### Return value

Return values, such as `Response<IReadOnlyList<TranslatedTextElement>>`, is the result of a Text Translation operation, containing array with one result for each string in the input array.  An operation's return value also may optionally include information about the input text element (for example detected language).

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets using the `client` [created above](#create-a-TextTranslationClient-using-an-api-key-and-region-credential), and covers the main features present in this client library. Although most of the snippets below make use of asynchronous service calls, keep in mind that the `Azure.AI.Translation.Text` package supports both synchronous and asynchronous APIs.

### Get Supported Languages

Gets the set of languages currently supported by other operations of the Translator.

```C# Snippet:Sample1_GetLanguages
try
{
    Response<GetLanguagesResult> response = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
    GetLanguagesResult languages = response.Value;

    Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the `languages` endpoint refer to more samples [here][languages_sample].

Please refer to the service documentation for a conceptual discussion of [languages][languages_doc].

### Translate

Renders single source-language text to multiple target-language texts with a single request.

```C# Snippet:Sample2_Translate
try
{
    IEnumerable<string> targetLanguages = new[] { "cs" };
    IEnumerable<InputText> inputTextElements = new []
    {
        new InputText { Text = "This is a test." }
    };

    Response<IReadOnlyList<TranslatedTextElement>> response = await client.TranslateAsync(targetLanguages, inputTextElements).ConfigureAwait(false);
    IReadOnlyList<TranslatedTextElement> translations = response.Value;
    TranslatedTextElement translation = translations.FirstOrDefault();

    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the `translate` endpoint refer to more samples [here][translate_sample].

Please refer to the service documentation for a conceptual discussion of [translate][translate_doc].

### Transliterate

Converts characters or letters of a source language to the corresponding characters or letters of a target language.

```C# Snippet:Sample3_Transliterate
try
{
    string language = "zh-Hans";
    string fromScript = "Hans";
    string toScript = "Latn";

    IEnumerable<InputText> inputTextElements = new[]
    {
        new InputText { Text = "这是个测试。" }
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

For samples on using the `transliterate` endpoint refer to more samples [here][transliterate_sample].

Please refer to the service documentation for a conceptual discussion of [transliterate][transliterate_doc].

### Break Sentence

Identifies the positioning of sentence boundaries in a piece of text.

```C# Snippet:Sample4_BreakSentence
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

For samples on using the `break sentece` endpoint refer to more samples [here][breaksentence_sample].

Please refer to the service documentation for a conceptual discussion of [break sentence][breaksentence_doc].

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

    Response<IReadOnlyList<DictionaryLookupElement>> response = await client.DictionaryLookupAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
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

For samples on using the `dictionary lookup` endpoint refer to more samples [here][dictionarylookup_sample].

Please refer to the service documentation for a conceptual discussion of [dictionary lookup][dictionarylookup_doc].

### Dictionary Examples

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

    Response<IReadOnlyList<DictionaryExampleElement>> response = await client.DictionaryExamplesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
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

For samples on using the `dictionary examples` endpoint refer to more samples [here][dictionaryexamples_sample].

Please refer to the service documentation for a conceptual discussion of [dictionary examples][dictionaryexamples_doc].

## Troubleshooting

When you interact with the Translator Service using the .NET Text Translator SDK, errors returned by the Translator service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a translation request without a target translate language, a `400` error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
try
{
    var translation = client.TranslateAsync(Array.Empty<string>(), new[] { new InputText { Text = "This is a Test" } }).ConfigureAwait(false);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Message:
    Azure.RequestFailedException: Service request failed.
    Status: 400 (Bad Request)

Content:
    {"error":{"code":400036,"message":"The target language is not valid."}}

Headers:
    X-RequestId: REDACTED
    Access-Control-Expose-Headers: REDACTED
    X-Content-Type-Options: REDACTED
    Strict-Transport-Security: REDACTED
    Date: Mon, 27 Feb 2023 23:31:37 GMT
    Content-Type: text/plain; charset=utf-8
    Content-Length: 71
```

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Samples showing how to use this client library are available in this GitHub repository.
Samples are provided for each main functional area, and for each area, samples are provided in both sync and async mode.

* [Languages][languages_sample]
* [Translate][translate_sample]
* [Transliterate][transliterate_sample]
* [Break Sentence][breaksentence_sample]
* [Dictionary Lookup][dictionarylookup_sample]
* [Dictionary Examples][dictionaryexamples_sample]

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

[translator_client_class]: https://github.com/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/src/TextTranslationClient.cs

[translator_auth]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference#authentication
[translator_token]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference#authenticating-with-an-access-token
[translator_vnet]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference#virtual-network-support
[translator_limits]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/request-limits

[languages_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-languages
[translate_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-translate
[transliterate_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-transliterate
[breaksentence_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-break-sentence
[dictionarylookup_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-lookup
[dictionaryexamples_doc]: https://learn.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-examples

[languages_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample1_GetLanguages.md
[translate_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample2_Translate.md
[transliterate_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample3_Transliterate.md
[breaksentence_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample4_BreakSentence.md
[dictionarylookup_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample5_DictionaryLookup.md
[dictionaryexamples_sample]: https://github.com/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample6_DictionaryExamples.md

[service_access]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[create_text_resource_azure_portal]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[create_text_resource_azure_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/
