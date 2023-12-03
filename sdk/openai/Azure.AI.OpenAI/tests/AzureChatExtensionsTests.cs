// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class AzureChatExtensionsTests : OpenAITestBase
{
    public AzureChatExtensionsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Live)
    {
    }

    public enum ExtensionObjectStrategy
    {
        WithGenericParentType,
        WithScenarioSpecificHelperType
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure, ExtensionObjectStrategy.WithGenericParentType)]
    [TestCase(OpenAIClientServiceTarget.Azure, ExtensionObjectStrategy.WithScenarioSpecificHelperType)]
    public async Task BasicSearchExtensionWorks(
        OpenAIClientServiceTarget serviceTarget,
        ExtensionObjectStrategy extensionStrategy)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.ChatCompletions);

        AzureChatExtensionsOptions extensionsOptions = new();
        switch (extensionStrategy)
        {
            case ExtensionObjectStrategy.WithGenericParentType:
                AzureChatExtensionConfiguration genericConfig = new()
                {
                    Type = "AzureCognitiveSearch",
                    Parameters = BinaryData.FromObjectAsJson(new
                    {
                        Endpoint = "https://openaisdktestsearch.search.windows.net",
                        IndexName = "openai-test-index-carbon-wiki",
                        GetCognitiveSearchApiKey().Key,
                    },
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                };
                extensionsOptions.Extensions.Add(genericConfig);
                break;
            case ExtensionObjectStrategy.WithScenarioSpecificHelperType:
                AzureCognitiveSearchChatExtensionConfiguration helperTypeConfig = new()
                {
                    Type = "AzureCognitiveSearch",
                    SearchEndpoint = new Uri("https://openaisdktestsearch.search.windows.net"),
                    IndexName = "openai-test-index-carbon-wiki"
                };
                helperTypeConfig.SetSearchKey(GetCognitiveSearchApiKey().Key);
                extensionsOptions.Extensions.Add(helperTypeConfig);
                break;
            default:
                throw new NotImplementedException("Don't know how to add the extension config!");
        }

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatMessage(ChatRole.User, "What does PR complete mean?"),
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
        Assert.That(context.Messages.First().Role, Is.EqualTo(ChatRole.Tool));
        Assert.That(context.Messages.First().Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Messages.First().Content.Contains("citations"));
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task StreamingSearchExtensionWorks(OpenAIClientServiceTarget serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.ChatCompletions);

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatMessage(ChatRole.User, "What does PR complete mean?"),
            },
            MaxTokens = 512,
            AzureExtensionsOptions = new()
            {
                Extensions =
                {
                    new AzureChatExtensionConfiguration()
                    {
                        Type = "AzureCognitiveSearch",
                        Parameters = BinaryData.FromObjectAsJson(new
                        {
                            Endpoint = "https://openaisdktestsearch.search.windows.net",
                            IndexName = "openai-test-index-carbon-wiki",
                            GetCognitiveSearchApiKey().Key,
                        },
                        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                    },
                }
            },
        };

        using StreamingResponse<StreamingChatCompletionsUpdate> response
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetRawResponse(), Is.Not.Null);

        ChatRole? streamedRole = null;
        IEnumerable<ChatMessage> azureContextMessages = null;
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
