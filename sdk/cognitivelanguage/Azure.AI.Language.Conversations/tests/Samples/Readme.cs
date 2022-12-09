// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

#region Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.AI.Language.Conversations;
#endregion
#region Snippet:ConversationAuthoringClient_Namespace
using Azure.AI.Language.Conversations.Authoring;
#endregion
#region Snippet:Conversation_Identity_Namespace
using Azure.Identity;
#endregion

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public void CreateConversationAnalysisClient()
        {
            #region Snippet:ConversationAnalysisClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
            #endregion
        }

        public void CreateConversationAnalysisClientWithDefaultAzureCredential()
        {
            #region Snippet:ConversationAnalysisClient_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();

            ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void BadArgument()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysisClient_BadRequest
            try
            {
                var data = new
                {
                    analysisInput = new
                    {
                        conversationItem = new
                        {
                            text = "Send an email to Carol about tomorrow's demo",
                            id = "1",
                            participantId = "1",
                        }
                    },
                    parameters = new
                    {
                        projectName = "invalid-project",
                        deploymentName = "production",

                        // Use Utf16CodeUnit for strings in .NET.
                        stringIndexType = "Utf16CodeUnit",
                    },
                    kind = "Conversation",
                };

                Response response = client.AnalyzeConversation(RequestContent.Create(data));
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
