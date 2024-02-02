// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class CompletionsTests : OpenAITestBase
    {
        public CompletionsTests(bool isAsync)
            : base(Scenario.Completions, isAsync) // , RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task Completions(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            CompletionsOptions requestOptions = new()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "Hello world",
                    "running over the same old ground",
                },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(requestOptions.Prompts.Count));
            Assert.That(response.Value.Choices[0].FinishReason, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure, Ignore = "Tokens not supported for non-Azure")]
        public async Task CompletionsWithTokenCredential(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget, Scenario.Completions, TestAuthType.Token);
            string deploymentName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentName,
                Prompts = { "Hello, world!", "I can have multiple prompts" },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(2));
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task CompletionsContentFilterCategories(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts = { "How do I cook a bell pepper?" },
                Temperature = 0
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

            Choice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);

            AssertExpectedPromptFilterResults(
                response.Value.PromptFilterResults,
                serviceTarget,
                expectedCount: requestOptions.Prompts.Count * (requestOptions.ChoicesPerPrompt ?? 1));
            AssertExpectedContentFilterResponseResults(firstChoice.ContentFilterResults, serviceTarget);
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task AdvancedCompletionsOptions(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            string promptText = "Are bananas especially radioactive?";
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts = { promptText },
                GenerationSampleCount = 3,
                Temperature = 0.75f,
                User = "AzureSDKOpenAITests",
                Echo = true,
                LogProbabilityCount = 1,
                MaxTokens = 512,
                TokenSelectionBiases =
                {
                    [25996] = -100, // ' banana', with the leading space
                    [35484] = -100, // ' bananas', with the leading space
                    [40058] = -100, // ' Banana'
                    [15991] = -100, // 'anas'
                },
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            string rawResponse = response.GetRawResponse().Content.ToString();
            Assert.That(rawResponse, Is.Not.Null.Or.Empty);

            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));

            Choice choice = response.Value.Choices[0];

            string choiceText = choice.Text;
            Assert.That(choiceText, Is.Not.Null.Or.Empty);
            Assert.That(choiceText.Length, Is.GreaterThan(promptText.Length));
            Assert.That(choiceText.ToLower().StartsWith(promptText.ToLower()));
            Assert.That(choiceText.Substring(promptText.Length).Contains(" banana"), Is.False);

            Assert.That(choice.LogProbabilityModel, Is.Not.Null.Or.Empty);
            Assert.That(choice.LogProbabilityModel.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(response.Value.Choices[0].LogProbabilityModel.Tokens.Count));
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure, Ignore = "Not applicable to non-Azure OpenAI")]
        public void BadDeploymentFails(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            var completionsRequest = new CompletionsOptions()
            {
                DeploymentName = "BAD_DEPLOYMENT_ID",
                Prompts = { "Hello world" },
            };
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetCompletionsAsync(completionsRequest);
            });
            Assert.AreEqual(404, exception.Status);
            Assert.That(exception.ErrorCode, Is.EqualTo("DeploymentNotFound"));
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task TokenCutoff(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget, Scenario.LegacyCompletions);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "How long would it take an unladen swallow to travel between Seattle, WA"
                        + " and New York, NY?"
                },
                MaxTokens = 3,
            };
            Response<Completions> response = await client.GetCompletionsAsync(requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo(CompletionsFinishReason.TokenLimitReached));
            Assert.IsTrue(response.Value.Choices[0].FinishReason == CompletionsFinishReason.TokenLimitReached);
            Assert.IsTrue(response.Value.Choices[0].FinishReason == "length");
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task StreamingCompletions(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget, Scenario.LegacyCompletions);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.LegacyCompletions);
            var requestOptions = new CompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Prompts =
                {
                    "Tell me some jokes about mangos",
                    "What are some disturbing facts about papayas?"
                },
                MaxTokens = 512,
                LogProbabilityCount = 1,
            };

            using StreamingResponse<Completions> response = await client.GetCompletionsStreamingAsync(requestOptions);
            Assert.That(response, Is.Not.Null);

            Dictionary<int, ContentFilterResultsForPrompt> promptFilterResultsByPromptIndex = new();
            Dictionary<int, CompletionsFinishReason> finishReasonsByChoiceIndex = new();
            Dictionary<int, StringBuilder> textBuildersByChoiceIndex = new();

            await foreach (Completions streamingCompletions in response)
            {
                if (streamingCompletions.PromptFilterResults is not null)
                {
                    foreach (ContentFilterResultsForPrompt promptFilterResult in streamingCompletions.PromptFilterResults)
                    {
                        // When providing multiple prompts, the filter results may arrive across separate messages and
                        // the payload array index may differ from the in-data index property
                        AssertExpectedContentFilterRequestResults(promptFilterResult.ContentFilterResults, serviceTarget);
                        promptFilterResultsByPromptIndex[promptFilterResult.PromptIndex] = promptFilterResult;
                    }
                }
                foreach (Choice choice in streamingCompletions.Choices)
                {
                    if (choice.FinishReason.HasValue)
                    {
                        // Each choice should only receive a single finish reason and, in this case, it should be
                        // 'stop'
                        Assert.That(!finishReasonsByChoiceIndex.ContainsKey(choice.Index));
                        Assert.That(choice.FinishReason.Value == CompletionsFinishReason.Stopped);
                        finishReasonsByChoiceIndex[choice.Index] = choice.FinishReason.Value;
                    }

                    // The 'Text' property of streamed Completions will only contain the incremental update for a
                    // choice; these should be appended to each other to form the complete text
                    if (!textBuildersByChoiceIndex.ContainsKey(choice.Index))
                    {
                        textBuildersByChoiceIndex[choice.Index] = new();
                    }
                    textBuildersByChoiceIndex[choice.Index].Append(choice.Text);

                    Assert.That(choice.LogProbabilityModel, Is.Not.Null);

                    if (!string.IsNullOrEmpty(choice.Text))
                    {
                        // Content filter results are only populated when content (text) is present
                        AssertExpectedContentFilterResponseResults(choice.ContentFilterResults, serviceTarget);
                    }
                }
            }

            int expectedPromptCount = requestOptions.Prompts.Count;
            int expectedChoiceCount = expectedPromptCount * (requestOptions.ChoicesPerPrompt ?? 1);

            if (serviceTarget == Service.Azure)
            {
                for (int i = 0; i < expectedPromptCount; i++)
                {
                    Assert.That(promptFilterResultsByPromptIndex.ContainsKey(i));
                }
            }

            for (int i = 0; i < expectedChoiceCount; i++)
            {
                Assert.That(finishReasonsByChoiceIndex.ContainsKey(i));
                Assert.That(textBuildersByChoiceIndex.ContainsKey(i));
                Assert.That(textBuildersByChoiceIndex[i].ToString(), Is.Not.Null.Or.Empty);
            }
        }
    }
}
