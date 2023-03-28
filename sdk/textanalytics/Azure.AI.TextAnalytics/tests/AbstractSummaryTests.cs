// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
    public class AbstractSummaryTests : TextAnalyticsClientLiveTestBase
    {
        public AbstractSummaryTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string Document0 =
            "No roads or rails connect the 39,000 people dispersed across Nunavut, a territory in northeastern Canada that spans three time zones and features fjord-cut isles that stretch into the Arctic Circle off the west coast of Greenland. About 80% of the population is of Inuit descent with cultural ties to the land that date back more than 4,000 years."
            + " Today, low-bandwidth satellite internet service links the people of Nunavut to each other and with the rest of the world."
            + " The Government of Nunavut relies on this internet link to provide healthcare, education, housing and family, and financial and other services to 25 communities. The smallest, Grise Fiord, has a population of 130; the largest, the capital, Iqaluit, has 8,500 people. About 3,100 people work full-time for the government, which has an office in each community. Another 3,000 people work for the government as relief workers, casual, term or contractors."
            + " Managing information technology for this dispersed and elastic workforce is a constant challenge for Martin Joy, director of information communication and technology for the Government of Nunavut."
            + " “Traditionally, in IT, you would have to send a device or mail a device to that end user. In Nunavut, there is no road, there is no logistical framework that allows us to move stuff cost-effectively, so everything has to be flown,” he explained. “Based on weather, based on the types of cargo flows, that could take a considerable amount of time. It could take two to three weeks for us to get a user a device to get them onboarded securely into our environment.”"
            + " “Now, with Windows 365, we can do that within less than an hour of the account being created,” he said."
            + " Windows 365 puts Microsoft’s flagship operating system in the cloud. Users select Windows 10 or Windows 11, once it is generally available later this calendar year, along with a configuration of processing power, storage and memory that suits their needs. They then access their Cloud PC through a native application or web browser on any device, from anywhere with an internet connection."
            + " The creation of the Cloud PC follows other products and services to the cloud, from Windows Server on Azure to the suite of Microsoft Office productivity applications in Microsoft 365. Windows is already accessible in the cloud via Azure Virtual Desktop, which offers customers flexibility to create and run their own virtualization service. Windows 365 is a new virtualization technology for Windows that is easy to set up and deploy for today’s login-from-anywhere, mobile and elastic workforces."
            + " “Windows 365 is really going to make a huge difference for organizations that wanted to try virtualization for various reasons but could not – maybe it was too costly, too complex or they didn’t have the expertise in house to do it,” said Wangui McKelvey, general manager of Microsoft 365, who works from a home office in Atlanta, Georgia."
            + " With Windows 365, she added, IT admins can manage and deploy Cloud PCs using the same tools they use today to manage physical PCs."
            + " The remote and hybrid workforces of today and tomorrow were top of mind for Scott Manchester when he set out to develop Windows 365. The director of program management for Windows 365 in Redmond, Washington, wanted to deliver an experience with the look, feel and security of a traditional Windows PC, only accessed through a native app or web browser on a device of the user’s choosing from anywhere with an internet connection."
            + " “You want them to be able to get access to their corporate resources, applications, databases and HR tools, and do all the things they do in a typical workday sitting in the office – you want them to have that same experience,” he said. “And you want them to have that experience in such a way that it feels familiar to them. It’s not this jolting thing that takes away all the things they love about Windows.”"
            + " Virtualization, he noted, can be challenging to set up and maintain, especially for organizations without dedicated IT resources. IT consulting firms do brisk business working with companies to set up virtualization solutions and staffing help desks to field calls from employees when they run into complications. Manchester knows this because he worked on Microsoft’s Windows virtualization technologies for nearly two decades prior to leading the development of Windows 365."
            + " The inspiration for Windows 365 came earlier, when he was assigned to an internal team at Microsoft working on a project, code named Arcadia, a consumer-facing service that would stream video games from the cloud. The target audience – gamers – lacks an IT department to lean on when things glitch. “That started me thinking, ‘How do we build something that doesn’t require IT intervention, something that could truly scale to the consumer market?’” Manchester said."
            + " The consumer experience was Manchester’s benchmark when he started work on virtualization."
            + " “I took note of every time there was something that didn’t quite deliver on that,” he said. “And, as I started meeting with customers and partners and learning about how they fill in these gaps either by setting expectations of their workforce or having an IT department that picks up the phone and deals with those situations, I realized we had some ground to cover.”"
            + " Covering that ground led to improvements in Microsoft’s business offering now known as Azure Virtual Desktop. This offering continues to experience accelerated growth among customers who need full customization and control over their operating environment and have the resources for dedicated IT staff to support the system, Manchester noted. Windows 365 is for the approximate 80% of the marketplace that lacks the need for full customization or the resources for dedicated IT."
            + " To lead the development of Windows 365, Manchester leaned into his Arcadia mindset."
            + " “When we built this team, we brought in a couple of leaders who had experience with virtualization, but for the most part we brought in people who had experience with Windows and experience with consumer experiences because that was the bar we wanted to set,” he said."
            + " Soon after this bar was set, and the first batch of hires made – a handful of experts in virtualization and user experience – COVID-19 hit and changed the world."
            + " “We hired everybody else during the pandemic,” Manchester said. “They were remote. They were living all over the U.S., Australia, Europe and China. Many of them have never set foot in the office. And as soon as we got far enough along with the development, we moved those people to use the service. People who never used virtualization before, had no expectations – their bar was the experience they had on their laptop – and we basically used Windows 365 to build Windows 365.”"
            + " As the team used the service and encountered bugs in the system, they worked through and solved them on their way to creating a unique category of virtualization, the Cloud PC."
            + " “We’re giving you Windows from the cloud,” Manchester said.";

        private const string Document1 =
            "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure solutions to support employees suddenly forced to work from home, but “what really put the firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained that customers were asking, “’How do we create an experience for people that makes them still feel connected to the company without the physical presence of being there?”"
            + " In this new world of Windows 365, remote workers flip the lid on their laptop, bootup the family workstation or clip a keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365 account. From there, their Cloud PC appears with their background, apps, settings and content just as they left it when they last were last there – in the office, at home or a coffee shop."
            + " “And then, when you’re done, you’re done. You won’t have any issues around security because you’re not saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
            + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic hybrid workforce of the future, she added. It enables employees accustomed to working from home to continue working from home; it enables companies to hire interns from halfway around the world; it allows startups to scale without requiring IT expertise."
            + " “I think this will be interesting for those organizations who, for whatever reason, have shied away from virtualization. This is giving them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,” McKelvey said."
            + " The simplicity of Windows 365 won over Dean Wells, the corporate chief information officer for the Government of Nunavut. His team previously attempted to deploy a traditional virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of low-bandwidth satellite internet and the constant need for IT staff to manage the network and infrastructure."
            + " We didn’t run it for very long,” he said. “It didn’t turn out the way we had hoped. So, we actually had terminated the project and rolled back out to just regular PCs.”"
            + " He re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in November 2019 that took down everything from the phone system to the government’s servers. Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
            + " “The impact that I believe we are finding, and the impact that we’re going to find going forward, is being able to access specialists from outside the territory and organizations outside the territory to come in and help us with our projects, being able to get people on staff with us to help us deliver the day-to-day expertise that we need to run the government,” he said."
            + " “Being able to improve healthcare, being able to improve education, economic development is going to improve the quality of life in the communities.”";

        private static readonly List<string> s_batchConvenienceDocuments = new List<string>
        {
            Document0,
            Document1
        };

        private static List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("0", Document0)
            {
                 Language = "en",
            },
            new TextDocumentInput("1", Document1)
            {
                 Language = "en",
            }
        };

        private const int AbstractiveSummarizationSentenceCount = 3;

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchDocuments);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                Document1,
                "",
            };

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(documents, "en");
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            Assert.IsFalse(resultCollection[0].HasError);
            Assert.IsTrue(resultCollection[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchConvenienceDocuments);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            AbstractSummaryOptions options = new AbstractSummaryOptions()
            {
                SentenceCount = AbstractiveSummarizationSentenceCount,
                IncludeStatistics = true,
            };

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchConvenienceDocuments, "en", options);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchDocuments);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AbstractSummaryBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            AbstractSummaryOptions options = new AbstractSummaryOptions()
            {
                SentenceCount = AbstractiveSummarizationSentenceCount,
                IncludeStatistics = true,
            };

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchDocuments, options);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32614")]
        public async Task AbstractSummaryBatchConvenienceWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();

            AbstractSummaryOperation operation = await client.StartAbstractSummaryAsync(s_batchConvenienceDocuments, "en");
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            List<AbstractSummaryResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            AbstractSummaryResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection, isLanguageAutoDetected: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32614")]
        public async Task AnalyzeOperationAbstractSummaryWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            TextAnalyticsActions actions = new()
            {
                AbstractSummaryActions = new List<AbstractSummaryAction>() { new AbstractSummaryAction() },
                DisplayName = "AbstractSummaryWithAutoDetectedLanguage",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<AbstractSummaryActionResult> actionResults = resultCollection.AbstractSummaryResults;
            Assert.IsNotNull(actionResults);

            AbstractSummaryResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            ValidateSummaryBatchResult(results, isLanguageAutoDetected: true);
        }

        private void ValidateOperationProperties(AbstractSummaryOperation operation)
        {
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn.Value);
            }
        }

        private void ValidateSummaryBatchResult(
            AbstractSummaryResultCollection results,
            bool includeStatistics = default,
            bool isLanguageAutoDetected = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            if (includeStatistics)
            {
                Assert.IsNotNull(results.Statistics);
                Assert.Greater(results.Statistics.DocumentCount, 0);
                Assert.Greater(results.Statistics.TransactionCount, 0);
                Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
                Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);
            }
            else
            {
                Assert.IsNull(results.Statistics);
            }

            foreach (AbstractSummaryResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                Assert.False(result.HasError);

                if (includeStatistics)
                {
                    Assert.GreaterOrEqual(result.Statistics.CharacterCount, 0);
                    Assert.Greater(result.Statistics.TransactionCount, 0);
                }
                else
                {
                    Assert.AreEqual(0, result.Statistics.CharacterCount);
                    Assert.AreEqual(0, result.Statistics.TransactionCount);
                }

                if (isLanguageAutoDetected)
                {
                    Assert.IsNotNull(result.DetectedLanguage);
                    Assert.That(result.DetectedLanguage.Value.Name, Is.Not.Null.And.Not.Empty);
                    Assert.That(result.DetectedLanguage.Value.Iso6391Name, Is.Not.Null.And.Not.Empty);
                    Assert.GreaterOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 0.0);
                    Assert.LessOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 1.0);
                    Assert.IsNotNull(result.DetectedLanguage.Value.Warnings);
                    Assert.IsEmpty(result.DetectedLanguage.Value.Warnings);
                }
                else
                {
                    Assert.IsNull(result.DetectedLanguage);
                }

                Assert.IsNotNull(result.Warnings);
                Assert.Greater(result.Summaries.Count, 0);

                foreach (AbstractiveSummary summary in result.Summaries)
                {
                    string originalDocument = s_batchDocuments.Where(document => document.Id == result.Id).FirstOrDefault().Text;
                    Assert.That(summary.Text, Is.Not.Null.And.Not.Empty);
                    Assert.Less(summary.Text.Length, originalDocument.Length);

                    char[] separators = { '.', '!', '?' };
                    string[] sentences = summary.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    Assert.Greater(sentences.Length, 0);

                    Assert.IsNotNull(summary.Contexts);
                    Assert.Greater(summary.Contexts.Count, 0);

                    foreach (SummaryContext context in summary.Contexts)
                    {
                        Assert.GreaterOrEqual(context.Offset, 0);
                        Assert.GreaterOrEqual(context.Length, 0);
                        Assert.LessOrEqual(context.Offset + context.Length, originalDocument.Length);
                    }
                }
            }
        }
    }
}
