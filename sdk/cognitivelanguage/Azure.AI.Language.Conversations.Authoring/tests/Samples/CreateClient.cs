// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Authoring.Tests.Samples
{
    public partial class CreateClient : SamplesBase<AuthoringClientTestEnvironment>
    {
        public void CreateAuthoringClient()
        {
            #region Snippet:CreateConversationAuthoringClient
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
            ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
            #endregion
        }
    }
}
