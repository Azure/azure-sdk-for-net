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
        public void Chat()
        {
            QuestionAnsweringClient client = Client;
            KnowledgeBaseAnswer previousAnswer = QuestionAnsweringModelFactory.KnowledgeBaseAnswer(qnaId: 27);

            #region Snippet:QuestionAnsweringClient_Chat
            string projectName = "FAQ";
            string deploymentName = "prod";
#if SNIPPET
            // Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
            KnowledgeBaseAnswer previousAnswer = answers.Answers.First();
#else
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            AnswersOptions options = new AnswersOptions
            {
                AnswerContext = new KnowledgeBaseAnswerContext(previousAnswer.QnaId.Value)
            };

            Response<AnswersResult> response = client.GetAnswers("How long should charging take?", project, options);

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
        public async Task ChatAsync()
        {
            QuestionAnsweringClient client = Client;
            KnowledgeBaseAnswer previousAnswer = QuestionAnsweringModelFactory.KnowledgeBaseAnswer(qnaId: 27);

            #region Snippet:QuestionAnsweringClient_ChatAsync
            string projectName = "FAQ";
            string deploymentName = "prod";
#if SNIPPET
            // Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
            KnowledgeBaseAnswer previousAnswer = answers.Answers.First();
#else
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
#endif
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            AnswersOptions options = new AnswersOptions
            {
                AnswerContext = new KnowledgeBaseAnswerContext(previousAnswer.QnaId.Value)
            };

            Response<AnswersResult> response = await client.GetAnswersAsync("How long should charging take?", project, options);

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
