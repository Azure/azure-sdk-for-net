# Azure Text Translation client library for .NET

Azure text translation is a cloud-based REST API provided by the Azure Translator service. It utilizes neural machine translation technology to deliver precise, contextually relevant, and semantically accurate real-time text translations across all supported languages.

Use the Text Translation client library for .NET to:

- Retrieve the list of languages supported for translation and transliteration operations, as well as LLM models available for translations.

- Perform deterministic text translation from a specified source language to a target language, with configurable parameters to ensure precision and maintain contextual integrity.

- Execute transliteration by converting text from the original script to an alternative script representation.

- Use LLM models to produce translation output variants that are tone-specific and gender-aware.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/src) | [API reference documentation](https://learn.microsoft.com/azure/ai-services/translator/text-translation/preview/rest-api-guide) | [Product documentation](https://learn.microsoft.com/azure/cognitive-services/translator/)

## Getting started

### Install the package

Install the Azure Text Translation client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Translation.Text --prerelease
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version  |Supported API version of service
|-------------|-----------------------------------------------------|
|1.0.0-beta.1 | 3.0
|1.0.0 | 3.0
|2.0.0-beta.1 | 2025-10-01-preview

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Translator service or Cognitive Services resource. You can create Translator resource following [Create a Translator resource][translator_resource_create].

### Authenticate the client

Interaction with the service using the client library begins with creating an instance of the [TextTranslationClient][translator_client_class] class. You will need an **API key** or ``TokenCredential`` to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Translator Service][translator_auth].

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
string endpoint = "<Text Translator Resource Endpoint>";
string apiKey = "<Text Translator Resource API Key>";
string region = "<Text Translator Azure Region>";
TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
```

#### Create `TextTranslationClient` with Microsoft Entra ID

Client API key authentication is used in most of the examples, but you can also authenticate with Microsoft Entra ID using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.  Use this value for the `endpoint` variable for `Text Translator Custom Endpoint`.

You will also need to [register a new Microsoft Entra application][register_aad_app] and [grant access][aad_grant_access] to your Translator resource by assigning the `"Cognitive Services User"` role to your service principal.  Additional information about Microsoft Entra authentication is available [here][custom_details].

Set the values of the `client ID`, `tenant ID`, and `client secret` of the Microsoft Entra application as environment variables: `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_CLIENT_SECRET`.  The `DefaultAzureCredential` constructor uses these variables to create your credentials.

```C# Snippet:CreateTextTranslationClientWithAad
string endpoint = "<Text Translator Custom Endpoint>";
DefaultAzureCredential credential = new DefaultAzureCredential();
TextTranslationClient client = new TextTranslationClient(credential, new Uri(endpoint));
```

## Key concepts

### `TextTranslationClient`

A `TextTranslationClient` is the primary interface for developers using the Text Translation client library.  It provides both synchronous and asynchronous operations to access a specific use of text translator, such as get supported languages detection or text translation.

### Input

A **TranslateInputItem** is a single unit of input to be processed by the translation models in the Translator service. Each `TranslateInputItem` defines both the input string to translate and the output specifications for the translation. Operations on `TextTranslationClient` may take a single `TranslateInputItem` or a collection of `TranslateInputItem` objects.
For text element length limits, maximum requests size, and supported text encoding see [here][translator_limits].

### Return value

Return values, such as `Response<IReadOnlyList<TranslatedTextItem>>`, is the result of a Text Translation operation. It contains an array with one `TranslatedTextItem` for each input `TranslateInputItem`. An operation's return value also may optionally include information about the input text element (for example detected language).

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets using the `client` [created above](#create-a-texttranslationclient-using-an-api-key-and-region-credential), and covers the main features present in this client library. Although the snippets below make use of synchronous service calls, keep in mind that the `Azure.AI.Translation.Text` package supports both synchronous and asynchronous APIs.

### Get Supported Languages

Gets the set of languages currently supported by other operations of the Translator.

```C# Snippet:GetTextTranslationLanguages
try
{
    Response<GetSupportedLanguagesResult> response = client.GetSupportedLanguages(cancellationToken: CancellationToken.None);
    GetSupportedLanguagesResult languages = response.Value;

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

The simplest use of the Translate method is to invoke it with a single target language and one input string.

```C# Snippet:GetTextTranslation
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

For samples on using the `translate` endpoint refer to more samples [here][translate_sample].

Please refer to the service documentation for a conceptual discussion of [translate][translate_doc].

### Transliterate

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

For samples on using the `transliterate` endpoint refer to more samples [here][transliterate_sample].

Please refer to the service documentation for a conceptual discussion of [transliterate][transliterate_doc].

## Troubleshooting

When you interact with the Translator Service using the Text Translation client library, errors returned by the Translator service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a translation request without a target translate language, a `400` error is returned, indicating "Bad Request".

```C# Snippet:HandleBadRequest
try
{
    var translation = client.Translate("", "This is a Test");
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

```C# Snippet:CreateLoggingMonitor
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Samples showing how to use this client library are available in this GitHub repository.
Samples are provided for each main functional area, and for each area, samples are provided in both sync and async mode.

* [Create TextTranslationClient][client_sample]
* [Languages][languages_sample]
* [Translate][translate_sample]
* [Transliterate][transliterate_sample]

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

[translator_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Text/src/Custom/TextTranslationClient.cs

[translator_auth]: https://learn.microsoft.com/azure/ai-services/translator/text-translation/reference/authentication
[translator_limits]: https://learn.microsoft.com/azure/cognitive-services/translator/request-limits

[languages_doc]: https://learn.microsoft.com/azure/ai-services/translator/text-translation/preview/get-languages
[translate_doc]: https://learn.microsoft.com/azure/ai-services/translator/text-translation/preview/translate-api
[transliterate_doc]: https://learn.microsoft.com/azure/ai-services/translator/text-translation/preview/transliterate-api

[client_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample0_CreateClient.md
[languages_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample1_GetLanguages.md
[translate_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample2_Translate.md
[transliterate_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Text/samples/Sample3_Transliterate.md

[translator_resource_create]: https://learn.microsoft.com/azure/cognitive-services/Translator/create-translator-resource
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[register_aad_app]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[custom_details]: https://learn.microsoft.com/azure/ai-services/translator/text-translation/reference/authentication#authentication-with-microsoft-entra-id
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md

[azure_cli]: https://learn.microsoft.com/cli/azure/
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
