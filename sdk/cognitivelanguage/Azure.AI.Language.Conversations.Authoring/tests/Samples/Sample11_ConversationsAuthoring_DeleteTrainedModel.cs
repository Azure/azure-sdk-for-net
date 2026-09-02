// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class Sample11_ConversationsAuthoring_DeleteTrainedModel : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DeleteTrainedModel()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
            ConversationAuthoringTrainedModel trainedModelClient = client.GetConversationAuthoringTrainedModelClient();

            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";
            Response response = trainedModelClient.DeleteTrainedModel(projectName, trainedModelLabel);

            Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status); // Assuming a 204 No Content response indicates successful deletion
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteTrainedModelAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoring client = new ConversationAnalysisAuthoring(endpoint, credential);

            #region Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
            ConversationAuthoringTrainedModel trainedModelClient = client.GetConversationAuthoringTrainedModelClient();

            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";
            Response response = await trainedModelClient.DeleteTrainedModelAsync(projectName, trainedModelLabel);

            Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status); // Assuming a 204 No Content response indicates successful deletion
        }
    }
}
