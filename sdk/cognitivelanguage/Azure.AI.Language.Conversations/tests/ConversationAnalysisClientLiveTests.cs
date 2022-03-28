// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientLiveTests(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            TextConversationItem textConversationItem = new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo");
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync(textConversationItem, TestEnvironment.Project);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Conversation, customConversationalTaskResult.Results.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Read", customConversationalTaskResult.Results.Prediction.TopIntent);

            // cast prediction
            var conversationPrediction = customConversationalTaskResult.Results.Prediction as ConversationPrediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(conversationPrediction.Intents);
            Assert.IsNotEmpty(conversationPrediction.Entities);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            TextConversationItem textConversationItem = new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo");
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync(textConversationItem, TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Workflow, customConversationalTaskResult.Results.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", customConversationalTaskResult.Results.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Results.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as ConversationTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetKind.Conversation, topIntent.TargetKind);

            // assert entities and intents
            Assert.IsNotEmpty(topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty(topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            TextConversationItem textConversationItem = new TextConversationItem("1", "1", "Reserve a table for 2 at the Italian restaurant");
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync(textConversationItem, TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Workflow, customConversationalTaskResult.Results.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", customConversationalTaskResult.Results.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Results.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as LuisTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetKind.Luis, topIntent.TargetKind);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            TextConversationItem textConversationItem = new TextConversationItem("1", "1", "How are you?");
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync(textConversationItem, TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            CustomConversationalTaskResult customConversationalTaskResult = response.Value as CustomConversationalTaskResult;
            Assert.IsNotNull(customConversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Workflow, customConversationalTaskResult.Results.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", customConversationalTaskResult.Results.Prediction.TopIntent);

            // cast prediction
            var orchestratorPrediction = customConversationalTaskResult.Results.Prediction as OrchestratorPrediction;
            Assert.IsNotNull(orchestratorPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestratorPrediction.Intents);

            // cast top intent
            var topIntent = orchestratorPrediction.Intents[orchestratorPrediction.TopIntent] as QuestionAnsweringTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetKind.QuestionAnswering, topIntent.TargetKind);

            // assert - top intent answers
            Assert.IsNotEmpty(topIntent.Result.Answers);
        }
    }
}
