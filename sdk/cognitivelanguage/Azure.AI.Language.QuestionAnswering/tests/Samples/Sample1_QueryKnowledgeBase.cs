// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void QueryKnowledgeBase()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_QueryKnowledgeBase
            QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions("How long should my Surface battery last?");

#if SNIPPET
            Response<KnowledgeBaseAnswers> response = client.QueryKnowledgeBase("FAQ", options);
#else
            Response<KnowledgeBaseAnswers> response = client.QueryKnowledgeBase(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);
#endif

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
                Console.WriteLine($"Source: {answer.Source}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task QueryKnowledgeBaseAsync()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_QueryKnowledgeBaseAsync
#if SNIPPET
            string projectName = "FAQ";
#endif
            QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions("How long should my Surface battery last?");

#if SNIPPET
            Response<KnowledgeBaseAnswers> response = await client.QueryKnowledgeBaseAsync(projectName, options);
#else
            Response<KnowledgeBaseAnswers> response = await client.QueryKnowledgeBaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);
#endif

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"({answer.ConfidenceScore:P2}) {answer.Answer}");
                Console.WriteLine($"Source: {answer.Source}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
