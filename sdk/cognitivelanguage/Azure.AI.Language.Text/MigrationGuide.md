# Migrate from Azure.AI.TextAnalytics to Azure.AI.Language.Text

This guide is intended to assist in the migration to the new Text Analytics client library [`Azure.AI.Language.Text`](https://www.nuget.org/packages/) from the old one [`Azure.AI.TextAnalytics`](https://www.nuget.org/packages/Azure.AI.TextAnalytics). It will focus on side-by-side comparisons for similar operations between the two packages.

Familiarity with the `Azure.AI.TextAnalytics` library is assumed. For those new to the Text Analytics client library for .NET, please refer to the [`Azure.AI.Language.Text` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/README.md) and [`Azure.AI.Language.Text` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples) for the `Azure.AI.Language.Text` library rather than this guide.

## Table of contents

- [Migrate from Azure.AI.TextAnalytics to Azure.AI.Language.Text](#migrate-from-azureaitextanalytics-to-azureailanguagetext)
  - [Table of contents](#table-of-contents)
  - [Migration benefits](#migration-benefits)
  - [General changes](#general-changes)
    - [Package and namespaces](#package-and-namespaces)
    - [Runtime Client](#runtime-client)
      - [Authenticating runtime client](#authenticating-runtime-client)
      - [Detecting language](#detecting-language)
      - [Analyze Sentiment](#analyze-sentiment)
      - [Extract Key Phrases](#extract-key-phrases)
      - [Recognize Named Entities](#recognize-named-entities)
      - [Recognize PII Entities](#recognize-pii-entities)
      - [Recognize Linked Entities](#recognize-linked-entities)
      - [Analyze healthcare entities](#analyze-healthcare-entities)
      - [Perform custom named entity recognition (NER)](#perform-custom-named-entity-recognition-ner)
      - [Perform custom single-label classification](#perform-custom-single-label-classification)
      - [Perform custom multi-label classification](#perform-custom-multi-label-classification)
      - [Summarize documents with extractive summarization](#summarize-documents-with-extractive-summarization)
      - [Summarize documents with abstractive summarization](#summarize-documents-with-abstractive-summarization)
      - [Perform multiple text analysis actions](#perform-multiple-text-analysis-actions)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Question Answering, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Services]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Question Answering, the modern client libraries have packages and namespaces that begin with `Azure.AI.Language.Text` and were released beginning with version 1. The legacy client libraries have packages and namespaces that begin with `Azure.AI.TextAnalytics` and a version of 5.3.X or below.

### Runtime Client

#### Authenticating runtime client

Previously in `Azure.AI.TextAnalytics`, you could create a `TextAnalyticsClient` along with `AzureKeyCredential` from the package `Azure.Core`::

```C#
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalyticsClient client = new(endpoint, credential);
```

Now in `Azure.AI.Language.Text`, you create a `TextAnalysisClient` along with `AzureKeyCredential` from the package `Azure.Core`:

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

#### Detecting language

Previously in `Azure.AI.TextAnalytics`, you would call the `DetectLanguageBatchAsync` method on the `TextAnalyticsClient`:

```C#
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

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<DetectLanguageResultCollection> response = await client.DetectLanguageBatchAsync(batchedDocuments);
DetectLanguageResultCollection documentsLanguage = response.Value;

int i = 0;
Console.WriteLine($"Detect Language, model version: \"{documentsLanguage.ModelVersion}\"");
Console.WriteLine();

foreach (DetectLanguageResult documentResult in documentsLanguage)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Detected language: {documentResult.PrimaryLanguage.Name}");
    Console.WriteLine($"  Confidence score: {documentResult.PrimaryLanguage.ConfidenceScore}");
    Console.WriteLine();
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextLanguageDetectionInput` as the input:

```C# Snippet:Sample1_AnalyzeTextAsync_LanguageDetection
string textA =
    "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
    + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
    + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
    + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
    + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
    + " algunos idiomas regionales o culturales.";

string textB =
    "This document is written in English. Its objective is to demonstrate how to call the language"
    + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
    + " information returned by the service. This functionality is useful for applications that collect"
    + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
    + " of languages, variants, dialects, and some regional or cultural languages.";

string textC =
    "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
    + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
    + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
    + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
    + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
    + " dialectes et certaines langues régionales ou culturelles.";

try
{
    AnalyzeTextInput body = new TextLanguageDetectionInput()
    {
        TextInput = new LanguageDetectionTextInput()
        {
            LanguageInputs =
            {
                new LanguageInput("A", textA),
                new LanguageInput("B", textB),
                new LanguageInput("C", textC),
            }
        }
    };

    Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
    AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

    foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
    {
        Console.WriteLine($"Result for document with Id = \"{document.Id}\":");
        Console.WriteLine($"    Name: {document.DetectedLanguage.Name}");
        Console.WriteLine($"    Iso6391Name: {document.DetectedLanguage.Iso6391Name}");
        if (document.DetectedLanguage.ScriptName != null)
        {
            Console.WriteLine($"    ScriptName: {document.DetectedLanguage.ScriptName}");
            Console.WriteLine($"    ScriptIso15924Code: {document.DetectedLanguage.ScriptIso15924Code}");
        }
        Console.WriteLine($"    ConfidenceScore: {document.DetectedLanguage.ConfidenceScore}");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

#### Analyze Sentiment

Previously in `Azure.AI.TextAnalytics`, you would call the `AnalyzeSentimentBatchAsync` method on the `TextAnalyticsClient`:

```C#
string documentA =
    "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
    + " quality of the food and the process to get room service they refunded the money we spent at the"
    + " restaurant and gave us a voucher for nearby restaurants.";

string documentB =
    "Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms were old and the"
    + " toilet was dirty when we arrived. It was close to bus stops and groceries stores. If you want to"
    + " be close to campus I will recommend it, otherwise, might be better to stay in a cleaner one";

string documentC =
    "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
    + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
    + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
    + " smelly. It could have been that the toilet was not cleaned before we arrived.";

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<AnalyzeSentimentResultCollection> response = await client.AnalyzeSentimentBatchAsync(batchedDocuments);
AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Analyze Sentiment, model version: \"{sentimentPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (AnalyzeSentimentResult documentResult in sentimentPerDocuments)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Document sentiment is {documentResult.DocumentSentiment.Sentiment} with: ");
    Console.WriteLine($"    Positive confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Positive}");
    Console.WriteLine($"    Neutral confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Neutral}");
    Console.WriteLine($"    Negative confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Negative}");
    Console.WriteLine();
    Console.WriteLine($"  Sentence sentiment results:");

    foreach (SentenceSentiment sentimentInSentence in documentResult.DocumentSentiment.Sentences)
    {
        Console.WriteLine($"  * For sentence: \"{sentimentInSentence.Text}\"");
        Console.WriteLine($"    Sentiment is {sentimentInSentence.Sentiment} with: ");
        Console.WriteLine($"      Positive confidence score: {sentimentInSentence.ConfidenceScores.Positive}");
        Console.WriteLine($"      Neutral confidence score: {sentimentInSentence.ConfidenceScores.Neutral}");
        Console.WriteLine($"      Negative confidence score: {sentimentInSentence.ConfidenceScores.Negative}");
        Console.WriteLine();
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextSentimentAnalysisInput` as the input:

```C# Snippet:Sample2_AnalyzeTextAsync_Sentiment
string textA =
    "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
    + " quality of the food and the process to get room service they refunded the money we spent at the"
    + " restaurant and gave us a voucher for nearby restaurants.";

string textB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sab�a de nuestra"
    + " celebraci�n y me ayudaron a tenerle una sorpresa a mi pareja. La habitaci�n estaba limpia y"
    + " decorada como yo hab�a pedido. Una gran experiencia. El pr�ximo a�o volveremos.";

string textC =
    "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
    + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
    + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
    + " smelly. It could have been that the toilet was not cleaned before we arrived.";

try
{
    AnalyzeTextInput body = new TextSentimentAnalysisInput()
    {
        TextInput = new MultiLanguageTextInput()
        {
            MultiLanguageInputs =
            {
                new MultiLanguageInput("A", textA) { Language = "en" },
                new MultiLanguageInput("B", textB) { Language = "es" },
                new MultiLanguageInput("C", textC) { Language = "en" },
            }
        }
    };

    Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
    AnalyzeTextSentimentResult AnalyzeTextSentimentResult = (AnalyzeTextSentimentResult)response.Value;

    foreach (SentimentActionResult sentimentResponseWithDocumentDetectedLanguage in AnalyzeTextSentimentResult.Results.Documents)
    {
        Console.WriteLine($"Document {sentimentResponseWithDocumentDetectedLanguage.Id} sentiment is {sentimentResponseWithDocumentDetectedLanguage.Sentiment} with: ");
        Console.WriteLine($"  Positive confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Positive}");
        Console.WriteLine($"  Neutral confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Neutral}");
        Console.WriteLine($"  Negative confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Negative}");
    }

    foreach (DocumentError analyzeTextDocumentError in AnalyzeTextSentimentResult.Results.Errors)
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
    Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

#### Extract Key Phrases

Previously in `Azure.AI.TextAnalytics`, you would call the `ExtractKeyPhrasesBatchAsync` method on the `TextAnalyticsClient`:

```C#
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string documentB =
    "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
    + " so they helped me organize a little surprise for my partner. The room was clean and with the"
    + " decoration I requested. It was perfect!";

string documentC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<ExtractKeyPhrasesResultCollection> response = await client.ExtractKeyPhrasesBatchAsync(batchedDocuments);
ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Extract Key Phrases, model version: \"{keyPhrasesInDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (ExtractKeyPhrasesResult documentResult in keyPhrasesInDocuments)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Extracted {documentResult.KeyPhrases.Count()} key phrases:");

    foreach (string keyPhrase in documentResult.KeyPhrases)
    {
        Console.WriteLine($"    {keyPhrase}");
    }
    Console.WriteLine();
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextKeyPhraseExtractionInput` as the input:

```C# Snippet:Sample3_AnalyzeTextAsync_ExtractKeyPhrases
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string textB =
"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string textC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string textD = string.Empty;

AnalyzeTextInput body = new TextKeyPhraseExtractionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC) { Language = "en" },
            new MultiLanguageInput("D", textD),
        }
    },
    ActionContent = new KeyPhraseActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextKeyPhraseResult keyPhraseTaskResult = (AnalyzeTextKeyPhraseResult)response.Value;

foreach (KeyPhrasesActionResult kpeResult in keyPhraseTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
    foreach (string keyPhrase in kpeResult.KeyPhrases)
    {
        Console.WriteLine($"    {keyPhrase}");
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in keyPhraseTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

#### Recognize Named Entities

Previously in `Azure.AI.TextAnalytics`, you would call the `RecognizeEntitiesBatchAsync` method on the `TextAnalyticsClient`:

```c#
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
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<RecognizeEntitiesResultCollection> response = await client.RecognizeEntitiesBatchAsync(batchedDocuments);
RecognizeEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Recognize Entities, model version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (RecognizeEntitiesResult documentResult in entititesPerDocuments)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

    foreach (CategorizedEntity entity in documentResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"    SubCategory: {entity.SubCategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextEntityRecognitionInput` as the input:

```C# Snippet:Sample4_AnalyzeTextAsync_RecognizeEntities
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string textB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string textC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string textD = string.Empty;

AnalyzeTextInput body = new TextEntityRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC) { Language = "en" },
            new MultiLanguageInput("D", textD),
        }
    },
    ActionContent = new EntitiesActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

    Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

    foreach (NamedEntityWithMetadata entity in nerResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        Console.WriteLine($"    Type: {entity.Type}");
        Console.WriteLine($"    Tags:");
        foreach (EntityTag tag in entity.Tags)
        {
            Console.WriteLine($"            TagName: {tag.Name}");
            Console.WriteLine($"            TagConfidenceScore: {tag.ConfidenceScore}");
        }
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

#### Recognize PII Entities

Previously in `Azure.AI.TextAnalytics`, you would call the `RecognizePiiEntitiesBatchAsync` method on the `TextAnalyticsClient`:

```c#
string documentA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string documentB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string documentC = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC
};

Response<RecognizePiiEntitiesResultCollection> response = await client.RecognizePiiEntitiesBatchAsync(batchedDocuments);
RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Recognize PII Entities, model version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (RecognizePiiEntitiesResult documentResult in entititesPerDocuments)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"  Redacted Text: {documentResult.Entities.RedactedText}");
    Console.WriteLine();
    Console.WriteLine($"  Recognized {documentResult.Entities.Count} PII entities:");
    foreach (PiiEntity piiEntity in documentResult.Entities)
    {
        Console.WriteLine($"    Text: {piiEntity.Text}");
        Console.WriteLine($"    Category: {piiEntity.Category}");
        if (!string.IsNullOrEmpty(piiEntity.SubCategory))
            Console.WriteLine($"    SubCategory: {piiEntity.SubCategory}");
        Console.WriteLine($"    Confidence score: {piiEntity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextPiiEntitiesRecognitionInput` as the input:

```C# Snippet:Sample5_AnalyzeTextAsync_RecognizePii
string textA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string textB =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

string textC = string.Empty;

AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC),
        }
    },
    ActionContent = new PiiActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
    Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (PiiEntity entity in piiResult.Entities)
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

foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

#### Recognize Linked Entities

Previously in `Azure.AI.TextAnalytics`, you would call the `RecognizeLinkedEntitiesBatchAsync` method on the `TextAnalyticsClient`:

```c#
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

string documentC = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC
};

Response<RecognizeLinkedEntitiesResultCollection> response = await client.RecognizeLinkedEntitiesBatchAsync(batchedDocuments);
RecognizeLinkedEntitiesResultCollection entitiesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Recognize Linked Entities, model version: \"{entitiesInDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (RecognizeLinkedEntitiesResult documentResult in entitiesInDocuments)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine($"Recognized {documentResult.Entities.Count} entities:");
    foreach (LinkedEntity linkedEntity in documentResult.Entities)
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
    Console.WriteLine();
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextAsync` with `TextEntityLinkingInput` as the input:

```C# Snippet:Sample6_AnalyzeTextAsync_RecognizeLinkedEntities
string textA =
    "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
    + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
    + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
    + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

string textB =
    "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
    + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
    + " chairman chief executive officer, president and chief software architect while also being the"
    + " largest individual shareholder until May 2014.";

string textC =
    "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
    + " Ingeniero de Software en el año 1992.";

string textD = string.Empty;

AnalyzeTextInput body = new TextEntityLinkingInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "en" },
            new MultiLanguageInput("C", textC) { Language = "es" },
            new MultiLanguageInput("D", textD),
        }
    },
    ActionContent = new EntityLinkingActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextEntityLinkingResult entityLinkingTaskResult = (AnalyzeTextEntityLinkingResult)response.Value;

foreach (EntityLinkingActionResult entityLinkingResult in entityLinkingTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{entityLinkingResult.Id}\":");
    Console.WriteLine($"Recognized {entityLinkingResult.Entities.Count} entities:");
    foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
    {
        Console.WriteLine($"  Name: {linkedEntity.Name}");
        Console.WriteLine($"  LanguageClient: {linkedEntity.Language}");
        Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
        Console.WriteLine($"  URL: {linkedEntity.Url}");
        Console.WriteLine($"  NamedEntity Id in Data Source: {linkedEntity.Id}");
        foreach (EntityLinkingMatch match in linkedEntity.Matches)
        {
            Console.WriteLine($"    EntityLinkingMatch Text: {match.Text}");
            Console.WriteLine($"    Offset: {match.Offset}");
            Console.WriteLine($"    Length: {match.Length}");
            Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
        }
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in entityLinkingTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

#### Analyze healthcare entities

Previously in `Azure.AI.TextAnalytics`, you would call the `AnalyzeHealthcareEntitiesAsync` method on the `TextAnalyticsClient`:

```C#
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

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `HealthcareOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample7_AnalyzeTextOperationAsync_HealthcareOperationAction
string textA =
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

string textB = "Prescribed 100mg ibuprofen, taken twice daily.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "en" },
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new HealthcareOperationAction
    {
        Name = "HealthcareOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is HealthcareOperationResult)
    {
        HealthcareOperationResult healthcareLROResult = (HealthcareOperationResult)analyzeTextLROResult;
        Console.WriteLine($"Analyze Healthcare Entities, model version: \"{healthcareLROResult.Results.ModelVersion}\"");
        Console.WriteLine();

        // View the healthcare entities recognized in the input documents.
        foreach (HealthcareActionResult healthcareEntitiesDocument in healthcareLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{healthcareEntitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized the following {healthcareEntitiesDocument.Entities.Count} healthcare entities:");
            foreach (HealthcareEntity healthcareEntity in healthcareEntitiesDocument.Entities)
            {
                Console.WriteLine($"  NamedEntity: {healthcareEntity.Text}");
                Console.WriteLine($"  Category: {healthcareEntity.Category}");
                Console.WriteLine($"  Offset: {healthcareEntity.Offset}");
                Console.WriteLine($"  Length: {healthcareEntity.Length}");
                Console.WriteLine($"  Name: {healthcareEntity.Name}");
                Console.WriteLine($"  Links:");

                // View the entity data sources.
                foreach (HealthcareEntityLink healthcareEntityLink in healthcareEntity.Links)
                {
                    Console.WriteLine($"    NamedEntity ID in Data Source: {healthcareEntityLink.Id}");
                    Console.WriteLine($"    DataSource: {healthcareEntityLink.DataSource}");
                }

                // View the entity assertions.
                if (healthcareEntity.Assertion is not null)
                {
                    Console.WriteLine($"  Assertions:");
                    if (healthcareEntity.Assertion?.Association is not null)
                    {
                        Console.WriteLine($"    HealthcareAssociation: {healthcareEntity.Assertion?.Association}");
                    }
                    if (healthcareEntity.Assertion?.Certainty is not null)
                    {
                        Console.WriteLine($"    HealthcareCertainty: {healthcareEntity.Assertion?.Certainty}");
                    }
                    if (healthcareEntity.Assertion?.Conditionality is not null)
                    {
                        Console.WriteLine($"    HealthcareConditionality: {healthcareEntity.Assertion?.Conditionality}");
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
            foreach (DocumentError error in healthcareLROResult.Results.Errors)
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

#### Perform custom named entity recognition (NER)

Previously in `Azure.AI.TextAnalytics`, you would call the `RecognizeCustomEntitiesAsync` method on the `TextAnalyticsClient`:

```c#
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
List<TextDocumentInput> batchedDocuments = new()
{
    new TextDocumentInput("1", documentA)
    {
         Language = "en",
    },
    new TextDocumentInput("2", documentB)
    {
         Language = "en",
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);

await foreach (RecognizeCustomEntitiesResultCollection documentsInPage in operation.Value)
{
    foreach (RecognizeEntitiesResult documentResult in documentsInPage)
    {
        Console.WriteLine($"Result for document with Id = \"{documentResult.Id}\":");

        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            Console.WriteLine();
            continue;
        }

        Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

        foreach (CategorizedEntity entity in documentResult.Entities)
        {
            Console.WriteLine($"  Entity: {entity.Text}");
            Console.WriteLine($"  Category: {entity.Category}");
            Console.WriteLine($"  Offset: {entity.Offset}");
            Console.WriteLine($"  Length: {entity.Length}");
            Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `CustomEntitiesOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample8_AnalyzeTextOperationAsync_CustomEntitiesOperationAction
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us.";

string textB =
    "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
    + " so they helped me organize a little surprise for my partner. The room was clean and with the"
    + " decoration I requested. It was perfect!";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "en" },
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

CustomEntitiesActionContent customEntitiesActionContent = new CustomEntitiesActionContent(projectName, deploymentName);

// Perform the text analysis operation.
var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new CustomEntitiesOperationAction
    {
        Name = "CustomEntitiesOperationActionSample", // Optional string for humans to identify action by name.
        ActionContent = customEntitiesActionContent
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is CustomEntityRecognitionOperationResult)
    {
        CustomEntityRecognitionOperationResult customClassificationResult = (CustomEntityRecognitionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (CustomEntityActionResult entitiesDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{entitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized {entitiesDocument.Entities.Count} Entities:");

            foreach (NamedEntity entity in entitiesDocument.Entities)
            {
                Console.WriteLine($"  NamedEntity: {entity.Text}");
                Console.WriteLine($"  Category: {entity.Category}");
                Console.WriteLine($"  Offset: {entity.Offset}");
                Console.WriteLine($"  Length: {entity.Length}");
                Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"  Subcategory: {entity.Subcategory}");
                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in customClassificationResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
        Console.WriteLine();
    }
}
```

#### Perform custom single-label classification

Previously in `Azure.AI.TextAnalytics`, you would call the `SingleLabelClassifyAsync` method on the `TextAnalyticsClient`:

```C#
string document =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    document
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);

// View the operation results.
await foreach (ClassifyDocumentResultCollection documentsInPage in operation.Value)
{
    foreach (ClassifyDocumentResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Predicted the following class:");
        Console.WriteLine();

        foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
        {
            Console.WriteLine($"  Category: {classification.Category}");
            Console.WriteLine($"  Confidence score: {classification.ConfidenceScore}");
            Console.WriteLine();
        }
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `CustomSingleLabelClassificationOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample9_AnalyzeTextOperationAsync_CustomSingleLabelClassificationOperationAction
string textA =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA)
        {
            Language = "en"
        },
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

CustomSingleLabelClassificationActionContent customSingleLabelClassificationActionContent = new CustomSingleLabelClassificationActionContent(projectName, deploymentName);

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new CustomSingleLabelClassificationOperationAction
    {
        Name = "CSCOperationActionSample", // Optional string for humans to identify action by name.
        ActionContent = customSingleLabelClassificationActionContent
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is CustomSingleLabelClassificationOperationResult)
    {
        CustomSingleLabelClassificationOperationResult customClassificationResult = (CustomSingleLabelClassificationOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{customClassificationDocument.Id}\":");
            Console.WriteLine($"  Recognized {customClassificationDocument.Class.Count} classifications:");

            foreach (ClassificationResult classification in customClassificationDocument.Class)
            {
                Console.WriteLine($"  Classification: {classification.Category}");
                Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in customClassificationResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

#### Perform custom multi-label classification

Previously in `Azure.AI.TextAnalytics`, you would call the `MultiLabelClassifyAsync` method on the `TextAnalyticsClient`:

```C#
string document =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    document
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);

// View the operation results.
await foreach (ClassifyDocumentResultCollection documentsInPage in operation.Value)
{
    foreach (ClassifyDocumentResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Predicted the following classes:");
        Console.WriteLine();

        foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
        {
            Console.WriteLine($"  Category: {classification.Category}");
            Console.WriteLine($"  Confidence score: {classification.ConfidenceScore}");
            Console.WriteLine();
        }
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `CustomMultiLabelClassificationOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample10_AnalyzeTextOperationAsync_CustomMultiLabelClassificationOperationAction
string textA =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA)
        {
            Language = "en"
        },
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

CustomMultiLabelClassificationActionContent customMultiLabelClassificationActionContent = new CustomMultiLabelClassificationActionContent(projectName, deploymentName);

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new CustomMultiLabelClassificationOperationAction
    {
        Name = "CMCOperationActionSample",
        ActionContent = customMultiLabelClassificationActionContent,
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is CustomMultiLabelClassificationOperationResult)
    {
        CustomMultiLabelClassificationOperationResult customClassificationResult = (CustomMultiLabelClassificationOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{customClassificationDocument.Id}\":");
            Console.WriteLine($"  Recognized {customClassificationDocument.Class.Count} classifications:");

            foreach (ClassificationResult classification in customClassificationDocument.Class)
            {
                Console.WriteLine($"  Classification: {classification.Category}");
                Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in customClassificationResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

#### Summarize documents with extractive summarization

Previously in `Azure.AI.TextAnalytics`, you would call the `ExtractiveSummarizeAsync` method on the `TextAnalyticsClient`:

```C#
string document =
    "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
    + " solutions to support employees suddenly forced to work from home, but “what really put the"
    + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
    + " that customers were asking, “How do we create an experience for people that makes them still feel"
    + " connected to the company without the physical presence of being there?” In this new world of"
    + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
    + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
    + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
    + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
    + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
    + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
    + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
    + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
    + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
    + " continue working from home; it enables companies to hire interns from halfway around the world; it"
    + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
    + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
    + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
    + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
    + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
    + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
    + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
    + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
    + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
    + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
    + " November 2019 that took down everything from the phone system to the government’s servers."
    + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
    + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
    + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
    + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
    + " is being able to access specialists from outside the territory and organizations outside the"
    + " territory to come in and help us with our projects, being able to get people on staff with us to"
    + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
    + " to improve healthcare, being able to improve education, economic development is going to improve"
    + " the quality of life in the communities.”";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    document
};

// Perform the text analysis operation.
ExtractiveSummarizeOperation operation = await client.ExtractiveSummarizeAsync(WaitUntil.Completed, batchedDocuments);

// View the operation results.
await foreach (ExtractiveSummarizeResultCollection documentsInPage in operation.Value)
{
    Console.WriteLine($"Extractive Summarize, version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine();

    foreach (ExtractiveSummarizeResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Extracted {documentResult.Sentences.Count} sentence(s):");
        Console.WriteLine();

        foreach (ExtractiveSummarySentence sentence in documentResult.Sentences)
        {
            Console.WriteLine($"  Sentence: {sentence.Text}");
            Console.WriteLine($"  Rank Score: {sentence.RankScore}");
            Console.WriteLine($"  Offset: {sentence.Offset}");
            Console.WriteLine($"  Length: {sentence.Length}");
            Console.WriteLine();
        }
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `ExtractiveSummarizationOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample11_AnalyzeTextOperationAsync_ExtractiveSummarizationOperationAction
string textA =
    "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
    + " solutions to support employees suddenly forced to work from home, but “what really put the"
    + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
    + " that customers were asking, “How do we create an experience for people that makes them still feel"
    + " connected to the company without the physical presence of being there?” In this new world of"
    + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
    + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
    + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
    + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
    + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
    + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
    + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
    + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
    + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
    + " continue working from home; it enables companies to hire interns from halfway around the world; it"
    + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
    + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
    + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
    + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
    + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
    + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
    + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
    + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
    + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
    + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
    + " November 2019 that took down everything from the phone system to the government’s servers."
    + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
    + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
    + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
    + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
    + " is being able to access specialists from outside the territory and organizations outside the"
    + " territory to come in and help us with our projects, being able to get people on staff with us to"
    + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
    + " to improve healthcare, being able to improve education, economic development is going to improve"
    + " the quality of life in the communities.”";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new ExtractiveSummarizationOperationAction
    {
        Name = "ExtractiveSummarizationOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is ExtractiveSummarizationOperationResult)
    {
        ExtractiveSummarizationOperationResult extractiveSummarizationLROResult = (ExtractiveSummarizationOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (ExtractedSummaryActionResult extractedSummyDocument in extractiveSummarizationLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{extractedSummyDocument.Id}\":");
            Console.WriteLine($"  Extracted {extractedSummyDocument.Sentences.Count} sentence(s):");
            Console.WriteLine();

            foreach (ExtractedSummarySentence sentence in extractedSummyDocument.Sentences)
            {
                Console.WriteLine($"  Sentence: {sentence.Text}");
                Console.WriteLine($"  Rank Score: {sentence.RankScore}");
                Console.WriteLine($"  Offset: {sentence.Offset}");
                Console.WriteLine($"  Length: {sentence.Length}");
                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in extractiveSummarizationLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

#### Summarize documents with abstractive summarization

Previously in `Azure.AI.TextAnalytics`, you would call the `AbstractiveSummarizeAsync` method on the `TextAnalyticsClient`:

```C#
string document =
    "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
    + " solutions to support employees suddenly forced to work from home, but “what really put the"
    + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
    + " that customers were asking, “How do we create an experience for people that makes them still feel"
    + " connected to the company without the physical presence of being there?” In this new world of"
    + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
    + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
    + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
    + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
    + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
    + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
    + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
    + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
    + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
    + " continue working from home; it enables companies to hire interns from halfway around the world; it"
    + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
    + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
    + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
    + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
    + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
    + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
    + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
    + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
    + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
    + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
    + " November 2019 that took down everything from the phone system to the government’s servers."
    + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
    + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
    + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
    + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
    + " is being able to access specialists from outside the territory and organizations outside the"
    + " territory to come in and help us with our projects, being able to get people on staff with us to"
    + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
    + " to improve healthcare, being able to improve education, economic development is going to improve"
    + " the quality of life in the communities.”";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    document
};

// Perform the text analysis operation.
AbstractiveSummarizeOperation operation = await client.AbstractiveSummarizeAsync(WaitUntil.Completed, batchedDocuments);

// View the operation results.
await foreach (AbstractiveSummarizeResultCollection documentsInPage in operation.Value)
{
    Console.WriteLine($"Abstractive Summarize, model version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine();

    foreach (AbstractiveSummarizeResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Produced the following abstractive summaries:");
        Console.WriteLine();

        foreach (AbstractiveSummary summary in documentResult.Summaries)
        {
            Console.WriteLine($"  Text: {summary.Text.Replace("\n", " ")}");
            Console.WriteLine($"  Contexts:");

            foreach (AbstractiveSummaryContext context in summary.Contexts)
            {
                Console.WriteLine($"    Offset: {context.Offset}");
                Console.WriteLine($"    Length: {context.Length}");
            }

            Console.WriteLine();
        }
    }
}
```

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with `AbstractiveSummarizationOperationAction` as one of the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample12_AnalyzeTextOperationAsync_AbstractiveSummarizationOperationAction
string textA =
    "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
    + " solutions to support employees suddenly forced to work from home, but “what really put the"
    + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
    + " that customers were asking, “How do we create an experience for people that makes them still feel"
    + " connected to the company without the physical presence of being there?” In this new world of"
    + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
    + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
    + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
    + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
    + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
    + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
    + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
    + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
    + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
    + " continue working from home; it enables companies to hire interns from halfway around the world; it"
    + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
    + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
    + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
    + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
    + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
    + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
    + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
    + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
    + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
    + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
    + " November 2019 that took down everything from the phone system to the government’s servers."
    + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
    + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
    + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
    + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
    + " is being able to access specialists from outside the territory and organizations outside the"
    + " territory to come in and help us with our projects, being able to get people on staff with us to"
    + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
    + " to improve healthcare, being able to improve education, economic development is going to improve"
    + " the quality of life in the communities.”";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new AbstractiveSummarizationOperationAction
    {
        Name = "AbsractiveSummarizationOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is AbstractiveSummarizationOperationResult)
    {
        AbstractiveSummarizationOperationResult abstractiveSummarizationLROResult = (AbstractiveSummarizationOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (AbstractiveSummaryActionResult extractedSummaryDocument in abstractiveSummarizationLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{extractedSummaryDocument.Id}\":");
            Console.WriteLine($"  Produced the following abstractive summaries:");
            Console.WriteLine();

            foreach (AbstractiveSummary summary in extractedSummaryDocument.Summaries)
            {
                Console.WriteLine($"  Text: {summary.Text.Replace("\n", " ")}");
                Console.WriteLine($"  Contexts:");

                foreach (SummaryContext context in summary.Contexts)
                {
                    Console.WriteLine($"    Offset: {context.Offset}");
                    Console.WriteLine($"    Length: {context.Length}");
                }

                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in abstractiveSummarizationLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

#### Perform multiple text analysis actions

Previously in `Azure.AI.TextAnalytics`, you would call the `AnalyzeActionsAsync` method on the `TextAnalyticsClient`:

```C#
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

Now in `Azure.AI.Language.Text` you use `client.AnalyzeTextOperationAsync` with the actions you want to run (the below example uses `EntitiesOperationAction` and `KeyPhraseOperationAction`) as the `AnalyzeTextOperationAction` as input:

```C# Snippet:Sample13_AnalyzeTextOperationAsync_MultipleActions
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string textB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string textC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string textD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "es" },
        new MultiLanguageInput("C", textC) { Language = "en" },
        new MultiLanguageInput("D", textD),
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new EntitiesOperationAction
    {
        Name = "EntitiesOperationActionSample", // Optional string for humans to identify action by name.
    },
    new KeyPhraseOperationAction
    {
        Name = "KeyPhraseOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is EntityRecognitionOperationResult)
    {
        EntityRecognitionOperationResult entityRecognitionLROResult = (EntityRecognitionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (EntityActionResultWithMetadata nerResult in entityRecognitionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

            Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

            foreach (NamedEntityWithMetadata entity in nerResult.Entities)
            {
                Console.WriteLine($"    Text: {entity.Text}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    Length: {entity.Length}");
                Console.WriteLine($"    Category: {entity.Category}");
                Console.WriteLine($"    Type: {entity.Type}");
                Console.WriteLine($"    Tags:");
                foreach (EntityTag tag in entity.Tags)
                {
                    Console.WriteLine($"            TagName: {tag.Name}");
                    Console.WriteLine($"            TagConfidenceScore: {tag.ConfidenceScore}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (DocumentError error in entityRecognitionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }

    if (analyzeTextLROResult is KeyPhraseExtractionOperationResult)
    {
        KeyPhraseExtractionOperationResult keyPhraseExtractionLROResult = (KeyPhraseExtractionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (KeyPhrasesActionResult kpeResult in keyPhraseExtractionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
            foreach (string keyPhrase in kpeResult.KeyPhrases)
            {
                Console.WriteLine($"    {keyPhrase}");
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (DocumentError error in keyPhraseExtractionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```
