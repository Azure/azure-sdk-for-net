# Recognizing Healthcare Entities from Documents
This sample demonstrates how to recognize healthcare entities in one or more documents and get them asynchronously. To get started you will need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize healthcare entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing healthcare entities in a single document asynchronously

To recognize healthcare entities in a document, use the `StarthealthcareAsyc` method.  The returned type is a Long Running operation of type `HealthcareOperation` which polls for the results from the API.

```C# Snippet:RecognizeHealthcareEntities
    string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | \
                        Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. \
                        HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. \
                        The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease ,\
                        with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and \
                        another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , \
                        which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with \
                        minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's \
                        increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.";

    HealthcareOperation healthOperation = client.StartHealthcare(document);

    await healthOperation.WaitForCompletionAsync();

    RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;

    Console.WriteLine($"Results of Azure Text Analytics \"Healthcare\" Model, version: \"{results.ModelVersion}\"");
    Console.WriteLine("");

    foreach (DocumentHealthcareResult result in results)
    {
           Console.WriteLine($"    Recognized the following {result.Entities.Count} healthcare entities:");

            foreach (HealthcareEntity entity in result.Entities)
            {
                Console.WriteLine($"    Entity: {entity.Text}");
                Console.WriteLine($"    Category: {entity.Category}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    Length: {entity.Length}");
                Console.WriteLine($"    IsNegated: {entity.IsNegated}");
                Console.WriteLine($"    Links:");

                foreach (HealthcareEntityLink healthcareEntityLink in entity.Links)
                {
                    Console.WriteLine($"        ID: {healthcareEntityLink.Id}");
                    Console.WriteLine($"        DataSource: {healthcareEntityLink.DataSource}");
                }
            }
            Console.WriteLine("");
    }
}
```

## Recognizing healthcare entities in multiple documents

To recognize healthcare entities in multiple documents, call `StartHealthcareBatchAsync` on an `IEnumerable` of strings.  The result is a Long Running operation of type `HealthcareOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSampleHealthcareBatchConvenienceAsync
    string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | \
                        Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. \
                        HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. \
                        The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease ,\
                        with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and \
                        another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , \
                        which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with \
                        minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's \
                        increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.";

    List<string> batchInput = new List<string>()
    {
        document,
    };

    HealthcareOperation healthOperation = await client.StartHealthcareBatchAsync(batchInput, "en");

    await healthOperation.WaitForCompletionAsync();

    RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;

    Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{results.ModelVersion}\"");
    Console.WriteLine("");

    foreach (DocumentHealthcareResult result in results)
    {
        Console.WriteLine($"    Recognized the following {result.Entities.Count} healthcare entities:");

        foreach (HealthcareEntity entity in result.Entities)
        {
            Console.WriteLine($"    Entity: {entity.Text}");
            Console.WriteLine($"    Category: {entity.Category}");
            Console.WriteLine($"    Offset: {entity.Offset}");
            Console.WriteLine($"    Length: {entity.Length}");
            Console.WriteLine($"    IsNegated: {entity.IsNegated}");
            Console.WriteLine($"    Links:");

            foreach (HealthcareEntityLink healthcareEntityLink in entity.Links)
            {
                Console.WriteLine($"        ID: {healthcareEntityLink.Id}");
                Console.WriteLine($"        DataSource: {healthcareEntityLink.DataSource}");
            }
        }
        Console.WriteLine("");
    }
}
```

To see the full example source files, see:

* [Synchronously RecognizeHealthcare ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_Healthcare.cs)
* [Asynchronously RecognizeHealthcare ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync.cs)
* [Synchronously RecognizeHealthcareBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareBatch.cs)
* [Asynchronously RecognizeHealthcareBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareBatchAsync.cs)
* [Synchronously RecognizeHealthcare Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_Healthcare_Cancellation.cs)
* [Asynchronously RecognizeHealthcare Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_Cancellation.cs)
* [Automatic Polling HealthcareOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_AutomaticPolling.cs)
* [Manual Polling HealthcareOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_ManualPolling.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md