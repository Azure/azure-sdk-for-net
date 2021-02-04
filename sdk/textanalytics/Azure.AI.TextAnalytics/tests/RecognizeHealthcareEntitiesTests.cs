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

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);

            AnalyzeHealthcareEntitiesResult result = resultCollection[0];

            var entitiesList = new List<string> { "100mg", "ibuprofen", "twice daily" };

            Assert.AreEqual(3, result.Entities.Count);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual("1", result.Id);

            foreach (HealthcareEntity entity in result.Entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));

                if (entity.Text == "ibuprofen")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "ATC", "CCPSS", "CHV", "CSP", "DRUGBANK", "GS", "LCH_NW", "LNC", "MEDCIN", "MMSL", "MSH", "MTHSPL", "NCI", "NCI_CTRP", "NCI_DCP", "NCI_DTP", "NCI_FDA", "NCI_NCI-GLOSS", "NDDF", "PDQ", "RCD", "RXNORM", "SNM", "SNMI", "SNOMEDCT_US", "USP", "USPMG", "VANDF" };

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                        Assert.IsTrue(linksList.Contains(entityDataSource.Name));
                }

                if (entity.Text == "100mg")
                {
                    Assert.IsTrue(entity.RelatedEntities.Count == 1);

                    var relatedEntity = entity.RelatedEntities.FirstOrDefault().Key;

                    Assert.AreEqual("ibuprofen", relatedEntity.Text);
                    Assert.AreEqual("MedicationName", relatedEntity.Category);
                    Assert.AreEqual(0, relatedEntity.Length);
                    Assert.AreEqual(27, relatedEntity.Offset);
                    Assert.AreEqual(1.0, relatedEntity.ConfidenceScore);

                    // TODO - DosageOfMedication is not in relation types and is returned from the service. Need to add to swagger.
                    //Assert.AreEqual(HealthcareEntityRelationType.DosageOfMedication, entity.RelatedEntities.ElementAt(0).Value);
                }
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(new List<string>() { document }, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            foreach (AnalyzeHealthcareEntitiesResult result in resultCollection)
            {
                Assert.AreEqual(3, result.Entities.Count);
                Assert.IsNotNull(result.Id);
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithTopParameter()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                Top = 1
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

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

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                Skip = 1
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.IsFalse(resultCollection[0].HasError);
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

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.IsNotNull(resultCollection[2].Id);

            Assert.IsTrue(resultCollection[2].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[2].Error.ErrorCode.ToString());
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents, "en", options);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(documents.Count, resultCollection.Statistics.DocumentCount);

            Assert.AreEqual(48, resultCollection[0].Statistics.CharacterCount);
            Assert.AreEqual(1, resultCollection[0].Statistics.TransactionCount);

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

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchDocuments;

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents, options);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(2, resultCollection.Count);

            Assert.AreEqual(2, resultCollection.Statistics.DocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.TransactionCount);
            Assert.AreEqual(0, resultCollection.Statistics.InvalidDocumentCount);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithCancellation()
        {
            TextAnalyticsClient client = GetClient();
            string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS |";

            var batchDocuments = new List<string>();

            for (var i = 0; i < 10; i++)
            {
                batchDocuments.Add(document);
            }

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments, "en");

            await operation.CancelAsync();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async() => await operation.WaitForCompletionAsync());
            Assert.IsTrue(ex.Message.Contains("The operation was canceled so no value is available."));

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual(OperationStatus.Cancelled, operation.Status);

            try
            {
                Assert.IsNull(operation.Value);
            }
            catch (RequestFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("The operation was canceled so no value is available."));
            }
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

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                Top = 2
            };

            AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(list, "en", options);

            AsyncPageable<AnalyzeHealthcareEntitiesResult> results = client.GetHealthcareEntities(healthOperation);

            int resultCount = 0;
            await foreach (AnalyzeHealthcareEntitiesResult result in results)
            {
                resultCount += 1;
            }

            Assert.AreEqual(10, resultCount);
        }
    }
}
