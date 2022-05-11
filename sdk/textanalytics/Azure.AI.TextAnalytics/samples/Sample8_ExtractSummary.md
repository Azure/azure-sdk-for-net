# Perform Extractive Text Summarization in Documents
This sample demonstrates how to run an Extractive Text Summarization action in one or more documents.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to extract summary sentences from a document, you need a Cognitive Services or Language service endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client. See [README][README] for links and instructions.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing extractive text summarization in one or multiple documents

To perform extractive text summarization in one or multiple documents, set up an `ExtractSummaryAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsExtractSummaryAsync
// Get input document.
string document = @"Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure solutions to support employees suddenly forced to work from home, but “what really put the firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained that customers were asking, “’How do we create an experience for people that makes them still feel connected to the company without the physical presence of being there?”
                    In this new world of Windows 365, remote workers flip the lid on their laptop, bootup the family workstation or clip a keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365 account.From there, their Cloud PC appears with their background, apps, settings and content just as they left it when they last were last there – in the office, at home or a coffee shop.
                    And then, when you’re done, you’re done.You won’t have any issues around security because you’re not saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud.
                    The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic hybrid workforce of the future, she added. It enables employees accustomed to working from home to continue working from home; it enables companies to hire interns from halfway around the world; it allows startups to scale without requiring IT expertise.
                    “I think this will be interesting for those organizations who, for whatever reason, have shied away from virtualization.This is giving them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,” McKelvey said.
                    The simplicity of Windows 365 won over Dean Wells, the corporate chief information officer for the Government of Nunavut. His team previously attempted to deploy a traditional virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of low-bandwidth satellite internet and the constant need for IT staff to manage the network and infrastructure.
                    We didn’t run it for very long,” he said. “It didn’t turn out the way we had hoped.So, we actually had terminated the project and rolled back out to just regular PCs.”
                    He re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in November 2019 that took down everything from the phone system to the government’s servers. Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly.
                    “The impact that I believe we are finding, and the impact that we’re going to find going forward, is being able to access specialists from outside the territory and organizations outside the territory to come in and help us with our projects, being able to get people on staff with us to help us deliver the day-to-day expertise that we need to run the government,” he said.
                    “Being able to improve healthcare, being able to improve education, economic development is going to improve the quality of life in the communities.”";

// Prepare analyze operation input. You can add multiple documents to this list and perform the same
// operation to all of them.
var batchInput = new List<string>
{
    document
};

TextAnalyticsActions actions = new TextAnalyticsActions()
{
    ExtractSummaryActions = new List<ExtractSummaryAction>() { new ExtractSummaryAction() }
};

// Start analysis process.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsExtractSummaryOperationStatus
// View operation status.
Console.WriteLine($"AnalyzeActions operation has completed");
Console.WriteLine();

Console.WriteLine($"Created On   : {operation.CreatedOn}");
Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
Console.WriteLine($"Id           : {operation.Id}");
Console.WriteLine($"Status       : {operation.Status}");
Console.WriteLine($"Last Modified: {operation.LastModified}");
Console.WriteLine();
```

To view the final results of the long-running operation:

```C# Snippet:TextAnalyticsExtractSummaryAsyncViewResults
// View operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<ExtractSummaryActionResult> summaryResults = documentsInPage.ExtractSummaryResults;

    foreach (ExtractSummaryActionResult summaryActionResults in summaryResults)
    {
        if (summaryActionResults.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Action error code: {summaryActionResults.Error.ErrorCode}.");
            Console.WriteLine($"  Message: {summaryActionResults.Error.Message}");
            continue;
        }

        foreach (ExtractSummaryResult documentResults in summaryActionResults.DocumentsResults)
        {
            if (documentResults.HasError)
            {
                Console.WriteLine($"  Error!");
                Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                Console.WriteLine($"  Message: {documentResults.Error.Message}");
                continue;
            }

            Console.WriteLine($"  Extracted the following {documentResults.Sentences.Count} sentence(s):");
            Console.WriteLine();

            foreach (SummarySentence sentence in documentResults.Sentences)
            {
                Console.WriteLine($"  Sentence: {sentence.Text}");
                Console.WriteLine($"  Rank Score: {sentence.RankScore}");
                Console.WriteLine($"  Offset: {sentence.Offset}");
                Console.WriteLine($"  Length: {sentence.Length}");
                Console.WriteLine();
            }
        }
    }
}
```

To see the full example source files, see:

* [Synchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummary.cs)
* [Asynchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryAsync.cs)
* [Synchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenience.cs)
* [Asynchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md