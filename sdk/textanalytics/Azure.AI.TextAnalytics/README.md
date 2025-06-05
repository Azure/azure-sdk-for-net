# Azure Cognitive Services Text Analytics client library for .NET

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

## Getting started

### Install the package

Install the Azure Text Analytics client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.TextAnalytics
```

This table shows the relationship between SDK versions and supported API versions of the service:

> Note that `5.2.0` is the first stable version of the client library that targets the Azure Cognitive Service for Language APIs which includes the existing text analysis and natural language processing features found in the Text Analytics client library. In addition, the service API has changed from semantic to date-based versioning.

|SDK version  |Supported API version of service
|-------------|-----------------------------------------------------|
|5.3.X        | 3.0, 3.1, 2022-05-01, 2023-04-01 (default)
|5.2.X        | 3.0, 3.1, 2022-05-01 (default)
|5.1.X        | 3.0, 3.1 (default)
|5.0.X        | 3.0
|1.0.X        | 3.0

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Language service resource.

#### Create a Cognitive Services resource or a Language service resource

Azure Cognitive Service for Language supports both [multi-service and single-service access][service_access]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint and API key. To access the features of the Language service only, create a Language service resource instead.

You can create either resource via the [Azure portal][create_ta_resource_azure_portal] or, alternatively, you can follow the steps in [this document][create_ta_resource_azure_cli] to create it using the [Azure CLI][azure_cli].

### Authenticate the client

Interaction with the service using the client library begins with creating an instance of the [TextAnalyticsClient][textanalytics_client_class] class. You will need an **endpoint**, and either an **API key** or ``TokenCredential`` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the `endpoint` and `API key` from the Cognitive Services resource or Language service resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Language service resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create a `TextAnalyticsClient` using an API key credential

Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint and an `AzureKeyCredential`, you can create the [TextAnalyticsClient][textanalytics_client_class]:

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

#### Create a `TextAnalyticsClient` with an Azure Active Directory credential

Client API key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to the Language service by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateTextAnalyticsClientTokenCredential
Uri endpoint = new("<endpoint>");
TextAnalyticsClient client = new(endpoint, new DefaultAzureCredential());
```

## Key concepts

### `TextAnalyticsClient`

A `TextAnalyticsClient` is the primary interface for developers using the Text Analytics client library.  It provides both synchronous and asynchronous operations to access a specific use of text analysis, such as language detection or key phrase extraction.

### Input

A **document**, is a single unit of input to be analyzed by the predictive models in the Language service. Operations on `TextAnalyticsClient` may take a single document or a collection of documents to be analyzed as a batch.
For document length limits, maximum batch size, and supported text encoding see [here][data_limits].

### Operation on multiple documents

For each supported operation, `TextAnalyticsClient` provides a method that accepts a batch of documents as strings, or a batch of either `TextDocumentInput` or `DetectLanguageInput` objects. This methods allow callers to give each document a unique ID, indicate that the documents in the batch are written in different languages, or provide a country hint about the language of the document.

**Note:** It is recommended to use the batch methods when working on production environments as they allow you to send one request with multiple documents. This is more performant than sending a request per each document.

### Return value

Return values, such as `AnalyzeSentimentResult`, is the result of a Text Analytics operation, containing a prediction or predictions about a single document.  An operation's return value also may optionally include information about the document and how it was processed.

### Return value Collection

A Return value collection, such as `AnalyzeSentimentResultCollection`, is a collection of operation results, where each corresponds to one of the documents provided in the input batch.  A document and its result will have the same index in the input and result collections. The return value also contains a `HasError` property that allows to identify if an operation executed was successful or unsuccessful for the given document. It may optionally include information about the document batch and how it was processed.

### Long-Running Operations

For large documents which take a long time to execute, these operations are implemented as [**long-running operations**][dotnet_lro]. Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>` or a `PageableOperation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#run-multiple-actions-asynchronously).

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets using the `client` [created above](#create-a-textanalyticsclient-using-an-api-key-credential), and covers the main features present in this client library. Although most of the snippets below make use of synchronous service calls, keep in mind that the `Azure.AI.TextAnalytics` package supports both synchronous and asynchronous APIs.

### Sync examples

* [Detect Language](#detect-language)
* [Analyze Sentiment](#analyze-sentiment)
* [Extract Key Phrases](#extract-key-phrases)
* [Recognize Named Entities](#recognize-named-entities)
* [Recognize PII Entities](#recognize-pii-entities)
* [Recognize Linked Entities](#recognize-linked-entities)

### Async examples

* [Detect Language Asynchronously](#detect-language-asynchronously)
* [Recognize Named Entities Asynchronously](#recognize-named-entities-asynchronously)
* [Analyze Healthcare Entities Asynchronously](#analyze-healthcare-entities-asynchronously)
* [Run multiple actions Asynchronously](#run-multiple-actions-asynchronously)

### Detect Language

Run a predictive model to determine the language that the passed-in document or batch of documents are written in.

```C# Snippet:Sample1_DetectLanguage
string document =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de Detección de Lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para los sistemas de contenido que recopilan texto arbitrario, donde el lenguaje no se conoce"
    + " de antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

try
{
    Response<DetectedLanguage> response = client.DetectLanguage(document);
    DetectedLanguage language = response.Value;

    Console.WriteLine($"Detected language is {language.Name} with a confidence score of {language.ConfidenceScore}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `DetectLanguageBatch` see [here][detect_language_sample].

Please refer to the service documentation for a conceptual discussion of [language detection][language_detection].

### Analyze Sentiment

Run a predictive model to determine the positive, negative, neutral or mixed sentiment contained in the passed-in document or batch of documents.

```C# Snippet:Sample2_AnalyzeSentiment
string document =
    "I had the best day of my life. I decided to go sky-diving and it made me appreciate my whole life so"
    + "much more. I developed a deep-connection with my instructor as well, and I feel as if I've made a"
    + "life-long friend in her.";

try
{
    Response<DocumentSentiment> response = client.AnalyzeSentiment(document);
    DocumentSentiment docSentiment = response.Value;

    Console.WriteLine($"Document sentiment is {docSentiment.Sentiment} with: ");
    Console.WriteLine($"  Positive confidence score: {docSentiment.ConfidenceScores.Positive}");
    Console.WriteLine($"  Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}");
    Console.WriteLine($"  Negative confidence score: {docSentiment.ConfidenceScores.Negative}");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `AnalyzeSentimentBatch` see [here][analyze_sentiment_sample].

To get more granular information about the opinions related to targets of a product/service, also known as Aspect-based Sentiment Analysis in Natural Language Processing (NLP), see a sample on sentiment analysis with opinion mining [here][analyze_sentiment_opinion_mining_sample].

Please refer to the service documentation for a conceptual discussion of [sentiment analysis][sentiment_analysis].

### Extract Key Phrases

Run a model to identify a collection of significant phrases found in the passed-in document or batch of documents.

```C# Snippet:Sample3_ExtractKeyPhrases
string document =
    "My cat might need to see a veterinarian. It has been sneezing more than normal, and although my"
    + " little sister thinks it is funny, I am worried it has the cold that I got last week. We are going"
    + " to call tomorrow and try to schedule an appointment for this week. Hopefully it will be covered by"
    + " the cat's insurance. It might be good to not let it sleep in my room for a while.";

try
{
    Response<KeyPhraseCollection> response = client.ExtractKeyPhrases(document);
    KeyPhraseCollection keyPhrases = response.Value;

    Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
    foreach (string keyPhrase in keyPhrases)
    {
        Console.WriteLine($"  {keyPhrase}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `ExtractKeyPhrasesBatch` see [here][extract_key_phrases_sample].

Please refer to the service documentation for a conceptual discussion of [key phrase extraction][key_phrase_extraction].

### Recognize Named Entities

Run a predictive model to identify a collection of named entities in the passed-in document or batch of documents and categorize those entities into categories such as person, location, or organization.  For more information on available categories, see [Text Analytics Named Entity Categories][named_entities_categories].

```C# Snippet:Sample4_RecognizeEntities
string document =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

try
{
    Response<CategorizedEntityCollection> response = client.RecognizeEntities(document);
    CategorizedEntityCollection entitiesInDocument = response.Value;

    Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
    foreach (CategorizedEntity entity in entitiesInDocument)
    {
        Console.WriteLine($"  Text: {entity.Text}");
        Console.WriteLine($"  Offset: {entity.Offset}");
        Console.WriteLine($"  Length: {entity.Length}");
        Console.WriteLine($"  Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
        Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `RecognizeEntitiesBatch` see [here][recognize_entities_sample].

Please refer to the service documentation for a conceptual discussion of [named entity recognition][named_entity_recognition].

### Recognize PII Entities

Run a predictive model to identify a collection of entities containing Personally Identifiable Information found in the passed-in document or batch of documents, and categorize those entities into categories such as US social security number, drivers license number, or credit card number.

```C# Snippet:Sample5_RecognizePiiEntities
string document =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

try
{
    Response<PiiEntityCollection> response = client.RecognizePiiEntities(document);
    PiiEntityCollection entities = response.Value;

    Console.WriteLine($"Redacted Text: {entities.RedactedText}");
    Console.WriteLine();
    Console.WriteLine($"Recognized {entities.Count} PII entities:");
    foreach (PiiEntity entity in entities)
    {
        Console.WriteLine($"  Text: {entity.Text}");
        Console.WriteLine($"  Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
        Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `RecognizePiiEntitiesBatch` see [here][recognize_pii_entities_sample].

Please refer to the service documentation for supported [PII entity types][pii_entity].

### Recognize Linked Entities

Run a predictive model to identify a collection of entities found in the passed-in document or batch of documents, and include information linking the entities to their corresponding entries in a well-known knowledge base.

```C# Snippet:Sample6_RecognizeLinkedEntities
string document =
    "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
    + " Ballmer, eventually became CEO after Bill Gates as well. Steve Ballmer eventually stepped down as"
    + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
    + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond.";

try
{
    Response<LinkedEntityCollection> response = client.RecognizeLinkedEntities(document);
    LinkedEntityCollection linkedEntities = response.Value;

    Console.WriteLine($"Recognized {linkedEntities.Count} entities:");
    foreach (LinkedEntity linkedEntity in linkedEntities)
    {
        Console.WriteLine($"  Name: {linkedEntity.Name}");
        Console.WriteLine($"  Language: {linkedEntity.Language}");
        Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
        Console.WriteLine($"  URL: {linkedEntity.Url}");
        Console.WriteLine($"  Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
        foreach (LinkedEntityMatch match in linkedEntity.Matches)
        {
            Console.WriteLine($"    Match Text: {match.Text}");
            Console.WriteLine($"    Offset: {match.Offset}");
            Console.WriteLine($"    Length: {match.Length}");
            Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
        }
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

For samples on using the production recommended option `RecognizeLinkedEntitiesBatch` see [here][recognize_linked_entities_sample].

Please refer to the service documentation for a conceptual discussion of [entity linking][entity_linking].

### Detect Language Asynchronously

Run a predictive model to determine the language that the passed-in document or batch of documents are written in.

```C# Snippet:Sample1_DetectLanguageAsync
string document =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de Detección de Lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para los sistemas de contenido que recopilan texto arbitrario, donde el lenguaje no se conoce"
    + " de antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

try
{
    Response<DetectedLanguage> response = await client.DetectLanguageAsync(document);
    DetectedLanguage language = response.Value;

    Console.WriteLine($"Detected language is {language.Name} with a confidence score of {language.ConfidenceScore}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Recognize Named Entities Asynchronously

Run a predictive model to identify a collection of named entities in the passed-in document or batch of documents and categorize those entities into categories such as person, location, or organization.  For more information on available categories, see [Text Analytics Named Entity Categories][named_entities_categories].

```C# Snippet:Sample4_RecognizeEntitiesAsync
string document =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

try
{
    Response<CategorizedEntityCollection> response = await client.RecognizeEntitiesAsync(document);
    CategorizedEntityCollection entitiesInDocument = response.Value;

    Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
    foreach (CategorizedEntity entity in entitiesInDocument)
    {
        Console.WriteLine($"  Text: {entity.Text}");
        Console.WriteLine($"  Offset: {entity.Offset}");
        Console.WriteLine($"  Length: {entity.Length}");
        Console.WriteLine($"  Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
        Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Analyze Healthcare Entities Asynchronously

Text Analytics for health is a containerized service that extracts and labels relevant medical information from unstructured texts such as doctor's notes, discharge summaries, clinical documents, and electronic health records. For more information see [How to: Use Text Analytics for health][healthcare].

```C# Snippet:Sample7_AnalyzeHealthcareEntitiesConvenienceAsync_All
string documentA =
    "RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM |"
    + " CORONARY ARTERY DISEASE | Signed | DIS |"
    + Environment.NewLine
    + " Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001"
    + " ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE."
    + Environment.NewLine
    + " HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive"
    + " angina over the past several months. The patient had a cardiac catheterization in July of this"
    + " year revealing total occlusion of the RCA and 50% left main disease, with a strong family history"
    + " of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and"
    + " another brother who is status post coronary artery bypass grafting. The patient had a stress"
    + " echocardiogram done on July, 2001, which showed no wall motion abnormalities, but this was a"
    + " difficult study due to body habitus. The patient went for six minutes with minimal ST depressions"
    + " in the anterior lateral leads, thought due to fatigue and wrist pain, his anginal equivalent. Due"
    + " to the patient'sincreased symptoms and family history and history left main disease with total"
    + " occasional of his RCA was referred for revascularization with open heart surgery.";

string documentB = "Prescribed 100mg ibuprofen, taken twice daily.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB
};

// Perform the text analysis operation.
AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, batchedDocuments);

Console.WriteLine($"The operation has completed.");
Console.WriteLine();

// View the operation status.
Console.WriteLine($"Created On   : {operation.CreatedOn}");
Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
Console.WriteLine($"Id           : {operation.Id}");
Console.WriteLine($"Status       : {operation.Status}");
Console.WriteLine($"Last Modified: {operation.LastModified}");
Console.WriteLine();

// View the operation results.
await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in operation.Value)
{
    Console.WriteLine($"Analyze Healthcare Entities, model version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine();

    foreach (AnalyzeHealthcareEntitiesResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Recognized the following {documentResult.Entities.Count} healthcare entities:");
        Console.WriteLine();

        // View the healthcare entities that were recognized.
        foreach (HealthcareEntity entity in documentResult.Entities)
        {
            Console.WriteLine($"  Entity: {entity.Text}");
            Console.WriteLine($"  Category: {entity.Category}");
            Console.WriteLine($"  Offset: {entity.Offset}");
            Console.WriteLine($"  Length: {entity.Length}");
            Console.WriteLine($"  NormalizedText: {entity.NormalizedText}");
            Console.WriteLine($"  Links:");

            // View the entity data sources.
            foreach (EntityDataSource entityDataSource in entity.DataSources)
            {
                Console.WriteLine($"    Entity ID in Data Source: {entityDataSource.EntityId}");
                Console.WriteLine($"    DataSource: {entityDataSource.Name}");
            }

            // View the entity assertions.
            if (entity.Assertion is not null)
            {
                Console.WriteLine($"  Assertions:");

                if (entity.Assertion?.Association is not null)
                {
                    Console.WriteLine($"    Association: {entity.Assertion?.Association}");
                }

                if (entity.Assertion?.Certainty is not null)
                {
                    Console.WriteLine($"    Certainty: {entity.Assertion?.Certainty}");
                }

                if (entity.Assertion?.Conditionality is not null)
                {
                    Console.WriteLine($"    Conditionality: {entity.Assertion?.Conditionality}");
                }
            }
        }

        Console.WriteLine($"  We found {documentResult.EntityRelations.Count} relations in the current document:");
        Console.WriteLine();

        // View the healthcare entity relations that were recognized.
        foreach (HealthcareEntityRelation relation in documentResult.EntityRelations)
        {
            Console.WriteLine($"    Relation: {relation.RelationType}");
            if (relation.ConfidenceScore is not null)
            {
                Console.WriteLine($"    ConfidenceScore: {relation.ConfidenceScore}");
            }
            Console.WriteLine($"    For this relation there are {relation.Roles.Count} roles");

            // View the relation roles.
            foreach (HealthcareEntityRelationRole role in relation.Roles)
            {
                Console.WriteLine($"      Role Name: {role.Name}");

                Console.WriteLine($"      Associated Entity Text: {role.Entity.Text}");
                Console.WriteLine($"      Associated Entity Category: {role.Entity.Category}");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
```

### Run multiple actions Asynchronously

This functionality allows running multiple actions in one or more documents. Actions include:

* Named Entities Recognition
* PII Entities Recognition
* Linked Entity Recognition
* Key Phrase Extraction
* Sentiment Analysis
* Healthcare Entities Recognition (see sample [here][analyze_healthcare_sample])
* Custom Named Entities Recognition (see sample [here][recognize_custom_entities_sample])
* Custom Single Label Classification (see sample [here][single_category_classify_sample])
* Custom Multi Label Classification (see sample [here][multi_category_classify_sample])

```C# Snippet:AnalyzeOperationConvenienceAsync
    string documentA =
        "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
        + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
        + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
        + " athletic among us.";

    string documentB =
        "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
        + " so they helped me organize a little surprise for my partner. The room was clean and with the"
        + " decoration I requested. It was perfect!";

    // Prepare the input of the text analysis operation. You can add multiple documents to this list and
    // perform the same operation on all of them simultaneously.
    List<string> batchedDocuments = new()
    {
        documentA,
        documentB
    };

    TextAnalyticsActions actions = new()
    {
        ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() { ActionName = "ExtractKeyPhrasesSample" } },
        RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() { ActionName = "RecognizeEntitiesSample" } },
        DisplayName = "AnalyzeOperationSample"
    };

    // Perform the text analysis operation.
    AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchedDocuments, actions);

    // View the operation status.
    Console.WriteLine($"Created On   : {operation.CreatedOn}");
    Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
    Console.WriteLine($"Id           : {operation.Id}");
    Console.WriteLine($"Status       : {operation.Status}");
    Console.WriteLine($"Last Modified: {operation.LastModified}");
    Console.WriteLine();

    if (!string.IsNullOrEmpty(operation.DisplayName))
    {
        Console.WriteLine($"Display name: {operation.DisplayName}");
        Console.WriteLine();
    }

    Console.WriteLine($"Total actions: {operation.ActionsTotal}");
    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
    Console.WriteLine();

    await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
    {
        IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResults = documentsInPage.ExtractKeyPhrasesResults;
        IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResults = documentsInPage.RecognizeEntitiesResults;

        Console.WriteLine("Recognized Entities");
        int docNumber = 1;
        foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesResults)
        {
            Console.WriteLine($" Action name: {entitiesActionResults.ActionName}");
            Console.WriteLine();
            foreach (RecognizeEntitiesResult documentResult in entitiesActionResults.DocumentsResults)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

                foreach (CategorizedEntity entity in documentResult.Entities)
                {
                    Console.WriteLine();
                    Console.WriteLine($"    Entity: {entity.Text}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    Length: {entity.Length}");
                    Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                    Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("Extracted Key Phrases");
        docNumber = 1;
        foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesResults)
        {
            Console.WriteLine($" Action name: {keyPhrasesActionResult.ActionName}");
            Console.WriteLine();
            foreach (ExtractKeyPhrasesResult documentResults in keyPhrasesActionResult.DocumentsResults)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {documentResults.KeyPhrases.Count} Keyphrases:");

                foreach (string keyphrase in documentResults.KeyPhrases)
                {
                    Console.WriteLine($"    {keyphrase}");
                }
                Console.WriteLine();
            }
        }
    }
}
```

## Troubleshooting

### General

When you interact with the Cognitive Services for Language using the .NET Text Analytics SDK, errors returned by the Language service correspond to the same HTTP status codes returned for REST API requests.

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

```text
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

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Samples showing how to use this client library are available in this GitHub repository.
Samples are provided for each main functional area, and for each area, samples are provided for analyzing a single document, and a collection of documents in both sync and async mode.

* [Detect Language][detect_language_sample]
* [Analyze Sentiment][analyze_sentiment_sample]
* [Extract Key Phrases][extract_key_phrases_sample]
* [Recognize Named Entities][recognize_entities_sample]
* [Recognize PII Entities][recognize_pii_entities_sample]
* [Recognize Linked Entities][recognize_linked_entities_sample]
* [Recognize Healthcare Entities][analyze_healthcare_sample]
* [Custom Named Entities Recognition][recognize_custom_entities_sample]
* [Custom Single Label Classification][single_category_classify_sample]
* [Custom Multi Label Classification][multi_category_classify_sample]
* [Extractive Summarization][extractive_summarize_sample]
* [Abstractive Summarization][abstractive_summarize_sample]

### Advanced samples

* [Understand how to work with long-running operations][lro_sample]
* [Running multiple actions in one or more documents][analyze_operation_sample]
* [Analyze Sentiment with Opinion Mining][analyze_sentiment_opinion_mining_sample]
* [Mock a client for testing][mock_client_sample] using the [Moq][moq] library

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[textanalytics_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/src
[language_service_docs]: https://learn.microsoft.com/azure/cognitive-services/language-service/
[textanalytics_refdocs]: https://aka.ms/azsdk-net-textanalytics-ref-docs
[textanalytics_nuget_package]: https://www.nuget.org/packages/Azure.AI.TextAnalytics
[textanalytics_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/README.md
[dotnet_lro]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt

[lro_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_LROPolling.md
[analyze_operation_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_AnalyzeActions.md
[analyze_sentiment_opinion_mining_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample2.1_AnalyzeSentimentWithOpinionMining.md
[mock_client_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_MockClient.md

[healthcare]: https://learn.microsoft.com/azure/cognitive-services/language-service/text-analytics-for-health/overview?tabs=ner
[language_detection]: https://learn.microsoft.com/azure/cognitive-services/language-service/language-detection/overview
[sentiment_analysis]: https://learn.microsoft.com/azure/cognitive-services/language-service/sentiment-opinion-mining/overview
[key_phrase_extraction]: https://learn.microsoft.com/azure/cognitive-services/language-service/key-phrase-extraction/overview
[named_entity_recognition]: https://learn.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/overview
[entity_linking]: https://learn.microsoft.com/azure/cognitive-services/language-service/entity-linking/overview
[named_entities_categories]: https://learn.microsoft.com/azure/cognitive-services/language-service/named-entity-recognition/concepts/named-entity-categories
[pii_entity]:https://learn.microsoft.com/azure/cognitive-services/language-service/personally-identifiable-information/overview

[textanalytics_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/src/TextAnalyticsClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[cognitive_auth]: https://learn.microsoft.com/azure/cognitive-services/authentication
[register_aad_app]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[data_limits]: https://aka.ms/azsdk/textanalytics/data-limits
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

[detect_language_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample1_DetectLanguage.md
[analyze_sentiment_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample2_AnalyzeSentiment.md
[extract_key_phrases_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample3_ExtractKeyPhrases.md
[recognize_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample4_RecognizeEntities.md
[recognize_pii_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample5_RecognizePiiEntities.md
[recognize_linked_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample6_RecognizeLinkedEntities.md
[analyze_healthcare_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample7_AnalyzeHealthcareEntities.md
[recognize_custom_entities_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample8_RecognizeCustomEntities.md
[single_category_classify_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample9_SingleLabelClassify.md
[multi_category_classify_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample10_MultiLabelClassify.md
[extractive_summarize_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample11_ExtractiveSummarize.md
[abstractive_summarize_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample12_AbstractiveSummarize.md

[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[service_access]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[create_ta_resource_azure_portal]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[create_ta_resource_azure_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
