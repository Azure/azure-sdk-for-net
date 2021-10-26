// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversationDeepstack()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationDeepstack

#if SNIPPET
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            DeepstackPrediction deepstackPrediction = response.Value.Prediction as DeepstackPrediction;

            Console.WriteLine("Intents:");
            foreach (DeepstackIntent intent in deepstackPrediction.Intents)
            {
                Console.WriteLine($"Category:{intent.Category}");
                Console.WriteLine($"Confidence Score:{intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (DeepstackEntity entity in deepstackPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(deepstackPrediction.TopIntent, Is.EqualTo("Order"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationDeepstackAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationDeepstackAsync

#if SNIPPET
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            DeepstackPrediction deepstackPrediction = response.Value.Prediction as DeepstackPrediction;

            Console.WriteLine("Intents:");
            foreach (DeepstackIntent intent in deepstackPrediction.Intents)
            {
                Console.WriteLine($"Category:{intent.Category}");
                Console.WriteLine($"Confidence Score:{intent.ConfidenceScore}");
                Console.WriteLine();
            }

            Console.WriteLine("Entities:");
            foreach (DeepstackEntity entity in deepstackPrediction.Entities)
            {
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(deepstackPrediction.TopIntent, Is.EqualTo("Order"));
        }
    }
}
