# Analyze sentiment with Opinion Mining

This sample demonstrates how to analyze sentiment of documents and get more granular information about the opinions related to aspects of a product/service, also knows as Aspect-based Sentiment Analysis in Natural Language Processing (NLP). This feature is only available for clients with api version v3.1-preview.1 and higher.

For the purpose of the sample, we will be the administrator of a hotel and we've set a system to look at the online reviews customers are posting to identify the major complaints about our hotel.
In order to do so, we will use the Sentiment Analysis feature of the Text Analytics client library. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample1CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Identify complaints

To get a deeper analysis into which are the aspects that people considered good or bad, we will need to include the `AdditionalSentimentAnalyses.OpinionMining` type into the `AnalyzeSentimentOptions`.

```C# Snippet:TAAnalyzeSentimentWithOpinionMining
var documents = new List<string>
{
    "The food and service were unacceptable, but the concierge were nice.",
    "The rooms were beautiful. The AC was good and quiet.",
    "The breakfast was good, but the toilet was smelly.",
    "Loved this hotel - good breakfast - nice shuttle service - clean rooms.",
    "I had a great unobstructed view of the Microsoft campus.",
    "Nice rooms but bathrooms were old and the toilet was dirty when we arrived.",
    "We changed rooms as the toilet smelled."
};

AnalyzeSentimentResultCollection reviews = client.AnalyzeSentimentBatch(documents, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

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
   bathrooms, 1
   rooms, 1
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