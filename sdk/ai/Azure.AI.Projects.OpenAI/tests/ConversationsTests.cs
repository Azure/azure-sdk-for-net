// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.OpenAI.Tests;

/// <summary>
/// Many of these tests are adapted from https://github.com/openai/openai-dotnet/tree/main/tests/Responses.
/// </summary>
public class ConversationsTests : ProjectsOpenAITestBase
{
    public ConversationsTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task ConversationOperationsWork()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();
        ProjectConversation conversation = await client.Conversations.CreateProjectConversationAsync(
            new ProjectConversationCreationOptions()
            {
                Items =
                {
                    ResponseItem.CreateUserMessageItem("hello, world"),
                    ResponseItem.CreateAssistantMessageItem("hi there, user"),
                    ResponseItem.CreateFunctionCallItem("call_abcd1234", "some_function", BinaryData.FromString("{}")),
                    ResponseItem.CreateFunctionCallOutputItem("call_abcd1234", "some_function_output")
                },
            });

        ProjectConversation retrievedConversation = await client.Conversations.GetProjectConversationAsync(conversation.Id);
        Assert.That(retrievedConversation.Id, Is.EqualTo(conversation.Id));

        retrievedConversation = null;
        await foreach (ProjectConversation listedConversation in client.Conversations.GetProjectConversationsAsync(limit: 10))
        {
            if (listedConversation.Id == conversation.Id)
            {
                retrievedConversation = listedConversation;
                break;
            }
        }
        Assert.That(retrievedConversation, Is.Not.Null);

        List<AgentResponseItem> items = [];
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id))
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(4));
        Assert.That(items.First().AsOpenAIResponseItem(), Is.InstanceOf<FunctionCallOutputResponseItem>());
        Assert.That(items.Last().AsOpenAIResponseItem(), Is.InstanceOf<MessageResponseItem>());

        items.Clear();
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id, order: "asc"))
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(4));
        Assert.That(items.First().AsOpenAIResponseItem(), Is.InstanceOf<MessageResponseItem>());
        Assert.That(items.Last().AsOpenAIResponseItem(), Is.InstanceOf<FunctionCallOutputResponseItem>());

        items.Clear();
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id, itemKind: AgentResponseItemKind.Message))
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(2));
        Assert.That(items.All(item => item.AsOpenAIResponseItem() as MessageResponseItem is not null), Is.True);

        AgentResponseItem retrievedItem = await client.Conversations.GetProjectConversationItemAsync(conversation.Id, items.Last().Id);
        Assert.That(retrievedItem.Id, Is.EqualTo(items.Last().Id));

        await client.Conversations.DeleteConversationAsync(conversation.Id);
        Assert.ThrowsAsync<ClientResultException>(async () => await client.Conversations.GetProjectConversationAsync(conversation.Id));

        await foreach (ProjectConversation listedConversation in client.Conversations.GetProjectConversationsAsync(limit: 10))
        {
            if (listedConversation.Id == conversation.Id)
            {
                Assert.Fail($"Found listed conversation that should be deleted: {listedConversation.Id}");
            }
        }
    }
}
