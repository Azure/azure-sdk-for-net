# Extracting Key Phrases from Documents

This sample demonstrates how to extract key phrases from one or more documents.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Extracting key phrases from a single document

To extract key phrases from a document, use the `ExtractKeyPhrases` method.  The returned value the collection of `KeyPhrases` that were extracted from the document.

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

## Extracting key phrases from multiple documents

To extract key phrases from multiple documents, call `ExtractKeyPhrasesBatch` on an `IEnumerable` of strings.  The results are returned as a `ExtractKeyPhrasesResultCollection`.

```C# Snippet:Sample3_ExtractKeyPhrasesBatchConvenience
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

Response<ExtractKeyPhrasesResultCollection> response = client.ExtractKeyPhrasesBatch(batchedDocuments);
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

To extract key phrases from a collection of documents in different languages, call `ExtractKeyPhrasesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:Sample3_ExtractKeyPhrasesBatch
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

TextAnalyticsRequestOptions options = new() { IncludeStatistics = true };
Response<ExtractKeyPhrasesResultCollection> response = client.ExtractKeyPhrasesBatch(batchedDocuments, options);
ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Extract Key Phrases, model version: \"{keyPhrasesInDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (ExtractKeyPhrasesResult documentResult in keyPhrasesInDocuments)
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

    Console.WriteLine($"  Extracted {documentResult.KeyPhrases.Count()} key phrases:");

    foreach (string keyPhrase in documentResult.KeyPhrases)
    {
        Console.WriteLine($"    {keyPhrase}");
    }

    Console.WriteLine();

    Console.WriteLine($"  Document statistics:");
    Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
    Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
    Console.WriteLine();
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {keyPhrasesInDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {keyPhrasesInDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {keyPhrasesInDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {keyPhrasesInDocuments.Statistics.TransactionCount}");
Console.WriteLine();
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
