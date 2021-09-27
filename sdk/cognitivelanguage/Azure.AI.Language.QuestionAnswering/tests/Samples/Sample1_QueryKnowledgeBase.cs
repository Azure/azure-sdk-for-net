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
            string projectName = "FAQ";
            string deploymentName = "prod";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions(projectName, deploymentName, "How long should my Surface battery last?");
            Response<KnowledgeBaseAnswers> response = client.QueryKnowledgeBase(options);

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
            string projectName = "FAQ";
            string deploymentName = "prod";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QueryKnowledgeBaseOptions options = new QueryKnowledgeBaseOptions(projectName, deploymentName, "How long should my Surface battery last?");
            Response<KnowledgeBaseAnswers> response = await client.QueryKnowledgeBaseAsync(options);

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
