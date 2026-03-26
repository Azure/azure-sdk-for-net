// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.AI.Language.Conversations.Authoring.Tests;
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
            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";

            Response response = client.DeleteTrainedModel(projectName, trainedModelLabel);

            Console.WriteLine($"Trained model deleted with status: {response.Status}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DeleteTrainedModelAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
            string projectName = "{projectName}";
            string trainedModelLabel = "{trainedModelLabel}";

            Response response = await client.DeleteTrainedModelAsync(projectName, trainedModelLabel);

            Console.WriteLine($"Trained model deleted with status: {response.Status}");
            #endregion
        }
    }
}
