# Analyze healthcare entities

This sample demonstrates how to analyze healthcare entities in one or more documents.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Analyze healthcare entities in one or more text documents

To analyze healthcare entities in one or more text documents, call `AnalyzeHealthcareEntitiesAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns an `AnalyzeHealthcareEntitiesOperation`.

```C# Snippet:Sample7_AnalyzeHealthcareEntitiesConvenienceAsync_PerformOperation
string documentA =
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

string documentB = "Prescribed 100mg ibuprofen, taken twice daily.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB
};

// Perform the text analysis operation.
AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, batchedDocuments);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the healthcare entities analysis, including any errors that might have occurred:

```C# Snippet:Sample7_AnalyzeHealthcareEntitiesConvenienceAsync_ViewResults
// View the operation results.
await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in operation.Value)
{
    Console.WriteLine($"Analyze Healthcare Entities, model version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine();

    foreach (AnalyzeHealthcareEntitiesResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Recognized the following {documentResult.Entities.Count} healthcare entities:");
        Console.WriteLine();

        // View the healthcare entities that were recognized.
        foreach (HealthcareEntity entity in documentResult.Entities)
        {
            Console.WriteLine($"  Entity: {entity.Text}");
            Console.WriteLine($"  Category: {entity.Category}");
            Console.WriteLine($"  Offset: {entity.Offset}");
            Console.WriteLine($"  Length: {entity.Length}");
            Console.WriteLine($"  NormalizedText: {entity.NormalizedText}");
            Console.WriteLine($"  Links:");

            // View the entity data sources.
            foreach (EntityDataSource entityDataSource in entity.DataSources)
            {
                Console.WriteLine($"    Entity ID in Data Source: {entityDataSource.EntityId}");
                Console.WriteLine($"    DataSource: {entityDataSource.Name}");
            }

            // View the entity assertions.
            if (entity.Assertion is not null)
            {
                Console.WriteLine($"  Assertions:");

                if (entity.Assertion?.Association is not null)
                {
                    Console.WriteLine($"    Association: {entity.Assertion?.Association}");
                }

                if (entity.Assertion?.Certainty is not null)
                {
                    Console.WriteLine($"    Certainty: {entity.Assertion?.Certainty}");
                }

                if (entity.Assertion?.Conditionality is not null)
                {
                    Console.WriteLine($"    Conditionality: {entity.Assertion?.Conditionality}");
                }
            }
        }

        Console.WriteLine($"  We found {documentResult.EntityRelations.Count} relations in the current document:");
        Console.WriteLine();

        // View the healthcare entity relations that were recognized.
        foreach (HealthcareEntityRelation relation in documentResult.EntityRelations)
        {
            Console.WriteLine($"    Relation: {relation.RelationType}");
            if (relation.ConfidenceScore is not null)
            {
                Console.WriteLine($"    ConfidenceScore: {relation.ConfidenceScore}");
            }
            Console.WriteLine($"    For this relation there are {relation.Roles.Count} roles");

            // View the relation roles.
            foreach (HealthcareEntityRelationRole role in relation.Roles)
            {
                Console.WriteLine($"      Role Name: {role.Name}");

                Console.WriteLine($"      Associated Entity Text: {role.Entity.Text}");
                Console.WriteLine($"      Associated Entity Category: {role.Entity.Category}");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
