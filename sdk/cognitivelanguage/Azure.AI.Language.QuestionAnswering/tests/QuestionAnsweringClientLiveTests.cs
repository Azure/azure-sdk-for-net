// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringClientLiveTests : QuestionAnsweringTestBase<QuestionAnsweringClient>
    {
        public QuestionAnsweringClientLiveTests(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnswersKnowledgebaseQuestion()
        {
            KnowledgebaseQueryOptions options = new("How long should my Surface battery last?")
            {
                Top = 3,
                UserId = "sd53lsY=",
                ConfidenceScoreThreshold = 0.2,
                AnswerSpanRequest = new()
                {
                    Enable = true,
                    ConfidenceScoreThreshold = 0.2,
                    TopAnswersWithSpan = 1,
                },
                IncludeUnstructuredSources = true,
            };

            Response<KnowledgebaseAnswers> response = await Client.QueryKnowledgebaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<KnowledgebaseAnswer> answers = response.Value.Answers.Where(answer => answer.ConfidenceScore > 0.9).ToList();
            Assert.That(answers, Has.Count.EqualTo(1));
            Assert.That(answers, Has.All.Matches<KnowledgebaseAnswer>(answer => answer.Id == 27 && answer.Source == "surface-pro-4-user-guide-EN.pdf"));
        }

        [RecordedTest]
        public async Task AnswersFollowupKnowledgebaseQuestion()
        {
            KnowledgebaseQueryOptions options = new("How long it takes to charge Surface?")
            {
                Top = 3,
                UserId = "sd53lsY=",
                ConfidenceScoreThreshold = 0.2,
                Context = new(27)
                {
                    PreviousUserQuery = "How long should my Surface battery last?",
                },
                AnswerSpanRequest = new()
                {
                    Enable = true,
                    ConfidenceScoreThreshold = 0.2,
                    TopAnswersWithSpan = 1,
                },
                IncludeUnstructuredSources = true,
            };

            Response<KnowledgebaseAnswers> response = await Client.QueryKnowledgebaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Answers.Count, Is.EqualTo(2));

            IList<KnowledgebaseAnswer> answers = response.Value.Answers.Where(answer => answer.ConfidenceScore > 0.6).ToList();
            Assert.That(answers, Has.Count.EqualTo(1));
            Assert.That(answers, Has.All.Matches<KnowledgebaseAnswer>(answer => answer.Id == 23 && answer.AnswerSpan.Text == "two to four hours"));
        }

        [RecordedTest]
        public void QueryKnowledgebaseBadArgument()
        {
            KnowledgebaseQueryOptions options = new(" ");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await Client.QueryKnowledgebaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);
            });

            Assert.That(ex.Status, Is.EqualTo(400));
            Assert.That(ex.ErrorCode, Is.EqualTo("BadArgument"));
       }

        [RecordedTest]
        public async Task GetsKnowledgebaseQuestion()
        {
            KnowledgebaseQueryOptions options = new(24);

            Response<KnowledgebaseAnswers> response = await Client.QueryKnowledgebaseAsync(TestEnvironment.ProjectName, options, TestEnvironment.DeploymentName);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Answers.Count, Is.EqualTo(1));

            KnowledgebaseAnswer answer = response.Value.Answers[0];
            Assert.That(answer.Id, Is.EqualTo(24));
            Assert.That(answer.Questions, Has.All.EqualTo("Check the battery level"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestion()
        {
            TextQueryOptions options = new(
                "How long it takes to charge surface?",
                new TextInput[]
                {
                    new("1", "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                             "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it."),

                    new("2", "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. "+
                             "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface."),
                });

            Response<TextAnswers> response = await Client.QueryTextAsync(options);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.ConfidenceScore > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.AnswerSpan.Text == "two to four hours"));
        }
    }
}
