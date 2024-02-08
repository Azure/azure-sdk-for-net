// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class ChatExtensionsTests : OpenAITestBase
{
    public ChatExtensionsTests(bool isAsync)
        : base(Scenario.ChatCompletions, isAsync)//, RecordedTestMode.Live)
    {
    }

    public enum ExtensionObjectStrategy
    {
        WithGenericParentType,
        WithScenarioSpecificHelperType
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    public async Task BasicSearchExtensionWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        AzureSearchChatExtensionConfiguration searchExtension = new()
        {
            SearchEndpoint = new Uri("https://openaisdktestsearch.search.windows.net"),
            IndexName = "openai-test-index-carbon-wiki",
            Authentication = new OnYourDataApiKeyAuthenticationOptions(GetCognitiveSearchApiKey().Key),
        };
        AzureChatExtensionsOptions extensionsOptions = new()
        {
            Extensions = { searchExtension },
        };

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatRequestUserMessage("What does PR complete mean?"),
            },
            MaxTokens = 512,
            AzureExtensionsOptions = extensionsOptions,
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.Not.Null);
        Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

        ChatChoice firstChoice = response.Value.Choices[0];
        Assert.That(firstChoice, Is.Not.Null);
        Assert.That(firstChoice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
        Assert.That(firstChoice.Message.Role, Is.EqualTo(ChatRole.Assistant));

        AzureChatExtensionsMessageContext context = firstChoice.Message.AzureExtensionsContext;
        Assert.That(context, Is.Not.Null);
        Assert.That(context.Intent, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0], Is.Not.Null);
        Assert.That(context.Citations[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Title, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Filepath, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Url, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].ChunkId, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    public async Task StreamingSearchExtensionWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        AzureSearchChatExtensionConfiguration searchConfig = new()
        {
            SearchEndpoint = new Uri("https://openaisdktestsearch.search.windows.net"),
            IndexName = "openai-test-index-carbon-wiki",
            Authentication = new OnYourDataApiKeyAuthenticationOptions(GetCognitiveSearchApiKey().Key),
        };

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatRequestUserMessage("What does PR complete mean?"),
            },
            MaxTokens = 512,
            AzureExtensionsOptions = new()
            {
                Extensions = { searchConfig },
            },
        };

        using StreamingResponse<StreamingChatCompletionsUpdate> response
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetRawResponse(), Is.Not.Null);

        ChatRole? streamedRole = null;
        string intent = null;
        IEnumerable<AzureChatExtensionDataSourceResponseCitation> citations = null;
        StringBuilder contentBuilder = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        {
            if (chatUpdate.Role.HasValue)
            {
                Assert.That(streamedRole, Is.Null);
                streamedRole = chatUpdate.Role.Value;
            }
            if (chatUpdate.AzureExtensionsContext?.Intent != null)
            {
                Assert.That(intent, Is.Null);
                intent = chatUpdate.AzureExtensionsContext.Intent;
            }
            if (chatUpdate.AzureExtensionsContext?.Citations?.Count > 0)
            {
                Assert.That(citations, Is.Null);
                citations = chatUpdate.AzureExtensionsContext.Citations;
            }
            contentBuilder.Append(chatUpdate.ContentUpdate);
        }

        Assert.That(streamedRole, Is.EqualTo(ChatRole.Assistant));
        Assert.That(contentBuilder.ToString(), Is.Not.Null.Or.Empty);
        Assert.That(intent, Is.Not.Null.Or.Empty);
        Assert.That(citations, Is.Not.Null.Or.Empty);
        Assert.That(citations.Any(citation => !string.IsNullOrEmpty(citation.Content)));
        Assert.That(citations.Any(citation => !string.IsNullOrEmpty(citation.Title)));
        Assert.That(citations.Any(citation => !string.IsNullOrEmpty(citation.Filepath)));
        Assert.That(citations.Any(citation => !string.IsNullOrEmpty(citation.Url)));
        Assert.That(citations.Any(citation => !string.IsNullOrEmpty(citation.ChunkId)));
    }
}
