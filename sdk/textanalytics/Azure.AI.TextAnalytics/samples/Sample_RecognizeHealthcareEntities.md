# Recognizing Healthcare Entities from Documents
This sample demonstrates how to recognize healthcare entities in one or more document. To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize healthcare entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing healthcare entities in multiple documents

To recognize healthcare entities in multiple documents, call `StartHealthcareBatchAsync` on an `IEnumerable` of strings.  The result is a Long Running operation of type `HealthcareOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSampleHealthcareBatchConvenienceAsync
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

    List<TextDocumentInput> batchInput = new List<TextDocumentInput>()
    {
        new TextDocumentInput("1", document1)
        { Language = "en" },
        new TextDocumentInput("2", document2)
        { Language = "en" },
        new TextDocumentInput("3", string.Empty)
    };
    var options = new AnalyzeHealthcareEntitiesOptions { IncludeStatistics = true };

    AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(batchInput, options);

    await healthOperation.WaitForCompletionAsync();

    Console.WriteLine($"Created On   : {healthOperation.CreatedOn}");
    Console.WriteLine($"Expires On   : {healthOperation.ExpiresOn}");
    Console.WriteLine($"Id           : {healthOperation.Id}");
    Console.WriteLine($"Status       : {healthOperation.Status}");
    Console.WriteLine($"Last Modified: {healthOperation.LastModified}");

    int i = 0;

    await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.Value)
    {
        Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{documentsInPage.ModelVersion}\"");
        Console.WriteLine("");

        TextDocumentInput document = batchInput[i++];

        Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

        foreach (AnalyzeHealthcareEntitiesResult entitiesInDoc in documentsInPage)
        {
            if (!entitiesInDoc.HasError)
            {
                foreach (var entity in entitiesInDoc.Entities)
                {
                    Console.WriteLine($"    Entity: {entity.Text}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    Length: {entity.Length}");
                    Console.WriteLine($"    Links:");

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                    {
                        Console.WriteLine($"        Entity ID in Data Source: {entityDataSource.EntityId}");
                        Console.WriteLine($"        DataSource: {entityDataSource.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine("  Error!");
                Console.WriteLine($"  Document error code: {entitiesInDoc.Error.ErrorCode}.");
                Console.WriteLine($"  Message: {entitiesInDoc.Error.Message}");
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {entitiesInDoc.Statistics.CharacterCount}");
            Console.WriteLine($"  Valid document count: {entitiesInDoc.Statistics.TransactionCount}");
            Console.WriteLine("");
        }

        Console.WriteLine($"Request statistics:");
        Console.WriteLine($"    Document Count: {documentsInPage.Statistics.DocumentCount}");
        Console.WriteLine($"    Valid Document Count: {documentsInPage.Statistics.ValidDocumentCount}");
        Console.WriteLine($"    Transaction Count: {documentsInPage.Statistics.TransactionCount}");
        Console.WriteLine($"    Invalid Document Count: {documentsInPage.Statistics.InvalidDocumentCount}");
        Console.WriteLine("");
    }
}
```

To see the full example source files, see:

* [AnalyzeHealthcareEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesBatch.cs)
* [AnalyzeHealthcareEntitiesAsync](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesBatchAsync.cs)
* [AnalyzeHealthcareEntities Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntities_Cancellation.cs)
* [AnalyzeHealthcareEntitiesAsync Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntities_Cancellation.cs)
* [Automatic Polling AnalyzeHealthcareEntities ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesAsync_AutomaticPolling.cs)
* [Manual Polling AnalyzeHealthcareEntities ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesAsync_ManualPolling.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md