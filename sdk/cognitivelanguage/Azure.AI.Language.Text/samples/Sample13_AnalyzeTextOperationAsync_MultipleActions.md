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

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Summarize one or more text documents

To perform multiple actions on one or more text documents, call `AnalyzeTextOperationAsync` on the `TextAnalysisClient` client by passing the documents as a `MultiLanguageTextInput` parameter with the actions you want to take (in this example the actions are `EntitiesOperationAction` and `KeyPhraseOperationAction`). This returns an `Response<AnalyzeTextOperationState>` which you can extract the results of the actions you chose for you input (in this example the actions are `EntityRecognitionOperationResult` and `KeyPhraseExtractionOperationResult`).

```C# Snippet:Sample13_AnalyzeTextOperationAsync_MultipleActions
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

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "es" },
        new MultiLanguageInput("C", textC) { Language = "en" },
        new MultiLanguageInput("D", textD),
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new EntitiesOperationAction
    {
        Name = "EntitiesOperationActionSample", // Optional string for humans to identify action by name.
    },
    new KeyPhraseOperationAction
    {
        Name = "KeyPhraseOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is EntityRecognitionOperationResult)
    {
        EntityRecognitionOperationResult entityRecognitionLROResult = (EntityRecognitionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (EntityActionResultWithMetadata nerResult in entityRecognitionLROResult.Results.Documents)
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
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (DocumentError error in entityRecognitionLROResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
    }

    if (analyzeTextLROResult is KeyPhraseExtractionOperationResult)
    {
        KeyPhraseExtractionOperationResult keyPhraseExtractionLROResult = (KeyPhraseExtractionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (KeyPhrasesActionResult kpeResult in keyPhraseExtractionLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
            foreach (string keyPhrase in kpeResult.KeyPhrases)
            {
                Console.WriteLine($"    {keyPhrase}");
            }
            Console.WriteLine();
        }
        // View the errors in the document
        foreach (DocumentError error in keyPhraseExtractionLROResult.Results.Errors)
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
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
