// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples : QuestionAnsweringTestBase<QuestionAnsweringClient>
    {
        public void CreateQuestionAnsweringClient()
        {
            #region Snippet:QuestionAnsweringClient_Create
            Uri endpoint = new Uri("{LanguageEndpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            #endregion
        }

        public void CreateQuestionAnsweringProjectsClient()
        {
            #region Snippet:QuestionAnsweringProjectsClient_Create
            Uri endpoint = new Uri("{LanguageEndpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

            QuestionAnsweringProjectsClient client = new QuestionAnsweringProjectsClient(endpoint, credential);
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
