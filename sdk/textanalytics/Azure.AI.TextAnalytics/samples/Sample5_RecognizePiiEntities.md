# Recognizing Personally Identifiable Information in Documents

This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognizing Personally Identifiable Information in a single document

To recognize Personally Identifiable Information in a document, use the `RecognizePiiEntities` method.  The returned value is the collection of `PiiEntity` containing Personally Identifiable Information that were recognized in the document.

```C# Snippet:Sample5_RecognizePiiEntities
string document =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

try
{
    Response<PiiEntityCollection> response = client.RecognizePiiEntities(document);
    PiiEntityCollection entities = response.Value;

    Console.WriteLine($"Redacted Text: {entities.RedactedText}");
    Console.WriteLine();
    Console.WriteLine($"Recognized {entities.Count} PII entities:");
    foreach (PiiEntity entity in entities)
    {
        Console.WriteLine($"  Text: {entity.Text}");
        Console.WriteLine($"  Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.SubCategory))
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
        Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizePiiEntitiesResultCollection`.

```C# Snippet:Sample5_RecognizePiiEntitiesBatchConvenience
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

Response<RecognizePiiEntitiesResultCollection> response = client.RecognizePiiEntitiesBatch(batchedDocuments);
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

To recognize Personally Identifiable Information in a collection of documents in different languages, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:Sample5_RecognizePiiEntitiesBatch
string documentA =
    "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
    + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
    + " 998.214.865-68.";

string documentB =
    "Hoy recibí una llamada al medio día del usuario Juanito Perez, quien preguntaba cómo acceder a su"
    + " nuevo correo electrónico. Este trabaja en Microsoft y su correo es juanito.perez@contoso.com. El"
    + " usuario accedió a compartir su número para futuras comunicaciones. El número es 800-102-1101.";

string documentC =
    "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
    + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
    + " they confirmed the number was 111000025.";

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
    }
};

RecognizePiiEntitiesOptions options = new() { IncludeStatistics = true };
Response<RecognizePiiEntitiesResultCollection> response = client.RecognizePiiEntitiesBatch(batchedDocuments, options);
RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Recognize PII Entities, model version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine();

foreach (RecognizePiiEntitiesResult documentResult in entititesPerDocuments)
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

    Console.WriteLine($"  Document statistics:");
    Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
    Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
    Console.WriteLine();
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {entititesPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {entititesPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {entititesPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {entititesPerDocuments.Statistics.TransactionCount}");
Console.WriteLine();
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
