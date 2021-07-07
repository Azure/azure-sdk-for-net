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
        public void QueryKnowledgebase()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_QueryKnowledgebase
            KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should my Surface battery last?");

#if SNIPPET
            Response<KnowledgebaseAnswers> response = client.QueryKnowledgebase("FAQ", options);
#else
            Response<KnowledgebaseAnswers> response = client.QueryKnowledgebase(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);
#endif

            foreach (KnowledgebaseAnswer answer in response.Value.Answers)
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
        public async Task QueryKnowledgebaseAsync()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_QueryKnowledgebaseAsync
#if SNIPPET
            string projectName = "FAQ";
#endif
            KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should my Surface battery last?");

#if SNIPPET
            Response<KnowledgebaseAnswers> response = await client.QueryKnowledgebaseAsync(projectName, options);
#else
            Response<KnowledgebaseAnswers> response = await client.QueryKnowledgebaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);
#endif

            foreach (KnowledgebaseAnswer answer in response.Value.Answers)
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
