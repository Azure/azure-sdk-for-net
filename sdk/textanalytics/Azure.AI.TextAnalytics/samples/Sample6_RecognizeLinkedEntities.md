# Recognizing Linked Entities in Documents

This sample demonstrates how to recognize linked entities in one or more documents. To get started you will need a Cognitive Services or Language service endpoint and credentials.  See [README][README] for links and instructions.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognizing linked entities in a single document

To recognize linked entities in a document, use the `RecognizeLinkedEntities` method.  The returned value is the collection of `LinkedEntities` containing entities recognized in the document as well as links to those entities in a reference data source, such as Wikipedia.

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

## Recognizing linked entities in multiple documents

To recognize linked entities in multiple documents, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizeLinkedEntitiesResultCollection`.

```C# Snippet:Sample6_RecognizeLinkedEntitiesBatchConvenience
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

Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(batchedDocuments);
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

To recognize linked entities in a collection of documents in different languages, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:Sample6_RecognizeLinkedEntitiesBatch
string documentA =
    "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
    + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
    + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
    + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond.";

string documentB =
    "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
    + " Ingeniero de Software en el año 1992.";

string documentC =
    "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
    + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
    + " chairman chief executive officer, president and chief software architect while also being the"
    + " largest individual shareholder until May 2014.";

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
Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(batchedDocuments, options);
RecognizeLinkedEntitiesResultCollection entitiesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Recognize Linked Entities, model version: \"{entitiesPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (RecognizeLinkedEntitiesResult documentResult in entitiesPerDocuments)
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

    Console.WriteLine($"  Document statistics:");
    Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
    Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
    Console.WriteLine();
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {entitiesPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {entitiesPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {entitiesPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {entitiesPerDocuments.Statistics.TransactionCount}");
Console.WriteLine();
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
