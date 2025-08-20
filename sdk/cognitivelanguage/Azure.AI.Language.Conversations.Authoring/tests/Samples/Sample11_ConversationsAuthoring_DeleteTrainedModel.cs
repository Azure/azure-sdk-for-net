// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
            string projectName = "SampleProject";
            string trainedModelLabel = "SampleModel";
            ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Response response = trainedModelClient.DeleteTrainedModel();

            Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
            #endregion

            Assert.AreEqual(204, response.Status); // Assuming a 204 No Content response indicates successful deletion
        }
    }
}
