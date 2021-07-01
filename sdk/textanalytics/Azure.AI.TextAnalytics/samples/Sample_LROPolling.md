# Polling Long Running Operations
This sample demonstrates the different ways to consume or poll the status of a Text Analytics client Long Running Operation.  It uses the [Analyze Healthcare Entities][analyze-healthcare-entities] functionality as an example.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to analyze healthcare entities for a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Automatic polling

In the below snippet the polling is happening by default when we call `WaitForCompletionAsync()` method.

```C# Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsync
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
    document2
};

// start analysis process
AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(batchInput);
await healthOperation.WaitForCompletionAsync();
```

By default the polling happens every 1 second when there is no `pollingInterval` sent.

## Manual polling

This method is for users who want to have intermittent code paths during the polling process, or want to stick to a sync behavior.

```C# Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenience
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
    document2
};

// start analysis process
AnalyzeHealthcareEntitiesOperation healthOperation = client.StartAnalyzeHealthcareEntities(batchInput);

// wait for completion with manual polling
TimeSpan pollingInterval = new TimeSpan(1000);

while (true)
{
    Console.WriteLine($"Status: {healthOperation.Status}");
    healthOperation.UpdateStatus();
    if (healthOperation.HasCompleted)
    {
        break;
    }

    Thread.Sleep(pollingInterval);
}

Console.WriteLine($"AnalyzeHealthcareEntities operation was completed");
```

To see the full example source files, see:

* [Asynchronous AnalyzeHealthcareEntities Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesConvenienceAsync.cs)
* [Synchronous AnalyzeHealthcareEntities Convenience ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample7_AnalyzeHealthcareEntitiesConvenience.cs)

[analyze-healthcare-entities]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample7_AnalyzeHealthcareEntities.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
