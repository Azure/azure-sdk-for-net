# Analyze sentiment with Opinion Mining

This sample demonstrates how to analyze sentiment of documents and get more granular information about the opinions related to targets of a product/service, also knows as Aspect-based Sentiment Analysis in Natural Language Processing (NLP). This feature is only available for clients with api version v3.1 and higher.

For example, if a customer leaves feedback about a hotel such as "The room was great, but the staff was unfriendly.", Opinion Mining will locate targets in the text, and their associated opinion and sentiments. Sentiment Analysis might only report a negative sentiment.

For the purpose of the sample, we will be the administrator of a hotel and we've set a system to look at the online reviews customers are posting to identify the major complaints about our hotel.
In order to do so, we will use the Sentiment Analysis feature of the Text Analytics client library.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Identify complaints

To get a deeper analysis into which are the targets that people considered good or bad, we will need to set the `IncludeOpinionMining` type into the `AnalyzeSentimentOptions`.

```C# Snippet:Sample2_AnalyzeSentimentWithOpinionMining
string reviewA =
    "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
    + " quality of the food and the process to get room service they refunded the money we spent at the"
    + " restaurant and gave us a voucher for nearby restaurants.";

string reviewB =
    "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
    + "our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
    + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
    + "smelly. It could have been that the toilet was not cleaned before we arrived. Either way it was"
    + "very uncomfortable. Once we notified the staff, they came and cleaned it and left candles.";

string reviewC =
    "Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms were old and the"
    + "toilet was dirty when we arrived. It was close to bus stops and groceries stores. If you want to"
    + "be close to campus I will recommend it, otherwise, might be better to stay in a cleaner one.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    reviewA,
    reviewB,
    reviewC
};

AnalyzeSentimentOptions options = new() { IncludeOpinionMining = true };
Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(batchedDocuments, options: options);
AnalyzeSentimentResultCollection reviews = response.Value;

Dictionary<string, int> complaints = GetComplaints(reviews);

string negativeAspect = complaints.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
Console.WriteLine($"Alert! major complaint is *{negativeAspect}*");
Console.WriteLine();
Console.WriteLine("---All complaints:");
foreach (KeyValuePair<string, int> complaint in complaints)
{
    Console.WriteLine($"   {complaint.Key}, {complaint.Value}");
}
```

Output:

```text
Alert! major complaint is *toilet*

---All complaints:
   food, 1
   service, 1
   toilet, 3
```

## Define method `GetComplaints`

Implementation for calculating complaints:

```C# Snippet:Sample2_AnalyzeSentimentWithOpinionMining_GetComplaints
private Dictionary<string, int> GetComplaints(AnalyzeSentimentResultCollection reviews)
{
    Dictionary<string, int> complaints = new();
    foreach (AnalyzeSentimentResult review in reviews)
    {
        foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
        {
            foreach (SentenceOpinion opinion in sentence.Opinions)
            {
                if (opinion.Target.Sentiment == TextSentiment.Negative)
                {
                    complaints.TryGetValue(opinion.Target.Text, out int value);
                    complaints[opinion.Target.Text] = value + 1;
                }
            }
        }
    }
    return complaints;
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
