// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
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
    public ConversationsTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
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
        Assert.That(items.First().AsResponseResultItem(), Is.InstanceOf<FunctionCallOutputResponseItem>());
        Assert.That(items.Last().AsResponseResultItem(), Is.InstanceOf<MessageResponseItem>());

        items.Clear();
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id, order: "asc"))
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(4));
        Assert.That(items.First().AsResponseResultItem(), Is.InstanceOf<MessageResponseItem>());
        Assert.That(items.Last().AsResponseResultItem(), Is.InstanceOf<FunctionCallOutputResponseItem>());

        items.Clear();
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id, itemKind: AgentResponseItemKind.Message))
        {
            items.Add(item);
        }

        Assert.That(items, Has.Count.EqualTo(2));
        Assert.That(items.All(item => item.AsResponseResultItem() as MessageResponseItem is not null), Is.True);

        AgentResponseItem retrievedItem = await client.Conversations.GetProjectConversationItemAsync(conversation.Id, items.Last().Id);
        Assert.That(retrievedItem.Id, Is.EqualTo(items.Last().Id));

        await client.Conversations.DeleteConversationAsync(conversation.Id);
        Assert.ThrowsAsync<ClientResultException>(async () => await client.Conversations.GetProjectConversationAsync(conversation.Id));

        int conversationsChecked = 0;

        await foreach (ProjectConversation listedConversation in client.Conversations.GetProjectConversationsAsync(limit: 10))
        {
            if (listedConversation.Id == conversation.Id)
            {
                Assert.Fail($"Found listed conversation that should be deleted: {listedConversation.Id}");
            }
            if (conversationsChecked++ >= 20)
            {
                // Good enough
                break;
            }
        }
    }

    [RecordedTest]
    public async Task ConversationItemPaginationWorks()
    {
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        // Create a conversation
        ProjectConversation conversation = await client.Conversations.CreateProjectConversationAsync();
        Assert.That(conversation?.Id, Does.StartWith("conv_"));

        // Create 40 messages for the conversation
        List<ResponseItem> messagesToAdd = new();
        for (int i = 1; i <= 40; i++)
        {
            messagesToAdd.Add(ResponseItem.CreateUserMessageItem($"Message {i}"));
        }

        // Trying to add all 40 at once should fail
        ClientResultException exceptionFromOperation = Assert.ThrowsAsync<ClientResultException>(async () => _ = await client.Conversations.CreateProjectConversationItemsAsync(conversation.Id, messagesToAdd));
        Assert.That(exceptionFromOperation.GetRawResponse().Content.ToString(), Does.Contain("20 items"));

        List<ResponseItem> firstHalfMessages = [];
        for (int i = 0; i < 20; i++)
        {
            firstHalfMessages.Add(messagesToAdd[i]);
        }
        List<ResponseItem> secondHalfMessages = [];
        for (int i = 20; i < messagesToAdd.Count; i++)
        {
            secondHalfMessages.Add(messagesToAdd[i]);
        }

        ReadOnlyCollection<ResponseItem> createdItems = await client.Conversations.CreateProjectConversationItemsAsync(
            conversation.Id,
            firstHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));
        createdItems = await client.Conversations.CreateProjectConversationItemsAsync(conversation.Id, secondHalfMessages);
        Assert.That(createdItems, Has.Count.EqualTo(20));

        // Test ascending order traversal
        List<AgentResponseItem> ascendingItems = [];
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "asc"))
        {
            ascendingItems.Add(item);
        }
        Assert.That(ascendingItems, Has.Count.EqualTo(40));

        // Test descending order traversal
        List<AgentResponseItem> descendingItems = [];
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(
            conversation.Id,
            limit: 5,
            order: "desc"))
        {
            descendingItems.Add(item);
        }
        Assert.That(descendingItems, Has.Count.EqualTo(40));

        // Verify that ascending and descending lists contain the same items but in reverse order
        descendingItems.Reverse();
        Assert.That(ascendingItems.Count, Is.EqualTo(descendingItems.Count));
        for (int i = 0; i < ascendingItems.Count; i++)
        {
            Assert.That(ascendingItems[i].Id, Is.EqualTo(descendingItems[i].Id),
                $"Item at position {i} should be the same in both orderings");
        }

        // Verify that we can collect all items consistently
        List<AgentResponseItem> allItems = [];
        await foreach (AgentResponseItem item in client.Conversations.GetProjectConversationItemsAsync(conversation.Id))
        {
            allItems.Add(item);
        }
        Assert.That(allItems, Has.Count.EqualTo(40));
    }
}
