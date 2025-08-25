# Performing named entity recognition (NER)

This sample demonstrates how to recognize named entities in one or more documents.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognize entities in multiple documents

To recognize entities in multiple documents, call `AnalyzeText` on the `TextAnalysisClient` by passing the documents as an `AnalyzeTextInput` parameter. This returns a `AnalyzeTextEntitiesResult`.

```C# Snippet:Sample4_AnalyzeText_RecognizeEntities
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
    + " offers services for childcare in case you want that.";

string textB =
    "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
    + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
    + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

string textC =
    "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
    + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
    + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
    + " great. We will definitely come back.";

string textD = string.Empty;

AnalyzeTextInput body = new TextEntityRecognitionInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "es" },
            new MultiLanguageInput("C", textC) { Language = "en" },
            new MultiLanguageInput("D", textD),
        }
    },
    ActionContent = new EntitiesActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = client.AnalyzeText(body);
AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

    Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

    foreach (NamedEntityWithMetadata entity in nerResult.Entities)
    {
        Console.WriteLine($"    Text: {entity.Text}");
        Console.WriteLine($"    Offset: {entity.Offset}");
        Console.WriteLine($"    Length: {entity.Length}");
        Console.WriteLine($"    Category: {entity.Category}");
        Console.WriteLine($"    Type: {entity.Type}");
        Console.WriteLine($"    Tags:");
        foreach (EntityTag tag in entity.Tags)
        {
            Console.WriteLine($"            TagName: {tag.Name}");
            Console.WriteLine($"            TagConfidenceScore: {tag.ConfidenceScore}");
        }
        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
        Console.WriteLine();
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
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
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
