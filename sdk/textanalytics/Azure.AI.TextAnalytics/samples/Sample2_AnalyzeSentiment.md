# Analyzing the Sentiment of Documents

This sample demonstrates how to analyze the sentiment in one or more documents.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Analyzing the sentiment of a single document

To analyze the sentiment of a document, use the `AnalyzeSentiment` method.  The returned `DocumentSentiment` describes the sentiment of the document, as well as a collection of `Sentences` indicating the sentiment of each individual sentence.

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

## Analyzing the sentiment of multiple documents

To analyze the sentiment of a collection of documents in the same language, call `AnalyzeSentimentBatch` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

```C# Snippet:Sample2_AnalyzeSentimentBatchConvenience
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

Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(batchedDocuments);
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

To analyze the sentiment of a collection of documents in different languages, call `AnalyzeSentimentBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:Sample2_AnalyzeSentimentBatch
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
    + " smelly. It could have been that the toilet was not cleaned before we arrived. Either way it was"
    + " very uncomfortable. Once we notified the staff, they came and cleaned it and left candles.";

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
         Language = "es",
    },
    new TextDocumentInput("3", documentC)
    {
         Language = "en",
    },
    new TextDocumentInput("4", string.Empty)
};

AnalyzeSentimentOptions options = new() { IncludeStatistics = true };
Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(batchedDocuments, options);
AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Analyze Sentiment, model version: \"{sentimentPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (AnalyzeSentimentResult documentResult in sentimentPerDocuments)
{
    TextDocumentInput document = batchedDocuments[i++];

    Console.WriteLine($"Result for document with Id = \"{document.Id}\" and Language = \"{document.Language}\":");

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

    Console.WriteLine($"  Document statistics:");
    Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
    Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
    Console.WriteLine();
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {sentimentPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {sentimentPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {sentimentPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {sentimentPerDocuments.Statistics.TransactionCount}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
