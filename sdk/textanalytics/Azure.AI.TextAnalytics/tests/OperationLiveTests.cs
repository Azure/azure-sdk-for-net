// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
    public class OperationLiveTests : TextAnalyticsClientLiveTestBase
    {
        public OperationLiveTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        #region Analyze

        [RecordedTest]
        public async Task AnalyzeOperationCanPollFromNewObject()
        {
            TextAnalyticsClient client = GetClient(out var nonInstrumentedClient);

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Elon Musk is the CEO of SpaceX and Tesla.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Tesla stock is up by 400% this year.")
                {
                     Language = "en",
                }
            };

            TextAnalyticsActions batchActions = new()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            var sameOperation = InstrumentOperation(new AnalyzeActionsOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
        }

        [RecordedTest]
        public async Task AnalyzeOperationConvenienceCanPollFromNewObject()
        {
            TextAnalyticsClient client = GetClient(out var nonInstrumentedClient);

            var documents = new List<string>
            {
                "Elon Musk is the CEO of SpaceX and Tesla.",
                "Tesla stock is up by 400% this year."
            };

            TextAnalyticsActions batchActions = new()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            var sameOperation = InstrumentOperation(new AnalyzeActionsOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
        }

        #endregion Analyze

        #region Healthcare

        [RecordedTest]
        public async Task HealthcareOperationCanPollFromNewObject()
        {
            TextAnalyticsClient client = GetClient(out var nonInstrumentedClient);

            var documents = new List<TextDocumentInput>
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

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);
            var sameOperation = InstrumentOperation(new AnalyzeHealthcareEntitiesOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
        }

        [RecordedTest]
        public async Task HealthcareOperationConvenienceCanPollFromNewObject()
        {
            TextAnalyticsClient client = GetClient(out var nonInstrumentedClient);

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure."
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);
            var sameOperation = InstrumentOperation(new AnalyzeHealthcareEntitiesOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
        }

        #endregion Healthcare
    }
}
