# Azure.AI.Language.Text client library for .NET

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

[Source code][textanalytics_client_src] | [Package (NuGet)][textanalytics_nuget_package] | [API reference documentation][textanalytics_refdocs] | [Product documentation][language_service_docs] | [Samples][textanalytics_samples]

## ## Getting started

### Install the package

Install the Azure Cognitive Language Services Text client library for .NET with [NuGet][nuget]:

```powershell
dotnet add package Azure.AI.Language.Text
```

### Prerequisites

* An [Azure subscription][azure_subscription]
* An existing Azure Language Service Resource

Though you can use this SDK to create and import conversation projects, [Language Studio][language_studio] is the preferred method for creating projects.

### Authenticate the client

In order to interact with the Analyze Text service, you'll need to create an instance of the [`AnalyzeTextClient`][analyzetextclient_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Cognitive Service resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Namespaces

Start by importing the namespace for the [`AnalyzeTextClient`][analyzetextclient_client_class] and related class:

```C# Snippet:AnalyzeTextClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Text;
```

#### Create a AnalyzeTextClient

Once you've determined your **endpoint** and **API key** you can instantiate a `AnalyzeTextClient`:

```C# Snippet:AnalyzeTextClient_Create
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new(TestEnvironment.ApiKey);

Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

#### Create a client using Azure Active Directory authentication

You can also create a `AnalyzeTextClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Conversation_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:ConversationAnalysisClient_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();

Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

## Key concepts

### ConversationAnalysisClient

The [`AnalyzeTextClient`][analyzetextclient_client_class] is the primary interface for developers using the Text Analytics client library.  It provides both synchronous and asynchronous operations to access a specific use of text analysis, such as language detection or key phrase extraction.

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples).

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[healthcare]: https://docs.microsoft.com/azure/cognitive-services/language-service/text-analytics-for-health/overview?tabs=ner
[language_detection]: https://docs.microsoft.com/azure/cognitive-services/language-service/language-detection/overview
[sentiment_analysis]: https://docs.microsoft.com/azure/cognitive-services/language-service/sentiment-opinion-mining/overview
[key_phrase_extraction]: https://docs.microsoft.com/azure/cognitive-services/language-service/key-phrase-extraction/overview
[named_entity_recognition]: https://docs.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/overview
[entity_linking]: https://docs.microsoft.com/azure/cognitive-services/language-service/entity-linking/overview
[named_entities_categories]: https://docs.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories
[pii_entity]:https://docs.microsoft.com/azure/cognitive-services/language-service/personally-identifiable-information/overview

[analyzetextclient_client_class]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/src/Generated/AnalyzeTextClient.cs

[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[data_limits]: https://aka.ms/azsdk/textanalytics/data-limits
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

[textanalytics_client_src]: https://github.com/quentinRobinson/azure-sdk-for-net/tree/qrobinson/analyze-text-sdk
[textanalytics_nuget_package]: https://www.nuget.org/packages/Azure.AI.Language.Text/
[textanalytics_refdocs]: https://learn.microsoft.com/en-us/dotnet/api/overview/azure/ai.textanalytics-readme?view=azure-dotnet
[language_service_docs]: https://docs.microsoft.com/azure/cognitive-services/language-service/
[textanalytics_samples]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/README.md
[dotnet_lro]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt

[azure_cli]: https://docs.microsoft.com/cli/azure/
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[azure_portal]: https://portal.azure.com/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[core_logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[custom_domain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[language_studio]: https://language.cognitive.azure.com/
[nuget]: https://www.nuget.org/

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/cognitivelanguage/Azure.AI.Language.Text/README.png)
