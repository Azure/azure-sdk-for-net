// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
#region Snippet:QuestionAnsweringClient_Namespaces
using Azure.Core;
using Azure.AI.Language.QuestionAnswering;
#endregion
#region Snippet:QuestionAnsweringAuthoringClient_Namespace
using Azure.AI.Language.QuestionAnswering.Authoring;
#endregion
#region Snippet:QuestionAnswering_Identity_Namespace
using Azure.Identity;
#endregion
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Inference.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples : QuestionAnsweringTestBase<QuestionAnsweringClient>
    {
        public void CreateQuestionAnsweringClient()
        {
            #region Snippet:QuestionAnsweringClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            #endregion
        }

        public void CreateQuestionAnsweringAuthoringClient()
        {
            #region Snippet:QuestionAnsweringAuthoringClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
            #endregion
        }

        public void CreateQuestionAnsweringClientWithDefaultAzureCredential()
        {
            #region Snippet:QuestionAnsweringClient_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void BadArgument()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_BadRequest
            try
            {
                QuestionAnsweringProject project = new QuestionAnsweringProject("invalid-knowledgebase", "test");
                Response<AnswersResult> response = client.GetAnswers("Does this knowledge base exist?", project);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
