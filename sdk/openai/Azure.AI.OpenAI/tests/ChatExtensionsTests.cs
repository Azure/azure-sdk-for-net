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

        AzureCognitiveSearchChatExtensionConfiguration searchExtension = new()
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
        Assert.That(context.Messages, Is.Not.Null.Or.Empty);
        Assert.That(context.Messages[0], Is.Not.Null);
        Assert.That(context.Messages[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Messages[0].Content.Contains("citations"));
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    public async Task StreamingSearchExtensionWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        AzureCognitiveSearchChatExtensionConfiguration searchConfig = new()
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
        IEnumerable<ChatResponseMessage> azureContextMessages = null;
        StringBuilder contentBuilder = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        {
            if (chatUpdate.Role.HasValue)
            {
                Assert.That(streamedRole, Is.Null);
                streamedRole = chatUpdate.Role.Value;
            }
            if (chatUpdate.AzureExtensionsContext?.Messages?.Count > 0)
            {
                Assert.That(azureContextMessages, Is.Null);
                azureContextMessages = chatUpdate.AzureExtensionsContext.Messages;
            }
            contentBuilder.Append(chatUpdate.ContentUpdate);
        }

        Assert.That(streamedRole, Is.EqualTo(ChatRole.Assistant));
        Assert.That(contentBuilder.ToString(), Is.Not.Null.Or.Empty);
        Assert.That(azureContextMessages, Is.Not.Null.Or.Empty);
        Assert.That(azureContextMessages.Any(contextMessage => contextMessage.Role == ChatRole.Tool));
        Assert.That(azureContextMessages.Any(contextMessage => !string.IsNullOrEmpty(contextMessage.Content)));
    }
}
