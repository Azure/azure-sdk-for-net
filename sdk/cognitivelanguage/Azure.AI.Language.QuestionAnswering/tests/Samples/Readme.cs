// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples : QuestionAnsweringTestBase<QuestionAnsweringClient>
    {
        public void CreateQuestionAnsweringClient()
        {
            #region Snippet:QuestionAnsweringClient_Create
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

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
                Response<KnowledgeBaseAnswers> response = client.QueryKnowledgeBase("invalid-knowledgebase", "test", "Does this knowledge base exist?");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
