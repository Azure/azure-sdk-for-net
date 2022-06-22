// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Sockets;
using System.Text.Json;
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
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.ProjectName, TestEnvironment.DeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.IsNotNull(conversationalTaskResult);

            // assert - prediction type
            Assert.AreEqual(ProjectKind.Conversation, conversationalTaskResult.Result.Prediction.ProjectKind);

            // assert - top intent
            Assert.AreEqual("Send", conversationalTaskResult.Result.Prediction.TopIntent);

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
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29136")]
        public async Task AnalyzeConversation_Orchestration_Luis()
        {
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Reserve a table for 2 at the Italian restaurant")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
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
            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "How are you?")),
                new ConversationTaskParameters(TestEnvironment.OrchestrationProjectName, TestEnvironment.OrchestrationDeploymentName));

            Response response = await Client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            // assert - main object
            Assert.IsNotNull(response);

            // deserialize
            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
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
        }

        [RecordedTest]
        public async Task SupportsAadAuthentication()
        {
            ConversationAnalysisClient client = CreateClient<ConversationAnalysisClient>(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(
                    new ConversationAnalysisClientOptions(ServiceVersion)));

            ConversationalTask conversationalTask = new(
                new ConversationAnalysisOptions(new TextConversationItem("1", "1", "Send an email to Carol about the tomorrow's demo")),
                new ConversationTaskParameters(TestEnvironment.ProjectName, TestEnvironment.DeploymentName));

            Response response = await client.AnalyzeConversationAsync(conversationalTask.AsRequestContent());

            using JsonDocument json = await JsonDocument.ParseAsync(response.ContentStream);
            ConversationalTaskResult conversationalTaskResult = ConversationalTaskResult.DeserializeConversationalTaskResult(json.RootElement);
            Assert.That(conversationalTaskResult.Result.Prediction.TopIntent, Is.EqualTo("Send"));
        }
    }
}
