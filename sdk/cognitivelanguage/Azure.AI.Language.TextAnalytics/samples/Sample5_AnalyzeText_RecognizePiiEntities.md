# Recognizing Personally Identifiable Information in Documents

This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents.

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `AnalyzeText` on an `AnalyzeTextPIIEntitiesRecognitionInput`.  The results are returned as a `PIITaskResult`.

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

AnalyzeTextTask body = new AnalyzeTextPIIEntitiesRecognitionInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "es"),
            new MultiLanguageInput("C", documentC, "en"),
        }
    },
    Parameters = new PIITaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
PIITaskResult piiTaskResult = (PIITaskResult)response.Value;

foreach (PIIResultWithDetectedLanguage piiResult in piiTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");

    Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

    foreach (Entity entity in piiResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        if (!string.IsNullOrEmpty(entity.Subcategory))
            Console.WriteLine($"    SubCategory: {entity.Subcategory}");
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
{
    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
    Console.WriteLine();
    continue;
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
