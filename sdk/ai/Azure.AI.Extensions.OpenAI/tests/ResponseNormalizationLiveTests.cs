// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001
/// <summary>
/// Live/recorded tests that verify Azure-only <see cref="ResponseItem"/> / <see cref="ResponseTool"/>
/// subtypes round-trip through the real service and materialize as their strongly-typed Azure
/// subtypes via the normalization bridge, without the caller having to invoke
/// <c>AsAgentResponseItem()</c>. Each test targets a distinct response funnel
/// (non-streaming create, retrieval, list, streaming) plus the conversation-item type-builder path,
/// so that regressions are attributed to the funnel they affect. All tests reuse the Bing grounding
/// connection provisioned by the default test-resources scripts.
/// </summary>
public class ResponseNormalizationLiveTests : ProjectsOpenAITestBase
{
    private const string OpenAIUnknownItemTypeName = "OpenAI.Responses.InternalUnknownItemResource";

    private const string BingGroundingPrompt =
        "What is the latest news about the Mars Perseverance rover? Use Bing grounding.";

    public ResponseNormalizationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    // Test 3 (create funnel + tool-echo): the original promise of the normalization bridge on the
    // non-streaming create funnel. An Azure-only tool-call output item (Bing grounding) round-trips
    // through the real service and materializes as its strongly-typed Azure subtype WITHOUT the
    // caller invoking AsAgentResponseItem(). Also asserts the echoed tool definition is typed.
    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesToTypedItem()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        ResponseResult response = await responsesClient.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool));

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        // The crux: the Bing grounding call surfaces as the typed Azure subtype directly off
        // OutputItems, with no AsAgentResponseItem() conversion by the caller.
        BingGroundingToolCall bingCall = response.OutputItems.OfType<BingGroundingToolCall>().FirstOrDefault();
        Assert.That(
            bingCall,
            Is.Not.Null,
            "Expected a strongly-typed BingGroundingToolCall in OutputItems (normalization bridge). "
            + "Getting InternalUnknownItemResource instead means the bridge did not fire.");

        AssertNoOpaqueUnknownItems(response);

        // Tool-echo: the Bing tool definition echoed back in response.Tools should also normalize.
        Assert.That(
            response.Tools.OfType<BingGroundingTool>().Any(),
            Is.True,
            "Expected the echoed Bing grounding tool definition to normalize to BingGroundingTool.");
    }

    // Test 2 (retrieval funnel): a Bing response created, then re-fetched via GetResponse(id), must
    // normalize to the typed Azure subtype. This proves the retrieval funnel normalizes persisted
    // service payloads, not just the create response object.
    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesOnRetrieval()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        ResponseResult created = await responsesClient.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool));
        Assert.That(created?.Id, Is.Not.Null.And.Not.Empty);

        ResponseResult retrieved = await responsesClient.GetResponseAsync(created.Id);

        Assert.That(retrieved.Id, Is.EqualTo(created.Id));
        Assert.That(
            retrieved.OutputItems.OfType<BingGroundingToolCall>().Any(),
            Is.True,
            "The retrieval funnel (GetResponse) should normalize the Bing grounding call to its typed subtype.");
        AssertNoOpaqueUnknownItems(retrieved);
    }

    // Test 4 (call + output pairing): the tool call and its output item are distinct Azure
    // discriminators. Assert both surface as their strongly-typed subtypes end-to-end, and that a
    // returned output is paired to a call via CallId.
    [RecordedTest]
    public async Task BingGroundingToolCallAndOutputAreTyped()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        ResponseResult response = await responsesClient.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool));

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        BingGroundingToolCall bingCall = response.OutputItems.OfType<BingGroundingToolCall>().FirstOrDefault();
        Assert.That(bingCall, Is.Not.Null, "Expected a typed BingGroundingToolCall.");
        AssertNoOpaqueUnknownItems(response);

        // Any bing-grounding output item present must be its strongly-typed subtype (never opaque),
        // and must reference a preceding call.
        List<BingGroundingToolCallOutput> outputs =
            response.OutputItems.OfType<BingGroundingToolCallOutput>().ToList();
        foreach (BingGroundingToolCallOutput output in outputs)
        {
            Assert.That(
                output.CallId,
                Is.Not.Null.And.Not.Empty,
                "A typed BingGroundingToolCallOutput should carry the CallId that pairs it to its call.");
        }
    }

    // Test 5 (list funnel): a Bing response scoped to a conversation, re-listed via
    // GetProjectResponses(conversationId), must have its output items normalized. This proves the
    // list funnel normalizes each enumerated response, not just single-response funnels.
    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesInListFunnel()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ProjectConversation conversation = await client.GetProjectConversationsClient().CreateProjectConversationAsync();
        ProjectResponsesClient responsesForConversation =
            client.GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME, conversation.Id);

        ResponseResult created = await responsesForConversation.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool, includeModel: false));
        Assert.That(created?.Id, Is.Not.Null.And.Not.Empty);

        List<ResponseResult> listed = [];
        await foreach (ResponseResult response in client.GetProjectResponsesClient().GetProjectResponsesAsync(conversationId: conversation.Id))
        {
            listed.Add(response);
        }

        Assert.That(listed, Has.Count.EqualTo(1));
        Assert.That(
            listed[0].OutputItems.OfType<BingGroundingToolCall>().Any(),
            Is.True,
            "The list funnel (GetProjectResponses) should normalize each response's Bing grounding call.");
        AssertNoOpaqueUnknownItems(listed[0]);
    }

    // Test 6 (over-normalization guard): a response containing both an Azure-specific item (Bing
    // grounding) and a plain OpenAI-recognized assistant message. The Azure item must be typed while
    // the plain message must remain MessageResponseItem — normalization must not disturb items OpenAI
    // already understands.
    [RecordedTest]
    public async Task NormalizationLeavesRecognizedMessageItemsUnchanged()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        ResponseResult response = await responsesClient.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool));

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(
            response.OutputItems.OfType<BingGroundingToolCall>().Any(),
            Is.True,
            "Expected the Azure Bing grounding call to be typed.");

        // The assistant's answer should still be an ordinary, OpenAI-recognized message item whose
        // concrete type is exactly MessageResponseItem (not re-dispatched to any Azure subtype).
        MessageResponseItem messageItem = response.OutputItems.OfType<MessageResponseItem>().FirstOrDefault();
        Assert.That(
            messageItem,
            Is.Not.Null,
            "Expected the assistant answer to remain a plain MessageResponseItem after normalization.");
        Assert.That(
            messageItem.GetType(),
            Is.EqualTo(typeof(MessageResponseItem)),
            "A message item OpenAI already recognizes should not be altered by normalization.");
        AssertNoOpaqueUnknownItems(response);
    }

    // Test 1 (streaming create funnel): the streaming path is bridged by
    // Normalizing[Async]StreamingCollectionResult rather than a single post-hoc pass. Assert the
    // Bing grounding item is typed on the incremental output_item.added / output_item.done updates
    // AND on the terminal completed update's response snapshot, with no opaque item leaking anywhere.
    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesInStreamingFunnel()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        CreateResponseOptions options = CreateBingResponseOptions(bingGroundingTool);
        options.StreamingEnabled = true;

        bool sawTypedItemUpdate = false;
        StreamingResponseCompletedUpdate completedUpdate = null;

        await foreach (StreamingResponseUpdate update in responsesClient.CreateResponseStreamingAsync(options))
        {
            switch (update)
            {
                case StreamingResponseOutputItemAddedUpdate added:
                    AssertNotOpaqueUnknownItem(added.Item);
                    sawTypedItemUpdate |= added.Item is BingGroundingToolCall;
                    break;
                case StreamingResponseOutputItemDoneUpdate done:
                    AssertNotOpaqueUnknownItem(done.Item);
                    sawTypedItemUpdate |= done.Item is BingGroundingToolCall;
                    break;
                case StreamingResponseCompletedUpdate completed:
                    completedUpdate = completed;
                    break;
            }
        }

        Assert.That(completedUpdate, Is.Not.Null, "Expected a terminal response.completed update.");
        Assert.That(
            sawTypedItemUpdate,
            Is.True,
            "Expected an incremental output-item update to carry a typed BingGroundingToolCall "
            + "(the streaming normalization bridge should type items as they arrive).");
        Assert.That(
            completedUpdate.Response.OutputItems.OfType<BingGroundingToolCall>().Any(),
            Is.True,
            "The completed update's response snapshot should contain a typed BingGroundingToolCall.");
        AssertNoOpaqueUnknownItems(completedUpdate.Response);
    }

    // Test 7 (conversation-item type-builder path): conversation items are materialized through the
    // AzureAIExtensionsOpenAIContext type-builder at read time, a mechanism entirely separate from
    // the ProjectResponsesClient post-hoc normalization. Run a Bing response tied to a conversation,
    // then read the conversation's items back and assert the Azure tool-call item is strongly typed.
    [RecordedTest]
    public async Task ConversationItemsMaterializeAzureSubtypes()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ProjectConversation conversation = await client.GetProjectConversationsClient().CreateProjectConversationAsync();
        ProjectResponsesClient responsesForConversation =
            client.GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME, conversation.Id);

        ResponseResult response = await responsesForConversation.CreateResponseAsync(
            CreateBingResponseOptions(bingGroundingTool, includeModel: false));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

        List<ResponseItem> items = [];
        await foreach (ResponseItem item in client.GetProjectConversationsClient().GetProjectConversationItemsAsync(conversation.Id))
        {
            items.Add(item);
        }

        Assert.That(items, Is.Not.Empty, "Expected the conversation to contain items after running a response.");
        Assert.That(
            items.OfType<BingGroundingToolCall>().Any(),
            Is.True,
            "Conversation items should materialize the Azure BingGroundingToolCall via the type-builder path.");
        Assert.That(
            items.Any(item => item.GetType().FullName == OpenAIUnknownItemTypeName),
            Is.False,
            "No conversation item should remain OpenAI's opaque InternalUnknownItemResource.");
    }

    private async Task<BingGroundingTool> GetBingGroundingToolAsync()
    {
        string bingConnectionName = TryGetBingConnectionName();
        if (string.IsNullOrEmpty(bingConnectionName))
        {
            Assert.Ignore("BING_CONNECTION_NAME is not configured; skipping until a Bing grounding connection is provisioned.");
        }

        AIProjectConnection bingConnection =
            await GetTestProjectClient().Connections.GetConnectionAsync(connectionName: bingConnectionName);

        return new BingGroundingTool(
            new BingGroundingSearchToolOptions(
                searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnection.Id)]));
    }

    private CreateResponseOptions CreateBingResponseOptions(BingGroundingTool bingGroundingTool, bool includeModel = true)
    {
        CreateResponseOptions options = new()
        {
            Tools = { bingGroundingTool },
            InputItems = { ResponseItem.CreateUserMessageItem(BingGroundingPrompt) },
        };
        if (includeModel)
        {
            options.Model = TestEnvironment.FOUNDRY_MODEL_NAME;
        }
        return options;
    }

    private static void AssertNoOpaqueUnknownItems(ResponseResult response)
    {
        Assert.That(
            response.OutputItems.Any(item => item.GetType().FullName == OpenAIUnknownItemTypeName),
            Is.False,
            "No output item should remain OpenAI's opaque InternalUnknownItemResource after normalization.");
    }

    private static void AssertNotOpaqueUnknownItem(ResponseItem item)
    {
        Assert.That(
            item?.GetType().FullName,
            Is.Not.EqualTo(OpenAIUnknownItemTypeName),
            "A streamed output item should not remain OpenAI's opaque InternalUnknownItemResource after normalization.");
    }

    private string TryGetBingConnectionName()
    {
        try
        {
            return TestEnvironment.BING_CONNECTION_NAME;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
#pragma warning restore AAIP001
