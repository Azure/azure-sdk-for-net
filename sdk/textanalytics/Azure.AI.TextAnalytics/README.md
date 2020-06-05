# Azure Cognitive Services Text Analytics client library for .NET
Azure Cognitive Services Text Analytics is a cloud service that provides advanced natural language processing over raw text, and includes the following main functions: 
* Language Detection
* Sentiment Analysis
* Key Phrase Extraction
* Named Entity Recognition
* Linked Entity Recognition

[Source code][textanalytics_client_src] | [Package (NuGet)][textanalytics_nuget_package] | [API reference documentation][textanalytics_refdocs] | [Product documentation][textanalytics_docs] | [Samples][textanalytics_samples]

## Getting started

### Install the package
Install the Azure Text Analytics client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.TextAnalytics
```
**Note:** This package version targets Azure Text Analytics service API version v3.0.

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Text Analytics resource.

#### Create a Cognitive Services or Text Analytics resource
Text Analytics supports both [multi-service and single-service access][cognitive_resource_portal]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint/key. For Text Analytics access only, create a Text Analytics resource.

You can create either resource using: 

**Option 1:** [Azure Portal][cognitive_resource_portal].

**Option 2:** [Azure CLI][cognitive_resource_cli]. 

Below is an example of how you can create a Text Analytics resource using the CLI:

```PowerShell
# Create a new resource group to hold the Text Analytics resource -
# if using an existing resource group, skip this step
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create Text Analytics
az cognitiveservices account create \
    --name <your-resource-name> \
    --resource-group <your-resource-group-name> \
    --kind TextAnalytics \
    --sku <sku> \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate the client
In order to interact with the Text Analytics service, you'll need to create an instance of the [TextAnalyticsClient][textanalytics_client_class] class. You will need an **endpoint**, and either an **API key** or ``TokenCredential`` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get API Key
You can get the `endpoint` and `API key` from the Cognitive Services resource or Text Analytics resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Text Analytics resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create TextAnalyticsClient with API Key Credential
Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint and an `AzureKeyCredential`, you can create the [TextAnalyticsClient][textanalytics_client_class]:

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new TextAnalyticsClient(new Uri(endpoint), credential);
```

#### Create TextAnalyticsClient with Azure Active Directory Credential

Client API key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.  

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

### Input
A **document**, is a single unit of input to be analyzed by the predictive models in the Text Analytics service.  Operations on `TextAnalyticsClient` may take a single document or a collection of documents to be analyzed as a batch.
For document length limits, maximum batch size, and supported text encoding see [here][data_limits].

### Operation on multiple documents
For each supported operation, `TextAnalyticsClient` provides a method that accepts a batch of documents as strings, or a batch of either `TextDocumentInput` or `DetectLanguageInput` objects. This methods allow callers to give each document a unique ID, indicate that the documents in the batch are written in different languages, or provide a country hint about the language of the document.

**Note:** It is recommended to use the batch methods when working on production environments as they allow you to send one request with multiple documents. This is more performant than sending a request per each document.

### Return value
Return values, such as `AnalyzeSentimentResult`, is the result of a Text Analytics operation, containing a prediction or predictions about a single document.  An operation's return value also may optionally include information about the document and how it was processed.

### Return value Collection
A Return value collection, such as `AnalyzeSentimentResultCollection`, is a collection of operation results, where each corresponds to one of the documents provided in the input batch.  A document and its result will have the same index in the input and result collections. The return value also contains a `HasError` property that allows to identify if an operation executed was succesful or unsuccesful for the given document. It may optionally include information about the document batch and how it was processed.

## Examples
The following section provides several code snippets using the `client` [created above](#create-textanalyticsclient-with-azure-active-directory-credential), and covers the main functions of Text Analytics.

### Sync examples
* [Detect Language](#detect-language)
* [Analyze Sentiment](#analyze-sentiment)
* [Extract Key Phrases](#extract-key-phrases)
* [Recognize Entities](#recognize-entities)
* [Recognize Linked Entities](#recognize-linked-entities)

### Async examples
* [Detect Language Asynchronously](#detect-language-asynchronously)
* [Recognize Entities Asyncronously](#recognize-entities-asynchronously)

### Detect Language
Run a Text Analytics predictive model to determine the language that the passed-in document or batch of documents are written in.

```C# Snippet:DetectLanguage
string document = "Este documento está en español.";

DetectedLanguage language = client.DetectLanguage(document);

Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
```
For samples on using the production recommended option `DetectLanguageBatch` see [here][detect_language_sample].

Please refer to the service documentation for a conceptual discussion of [language detection][language_detection].

### Analyze Sentiment
Run a Text Analytics predictive model to identify the positive, negative, neutral or mixed sentiment contained in the passed-in document or batch of documents.

```C# Snippet:AnalyzeSentiment
string document = "That was the best day of my life!";

DocumentSentiment docSentiment = client.AnalyzeSentiment(document);

Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with confidence scores: ");
Console.WriteLine($"    Positive confidence score: {docSentiment.ConfidenceScores.Positive}.");
Console.WriteLine($"    Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}.");
Console.WriteLine($"    Negative confidence score: {docSentiment.ConfidenceScores.Negative}.");
```
For samples on using the production recommended option `AnalyzeSentimentBatch` see [here][analyze_sentiment_sample].

Please refer to the service documentation for a conceptual discussion of [sentiment analysis][sentiment_analysis].

### Extract Key Phrases
Run a model to identify a collection of significant phrases found in the passed-in document or batch of documents.

```C# Snippet:ExtractKeyPhrases
string document = "My cat might need to see a veterinarian.";

KeyPhraseCollection keyPhrases = client.ExtractKeyPhrases(document);

Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
foreach (string keyPhrase in keyPhrases)
{
    Console.WriteLine(keyPhrase);
}
```
For samples on using the production recommended option `ExtractKeyPhrasesBatch` see [here][extract_key_phrases_sample].

Please refer to the service documentation for a conceptual discussion of [key phrase extraction][key_phrase_extraction].

### Recognize Entities
Run a predictive model to identify a collection of named entities in the passed-in document or batch of documents and categorize those entities into categories such as person, location, or organization.  For more information on available categories, see [Text Analytics Named Entity Categories][named_entities_categories].

```C# Snippet:RecognizeEntities
string document = "Microsoft was founded by Bill Gates and Paul Allen.";

CategorizedEntityCollection entities = client.RecognizeEntities(document);

Console.WriteLine($"Recognized {entities.Count} entities:");
foreach (CategorizedEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
}
```
For samples on using the production recommended option `RecognizeEntitiesBatch` see [here][recognize_entities_sample].

Please refer to the service documentation for a conceptual discussion of [named entity recognition][named_entity_recognition].

### Recognize Linked Entities
Run a predictive model to identify a collection of entities found in the passed-in document or batch of documents, and include information linking the entities to their corresponding entries in a well-known knowledge base.

```C# Snippet:RecognizeLinkedEntities
string document = "Microsoft was founded by Bill Gates and Paul Allen.";

LinkedEntityCollection linkedEntities = client.RecognizeLinkedEntities(document);

Console.WriteLine($"Extracted {linkedEntities.Count} linked entit{(linkedEntities.Count > 1 ? "ies" : "y")}:");
foreach (LinkedEntity linkedEntity in linkedEntities)
{
    Console.WriteLine($"Name: {linkedEntity.Name}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
    foreach (LinkedEntityMatch match in linkedEntity.Matches)
    {
        Console.WriteLine($"    Match Text: {match.Text}, Confidence score: {match.ConfidenceScore}");
    }
}
```
For samples on using the production recommended option `RecognizeLinkedEntitiesBatch` see [here][recognize_linked_entities_sample].

Please refer to the service documentation for a conceptual discussion of [entity linking][named_entity_recognition].

### Detect Language Asynchronously
Run a Text Analytics predictive model to determine the language that the passed-in document or batch of documents are written in.

```C# Snippet:DetectLanguageAsync
string document = "Este documento está en español.";

DetectedLanguage language = await client.DetectLanguageAsync(document);

Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
```

### Recognize Entities Asynchronously
Run a predictive model to identify a collection of named entities in the passed-in document or batch of documents and categorize those entities into categories such as person, location, or organization.  For more information on available categories, see [Text Analytics Named Entity Categories][named_entities_categories].

```C# Snippet:RecognizeEntitiesAsync
string document = "Microsoft was founded by Bill Gates and Paul Allen.";

CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document);

Console.WriteLine($"Recognized {entities.Count} entities:");
foreach (CategorizedEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
}
```

## Troubleshooting

### General
When you interact with the Cognitive Services Text Analytics client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][textanalytics_rest_api] requests.

For example, if you submit a batch of text document inputs containing duplicate document ids, a `400` error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
try
{
    DetectedLanguage result = client.DetectLanguage(document);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```
Message:
    Azure.RequestFailedException:
    Status: 400 (Bad Request)

Content:
    {"error":{"code":"InvalidRequest","innerError":{"code":"InvalidDocument","message":"Request contains duplicated Ids. Make sure each document has a unique Id."},"message":"Invalid document in request."}}

Headers:
    Transfer-Encoding: chunked
    x-aml-ta-request-id: 146ca04a-af54-43d4-9872-01a004bee5f8
    X-Content-Type-Options: nosniff
    x-envoy-upstream-service-time: 6
    apim-request-id: c650acda-2b59-4ff7-b96a-e316442ea01b
    Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
    Date: Wed, 18 Dec 2019 16:24:52 GMT
    Content-Type: application/json; charset=utf-8
```

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Samples showing how to use the Cognitive Services Text Analytics library are available in this GitHub repository.
Samples are provided for each main functional area, and for each area, samples are provided for analyzing a single document, and a collection of documents in both sync and async mode.

- [Detect Language][detect_language_sample]
- [Analyze Sentiment][analyze_sentiment_sample]
- [Extract Key Phrases][extract_key_phrases_sample]
- [Recognize Entities][recognize_entities_sample]
- [Recognize Linked Entities][recognize_linked_entities_sample]
- [Create a mock client][mock_client_sample] for testing using the [Moq][moq] library.

## Contributing
See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftextanalytics%2FAzure.AI.TextAnalytics%2FREADME.png)


<!-- LINKS -->
[textanalytics_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/src
[textanalytics_docs]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/
[textanalytics_refdocs]: https://aka.ms/azsdk-net-textanalytics-ref-docs
[textanalytics_nuget_package]: https://www.nuget.org/packages/Azure.AI.TextAnalytics
[textanalytics_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/README.md
[textanalytics_rest_api]: https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages
[cognitive_resource_portal]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli

[language_detection]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-language-detection
[sentiment_analysis]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis
[key_phrase_extraction]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-keyword-extraction
[named_entity_recognition]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-entity-linking
[named_entities_categories]: https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types

[textanalytics_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/src/TextAnalyticsClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md
[data_limits]: https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md

[detect_language_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample1_DetectLanguage.md
[analyze_sentiment_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample2_AnalyzeSentiment.md
[extract_key_phrases_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample3_ExtractKeyPhrases.md
[recognize_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample4_RecognizeEntities.md
[recognize_linked_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample6_RecognizeLinkedEntities.md
[mock_client_sample]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_MockClient.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
