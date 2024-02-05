# Performing named entity recognition (NER)

This sample demonstrates how to recognize named entities in one or more documents.

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognize entities in multiple documents

To recognize entities in multiple documents, call `AnalyzeText` on the `AnalyzeTextClient` by passing the documents as an `AnalyzeTextTask` parameter. This returns a `EntitiesTaskResult

`.

```C# Snippet:Sample4_AnalyzeText_RecognizeEntities
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

AnalyzeTextTask body = new AnalyzeTextEntityRecognitionInput()
{
    AnalysisInput = new MultiLanguageAnalysisInput()
    {
        Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "es"),
            new MultiLanguageInput("C", documentC, "en"),
            new MultiLanguageInput("D", documentD),
        }
    },
    Parameters = new EntitiesTaskParameters()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
EntitiesTaskResult entitiesTaskResult = (EntitiesTaskResult)response.Value;

foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entitiesTaskResult.Results.Documents)
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

foreach (AnalyzeTextDocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
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
