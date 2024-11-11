// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample9_ConversationsAuthoring_GetModelEvaluationResults : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetModelEvaluationResults()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            AuthoringClient client = new AuthoringClient(endpoint, credential);
            ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();

            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            #region Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResults
            Pageable<UtteranceEvaluationResult> results = authoringClient.GetModelEvaluationResults(
                projectName: projectName,
                trainedModelLabel: trainedModelLabel,
                stringIndexType: stringIndexType
            );

            foreach (UtteranceEvaluationResult result in results)
            {
                Console.WriteLine($"Text: {result.Text}");
                Console.WriteLine($"Language: {result.Language}");

                // Print intents result
                Console.WriteLine($"Expected Intent: {result.IntentsResult.ExpectedIntent}");
                Console.WriteLine($"Predicted Intent: {result.IntentsResult.PredictedIntent}");

                // Print entities result
                Console.WriteLine("Expected Entities:");
                foreach (var entity in result.EntitiesResult.ExpectedEntities)
                {
                    Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
                }

                Console.WriteLine("Predicted Entities:");
                foreach (var entity in result.EntitiesResult.PredictedEntities)
                {
                    Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
                }

                Console.WriteLine();
            }
            #endregion
        }
    }
}
