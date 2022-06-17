// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Send an email to Carol about the tomorrow's demo", TestEnvironment.Project);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            ConversationalTaskResult conversationalTaskResult = response.Value as ConversationalTaskResult;
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Conversation, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Setup", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var conversationPrediction = conversationalTaskResult.Result.Prediction as ConversationPrediction;
            Assert.IsNotNull(conversationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(conversationPrediction.Intents);
            Assert.IsNotEmpty(conversationPrediction.Entities);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Conversation()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Send an email to Carol about the tomorrow's demo", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            ConversationalTaskResult conversationalTaskResult = response.Value as ConversationalTaskResult;
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("EmailIntent", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as ConversationTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Conversation, topIntent.TargetProjectKind);

            // assert entities and intents
            Assert.IsNotEmpty(topIntent.Result.Prediction.Entities);
            Assert.IsNotEmpty(topIntent.Result.Prediction.Intents);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("Reserve a table for 2 at the Italian restaurant", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            ConversationalTaskResult conversationalTaskResult = response.Value as ConversationalTaskResult;
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("RestaurantIntent", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as LuisTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.Luis, topIntent.TargetProjectKind);
        }

        [RecordedTest]
        public async Task AnalyzeConversation_Orchestration_QuestionAnswering()
        {
            Response<AnalyzeConversationTaskResult> response = await Client.AnalyzeConversationAsync("How are you?", TestEnvironment.OrchestrationProject);

            // assert - main object
            Assert.IsNotNull(response);

            // cast
            ConversationalTaskResult conversationalTaskResult = response.Value as ConversationalTaskResult;
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Orchestration, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("ChitChat-QnA", conversationalTaskResult.Result.Prediction.TopIntent);

            // cast prediction
            var orchestrationPrediction = conversationalTaskResult.Result.Prediction as OrchestrationPrediction;
            Assert.IsNotNull(orchestrationPrediction);

            // assert - not empty
            Assert.IsNotEmpty(orchestrationPrediction.Intents);

            // cast top intent
            var topIntent = orchestrationPrediction.Intents[orchestrationPrediction.TopIntent] as QuestionAnsweringTargetIntentResult;
            Assert.IsNotNull(topIntent);

            // assert - inent target kind
            Assert.AreEqual(TargetProjectKind.QuestionAnswering, topIntent.TargetProjectKind);

            // assert - top intent answers
            Assert.IsNotEmpty(topIntent.Result.Answers);
        }
    }
}
