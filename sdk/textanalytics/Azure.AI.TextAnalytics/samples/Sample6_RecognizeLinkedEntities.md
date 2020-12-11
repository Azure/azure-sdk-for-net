# Recognizing Linked Entities in Documents
This sample demonstrates how to recognize linked entities in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize linked entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing linked entities in a single document

To recognize linked entities in a document, use the `RecognizeLinkedEntities` method.  The returned value is the collection of `LinkedEntities` containing entities recognized in the document as well as links to those entities in a reference data source, such as Wikipedia.

```C# Snippet:RecognizeLinkedEntities
string document = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                    Steve Ballmer, eventually became CEO after Bill Gates as well. Steve Ballmer eventually stepped
                    down as CEO of Microsoft, and was succeeded by Satya Nadella.
                    Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                    headquartered in Redmond";

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
            Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
        }
        Console.WriteLine("");
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Recognizing linked entities in multiple documents

To recognize linked entities in multiple documents, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizeLinkedEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
string documentA = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                    Steve Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped
                    down as CEO of Microsoft, and was succeeded by Satya Nadella.
                    Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                    headquartered in Redmond";

string documentB = @"Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and 
                    sell BASIC interpreters for the Altair 8800. During his career at Microsoft, Gates held
                    the positions of chairman chief executive officer, president and chief software architect
                    while also being the largest individual shareholder until May 2014.";

string documentC = string.Empty;

var documents = new List<string>
{
    documentA,
    documentB,
    documentC
};

Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(documents);
RecognizeLinkedEntitiesResultCollection entitiesInDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{entitiesInDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizeLinkedEntitiesResult entitiesInDocument in entitiesInDocuments)
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
        Console.WriteLine($"Recognized {entitiesInDocument.Entities.Count} entities:");
        foreach (LinkedEntity linkedEntity in entitiesInDocument.Entities)
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
                Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
            }
            Console.WriteLine("");
        }
    }
    Console.WriteLine("");
}
```

To recognize linked entities in a collection of documents in different languages, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
string documentA = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                    Steve Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped
                    down as CEO of Microsoft, and was succeeded by Satya Nadella.
                    Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                    headquartered in Redmond";

string documentB = @"El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él
                    empezó como Ingeniero de Software en el año 1992.";

string documentC = @"Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and 
                    sell BASIC interpreters for the Altair 8800. During his career at Microsoft, Gates held
                    the positions of chairman chief executive officer, president and chief software architect
                    while also being the largest individual shareholder until May 2014.";

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
Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(documents, options);
RecognizeLinkedEntitiesResultCollection entitiesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{entitiesPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizeLinkedEntitiesResult entitiesInDocument in entitiesPerDocuments)
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
        Console.WriteLine($"Recognized {entitiesInDocument.Entities.Count} entities:");
        foreach (LinkedEntity linkedEntity in entitiesInDocument.Entities)
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
                Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
            }
            Console.WriteLine("");
        }

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {entitiesInDocument.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {entitiesInDocument.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {entitiesPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {entitiesPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {entitiesPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {entitiesPerDocuments.Statistics.TransactionCount}");
Console.WriteLine("");
```

To see the full example source files, see:

* [Synchronous RecognizeLinkedEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntities.cs)
* [Asynchronous RecognizeLinkedEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesAsync.cs)
* [Synchronous RecognizeLinkedEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs)
* [Asynchronous RecognizeLinkedEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatchAsync.cs)
* [Synchronous RecognizeLinkedEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenience.cs)
* [Asynchronous RecognizeLinkedEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md