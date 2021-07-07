// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
        public void Chat()
        {
            QuestionAnsweringClient client = Client;
            KnowledgebaseAnswer previousAnswer = QuestionAnsweringModelFactory.KnowledgebaseAnswer(id: 27);

            #region Snippet:QuestionAnsweringClient_Chat
#if SNIPPET
            // Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
            KnowledgebaseAnswer previousAnswer = answers.Answers.First();
#endif
            KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
            {
                Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
            };

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
        public async Task ChatAsync()
        {
            QuestionAnsweringClient client = Client;
            KnowledgebaseAnswer previousAnswer = QuestionAnsweringModelFactory.KnowledgebaseAnswer(id: 27);

#region Snippet:QuestionAnsweringClient_ChatAsync
#if SNIPPET
            // Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
            KnowledgebaseAnswer previousAnswer = answers.Answers.First();
#endif
            KnowledgebaseQueryOptions options = new KnowledgebaseQueryOptions("How long should charging take?")
            {
                Context = new KnowledgebaseAnswerRequestContext(previousAnswer.Id.Value)
            };

#if SNIPPET
            Response<KnowledgebaseAnswers> response = await client.QueryKnowledgebaseAsync("FAQ", options);
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
