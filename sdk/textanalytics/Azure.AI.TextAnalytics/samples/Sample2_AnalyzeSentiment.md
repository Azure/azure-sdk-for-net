# Analyzing the Sentiment of Documents

This sample demonstrates how to analyze the sentiment in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to analyze the sentiment in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Analyzing the sentiment of a single document

To analyze the sentiment of a document, use the `AnalyzeSentiment` method.  The returned `DocumentSentiment` describes the sentiment of the document, as well as a collection of `Sentences` indicating the sentiment of each individual sentence.

```C# Snippet:AnalyzeSentiment
string document = @"I had the best day of my life. I decided to go sky-diving and it
                    made me appreciate my whole life so much more.
                    I developed a deep-connection with my instructor as well, and I
                    feel as if I've made a life-long friend in her.";

try
{
    Response<DocumentSentiment> response = client.AnalyzeSentiment(document);
    DocumentSentiment docSentiment = response.Value;

    Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with confidence scores: ");
    Console.WriteLine($"  Positive confidence score: {docSentiment.ConfidenceScores.Positive}.");
    Console.WriteLine($"  Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}.");
    Console.WriteLine($"  Negative confidence score: {docSentiment.ConfidenceScores.Negative}.");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Analyzing the sentiment of multiple documents

To analyze the sentiment of a collection of documents in the same language, call `AnalyzeSentimentBatch` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
string documentA = @"The food and service were unacceptable, but the concierge were nice.
                    After talking to them about the quality of the food and the process
                    to get room service they refunded the money we spent at the restaurant and
                    gave us a voucher for nearby restaurants.";

string documentB = @"Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms
                    were old and the toilet was dirty when we arrived. It was close to bus stops and
                    groceries stores.
                    If you want to be close to campus I will recommend it, otherwise, might be
                    better to stay in a cleaner one";

string documentC = @"The rooms were beautiful. The AC was good and quiet, which was key for us as outside
                    it was 100F and our baby was getting uncomfortable because of the heat. The breakfast
                    was good too with good options and good servicing times.
                    The thing we didn't like was that the toilet in our bathroom was smelly.
                    It could have been that the toilet was not cleaned before we arrived.";

string documentD = string.Empty;

var documents = new List<string>
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(documents);
AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{sentimentPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (AnalyzeSentimentResult sentimentInDocument in sentimentPerDocuments)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine("");

    if (sentimentInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error: {sentimentInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {sentimentInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"Document sentiment is {sentimentInDocument.DocumentSentiment.Sentiment}, with confidence scores: ");
        Console.WriteLine($"  Positive confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Positive}.");
        Console.WriteLine($"  Neutral confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Neutral}.");
        Console.WriteLine($"  Negative confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Negative}.");
        Console.WriteLine("");
        Console.WriteLine($"  Sentence sentiment results:");

        foreach (SentenceSentiment sentimentInSentence in sentimentInDocument.DocumentSentiment.Sentences)
        {
            Console.WriteLine($"  For sentence: \"{sentimentInSentence.Text}\"");
            Console.WriteLine($"  Sentiment is {sentimentInSentence.Sentiment}, with confidence scores: ");
            Console.WriteLine($"    Positive confidence score: {sentimentInSentence.ConfidenceScores.Positive}.");
            Console.WriteLine($"    Neutral confidence score: {sentimentInSentence.ConfidenceScores.Neutral}.");
            Console.WriteLine($"    Negative confidence score: {sentimentInSentence.ConfidenceScores.Negative}.");
            Console.WriteLine("");
        }
    }
    Console.WriteLine("");
}
```

To analyze the sentiment of a collection of documents in different languages, call `AnalyzeSentimentBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentBatch
string documentA = @"The food and service were unacceptable, but the concierge were nice.
                    After talking to them about the quality of the food and the process
                    to get room service they refunded the money we spent at the restaurant and
                    gave us a voucher for nearby restaurants.";

string documentB = @"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia
                    sabía de nuestra celebración y me ayudaron a tenerle una sorpresa a mi pareja.
                    La habitación estaba limpia y decorada como yo había pedido. Una gran experiencia.
                    El próximo año volveremos.";

string documentC = @"The rooms were beautiful. The AC was good and quiet, which was key for us as outside
                    it was 100F and our baby was getting uncomfortable because of the heat. The breakfast
                    was good too with good options and good servicing times.
                    The thing we didn't like was that the toilet in our bathroom was smelly.
                    It could have been that the toilet was not cleaned before we arrived.
                    Either way it was very uncomfortable. Once we notified the staff, they came and cleaned
                    it and left candles.";

var documents = new List<TextDocumentInput>
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

var options = new AnalyzeSentimentOptions { IncludeStatistics = true };

Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(documents, options);
AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{sentimentPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (AnalyzeSentimentResult sentimentInDocument in sentimentPerDocuments)
{
    TextDocumentInput document = documents[i++];

    Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

    if (sentimentInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error: {sentimentInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {sentimentInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"Document sentiment is {sentimentInDocument.DocumentSentiment.Sentiment}, with confidence scores: ");
        Console.WriteLine($"  Positive confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Positive}.");
        Console.WriteLine($"  Neutral confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Neutral}.");
        Console.WriteLine($"  Negative confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Negative}.");
        Console.WriteLine("");
        Console.WriteLine($"  Sentence sentiment results:");

        foreach (SentenceSentiment sentimentInSentence in sentimentInDocument.DocumentSentiment.Sentences)
        {
            Console.WriteLine($"  For sentence: \"{sentimentInSentence.Text}\"");
            Console.WriteLine($"  Sentiment is {sentimentInSentence.Sentiment}, with confidence scores: ");
            Console.WriteLine($"    Positive confidence score: {sentimentInSentence.ConfidenceScores.Positive}.");
            Console.WriteLine($"    Neutral confidence score: {sentimentInSentence.ConfidenceScores.Neutral}.");
            Console.WriteLine($"    Negative confidence score: {sentimentInSentence.ConfidenceScores.Negative}.");
            Console.WriteLine("");
        }

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {sentimentInDocument.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {sentimentInDocument.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {sentimentPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {sentimentPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {sentimentPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {sentimentPerDocuments.Statistics.TransactionCount}");
```

To see the full example source files, see:

* [Synchronous AnalyzeSentiment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentiment.cs)
* [Asynchronous AnalyzeSentiment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentAsync.cs)
* [Synchronous AnalyzeSentimentBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatch.cs)
* [Asynchronous AnalyzeSentimentBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchAsync.cs)
* [Synchronous AnalyzeSentimentBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs)
* [Asynchronous AnalyzeSentimentBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
