# Azure Cognitive Language Services Text client library for .NET

Text Analytics is part of the Azure Cognitive Service for Language, a cloud-based service that provides Natural Language Processing (NLP) features for understanding and analyzing text. This client library offers the following features:

* Language detection
* Sentiment analysis
* Key phrase extraction
* Named entity recognition (NER)
* Personally identifiable information (PII) entity recognition
* Entity linking
* Text analytics for health
* Custom named entity recognition (Custom NER)
* Custom text classification
* Extractive text summarization
* Abstractive text summarization

  [Source code][source_root] | [Package (NuGet)][package]| [API reference documentation][text_refdocs] | [Product documentation][text_docs] | [Samples][source_samples]

> [!NOTE]
> Text Authoring is not supported in version 2.0.0-beta.1. If you use Text Authoring, please continue to use version 1.1.0. You can find the [samples][textauthoring_samples] here.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Language.Text --prerelease
```

|SDK version  |Supported API version of service
|-------------|------------------------------------------------------------------------------------------------
|1.0.0-beta.3 | 2022-05-01, 2023-04-01, 2024-11-01, 2024-11-15-preview, 2025-05-15-preview (default)
|1.0.0-beta.2 | 2022-05-01, 2023-04-01, 2024-11-01, 2024-11-15-preview (default)
|1.0.0-beta.1 | 2022-05-01, 2023-04-01, 2023-11-15-preview (default)

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Language service resource.

### Authenticate the client

In order to interact with the Text service, you'll need to create an instance of the [`TextAnalysisClient`][textanalysisclient_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the `endpoint` and `API key` from the Cognitive Services resource or Language service resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Language service resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Migrating from Azure.Ai.TextAnalytics

Check the [migration guide][source_migration] for more information on migrating from Azure.AI.TextAnalytics to Azure.AI.Language.Text.

#### Create a TextAnalysisClient

To use the `TextAnalysisClient`, use the following namespace in addition to those above, if needed.

```C# Snippet:TextAnalysisClient_Namespace
using Azure.AI.Language.Text;
```

With your **endpoint** and **API key**, you can instantiate a `TextAnalysisClient`:

```C# Snippet:CreateTextClient
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
```

#### Create a client using Azure Active Directory authentication

You can also create a `TextAnalysisClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Text_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:TextAnalysisClient_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

If you do not select an api version we will default to the latest version available, which has the possibility of being a preview version.

## Key concepts

### TextAnalysisClient

The [`TextAnalysisClient`][textanalysisclient_class] is the primary interface for developers using the Azure AI Text client library.  It provides both synchronous and asynchronous operations to access a specific use of text analysis, such as language detection or key phrase extraction.

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples).

* [Detect Language](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample1_AnalyzeText_LanguageDetection.md)
* [Analyze Sentiment](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample2_AnalyzeText_Sentiment.md)
* [Extract Key Phrases](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample3_AnalyzeText_ExtractKeyPhrases.md)
* [Recognize Named Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample4_AnalyzeText_RecognizeEntities.md)
* [Recognize PII Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample5_AnalyzeText_RecognizePiiEntities.md)
* [Recognize Linked Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample6_AnalyzeText_RecognizeLinkedEntities.md)
* [Analyze Healthcare Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample7_AnalyzeTextOperation_HealthcareOperationAction.md)
* [Custom Named Entity Recognition](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample8_AnalyzeTextOperation_CustomEntitiesOperationAction.md)
* [Custom Single Label Classification](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample9_AnalyzeTextOperation_CustomSingleLabelClassificationOperationAction.md)
* [Custom Multi Label Classification](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample10_AnalyzeTextOperation_CustomMultiLabelClassificationOperationAction.md)
* [Extractive Summarization](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample11_AnalyzeTextOperation_ExtractiveSummarizationOperationAction.md)
* [Abstractive Summarization](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample12_AnalyzeTextOperation_AbstractiveSummarizationOperationAction.md)
* [Perform multiple text analysis actions](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/Sample13_AnalyzeTextOperation_MultipleActions.md)

## Troubleshooting

### General

When you interact with the Cognitive Language Services Text client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a utterance to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:TextAnalysisClient_BadRequest
try
{
    string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

    AnalyzeTextInput body = new TextEntityRecognitionInput()
    {
        TextInput = new MultiLanguageTextInput()
        {
            MultiLanguageInputs =
            {
                new MultiLanguageInput("D", textA),
            }
        },
        ActionContent = new EntitiesActionContent()
        {
            ModelVersion = "NotValid", // Invalid model version will is a bad request.
        }
    };

    Response<AnalyzeTextResult> response = client.AnalyzeText(body);
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Azure.RequestFailedException: The input parameter is invalid.
Status: 400 (Bad Request)
ErrorCode: InvalidArgument

Content:
Azure.RequestFailedException: Invalid Request.
Status: 400 (Bad Request)
ErrorCode: InvalidRequest

Content:
{"error":{"code":"InvalidRequest","message":"Invalid Request.","innererror":{"code":"ModelVersionIncorrect","message":"Invalid model version. Possible values are: latest,2021-06-01,2023-09-01,2024-05-01. For additional details see https://aka.ms/text-analytics-model-versioning"}}}

Headers:
Transfer-Encoding: chunked
x-envoy-upstream-service-time: REDACTED
apim-request-id: REDACTED
Strict-Transport-Security: REDACTED
X-Content-Type-Options: REDACTED
x-ms-region: REDACTED
Date: Wed, 24 Jul 2024 13:39:00 GMT
Content-Type: application/json; charset=utf-8
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

* View our [samples][source_samples].
* Read about the different [features][text_docs] of the Text service.

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
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[custom_domain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[source_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples
[source_migration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/MigrationGuide.md
[source_root]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/src
[package]: https://www.nuget.org/packages/
[text_refdocs]: https://learn.microsoft.com/dotnet/
[text_docs]: https://learn.microsoft.com/azure/cognitive-services/text-analytics/
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[textanalysisclient_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/src/TextAnalysisClient.cs
[cognitive_auth]: https://learn.microsoft.com/azure/cognitive-services/authentication/
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_portal]: https://portal.azure.com
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[textauthoring_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/README.md
