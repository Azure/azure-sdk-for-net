# Analyzing the Sentiment of Documents

This sample demonstrates how to analyze the sentiment in one or more documents.

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Analyzing the sentiment of adocuments

To analyze the sentiment of a document, use the `AnalyzeText` method.  The returned `SentimentTaskResult` describes the sentiment of the document, as well as a collection of `Sentences` indicating the sentiment of each individual sentence.

```C# Snippet:Sample2_AnalyzeSentiment
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

    foreach (SentimentDocumentResult docSentiment in sentimentTaskResult.Results.Documents)
    {
        Console.WriteLine($"Document {docSentiment.Id} sentiment is {docSentiment.Sentiment} with: ");
        Console.WriteLine($"  Positive confidence score: {docSentiment.ConfidenceScores.Positive}");
        Console.WriteLine($"  Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}");
        Console.WriteLine($"  Negative confidence score: {docSentiment.ConfidenceScores.Negative}");
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

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
