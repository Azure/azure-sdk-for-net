// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeCustomEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeCustomEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
           : base(isAsync, serviceVersion)
        {
        }

        private const string EnglishDocument1 = "A recent report by the Government Accountability Office (GAO) found that the dramatic increase in oil and natural gas development on federal lands over the past six years has stretched the staff of the BLM to a point that it has been unable to meet its environmental protection responsibilities.";

        private static readonly List<string> s_document1ExpectedOutput = new List<string>
        {
            //TODO
        };

        [RecordedTest]
        public async Task RecognizeCustomEntitiesWithADDTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(new List<string> { EnglishDocument1 }, batchActions);

            await operation.WaitForCompletionAsync();

            var Documents = ExtractDocumentsResultsFromResponse(operation);
            var FirstDocument = Documents.First();
            var Entites = FirstDocument.Entities;
            ValidateInDocumentResult(Entites, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(new List<string> { EnglishDocument1 }, batchActions);

            await operation.WaitForCompletionAsync();
            var Documents = ExtractDocumentsResultsFromResponse(operation);
            var FirstDocument = Documents.First();
            var Entites = FirstDocument.Entities;
            ValidateInDocumentResult(Entites, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            List<TextDocumentInput> DocumentsBatch = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", EnglishDocument1) { Language = "en" }
            };

            var operation = await client.StartAnalyzeActionsAsync(DocumentsBatch, batchActions);

            await operation.WaitForCompletionAsync();

            var Documents = ExtractDocumentsResultsFromResponse(operation);
            var FirstDocument = Documents.First();
            var Entites = FirstDocument.Entities;
            ValidateInDocumentResult(Entites, s_document1ExpectedOutput);
        }

        private RecognizeCustomEntitiesResultCollection ExtractDocumentsResultsFromResponse(AnalyzeActionsOperation analyzeActionOperation)
        {
            var resultCollection = analyzeActionOperation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            var RecognizeCustomEntitiesActionResult = resultCollection.RecognizeCustomEntitiesActionResults;
            var ActionResult = RecognizeCustomEntitiesActionResult.First();
            return ActionResult.DocumentsResults;
        }

        private void ValidateInDocumentResult(CategorizedEntityCollection entities, List<string> minimumExpectedOutput)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (CategorizedEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.IsTrue(minimumExpectedOutput.Contains(entity.Text, StringComparer.OrdinalIgnoreCase));
                Assert.IsNotNull(entity.Category);
                Assert.GreaterOrEqual(entity.ConfidenceScore, 0.0);
                Assert.GreaterOrEqual(entity.Offset, 0);
                Assert.Greater(entity.Length, 0);

                if (entity.SubCategory != null)
                {
                    Assert.IsNotEmpty(entity.SubCategory);
                }
            }
        }
    }
}
