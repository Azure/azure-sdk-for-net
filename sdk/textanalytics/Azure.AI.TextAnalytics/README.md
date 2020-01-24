# Azure Cognitive Services Text Analytics client library for .NET
Azure Cognitive Services Text Analytics is a cloud service that provides advanced natural language processing over raw text, and includes six main functions: 
* Language Detection
* Sentiment Analysis
* Key Phrase Extraction
* Named Entity Recognition
* Recognition of Personally Identifiable Information 
* Linked Entity Recognition

[Source code][textanalytics_client_src] | [Package (NuGet)][textanalytics_nuget_package] | [API reference documentation][textanalytics_refdocs] | [Product documentation][textanalytics_docs] | [Samples][textanalytics_samples]

## Getting started

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing [Cognitive Services][cognitive_resource] or Text Analytics resource. If you need to create the resource, you can use the [Azure Portal][azure_portal] or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>`, `<your-resource-name>`, `<location>`, and `<sku>` with your values:

```PowerShell
az cognitiveservices account create --kind TextAnalytics --resource-group <your-resource-group-name> --name <your-resource-name> --location <location> --sku <sku>
```

### Install the package
Install the Azure Text Analytics client library for .NET with [NuGet][nuget].  To use the [.NET CLI](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli), run the following command from PowerShell in the directory that contains your project file:

```PowerShell
dotnet add package Azure.AI.TextAnalytics --version 1.0.0-preview.1
```

For other installation methods, please see the package information on [NuGet][nuget].

### Authenticate the client
In order to interact with the Text Analytics service, you'll need to create an instance of the TextAnalyticsClient class. You will need an **endpoint**, and either a **subscription key** or ``TokenCredential`` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get Subscription Key

Use the [Azure CLI][azure_cli] snippet below to get the subscription key from the Text Analytics resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

Alternatively, you can get the endpoint and subscription key from the resource information in the [Azure Portal][azure_portal].

#### Create TextAnalyticsClient with Subscription Key Credential
Once you have the value for the subscription key, create a `TextAnalyticsSubscriptionKeyCredential`. This will allow you to
update the subscription key by using the `UpdateCredential` method without creating a new client.

With the value of the endpoint and a `TextAnalyticsSubscriptionKeyCredential`, you can create the [TextAnalyticsClient][textanalytics_client_class]:

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
var credential = new TextAnalyticsSubscriptionKeyCredential(subscriptionKey);
var client = new TextAnalyticsClient(new Uri(endpoint), credential);
```

#### Create TextAnalyticsClient with Azure Active Directory Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.  

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Text Analytics by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateTextAnalyticsClientTokenCredential
string endpoint = "<endpoint>";
var client = new TextAnalyticsClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### TextAnalyticsClient
A `TextAnalyticsClient` is the primary interface for developers using the Text Analytics client library.  It provides both synchronous and asynchronous operations to access a specific use of Text Analytics, such as language detection or key phrase extraction. 

### Text Input
A **text input**, sometimes called a **document**, is a single unit of input to be analyzed by the predictive models in the Text Analytics service.  Operations on `TextAnalyticsClient` may take a single text input or a collection of inputs to be analyzed as a batch.

### Operation Result
An operation result, such as `AnalyzeSentimentResult`, is the result of a Text Analytics operation, containing a prediction or predictions about a single text input.  An operation's result type also may optionally include information about the input document and how it was processed.

### Operation Result Collection
 An operation result collection, such as `AnalyzeSentimentResultCollection`, is a collection of operation results, where each corresponds to one of the text inputs provided in the input batch.  A text input and its result will have the same index in the input and result collections.  An operation result collection may optionally include information about the input batch and how it was processed.

 ### Operation Overloads
 For each supported operation, `TextAnalyticsClient` provides method overloads to take a single text input, a batch of text inputs as strings, or a batch of either `TextDocumentInput` or `DetectLanguageInput` objects.  The overload taking the `TextDocumentInput` or `DetectLanguageInput` batch allows callers to give each document a unique ID, or indicate that the documents in the batch are written in different languages.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftextanalytics%2FAzure.AI.TextAnalytics%2FREADME.png)


<!-- LINKS -->
[textanalytics_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/src
[textanalytics_docs]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/
[textanalytics_refdocs]: https://aka.ms/azsdk-net-textanalytics-ref-docs
[textanalytics_nuget_package]: https://www.nuget.org/packages/Azure.AI.TextAnalytics
[textanalytics_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples
[textanalytics_rest_api]: https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0-Preview-1/operations/Languages
[cognitive_resource]: https://docs.microsoft.com/en-us/azure/cognitive-services/cognitive-services-apis-create-account

[language_detection]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-language-detection
[sentiment_analysis]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis
[key_phrase_extraction]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-keyword-extraction
[named_entity_recognition]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-entity-linking


[textanalytics_client_class]: src/TextAnalyticsClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/en-us/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: ../../identity/Azure.Identity/README.md

[detect_language_sample0]: tests/samples/Sample1_DetectLanguage.cs
[detect_language_sample1]: tests/samples/Sample1_DetectLanguageBatchConvenience.cs
[detect_language_sample2]: tests/samples/Sample1_DetectLanguageBatch.cs
[detect_language_sample_async]: tests/samples/Sample1_DetectLanguageAsync.cs
[analyze_sentiment_sample0]: tests/samples/Sample2_AnalyzeSentiment.cs
[analyze_sentiment_sample1]: tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs
[analyze_sentiment_sample2]: tests/samples/Sample2_AnalyzeSentimentBatch.cs
[extract_key_phrases_sample0]: tests/samples/Sample3_ExtractKeyPhrases.cs
[extract_key_phrases_sample1]: tests/samples/Sample3_ExtractKeyPhrasesBatchConvenience.cs
[extract_key_phrases_sample2]: tests/samples/Sample3_ExtractKeyPhrasesBatch.cs
[recognize_entities_sample0]: tests/samples/Sample4_RecognizeEntities.cs
[recognize_entities_sample1]: tests/samples/Sample4_RecognizeEntitiesBatchConvenience.cs
[recognize_entities_sample2]: tests/samples/Sample4_RecognizeEntitiesBatch.cs
[recognize_entities_sample_async]: tests/samples/Sample4_RecognizeEntitiesAsync.cs
[recognize_pii_entities_sample0]: tests/samples/Sample5_RecognizePiiEntities.cs
[recognize_pii_entities_sample1]: tests/samples/Sample5_RecognizePiiEntitiesBatch.cs
[recognize_pii_entities_sample2]: tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs
[recognize_linked_entities_sample0]: tests/samples/Sample6_RecognizeLinkedEntities.cs
[recognize_linked_entities_sample1]: tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs
[recognize_linked_entities_sample2]: tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenience.cs

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
