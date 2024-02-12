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

The Azure.AI.Language.Text client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` [created above](#create-a-analyzetextclient).

### Sync examples

* [Detect Language](#detect-language)
* [Analyze Sentiment](#analyze-sentiment)
* [Extract Key Phrases](#extract-key-phrases)
* [Recognize Named Entities](#recognize-named-entities)
* [Recognize PII Entities](#recognize-pii-entities)
* [Recognize Linked Entities](#recognize-linked-entities)

### Async examples

* [Detect Language Asynchronously](#detect-language-asynchronously)
* [Analyze Healthcare Entities Asynchronously](#analyze-healthcare-entities-asynchronously)
* [Run multiple actions Asynchronously](#run-multiple-actions-asynchronously)

### Detect Language

Run a predictive model to determine the language that the passed-in AnalyzeTextTask.

```C# Snippet:Sample1_AnalyzeText_LanguageDetection
string documentA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string documentB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string documentC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

try
{
    AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
    {
        AnalysisInput = new LanguageDetectionAnalysisInput()
        {
            Documents =
            {
                new LanguageInput("A", documentA),
                new LanguageInput("B", documentB),
                new LanguageInput("C", documentC),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
    LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
    {
        Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Analyze Sentiment

Run a predictive model to determine the positive, negative, neutral or mixed sentiment contained in the passed-in AnalyzeTextTask.

```C# Snippet:Sample2_AnalyzeText_Sentiment
string documentA =
    "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
    + " quality of the food and the process to get room service they refunded the money we spent at the"
    + " restaurant and gave us a voucher for nearby restaurants.";

string documentB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string documentC =
    "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
    + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
    + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
    + " smelly. It could have been that the toilet was not cleaned before we arrived.";

try
{
    AnalyzeTextTask body = new AnalyzeTextSentimentAnalysisInput()
    {
        AnalysisInput = new MultiLanguageAnalysisInput()
        {
            Documents =
            {
                new MultiLanguageInput("A", documentA, "en"),
                new MultiLanguageInput("B", documentB, "es"),
                new MultiLanguageInput("C", documentC, "en"),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
    SentimentTaskResult sentimentTaskResult = (SentimentTaskResult)response.Value;

    foreach (SentimentResponseWithDocumentDetectedLanguage sentimentResponseWithDocumentDetectedLanguage in sentimentTaskResult.Results.Documents)
    {
        Console.WriteLine($"Document {sentimentResponseWithDocumentDetectedLanguage.Id} sentiment is {sentimentResponseWithDocumentDetectedLanguage.Sentiment} with: ");
        Console.WriteLine($"  Positive confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Positive}");
        Console.WriteLine($"  Neutral confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Neutral}");
        Console.WriteLine($"  Negative confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Negative}");
    }

    foreach (AnalyzeTextDocumentError analyzeTextDocumentError in sentimentTaskResult.Results.Errors)
    {
        Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
        Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
        Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
        Console.WriteLine();
        continue;
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

### Extract Key Phrases

Run a model to identify a collection of significant phrases found in the passed-in document or batch of documents.

```C# Snippet:Sample3_AnalyzeText_ExtractKeyPhrases
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string documentB =
"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string documentC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string documentD = string.Empty;

AnalyzeTextTask body = new AnalyzeTextKeyPhraseExtractionInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "es"),
            new MultiLanguageInput("C", documentC, "en"),
            new MultiLanguageInput("D", documentD),
        }
    },
    Parameters = new KeyPhraseTaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
KeyPhraseTaskResult keyPhraseTaskResult = (KeyPhraseTaskResult)response.Value;

foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
    foreach (string keyPhrase in kpeResult.KeyPhrases)
    {
        Console.WriteLine($"    {keyPhrase}");
    }
    Console.WriteLine();
}

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in keyPhraseTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

### Recognize Named Entities

Run a predictive model to identify a collection of named entities in the passed-in AnalyzeTextTask and categorize those entities into categories such as person, location, or organization.  For more information on available categories, see [Text Analytics Named Entity Categories][named_entities_categories].

```C# Snippet:Sample4_AnalyzeText_RecognizeEntities
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string documentB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string documentC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string documentD = string.Empty;

AnalyzeTextTask body = new AnalyzeTextEntityRecognitionInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "es"),
            new MultiLanguageInput("C", documentC, "en"),
            new MultiLanguageInput("D", documentD),
        }
    },
    Parameters = new EntitiesTaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
EntitiesTaskResult entitiesTaskResult = (EntitiesTaskResult)response.Value;

foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entitiesTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

    Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

    foreach (EntityWithMetadata entity in nerResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

### Recognize PII Entities

Run a predictive model to identify a collection of entities containing Personally Identifiable Information found in the passed-in AnalyzeTextTask, and categorize those entities into categories such as US social security number, drivers license number, or credit card number.

```C# Snippet:Sample5_AnalyzeText_RecognizePii
string documentA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string documentB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string documentC = string.Empty;

AnalyzeTextTask body = new AnalyzeTextPIIEntitiesRecognitionInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "es"),
            new MultiLanguageInput("C", documentC),
        }
    },
    Parameters = new PIITaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
PIITaskResult piiTaskResult = (PIITaskResult)response.Value;

foreach (PIIResultWithDetectedLanguage piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");

    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (Entity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

### Recognize Linked Entities

Run a predictive model to identify a collection of entities found in the passed-in AnalyzeTextTask, and include information linking the entities to their corresponding entries in a well-known knowledge base.

```C# Snippet:Sample6_AnalyzeText_RecognizeLinkedEntities
string documentA =
    "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
    + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
    + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
    + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

string documentB =
    "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
    + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
    + " chairman chief executive officer, president and chief software architect while also being the"
    + " largest individual shareholder until May 2014.";

string documentC =
    "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
    + " Ingeniero de Software en el año 1992.";

string documentD = string.Empty;

AnalyzeTextTask body = new AnalyzeTextEntityLinkingInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "en"),
            new MultiLanguageInput("C", documentC, "es"),
            new MultiLanguageInput("C", documentC),
        }
    },
    Parameters = new EntityLinkingTaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
EntityLinkingTaskResult entityLinkingTaskResult = (EntityLinkingTaskResult)response.Value;

foreach (EntityLinkingResultWithDetectedLanguage entityLinkingResult in entityLinkingTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{entityLinkingResult.Id}\":");
    Console.WriteLine($"Recognized {entityLinkingResult.Entities.Count} entities:");
    foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
    {
        Console.WriteLine($"  Name: {linkedEntity.Name}");
        Console.WriteLine($"  Language: {linkedEntity.Language}");
        Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
        Console.WriteLine($"  URL: {linkedEntity.Url}");
        Console.WriteLine($"  Entity Id in Data Source: {linkedEntity.Id}");
        foreach (Match match in linkedEntity.Matches)
        {
            Console.WriteLine($"    Match Text: {match.Text}");
            Console.WriteLine($"    Offset: {match.Offset}");
            Console.WriteLine($"    Length: {match.Length}");
            Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
        }
    }
    Console.WriteLine();
}

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in entityLinkingTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

### Detect Language Asynchronously

Run a predictive model to determine the language that the passed-in AnalyzeTextTask are written in.

```C# Snippet:Sample1_AnalyzeTextAsync_LanguageDetection_CountryHint
string documentA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string documentB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string documentC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

try
{
    AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
    {
        AnalysisInput = new LanguageDetectionAnalysisInput()
        {
            Documents =
            {
                new LanguageInput("A", documentA, "es"),
                new LanguageInput("B", documentB, "us"),
                new LanguageInput("C", documentC, "fr"),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = await client.AnalyzeTextAsync(body);
    LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
    {
        Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
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

```C# Snippet:Sample7_AnalyzeTextSubmitJob_HealthcareLROTask_PerformOperation
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
MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
{
    Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "en"),
        }
};

AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
{
    new HealthcareLROTask()
});

Operation operation = client.AnalyzeTextSubmitJob(WaitUntil.Completed, analyzeTextJobsInput);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the healthcare entities analysis, including any errors that might have occurred:

```C# Snippet:Sample7_AnalyzeTextSubmitJob_HealthcareLROTask_ViewResults
AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
{
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.HealthcareLROResults)
    {
        HealthcareLROResult healthcareLROResult = (HealthcareLROResult)analyzeTextLROResult;
        Console.WriteLine($"Analyze Healthcare Entities, model version: \"{healthcareLROResult.Results.ModelVersion}\"");
        Console.WriteLine();

        // View the healthcare entities recognized in the input documents.
        foreach (HealthcareEntitiesDocumentResultWithDocumentDetectedLanguage healthcareEntitiesDocument in healthcareLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{healthcareEntitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized the following {healthcareEntitiesDocument.Entities.Count} healthcare entities:");
            foreach (HealthcareEntity healthcareEntity in healthcareEntitiesDocument.Entities)
            {
                Console.WriteLine($"  Entity: {healthcareEntity.Text}");
                Console.WriteLine($"  Category: {healthcareEntity.Category}");
                Console.WriteLine($"  Offset: {healthcareEntity.Offset}");
                Console.WriteLine($"  Length: {healthcareEntity.Length}");
                Console.WriteLine($"  Name: {healthcareEntity.Name}");
                Console.WriteLine($"  Links:");

                // View the entity data sources.
                foreach (HealthcareEntityLink healthcareEntityLink in healthcareEntity.Links)
                {
                    Console.WriteLine($"    Entity ID in Data Source: {healthcareEntityLink.Id}");
                    Console.WriteLine($"    DataSource: {healthcareEntityLink.DataSource}");
                }

                // View the entity assertions.
                if (healthcareEntity.Assertion is not null)
                {
                    Console.WriteLine($"  Assertions:");
                    if (healthcareEntity.Assertion?.Association is not null)
                    {
                        Console.WriteLine($"    Association: {healthcareEntity.Assertion?.Association}");
                    }
                    if (healthcareEntity.Assertion?.Certainty is not null)
                    {
                        Console.WriteLine($"    Certainty: {healthcareEntity.Assertion?.Certainty}");
                    }
                    if (healthcareEntity.Assertion?.Conditionality is not null)
                    {
                        Console.WriteLine($"    Conditionality: {healthcareEntity.Assertion?.Conditionality}");
                    }
                }
            }

            Console.WriteLine($"  We found {healthcareEntitiesDocument.Relations.Count} relations in the current document:");
            Console.WriteLine();

            // View the healthcare entity relations that were recognized.
            foreach (HealthcareRelation relation in healthcareEntitiesDocument.Relations)
            {
                Console.WriteLine($"    Relation: {relation.RelationType}");
                if (relation.ConfidenceScore is not null)
                {
                    Console.WriteLine($"    ConfidenceScore: {relation.ConfidenceScore}");
                }
                Console.WriteLine($"    For this relation there are {relation.Entities.Count} roles");

                // View the relations
                foreach (HealthcareRelationEntity healthcareRelationEntity in relation.Entities)
                {
                    Console.WriteLine($"      Role: {healthcareRelationEntity.Role}");
                    Console.WriteLine($"      Refrence: {healthcareRelationEntity.Ref}");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            // View the errors in the document
            foreach (AnalyzeTextDocumentError error in healthcareLROResult.Results.Errors)
            {
                Console.WriteLine($"  Error in document: {error.Id}!");
                Console.WriteLine($"  Document error code: {error.Error.Code}");
                Console.WriteLine($"  Message: {error.Error.Message}");
                continue;
            }
        }
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
* Extractive Summarization (see sample [here][extractive_summarization_sample])
* Abstractive Summarization (see sample [here][abstractive_summarization_sample])

```C# Snippet:Sample13_AnalyzeTextSubmitJob_MultipleTasks
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string documentB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string documentC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
{
    Documents =
    {
        new MultiLanguageInput("A", documentA, "en"),
        new MultiLanguageInput("B", documentB, "es"),
        new MultiLanguageInput("C", documentC, "en"),
        new MultiLanguageInput("D", documentD),
    }
};

AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
{
    new EntitiesLROTask(),
    new KeyPhraseLROTask(),
});

Operation operation = client.AnalyzeTextSubmitJob(WaitUntil.Completed, analyzeTextJobsInput);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the abstractive summarization, including any errors that might have occurred:

```C# Snippet:Sample13_AnalyzeTextSubmitJob_MultipleTasks_ViewResults
// View the operation results.
AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
{
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.EntityRecognitionLROResults)
    {
        EntityRecognitionLROResult entityRecognitionLROResult = (EntityRecognitionLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entityRecognitionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

            Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

            foreach (EntityWithMetadata entity in nerResult.Entities)
            {
                Console.WriteLine($"    Text: {entity.Text}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    Length: {entity.Length}");
                Console.WriteLine($"    Category: {entity.Category}");
                if (!string.IsNullOrEmpty(entity.Subcategory))
                    Console.WriteLine($"    SubCategory: {entity.Subcategory}");
                Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (AnalyzeTextDocumentError error in entityRecognitionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
    Console.WriteLine();
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.KeyPhraseExtractionLROResults)
    {
        KeyPhraseExtractionLROResult keyPhraseExtractionLROResult = (KeyPhraseExtractionLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseExtractionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
            foreach (string keyPhrase in kpeResult.KeyPhrases)
            {
                Console.WriteLine($"    {keyPhrase}");
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (AnalyzeTextDocumentError error in keyPhraseExtractionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

## Troubleshooting

When you interact with the Cognitive Language Services Text client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a batch of text document inputs containing duplicate document ids, a `400` error is returned, indicating "Bad Request".

```C# Snippet:Bad_Request
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

try
{
    AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
    {
        AnalysisInput = new LanguageDetectionAnalysisInput()
        {
            Documents =
            {
                new LanguageInput("A", documentA),
                new LanguageInput("A", documentA),
            }
        }
    };

    Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Message:
    Azure.RequestFailedException: Invalid Document in request.
    Status: 400 (Bad Request)
    ErrorCode: InvalidRequest

Content:
    {"error":{"code":"InvalidRequest","message":"Invalid Document in request.","innererror":{"code":"InvalidDocument","message":"Request contains duplicated Ids. Make sure each document has a unique Id."}}}

Headers:
    Transfer-Encoding: chunked
    x-envoy-upstream-service-time: 15
    request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
    apim-request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
    Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
    X-Content-Type-Options: nosniff
    Date: Mon, 12 Feb 2024 22:25:12 GMT
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
* [Analyze Sentiment][sentiment_sample]
* [Extract Key Phrases][key_phrase_sample]
* [Recognize Named Entities][ner_sample]
* [Recognize PII Entities][pii_sample]
* [Recognize Linked Entities][entity_linking_sample]
* [Analyze Healthcare Entities][analyze_healthcare_sample]
* [Custom Named Entity Recognition][recognize_custom_entities_sample]
* [Custom Single Label Classification][single_category_classify_sample]
* [Custom Multi Label Classification][multi_category_classify_sample]
* [Extractive Summarization][extractive_summarization_sample]
* [Abstractive Summarization][abstractive_summarization_sample]
* [Perform multiple text analysis actions][multi_async_sample]

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

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

[detect_language_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample1_AnalyzeText_LanguageDetection.md
[sentiment_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample2_AnalyzeText_Sentiment.md
[key_phrase_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample3_AnalyzeText_ExtractKeyPhrases.md
[ner_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample4_AnalyzeText_RecognizeEntities.md
[pii_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample5_AnalyzeText_RecognizePiiEntities.md
[entity_linking_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample6_AnalyzeText_RecognizeLinkedEntities.md
[analyze_healthcare_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample7_AnalyzeTextSubmitJob_AnalyzeHealthcareEntities.md
[recognize_custom_entities_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample8_AnalyzeTextSubmitJob_RecognizeCustomEntities.md
[single_category_classify_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample9_AnalyzeTextSubmitJob_SingleLabelClassify.md
[multi_category_classify_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample8_AnalyzeTextSubmitJob_RecognizeCustomEntities.md
[extractive_summarization_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample11_AnalyzeTextSubmitJob_ExtractiveSummarize.md
[abstractive_summarization_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample12_AnalyzeTextSubmitJob_AbstractiveSummarize.md
[multi_async_sample]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/Sample13_AnalyzeTextSubmitJobAsync_MultipleTasks.md


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
