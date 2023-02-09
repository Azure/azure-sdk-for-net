# Analyzing healthcare entities
This sample demonstrates how to analyze healthcare entities in one or more documents.

## Create a `TextAnalyticsClient`
To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform text analysis on healthcare documents
To analyze healthcare entities in multiple healthcare documents, call `StartAnalyzeHealthcareEntities` on the `TextAnalyticsClient` by passing the documents as an `IEnumerable<string>` parameter. This returns an `AnalyzeHealthcareEntitiesOperation`, which is a long-running operation that can be used to poll the service until the operation has completed and the results of the text analysis are available.

```C# Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsync
// Get the documents.
string document1 =
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

string document2 = "Prescribed 100mg ibuprofen, taken twice daily.";

// Prepare the input of the text analysis operation.
List<string> documentBatch = new()
{
    document1,
    document2
};

// Start the text analysis operation.
AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(documentBatch);

await healthOperation.WaitForCompletionAsync();

Console.WriteLine($"The operation has completed.");
Console.WriteLine();
```

The `AnalyzeHealthcareEntitiesOperation` includes general information about the status of the operation, and it can be queried at any time:

```C# Snippet:TextAnalyticsSampleHealthcareOperationStatus
// View the operation status.
Console.WriteLine($"Created On   : {healthOperation.CreatedOn}");
Console.WriteLine($"Expires On   : {healthOperation.ExpiresOn}");
Console.WriteLine($"Id           : {healthOperation.Id}");
Console.WriteLine($"Status       : {healthOperation.Status}");
Console.WriteLine($"Last Modified: {healthOperation.LastModified}");
Console.WriteLine();
```

Once the long-running operation has completed, you can view the results of the text analysis, including any errors that might have occurred:

```C# Snippet:TextAnalyticsSampleHealthcareConvenienceAsyncViewResults
// View the operation results.
await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.Value)
{
    Console.WriteLine($"Results of \"Healthcare\" Model, version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine();

    foreach (AnalyzeHealthcareEntitiesResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}.");
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

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
