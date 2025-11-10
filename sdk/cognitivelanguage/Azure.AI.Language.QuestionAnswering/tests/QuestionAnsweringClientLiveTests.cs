// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task SupportsAadAuthentication()
        {
            QuestionAnsweringClientOptions clientOptions = new QuestionAnsweringClientOptions()
            {
                DefaultLanguage = "en",
            };

            QuestionAnsweringClient client = CreateClient<QuestionAnsweringClient>(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(clientOptions));

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(
                "How long it takes to charge surface?",
                new[]
                {
                    "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                    "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it.",

                    "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                    "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface.",
                });

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersKnowledgeBaseQuestion()
        {
            AnswersOptions options = new()
            {
                Size = 3,
                UserId = "sd53lsY=",
                ConfidenceThreshold = 0.2,
                ShortAnswerOptions = new()
                {
                    ConfidenceThreshold = 0.2,
                    Size = 1,
                },
                IncludeUnstructuredSources = true,
            };

            Response<AnswersResult> response = await Client.GetAnswersAsync("How long should my Surface battery last?", TestEnvironment.Project, options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<KnowledgeBaseAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.7).ToList();
            Assert.That(answers, Has.Count.EqualTo(1));
            Assert.That(answers, Has.All.Matches<KnowledgeBaseAnswer>(answer => answer.QnaId == 26 && answer.Source == "surface-book-user-guide-EN.pdf"));
        }

        [RecordedTest]
        public async Task AnswersFollowupKnowledgeBaseQuestion()
        {
            AnswersOptions options = new()
            {
                Size = 3,
                UserId = "sd53lsY=",
                ConfidenceThreshold = 0.5,
                AnswerContext = new(27)
                {
                    PreviousQuestion = "How long should my Surface battery last?",
                },
                ShortAnswerOptions = new()
                {
                    ConfidenceThreshold = 0.2,
                    Size = 1,
                },
                IncludeUnstructuredSources = true,
            };

            Response<AnswersResult> response = await Client.GetAnswersAsync("How long it takes to charge Surface?", TestEnvironment.Project, options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(1));

            IList<KnowledgeBaseAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.6).ToList();
            Assert.That(answers, Has.Count.EqualTo(1));
            Assert.That(answers, Has.All.Matches<KnowledgeBaseAnswer>(answer => answer.QnaId == 23 && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersKnowledgeBaseQuestionWithMetadataFilter()
        {
            AnswersOptions options = new()
            {
                Size = 3,
                Filters = new()
                {
                    MetadataFilter = new()
                    {
                        LogicalOperation = LogicalOperationKind.OR,
                        Metadata =
                        {
                            new("explicitlytaggedheading", "check the battery level"),
                            new("explicitlytaggedheading", "make your battery last"),
                        }
                    },
                },
            };

            Response<AnswersResult> response = await Client.GetAnswersAsync("Battery life", TestEnvironment.Project, options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(2));
            Assert.That(response.Value.Answers, Has.Some.Matches<KnowledgeBaseAnswer>(answer => answer.Metadata.TryGetValue("explicitlytaggedheading", out var value) && value == "check the battery level"));
            Assert.That(response.Value.Answers, Has.Some.Matches<KnowledgeBaseAnswer>(answer => answer.Metadata.TryGetValue("explicitlytaggedheading", out var value) && value == "make your battery last"));
        }

        [RecordedTest]
        public void QueryKnowledgeBaseBadArgument()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await Client.GetAnswersAsync(" ", TestEnvironment.Project);
            });

            Assert.That(ex.Status, Is.EqualTo(400));
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidArgument"));
       }

        [RecordedTest]
        public async Task GetsKnowledgeBaseQuestion()
        {
            Response<AnswersResult> response = await Client.GetAnswersAsync(24, TestEnvironment.Project);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Answers.Count, Is.EqualTo(1));

            KnowledgeBaseAnswer answer = response.Value.Answers[0];
            Assert.That(answer.QnaId, Is.EqualTo(24));
            Assert.That(answer.Questions, Has.All.EqualTo("Check the battery level"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestion()
        {
            AnswersFromTextOptions options = new(
                "How long it takes to charge surface?",
                new TextDocument[]
                {
                    new("1", "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                             "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it."),

                    new("2", "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                             "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface."),
                });

            Response<AnswersFromTextResult> response = await Client.GetAnswersFromTextAsync(options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestionWithLanguage()
        {
            // NOTE: Make sure the test recordings contain `"language": "en"` in the request since body comparisons are disabled.

            QuestionAnsweringClient client = CreateClient(new(ServiceVersion)
            {
                DefaultLanguage = "invalid",
            });

            AnswersFromTextOptions options = new(
                "How long it takes to charge surface?",
                new TextDocument[]
                {
                    new("1", "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                             "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it."),

                    new("2", "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                             "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface."),
                })
            {
                Language = "en",
            };

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestionWithDefaultLanguage()
        {
            // NOTE: Make sure the test recordings contain `"language": "en"` in the request since body comparisons are disabled.

            QuestionAnsweringClient client = CreateClient(new(ServiceVersion)
            {
                DefaultLanguage = "en",
            });

            AnswersFromTextOptions options = new(
                "How long it takes to charge surface?",
                new TextDocument[]
                {
                    new("1", "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                             "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it."),

                    new("2", "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                             "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface."),
                });

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(options);

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestionWithLanguageParameter()
        {
            // NOTE: Make sure the test recordings contain `"language": "en"` in the request since body comparisons are disabled.

            QuestionAnsweringClient client = CreateClient(new(ServiceVersion)
            {
                DefaultLanguage = "invalid",
            });

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(
                "How long it takes to charge surface?",
                new[]
                {
                    "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                    "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it.",

                    "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                    "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface.",
                },
                "en");

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }

        [RecordedTest]
        public async Task AnswersTextQuestionWithDefaultLanguageParameter()
        {
            // NOTE: Make sure the test recordings contain `"language": "en"` in the request since body comparisons are disabled.

            QuestionAnsweringClient client = CreateClient(new(ServiceVersion)
            {
                DefaultLanguage = "en",
            });

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(
                "How long it takes to charge surface?",
                new[]
                {
                    "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                    "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it.",

                    "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                    "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface.",
                });

            Assert.That(response.Value.Answers.Count, Is.EqualTo(3));

            IList<TextAnswer> answers = response.Value.Answers.Where(answer => answer.Confidence > 0.9).ToList();
            Assert.That(answers, Has.Count.AtLeast(2));
            Assert.That(answers, Has.All.Matches<TextAnswer>(answer => answer.Id == "1" && answer.ShortAnswer.Text?.Trim() == "two to four hours"));
        }
    }
}
