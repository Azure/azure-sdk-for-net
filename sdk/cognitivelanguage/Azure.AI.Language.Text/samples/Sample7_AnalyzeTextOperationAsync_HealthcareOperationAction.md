# Analyze healthcare entities

This sample demonstrates how to analyze healthcare entities in one or more documents.

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Analyze healthcare entities in one or more text documents

To analyze healthcare entities in one or more text documents, call `AnalyzeTextOperationAsync` on the `TextAnalysisClient` by passing the documents as `MultiLanguageTextInput` parameter and a `AnalyzeTextOperationAction` with a `HealthcareOperationAction` action. This returns an `Response<AnalyzeTextOperationState>` which you can extract the `HealthcareOperationResult`.

```C# Snippet:Sample7_AnalyzeTextOperationAsync_HealthcareOperationAction
string textA =
    "RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM |"
    + " CORONARY ARTERY DISEASE | Signed | DIS |"
    + Environment.NewLine
    + " Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001"
    + " ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE."
    + Environment.NewLine
    + " HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive"
    + " angina over the past several months. The patient had a cardiac catheterization in July of this"
    + " year revealing total occlusion of the RCA and 50% left main disease, with a strong family history"
    + " of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and"
    + " another brother who is status post coronary artery bypass grafting. The patient had a stress"
    + " echocardiogram done on July, 2001, which showed no wall motion abnormalities, but this was a"
    + " difficult study due to body habitus. The patient went for six minutes with minimal ST depressions"
    + " in the anterior lateral leads, thought due to fatigue and wrist pain, his anginal equivalent. Due"
    + " to the patient'sincreased symptoms and family history and history left main disease with total"
    + " occasional of his RCA was referred for revascularization with open heart surgery.";

string textB = "Prescribed 100mg ibuprofen, taken twice daily.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "en" },
    }
};

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new HealthcareOperationAction
    {
        Name = "HealthcareOperationActionSample", // Optional string for humans to identify action by name.
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is HealthcareOperationResult)
    {
        HealthcareOperationResult healthcareLROResult = (HealthcareOperationResult)analyzeTextLROResult;
        Console.WriteLine($"Analyze Healthcare Entities, model version: \"{healthcareLROResult.Results.ModelVersion}\"");
        Console.WriteLine();

        // View the healthcare entities recognized in the input documents.
        foreach (HealthcareActionResult healthcareEntitiesDocument in healthcareLROResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{healthcareEntitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized the following {healthcareEntitiesDocument.Entities.Count} healthcare entities:");
            foreach (HealthcareEntity healthcareEntity in healthcareEntitiesDocument.Entities)
            {
                Console.WriteLine($"  NamedEntity: {healthcareEntity.Text}");
                Console.WriteLine($"  Category: {healthcareEntity.Category}");
                Console.WriteLine($"  Offset: {healthcareEntity.Offset}");
                Console.WriteLine($"  Length: {healthcareEntity.Length}");
                Console.WriteLine($"  Name: {healthcareEntity.Name}");
                Console.WriteLine($"  Links:");

                // View the entity data sources.
                foreach (HealthcareEntityLink healthcareEntityLink in healthcareEntity.Links)
                {
                    Console.WriteLine($"    NamedEntity ID in Data Source: {healthcareEntityLink.Id}");
                    Console.WriteLine($"    DataSource: {healthcareEntityLink.DataSource}");
                }

                // View the entity assertions.
                if (healthcareEntity.Assertion is not null)
                {
                    Console.WriteLine($"  Assertions:");
                    if (healthcareEntity.Assertion?.Association is not null)
                    {
                        Console.WriteLine($"    HealthcareAssociation: {healthcareEntity.Assertion?.Association}");
                    }
                    if (healthcareEntity.Assertion?.Certainty is not null)
                    {
                        Console.WriteLine($"    HealthcareCertainty: {healthcareEntity.Assertion?.Certainty}");
                    }
                    if (healthcareEntity.Assertion?.Conditionality is not null)
                    {
                        Console.WriteLine($"    HealthcareConditionality: {healthcareEntity.Assertion?.Conditionality}");
                    }
                }
            }

            Console.WriteLine($"  We found {healthcareEntitiesDocument.Relations.Count} relations in the current document:");
            Console.WriteLine();

            // View the healthcare entity relations that were recognized.
            foreach (HealthcareRelation relation in healthcareEntitiesDocument.Relations)
            {
                Console.WriteLine($"    Relation: {relation.RelationType}");
                if (relation.ConfidenceScore is not null)
                {
                    Console.WriteLine($"    ConfidenceScore: {relation.ConfidenceScore}");
                }
                Console.WriteLine($"    For this relation there are {relation.Entities.Count} roles");

                // View the relations
                foreach (HealthcareRelationEntity healthcareRelationEntity in relation.Entities)
                {
                    Console.WriteLine($"      Role: {healthcareRelationEntity.Role}");
                    Console.WriteLine($"      Refrence: {healthcareRelationEntity.Ref}");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            // View the errors in the document
            foreach (DocumentError error in healthcareLROResult.Results.Errors)
            {
                Console.WriteLine($"  Error in document: {error.Id}!");
                Console.WriteLine($"  Document error code: {error.Error.Code}");
                Console.WriteLine($"  Message: {error.Error.Message}");
                continue;
            }
        }
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
