// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public void ExtractiveSummarize()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            // Get the document.
            string document =
                "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure solutions to support employees suddenly forced to work from"
                + " home, but “what really put the firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained that customers were asking,"
                + " “How do we create an experience for people that makes them still feel connected to the company without the physical presence of being there?” In this new"
                + " world of Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a keyboard onto a tablet, launch a native app or"
                + " modern web browser and login to their Windows 365 account. From there, their Cloud PC appears with their background, apps, settings and content just as they"
                + " left it when they last were last there – in the office, at home or a coffee shop. And then, when you’re done, you’re done. You won’t have any issues around"
                + " security because you’re not saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud. The ability to login to a Cloud"
                + " PC from anywhere on any device is part of Microsoft’s larger strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the"
                + " post-pandemic hybrid workforce of the future, she added. It enables employees accustomed to working from home to continue working from home; it enables"
                + " companies to hire interns from halfway around the world; it allows startups to scale without requiring IT expertise. “I think this will be interesting for"
                + " those organizations who, for whatever reason, have shied away from virtualization. This is giving them an opportunity to try it in a way that their regular,"
                + " everyday endpoint admin could manage,” McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information officer for the"
                + " Government of Nunavut. His team previously attempted to deploy a traditional virtual desktop infrastructure and found it inefficient and unsustainable given"
                + " the limitations of low-bandwidth satellite internet and the constant need for IT staff to manage the network and infrastructure. We didn’t run it for very"
                + " long,” he said. “It didn’t turn out the way we had hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He re-evaluated"
                + " this decision after the Government of Nunavut was hit by a ransomware attack in November 2019 that took down everything from the phone system to the"
                + " government’s servers. Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and Microsoft 365. Manchester’s team recruited"
                + " the Government of Nunavut to pilot Windows 365. Wells was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly. “The"
                + " impact that I believe we are finding, and the impact that we’re going to find going forward, is being able to access specialists from outside the territory"
                + " and organizations outside the territory to come in and help us with our projects, being able to get people on staff with us to help us deliver the day-to-day"
                + " expertise that we need to run the government,” he said. “Being able to improve healthcare, being able to improve education, economic development is going to"
                + " improve the quality of life in the communities.”";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<TextDocumentInput> documentBatch = new()
            {
                new TextDocumentInput("1", document)
                {
                     Language = "en",
                }
            };

            ExtractiveSummarizeOptions options = new()
            {
                MaxSentenceCount = 5,
                OrderBy = ExtractiveSummarySentencesOrder.Rank
            };

            // Start the text analysis operation.
            ExtractiveSummarizeOperation operation = client.StartExtractiveSummarize(documentBatch, options);

            operation.WaitForCompletion();

            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            // View the operation results.
            foreach (ExtractiveSummarizeResultCollection documentsInPage in operation.GetValues())
            {
                Console.WriteLine($"Results of \"Extractive Summarization\" Model, version: \"{documentsInPage.ModelVersion}\"");
                Console.WriteLine();

                foreach (ExtractiveSummarizeResult documentResult in documentsInPage)
                {
                    if (documentResult.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {documentResult.Error.Message}");
                        continue;
                    }

                    Console.WriteLine($"  Extracted the following {documentResult.Sentences.Count} sentence(s):");
                    Console.WriteLine();

                    foreach (ExtractiveSummarySentence sentence in documentResult.Sentences)
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
    }
}
