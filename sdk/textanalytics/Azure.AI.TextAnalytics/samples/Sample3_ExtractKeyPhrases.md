# Extracting Key Phrases from Documents

This sample demonstrates how to extract key phrases from one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to extract key phrases from a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Extracting key phrases from a single document

To extract key phrases from a document, use the `ExtractKeyPhrases` method.  The returned value the collection of `KeyPhrases` that were extracted from the document.

```C# Snippet:ExtractKeyPhrases
string document = @"My cat might need to see a veterinarian. It has been sneezing more than normal, and although my 
                    little sister thinks it is funny, I am worried it has the cold that I got last week.
                    We are going to call tomorrow and try to schedule an appointment for this week. Hopefully it
                    will be covered by the cat's insurance.
                    It might be good to not let it sleep in my room for a while.";

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

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesConvenience
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

Response<ExtractKeyPhrasesResultCollection> response = client.ExtractKeyPhrasesBatch(documents);
ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{keyPhrasesInDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (ExtractKeyPhrasesResult keyPhrases in keyPhrasesInDocuments)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine("");

    if (keyPhrases.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error: {keyPhrases.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {keyPhrases.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Extracted the following {keyPhrases.KeyPhrases.Count()} key phrases:");

        foreach (string keyPhrase in keyPhrases.KeyPhrases)
        {
            Console.WriteLine($"    {keyPhrase}");
        }
    }
    Console.WriteLine("");
}
```

To extract key phrases from a collection of documents in different languages, call `ExtractKeyPhrasesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesBatch
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
Response<ExtractKeyPhrasesResultCollection> response = client.ExtractKeyPhrasesBatch(documents, options);
ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{keyPhrasesInDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (ExtractKeyPhrasesResult keyPhrases in keyPhrasesInDocuments)
{
    TextDocumentInput document = documents[i++];

    Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

    if (keyPhrases.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error: {keyPhrases.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {keyPhrases.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Extracted the following {keyPhrases.KeyPhrases.Count()} key phrases:");

        foreach (string keyPhrase in keyPhrases.KeyPhrases)
        {
            Console.WriteLine($"    {keyPhrase}");
        }

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {keyPhrases.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {keyPhrases.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {keyPhrasesInDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {keyPhrasesInDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {keyPhrasesInDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {keyPhrasesInDocuments.Statistics.TransactionCount}");
Console.WriteLine("");
```

To see the full example source files, see:

* [Synchronous ExtractKeyPhrases](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrases.cs)
* [Asynchronous ExtractKeyPhrases](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesAsync.cs)
* [ExtractKeyPhrases with warnings](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesWithWarnings.cs)
* [Synchronous ExtractKeyPhrasesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatch.cs)
* [Asynchronous ExtractKeyPhrasesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchAsync.cs)
* [Synchronous ExtractKeyPhrasesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchConvenience.cs)
* [Asynchronous ExtractKeyPhrasesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
