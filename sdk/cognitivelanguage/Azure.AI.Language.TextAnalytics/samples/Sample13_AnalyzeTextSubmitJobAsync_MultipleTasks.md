# Summarize documents with abstractive summarization

This sample demonstrates how to perform multiple text analysis actions on one or more documents. These actions can include:

- Named Entities Recognition
- PII Entities Recognition
- Linked Entity Recognition
- Key Phrase Extraction
- Sentiment Analysis
- Extractive Summarization
- Custom Named Entity Recognition
- Custom Text Classification

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new(TestEnvironment.ApiKey);
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Summarize one or more text documents

To perform multiple actions on one or more text documents, call `AnalyzeTextSubmitJob` on the `Language` client by passing the documents as a `MultiLanguageAnalysisInput` parameter. This returns an `Operation`. Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the text analysis actions, including any errors that might have occurred.

```C# Snippet:Sample13_AnalyzeTextSubmitJobAsync_MultipleTasks
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

string documentD = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
{
    Documents =
    {
        new MultiLanguageInput("A", documentA, "en"),
        new MultiLanguageInput("B", documentB, "es"),
        new MultiLanguageInput("C", documentC, "en"),
        new MultiLanguageInput("D", documentD),
    }
};

AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
{
    new EntitiesLROTask(),
    new KeyPhraseLROTask(),
});

Operation operation = await client.AnalyzeTextSubmitJobAsync(WaitUntil.Completed, analyzeTextJobsInput);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the operation, including any errors that might have occurred:

```C# Snippet:Sample13_AnalyzeTextSubmitJobAsync_MultipleTasks_ViewResults
// View the operation results.
AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
{
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.EntityRecognitionLROResults)
    {
        EntityRecognitionLROResult entityRecognitionLROResult = (EntityRecognitionLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entityRecognitionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

            Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

            foreach (EntityWithMetadata entity in nerResult.Entities)
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
        // View the errors in the document
        foreach (AnalyzeTextDocumentError error in entityRecognitionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
    Console.WriteLine();
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.KeyPhraseExtractionLROResults)
    {
        KeyPhraseExtractionLROResult keyPhraseExtractionLROResult = (KeyPhraseExtractionLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseExtractionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
            foreach (string keyPhrase in kpeResult.KeyPhrases)
            {
                Console.WriteLine($"    {keyPhrase}");
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (AnalyzeTextDocumentError error in keyPhraseExtractionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
