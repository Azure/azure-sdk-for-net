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
    public partial class Sample11_ConversationsAuthoring_DeleteTrainedModelAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task DeleteTrainedModelAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";
            ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response response = await trainedModelClient.DeleteTrainedModelAsync();

            Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status); // Assuming a 204 No Content response indicates successful deletion
        }
    }
}
