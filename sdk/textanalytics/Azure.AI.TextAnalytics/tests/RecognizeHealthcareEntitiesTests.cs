// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeHealthcareEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeHealthcareEntitiesTests(bool isAsync) : base(isAsync) { }

        private const string singleEnglish = "Subject is taking 100mg of ibuprofen twice daily";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Subject is taking 100mg of ibuprofen twice daily",
            "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Subject is taking 100mg of ibuprofen twice daily")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.")
            {
                 Language = "en",
            }
        };

        [Test]
        public async Task RecognizeHealthcareEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            HealthcareOperation operation = await client.StartHealthcareAsync(document);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(1, resultCollection.Count);

            DocumentHealthcareResult result = resultCollection.Single();

            var entitiesList = new List<string> { "100mg", "ibuprofen", "twice daily" };

            Assert.AreEqual(3, result.Entities.Count);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual("0", result.Id);

            foreach (HealthcareEntity entity in result.Entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));

                if (entity.Text == "ibuprofen")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "ATC", "CCPSS", "CHV", "CSP", "DRUGBANK", "GS", "LCH_NW", "LNC", "MEDCIN", "MMSL", "MSH", "MTHSPL", "NCI", "NCI_CTRP", "NCI_DCP", "NCI_DTP", "NCI_FDA", "NCI_NCI-GLOSS", "NDDF", "PDQ", "RCD", "RXNORM", "SNM", "SNMI", "SNOMEDCT_US", "USP", "USPMG", "VANDF" };

                    foreach (HealthcareEntityLink link in entity.Links)
                        Assert.IsTrue(linksList.Contains(link.DataSource));
                }
            }

            foreach (HealthcareRelation relation in result.Relations)
            {
                if (relation.RelationType == "DosageOfMedication")
                {
                    Assert.AreEqual(relation.Source.Text, "100mg");
                    Assert.AreEqual(relation.Source.Category, "Dosage");
                    Assert.AreEqual(relation.Source.ConfidenceScore, 1);
                    Assert.AreEqual(relation.Source.Length, 5);
                    Assert.AreEqual(relation.Source.Offset, 18);

                    Assert.AreEqual(relation.Target.Text, "ibuprofen");
                    Assert.AreEqual(relation.Target.Category, "MedicationName");
                    Assert.AreEqual(relation.Target.ConfidenceScore, 1);
                    Assert.AreEqual(relation.Target.Length, 9);
                    Assert.AreEqual(relation.Target.Offset, 27);
                }
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(new List<string>() { document }, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            foreach (DocumentHealthcareResult result in resultCollection)
            {
                Assert.AreEqual(3, result.Entities.Count);
                Assert.IsNotNull(result.Id);
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithTopParameter()
        {
            TextAnalyticsClient client = GetClient();

            HealthcareOptions options = new HealthcareOptions()
            {
                Top = 1
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual(3, resultCollection[0].Entities.Count);
            Assert.IsNotNull(resultCollection[0].Id);
            Assert.AreEqual("1", resultCollection[0].Id);
            Assert.AreEqual("100mg", resultCollection[0].Entities.FirstOrDefault().Text);
            Assert.AreEqual("Dosage", resultCollection[0].Entities.FirstOrDefault().Category);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithSkipParameter()
        {
            TextAnalyticsClient client = GetClient();

            HealthcareOptions options = new HealthcareOptions()
            {
                Skip = 1
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.IsNotNull(resultCollection[0].TextAnalyticsError);
            Assert.IsNotNull(resultCollection[0].Warnings);
            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual(6, resultCollection[0].Entities.Count);
            Assert.IsNotNull(resultCollection[0].Id);
            Assert.AreEqual("2", resultCollection[0].Id);
            Assert.AreEqual("rapid", resultCollection[0].Entities.FirstOrDefault().Text);
            Assert.AreEqual("SymptomOrSign", resultCollection[0].Entities.FirstOrDefault().Category);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.",
                "",
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.IsNotNull(resultCollection[2].Id);
            Assert.IsNotNull(resultCollection[2].TextAnalyticsError);
            Assert.AreEqual("Document text is empty.", resultCollection[2].TextAnalyticsError.Message);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[2].TextAnalyticsError.ErrorCode.ToString());
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            HealthcareOptions options = new HealthcareOptions()
            {
                IncludeStatistics = true
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents, "en", options);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(documents.Count, resultCollection.Statistics.DocumentCount);

            Assert.AreEqual(48, resultCollection[0].Statistics.Value.CharacterCount);
            Assert.AreEqual(1, resultCollection[0].Statistics.Value.TransactionCount);

            Assert.Greater(resultCollection.Statistics.DocumentCount, 0);
            Assert.AreEqual(2, resultCollection.Statistics.DocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.TransactionCount);
            Assert.AreEqual(0, resultCollection.Statistics.InvalidDocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchDocuments;

            HealthcareOptions options = new HealthcareOptions()
            {
                IncludeStatistics = true
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);

            Assert.AreEqual(2, resultCollection.Statistics.DocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.TransactionCount);
            Assert.AreEqual(0, resultCollection.Statistics.InvalidDocumentCount);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithPagination()
        {
            TextAnalyticsClient client = GetClient();
            string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE.";

            var list = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(document);
            };

            HealthcareOptions options = new HealthcareOptions()
            {
                Top = 2
            };

            HealthcareOperation healthOperation = await client.StartHealthcareBatchAsync(list, "en", options);

            AsyncPageable<DocumentHealthcareResult> results = client.GetHealthcareEntities(healthOperation);

            int resultCount = 0;
            await foreach (DocumentHealthcareResult result in results)
            {
                resultCount += 1;
            }

            Assert.AreEqual(10, resultCount);
        }
    }
}
