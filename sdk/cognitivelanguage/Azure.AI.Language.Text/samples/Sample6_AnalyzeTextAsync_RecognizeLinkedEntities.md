# Recognizing Linked Entities in Documents

This sample demonstrates how to recognize linked entities in one or more documents. To get started you will need a Cognitive Services or Language service endpoint and credentials.  See [README][README] for links and instructions.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Recognizing linked entities in multiple documents

To recognize linked entities in multiple documents, call `AnalyzeText` on an TextEntityLinkingInput.  The results are returned as a `AnalyzeTextEntityLinkingResult`.

```C# Snippet:Sample6_AnalyzeTextAsync_RecognizeLinkedEntities
string textA =
    "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
    + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
    + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
    + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

string textB =
    "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
    + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
    + " chairman chief executive officer, president and chief software architect while also being the"
    + " largest individual shareholder until May 2014.";

string textC =
    "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
    + " Ingeniero de Software en el año 1992.";

string textD = string.Empty;

AnalyzeTextInput body = new TextEntityLinkingInput()
{
    TextInput = new MultiLanguageTextInput()
    {
        MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
            new MultiLanguageInput("B", textB) { Language = "en" },
            new MultiLanguageInput("C", textC) { Language = "es" },
            new MultiLanguageInput("D", textD),
        }
    },
    ActionContent = new EntityLinkingActionContent()
    {
        ModelVersion = "latest",
    }
};

Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
AnalyzeTextEntityLinkingResult entityLinkingTaskResult = (AnalyzeTextEntityLinkingResult)response.Value;

foreach (EntityLinkingActionResult entityLinkingResult in entityLinkingTaskResult.Results.Documents)
{
    Console.WriteLine($"Result for document with Id = \"{entityLinkingResult.Id}\":");
    Console.WriteLine($"Recognized {entityLinkingResult.Entities.Count} entities:");
    foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
    {
        Console.WriteLine($"  Name: {linkedEntity.Name}");
        Console.WriteLine($"  LanguageClient: {linkedEntity.Language}");
        Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
        Console.WriteLine($"  URL: {linkedEntity.Url}");
        Console.WriteLine($"  NamedEntity Id in Data Source: {linkedEntity.Id}");
        foreach (EntityLinkingMatch match in linkedEntity.Matches)
        {
            Console.WriteLine($"    EntityLinkingMatch Text: {match.Text}");
            Console.WriteLine($"    Offset: {match.Offset}");
            Console.WriteLine($"    Length: {match.Length}");
            Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
        }
    }
    Console.WriteLine();
}

foreach (DocumentError analyzeTextDocumentError in entityLinkingTaskResult.Results.Errors)
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
