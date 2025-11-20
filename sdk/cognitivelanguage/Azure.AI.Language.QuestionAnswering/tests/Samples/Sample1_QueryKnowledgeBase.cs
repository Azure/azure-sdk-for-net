// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void GetAnswers()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_GetAnswers
            string projectName = "{ProjectName}";
            string deploymentName = "{DeploymentName}";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            Response<AnswersResult> response = client.GetAnswers("How long should my Surface battery last?", project);

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"({answer.Confidence:P2}) {answer.Answer}");
                Console.WriteLine($"Source: {answer.Source}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetAnswersAsync()
        {
            QuestionAnsweringClient client = Client;

            #region Snippet:QuestionAnsweringClient_GetAnswersAsync
            string projectName = "{ProjectName}";
            string deploymentName = "{DeploymentName}";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            Response<AnswersResult> response = await client.GetAnswersAsync("How long should my Surface battery last?", project);

            foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
            {
                Console.WriteLine($"({answer.Confidence:P2}) {answer.Answer}");
                Console.WriteLine($"Source: {answer.Source}");
                Console.WriteLine();
            }
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
