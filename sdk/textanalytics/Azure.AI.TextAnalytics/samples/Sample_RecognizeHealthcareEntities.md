# Recognizing Healthcare Entities from Documents
This sample demonstrates how to recognize healthcare entities in one or more documents. To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize healthcare entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```
## Analyze Documents

To recognize healthcare entities in multiple documents, call `StartAnalyzeHealthcareEntities` on an `IEnumerable` of strings.  The result is a Long Running operation of type `AnalyzeHealthcareEntitiesOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSampleHealthcareConvenienceAnalyzeDocumentsAsync
// get input documents
string document1 = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | \
                    Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. \
                    HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. \
                    The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease ,\
                    with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and \
                    another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , \
                    which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with \
                    minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's \
                    increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.";

string document2 = "Prescribed 100mg ibuprofen, taken twice daily.";

// prepare analyze operation input
List<string> batchInput = new List<string>()
{
    document1,
    document2,
    string.Empty
};

var options = new AnalyzeHealthcareEntitiesOptions { };

// start analysis process
AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(batchInput, "en", options);

await healthOperation.WaitForCompletionAsync();
```
The returned healthcare operation contains general information about the status of the operation. It can be requested while the operation is running or when it completed. For example:


```C# Snippet:TextAnalyticsSampleHealthcareOperationStatus
// view operation status
Console.WriteLine($"Created On   : {healthOperation.CreatedOn}");
Console.WriteLine($"Expires On   : {healthOperation.ExpiresOn}");
Console.WriteLine($"Status       : {healthOperation.Status}");
Console.WriteLine($"Last Modified: {healthOperation.LastModified}");
```
To view the final results of the long-running operation:
```C# Snippet:TextAnalyticsSampleHealthcareConvenienceAsyncViewResults
// view operation results
await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.Value)
{
    Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{documentsInPage.ModelVersion}\"");
    Console.WriteLine("");

    foreach (AnalyzeHealthcareEntitiesResult entitiesInDoc in documentsInPage)
    {
        if (!entitiesInDoc.HasError)
        {
            foreach (var entity in entitiesInDoc.Entities)
            {
                // view recognized healthcare entities
                Console.WriteLine($"    Entity: {entity.Text}");
                Console.WriteLine($"    Category: {entity.Category}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    Length: {entity.Length}");
                Console.WriteLine($"    NormalizedText: {entity.NormalizedText}");
                Console.WriteLine($"    Links:");

                // view entity data sources
                foreach (EntityDataSource entityDataSource in entity.DataSources)
                {
                    Console.WriteLine($"        Entity ID in Data Source: {entityDataSource.EntityId}");
                    Console.WriteLine($"        DataSource: {entityDataSource.Name}");
                }

                // view assertion
                if (entity.Assertion != null)
                {
                    Console.WriteLine($"    Assertions:");

                    if (entity.Assertion?.Association != null)
                    {
                        Console.WriteLine($"        Association: {entity.Assertion?.Association}");
                    }

                    if (entity.Assertion?.Certainty != null)
                    {
                        Console.WriteLine($"        Certainty: {entity.Assertion?.Certainty}");
                    }
                    if (entity.Assertion?.Conditionality != null)
                    {
                        Console.WriteLine($"        Conditionality: {entity.Assertion?.Conditionality}");
                    }
                }
            }

            Console.WriteLine($"    We found {entitiesInDoc.EntityRelations.Count} relations in the current document:");
            Console.WriteLine("");

            // view recognized healthcare relations
            foreach (HealthcareEntityRelation relations in entitiesInDoc.EntityRelations)
            {
                Console.WriteLine($"        Relation: {relations.RelationType}");
                Console.WriteLine($"        For this relation there are {relations.Roles.Count} roles");

                // view relation roles
                foreach (HealthcareEntityRelationRole role in relations.Roles)
                {
                    Console.WriteLine($"            Role Name: {role.Name}");

                    Console.WriteLine($"            Associated Entity Text: {role.Entity.Text}");
                    Console.WriteLine($"            Associated Entity Category: {role.Entity.Category}");

                    Console.WriteLine("");
                }

                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("  Error!");
            Console.WriteLine($"  Document error code: {entitiesInDoc.Error.ErrorCode}.");
            Console.WriteLine($"  Message: {entitiesInDoc.Error.Message}");
        }

        Console.WriteLine("");
    }
}
```

To see the full example source files, see:

* [Synchronous AnalyzeHealthcareEntities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntities.cs)
* [Asynchronous AnalyzeHealthcareEntities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesAsync.cs)
* [Automatic Polling AnalyzeHealthcareEntities ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesAsync_AutomaticPolling.cs)
* [Manual Polling AnalyzeHealthcareEntities ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntities_ManualPolling.cs)
* [Automatic Polling AnalyzeHealthcareEntities Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesConvenienceAsync_AutomaticPolling.cs)
* [Manual Polling AnalyzeHealthcareEntities Convenience ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesConvenience_ManualPolling.cs)
* [Synchronous AnalyzeHealthcareEntities Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntities_Cancellation.cs)
* [Asynchronous AnalyzeHealthcareEntitiesAsync Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesAsync_Cancellation.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
