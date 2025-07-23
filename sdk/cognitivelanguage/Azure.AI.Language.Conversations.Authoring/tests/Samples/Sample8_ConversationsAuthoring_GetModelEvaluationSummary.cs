// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample8_ConversationsAuthoring_GetModelEvaluationSummary : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetModelEvaluationSummary()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample8_ConversationsAuthoring_GetModelEvaluationSummary
            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";
            ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response<ConversationAuthoringEvalSummary> evaluationSummaryResponse = trainedModelClient.GetModelEvaluationSummary();

            // Print entities evaluation summary
            EntitiesEvaluationSummary entitiesEval = evaluationSummaryResponse.Value.EntitiesEvaluation;
            Console.WriteLine($"Entities - Micro F1: {entitiesEval.MicroF1}, Micro Precision: {entitiesEval.MicroPrecision}, Micro Recall: {entitiesEval.MicroRecall}");
            Console.WriteLine($"Entities - Macro F1: {entitiesEval.MacroF1}, Macro Precision: {entitiesEval.MacroPrecision}, Macro Recall: {entitiesEval.MacroRecall}");

            // Print detailed metrics per entity
            foreach (KeyValuePair<string, ConversationAuthoringEntityEvalSummary> entity in entitiesEval.Entities)
            {
                Console.WriteLine($"Entity '{entity.Key}': F1 = {entity.Value.F1}, Precision = {entity.Value.Precision}, Recall = {entity.Value.Recall}");
                Console.WriteLine($"  True Positives: {entity.Value.TruePositiveCount}, True Negatives: {entity.Value.TrueNegativeCount}");
                Console.WriteLine($"  False Positives: {entity.Value.FalsePositiveCount}, False Negatives: {entity.Value.FalseNegativeCount}");
            }

            // Print intents evaluation summary
            IntentsEvaluationSummary intentsEval = evaluationSummaryResponse.Value.IntentsEvaluation;
            Console.WriteLine($"Intents - Micro F1: {intentsEval.MicroF1}, Micro Precision: {intentsEval.MicroPrecision}, Micro Recall: {intentsEval.MicroRecall}");
            Console.WriteLine($"Intents - Macro F1: {intentsEval.MacroF1}, Macro Precision: {intentsEval.MacroPrecision}, Macro Recall: {intentsEval.MacroRecall}");

            // Print detailed metrics per intent
            foreach (KeyValuePair<string, IntentEvaluationSummary> intent in intentsEval.Intents)
            {
                Console.WriteLine($"Intent '{intent.Key}': F1 = {intent.Value.F1}, Precision = {intent.Value.Precision}, Recall = {intent.Value.Recall}");
                Console.WriteLine($"  True Positives: {intent.Value.TruePositiveCount}, True Negatives: {intent.Value.TrueNegativeCount}");
                Console.WriteLine($"  False Positives: {intent.Value.FalsePositiveCount}, False Negatives: {intent.Value.FalseNegativeCount}");
            }

            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetModelEvaluationSummaryAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample8_ConversationsAuthoring_GetModelEvaluationSummaryAsync
            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";
            ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response<ConversationAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelClient.GetModelEvaluationSummaryAsync();

            // Print entities evaluation summary
            EntitiesEvaluationSummary entitiesEval = evaluationSummaryResponse.Value.EntitiesEvaluation;
            Console.WriteLine($"Entities - Micro F1: {entitiesEval.MicroF1}, Micro Precision: {entitiesEval.MicroPrecision}, Micro Recall: {entitiesEval.MicroRecall}");
            Console.WriteLine($"Entities - Macro F1: {entitiesEval.MacroF1}, Macro Precision: {entitiesEval.MacroPrecision}, Macro Recall: {entitiesEval.MacroRecall}");

            // Print detailed metrics per entity
            foreach (KeyValuePair<string, ConversationAuthoringEntityEvalSummary> entity in entitiesEval.Entities)
            {
                Console.WriteLine($"Entity '{entity.Key}': F1 = {entity.Value.F1}, Precision = {entity.Value.Precision}, Recall = {entity.Value.Recall}");
                Console.WriteLine($"  True Positives: {entity.Value.TruePositiveCount}, True Negatives: {entity.Value.TrueNegativeCount}");
                Console.WriteLine($"  False Positives: {entity.Value.FalsePositiveCount}, False Negatives: {entity.Value.FalseNegativeCount}");
            }

            // Print intents evaluation summary
            IntentsEvaluationSummary intentsEval = evaluationSummaryResponse.Value.IntentsEvaluation;
            Console.WriteLine($"Intents - Micro F1: {intentsEval.MicroF1}, Micro Precision: {intentsEval.MicroPrecision}, Micro Recall: {intentsEval.MicroRecall}");
            Console.WriteLine($"Intents - Macro F1: {intentsEval.MacroF1}, Macro Precision: {intentsEval.MacroPrecision}, Macro Recall: {intentsEval.MacroRecall}");

            // Print detailed metrics per intent
            foreach (KeyValuePair<string, IntentEvaluationSummary> intent in intentsEval.Intents)
            {
                Console.WriteLine($"Intent '{intent.Key}': F1 = {intent.Value.F1}, Precision = {intent.Value.Precision}, Recall = {intent.Value.Recall}");
                Console.WriteLine($"  True Positives: {intent.Value.TruePositiveCount}, True Negatives: {intent.Value.TrueNegativeCount}");
                Console.WriteLine($"  False Positives: {intent.Value.FalsePositiveCount}, False Negatives: {intent.Value.FalseNegativeCount}");
            }

            #endregion
        }
    }
}
