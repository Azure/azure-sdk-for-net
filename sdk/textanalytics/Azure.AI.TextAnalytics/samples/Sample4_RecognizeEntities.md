# Recognizing Entities from Documents
This sample demonstrates how to recognize entities in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing entities in a single document

To recognize entities in a document, use the `RecognizeEntities` method.  The returned type is the collection of `CategorizedEntity` that were recognized in the document.

```C# Snippet:RecognizeEntities
string document = @"We love this trail and make the trip every year. The views are breathtaking and well
                    worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                    We tried again today and it was amazing. Everyone in my family liked the trail although
                    it was too challenging for the less athletic among us.
                    Not necessarily recommended for small children.
                    A hotel close to the trail offers services for childcare in case you want that.";

try
{
    Response<CategorizedEntityCollection> response = client.RecognizeEntities(document);
    CategorizedEntityCollection entitiesInDocument = response.Value;

    Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
    foreach (CategorizedEntity entity in entitiesInDocument)
    {
        Console.WriteLine($"  Text: {entity.Text}");
        Console.WriteLine($"  Offset: {entity.Offset}");
        Console.WriteLine($"  Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
        Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine("");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Recognizing entities in multiple documents

To recognize entities in multiple documents, call `RecognizeEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizeEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesConvenience
string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                    worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                    We tried again today and it was amazing. Everyone in my family liked the trail although
                    it was too challenging for the less athletic among us.
                    Not necessarily recommended for small children.
                    A hotel close to the trail offers services for childcare in case you want that.";

string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                    our anniversary so they helped me organize a little surprise for my partner.
                    The room was clean and with the decoration I requested. It was perfect!";

string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                    They had great amenities that included an indoor pool, a spa, and a bar.
                    The spa offered couples massages which were really good. 
                    The spa was clean and felt very peaceful. Overall the whole experience was great.
                    We will definitely come back.";

string documentD = string.Empty;

var documents = new List<string>
{
    documentA,
    documentB,
    documentC,
    documentD
};

Response<RecognizeEntitiesResultCollection> response = client.RecognizeEntitiesBatch(documents);
RecognizeEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Named Entity Recognition\" Model, version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizeEntitiesResult entitiesInDocument in entititesPerDocuments)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine("");

    if (entitiesInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {entitiesInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {entitiesInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Recognized the following {entitiesInDocument.Entities.Count()} entities:");

        foreach (CategorizedEntity entity in entitiesInDocument.Entities)
        {
            Console.WriteLine($"    Text: {entity.Text}");
            Console.WriteLine($"    Offset: {entity.Offset}");
            Console.WriteLine($"    Category: {entity.Category}");
            if (!string.IsNullOrEmpty(entity.SubCategory))
                Console.WriteLine($"    SubCategory: {entity.SubCategory}");
            Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
            Console.WriteLine("");
        }
    }
    Console.WriteLine("");
}
```

To recognize entities in a collection of documents in different languages, call `RecognizeEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesBatch
string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                    worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                    We tried again today and it was amazing. Everyone in my family liked the trail although
                    it was too challenging for the less athletic among us.
                    Not necessarily recommended for small children.
                    A hotel close to the trail offers services for childcare in case you want that.";

string documentB = @"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia
                    sabía de nuestra celebración y me ayudaron a tenerle una sorpresa a mi pareja.
                    La habitación estaba limpia y decorada como yo había pedido. Una gran experiencia.
                    El próximo año volveremos.";

string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                    They had great amenities that included an indoor pool, a spa, and a bar.
                    The spa offered couples massages which were really good. 
                    The spa was clean and felt very peaceful. Overall the whole experience was great.
                    We will definitely come back.";

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

var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
Response<RecognizeEntitiesResultCollection> response = client.RecognizeEntitiesBatch(documents, options);
RecognizeEntitiesResultCollection entitiesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Named Entity Recognition\" Model, version: \"{entitiesInDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizeEntitiesResult entitiesInDocument in entitiesInDocuments)
{
    TextDocumentInput document = documents[i++];

    Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

    if (entitiesInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {entitiesInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {entitiesInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Recognized the following {entitiesInDocument.Entities.Count()} entities:");

        foreach (CategorizedEntity entity in entitiesInDocument.Entities)
        {
            Console.WriteLine($"    Text: {entity.Text}");
            Console.WriteLine($"    Offset: {entity.Offset}");
            Console.WriteLine($"    Category: {entity.Category}");
            if (!string.IsNullOrEmpty(entity.SubCategory))
                Console.WriteLine($"    SubCategory: {entity.SubCategory}");
            Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
            Console.WriteLine("");
        }

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {entitiesInDocument.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {entitiesInDocument.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {entitiesInDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {entitiesInDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {entitiesInDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {entitiesInDocuments.Statistics.TransactionCount}");
Console.WriteLine("");
```

To see the full example source files, see:

* [Synchronously RecognizeEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntities.cs)
* [Asynchronously RecognizeEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesAsync.cs)
* [Synchronously RecognizeEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatch.cs)
* [Asynchronously RecognizeEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchAsync.cs)
* [Synchronously RecognizeEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchConvenience.cs)
* [Asynchronously RecognizeEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md