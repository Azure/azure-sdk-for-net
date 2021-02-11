# Recognizing Personally Identifiable Information in Documents
This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents. To get started you'll need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize Personally Identifiable Information in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if neded, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing Personally Identifiable Information in a single document

To recognize Personally Identifiable Information in a document, use the `RecognizePiiEntities` method.  The returned value is the collection of `PiiEntity` containing Personally Identifiable Information that were recognized in the document.

```C# Snippet:RecognizePiiEntities
string document = @"Parker Doe has repaid all of their loans as of 2020-04-25.
                    Their SSN is 859-98-0987. To contact them, use their phone number 800-102-1100.
                    They are originally from Brazil and have document ID number 998.214.865-68";

try
{
    Response<PiiEntityCollection> response = client.RecognizePiiEntities(document);
    PiiEntityCollection entities = response.Value;

    Console.WriteLine($"Redacted Text: {entities.RedactedText}");
    Console.WriteLine("");
    Console.WriteLine($"Recognized {entities.Count} PII entities:");
    foreach (PiiEntity entity in entities)
    {
        Console.WriteLine($"  Text: {entity.Text}");
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

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizePiiEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
string documentA = @"Parker Doe has repaid all of their loans as of 2020-04-25.
                    Their SSN is 859-98-0987. To contact them, use their phone number 800-102-1100.
                    They are originally from Brazil and have document ID number 998.214.865-68";

string documentB = @"Yesterday, Dan Doe was asking where they could find the ABA number. I explained
                    that it is the first 9 digits in the lower left hand corner of their personal check.
                    After looking at their account they confirmed the number was 111000025";

string documentC = string.Empty;

var documents = new List<string>
{
    documentA,
    documentB,
    documentC
};

Response<RecognizePiiEntitiesResultCollection> response = client.RecognizePiiEntitiesBatch(documents);
RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"PII Entity Recognition\" Model, version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizePiiEntitiesResult piiEntititesInDocument in entititesPerDocuments)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine("");

    if (piiEntititesInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {piiEntititesInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {piiEntititesInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Redacted Text: {piiEntititesInDocument.Entities.RedactedText}");
        Console.WriteLine("");
        Console.WriteLine($"  Recognized {piiEntititesInDocument.Entities.Count} PII entities:");
        foreach (PiiEntity piiEntity in piiEntititesInDocument.Entities)
        {
            Console.WriteLine($"    Text: {piiEntity.Text}");
            Console.WriteLine($"    Category: {piiEntity.Category}");
            if (!string.IsNullOrEmpty(piiEntity.SubCategory))
                Console.WriteLine($"    SubCategory: {piiEntity.SubCategory}");
            Console.WriteLine($"    Confidence score: {piiEntity.ConfidenceScore}");
            Console.WriteLine("");
        }
    }
    Console.WriteLine("");
}
```

To recognize Personally Identifiable Information in a collection of documents in different languages, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesBatch
string documentA = @"Parker Doe has repaid all of their loans as of 2020-04-25.
                    Their SSN is 859-98-0987. To contact them, use their phone number 800-102-1100.
                    They are originally from Brazil and have document ID number 998.214.865-68";

string documentB = @"Hoy recibí una llamada al medio día del usuario Juanito Perez, quien preguntaba
                    cómo acceder a su nuevo correo electrónico. Este trabaja en Microsoft y su correo es
                    juanito.perez@contoso.com. El usuario accedió a compartir su número para futuras comunicaciones.
                    El número es 800-102-1101";

string documentC = @"Yesterday, Dan Doe was asking where they could find the ABA number. I explained
                    that it is the first 9 digits in the lower left hand corner of their personal check.
                    After looking at their account they confirmed the number was 111000025";

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
    }
};

var options = new RecognizePiiEntitiesOptions { IncludeStatistics = true };
Response<RecognizePiiEntitiesResultCollection> response = client.RecognizePiiEntitiesBatch(documents, options);
RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

int i = 0;
Console.WriteLine($"Results of Azure Text Analytics \"PII Entity Recognition\" Model, version: \"{entititesPerDocuments.ModelVersion}\"");
Console.WriteLine("");

foreach (RecognizePiiEntitiesResult piiEntititesInDocument in entititesPerDocuments)
{
    TextDocumentInput document = documents[i++];

    Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

    if (piiEntititesInDocument.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {piiEntititesInDocument.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {piiEntititesInDocument.Error.Message}");
    }
    else
    {
        Console.WriteLine($"  Redacted Text: {piiEntititesInDocument.Entities.RedactedText}");
        Console.WriteLine("");
        Console.WriteLine($"  Recognized {piiEntititesInDocument.Entities.Count} PII entities:");
        foreach (PiiEntity piiEntity in piiEntititesInDocument.Entities)
        {
            Console.WriteLine($"    Text: {piiEntity.Text}");
            Console.WriteLine($"    Category: {piiEntity.Category}");
            if (!string.IsNullOrEmpty(piiEntity.SubCategory))
                Console.WriteLine($"    SubCategory: {piiEntity.SubCategory}");
            Console.WriteLine($"    Confidence score: {piiEntity.ConfidenceScore}");
            Console.WriteLine("");
        }

        Console.WriteLine($"  Document statistics:");
        Console.WriteLine($"    Character count: {piiEntititesInDocument.Statistics.CharacterCount}");
        Console.WriteLine($"    Transaction count: {piiEntititesInDocument.Statistics.TransactionCount}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"Batch operation statistics:");
Console.WriteLine($"  Document count: {entititesPerDocuments.Statistics.DocumentCount}");
Console.WriteLine($"  Valid document count: {entititesPerDocuments.Statistics.ValidDocumentCount}");
Console.WriteLine($"  Invalid document count: {entititesPerDocuments.Statistics.InvalidDocumentCount}");
Console.WriteLine($"  Transaction count: {entititesPerDocuments.Statistics.TransactionCount}");
Console.WriteLine("");
```

To see the full example source files, see:
* [Synchronous RecognizePiiEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntities.cs)
* [Asynchronous RecognizePiiEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesAsync.cs)
* [Synchronous RecognizePiiEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatch.cs)
* [Asynchronous RecognizePiiEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchAsync.cs)
* [Synchronous RecognizePiiEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs)
* [Asynchronous RecognizePiiEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md