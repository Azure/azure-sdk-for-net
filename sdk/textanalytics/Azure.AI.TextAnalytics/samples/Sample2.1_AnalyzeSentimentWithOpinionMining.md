# Analyze sentiment with Opinion Mining

This sample demonstrates how to analyze sentiment of documents and get more granular information about the opinions related to aspects of a product/service, also knows as Aspect-based Sentiment Analysis in Natural Language Processing (NLP). This feature is only available for clients with api version v3.1-preview.1 and higher.

For the purpose of the sample, we will be the administrator of a hotel and we've set a system to look at the online reviews customers are posting to identify the major complaints about our hotel.
In order to do so, we will use the Sentiment Analysis feature of the Text Analytics client library. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Identify complaints

To get a deeper analysis into which are the aspects that people considered good or bad, we will need to include the `AdditionalSentimentAnalyses.OpinionMining` type into the `AnalyzeSentimentOptions`.

```C# Snippet:TAAnalyzeSentimentWithOpinionMining
string reviewA = @"The food and service were unacceptable, but the concierge were nice.
                 After talking to them about the quality of the food and the process
                 to get room service they refunded the money we spent at the restaurant
                 and gave us a voucher for nearby restaurants.";

string reviewB = @"The rooms were beautiful. The AC was good and quiet, which was key for
                us as outside it was 100F and our baby was getting uncomfortable because of the heat.
                The breakfast was good too with good options and good servicing times.
                The thing we didn't like was that the toilet in our bathroom was smelly.
                It could have been that the toilet was not cleaned before we arrived.
                Either way it was very uncomfortable.
                Once we notified the staff, they came and cleaned it and left candles.";

string reviewC = @"Nice rooms! I had a great unobstructed view of the Microsoft campus
                but bathrooms were old and the toilet was dirty when we arrived. 
                It was close to bus stops and groceries stores. If you want to be close to
                campus I will recommend it, otherwise, might be better to stay in a cleaner one.";

var documents = new List<string>
{
    reviewA,
    reviewB,
    reviewC
};

var options = new AnalyzeSentimentOptions() { IncludeOpinionMining = true };
Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(documents, options: options);
AnalyzeSentimentResultCollection reviews = response.Value;

Dictionary<string, int> complaints = GetComplaints(reviews);

var negativeAspect = complaints.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
Console.WriteLine($"Alert! major complaint is *{negativeAspect}*");
Console.WriteLine();
Console.WriteLine("---All complaints:");
foreach (KeyValuePair<string, int> complaint in complaints)
{
    Console.WriteLine($"   {complaint.Key}, {complaint.Value}");
}
```

Output:
```
Alert! major complaint is *toilet*

---All complaints:
   food, 1
   service, 1
   toilet, 3
```

## Define method `GetComplaints`
Implementation for calculating complaints:

```C# Snippet:TAGetComplaints
private Dictionary<string, int> GetComplaints(AnalyzeSentimentResultCollection reviews)
{
    var complaints = new Dictionary<string, int>();
    foreach (AnalyzeSentimentResult review in reviews)
    {
        foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
        {
            foreach (MinedOpinion minedOpinion in sentence.MinedOpinions)
            {
                if (minedOpinion.Aspect.Sentiment == TextSentiment.Negative)
                {
                    complaints.TryGetValue(minedOpinion.Aspect.Text, out var value);
                    complaints[minedOpinion.Aspect.Text] = value + 1;
                }
            }
        }
    }
    return complaints;
}
```


To see the full example source files, see:
* [Synchronous Analyze Sentiment with Opinion Mining](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics//tests/samples/Sample2.1_AnalyzeSentimentWithOpinionMining.cs)
* [Asynchronous Analyze Sentiment with Opinion Mining](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics//tests/samples/Sample2.1_AnalyzeSentimentWithOpinionMiningAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md