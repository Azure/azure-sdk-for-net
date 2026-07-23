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
using OpenAI.Conversations;

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
    [Ignore("5453301")]
    [RecordedTest]
    public async Task BingGroundingToolCallDeserializesInListFunnel()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ConversationResource conversation = await client.GetProjectConversationsClient().CreateProjectConversationAsync();
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

        // The assistant's answer should still be an OpenAI-recognized message item. The service
        // returns it as an OpenAI internal subtype of MessageResponseItem (e.g.
        // InternalResponsesAssistantMessage); normalization must not re-dispatch it into an
        // Azure-specific type.
        MessageResponseItem messageItem = response.OutputItems.OfType<MessageResponseItem>().FirstOrDefault();
        Assert.That(
            messageItem,
            Is.Not.Null,
            "Expected the assistant answer to remain a MessageResponseItem after normalization.");
        Assert.That(
            messageItem.GetType().FullName,
            Does.StartWith("OpenAI."),
            "A message item OpenAI already recognizes should not be re-dispatched to an Azure type by normalization.");
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
    [Ignore("5453301")]
    [RecordedTest]
    public async Task ConversationItemsMaterializeAzureSubtypes()
    {
        BingGroundingTool bingGroundingTool = await GetBingGroundingToolAsync();
        ProjectOpenAIClient client = GetTestProjectOpenAIClient();

        ConversationResource conversation = await client.GetProjectConversationsClient().CreateProjectConversationAsync();
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

    // Test 8 (second tool kind — guards against Bing-specific special-casing): the normalization
    // bridge must type ANY Azure tool/item discriminator, not just Bing grounding. The
    // CaptureStructuredOutputs tool needs only a model (no connection), so it isolates the bridge
    // from connection-dependent behavior. Assert both that the echoed tool definition normalizes to
    // CaptureStructuredOutputsTool (NormalizeAgentTools is not hard-coded to Bing) and that the
    // structured-output item the model produces materializes as the typed
    // AgentStructuredOutputsResponseItem rather than an opaque InternalUnknownItemResource.
    [RecordedTest]
    public async Task StructuredOutputsToolAndItemAreTyped()
    {
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient().GetProjectResponsesClient();

        CaptureStructuredOutputsTool structuredOutputsTool = CreateCapitalCaptureTool();

        CreateResponseOptions options = new()
        {
            Model = TestEnvironment.FOUNDRY_MODEL_NAME,
            Tools = { structuredOutputsTool },
            InputItems =
            {
                ResponseItem.CreateUserMessageItem(
                    "What is the capital of France? Capture the country and its capital as structured output."),
            },
        };

        ResponseResult response = await responsesClient.CreateResponseAsync(options);

        Assert.That(response, Is.Not.Null);

        // Tool-echo: the non-Bing Azure tool definition echoed in response.Tools must normalize to
        // its typed subtype. This is the deterministic proof that NormalizeAgentTools handles tool
        // kinds beyond Bing grounding.
        Assert.That(
            response.Tools.OfType<CaptureStructuredOutputsTool>().Any(),
            Is.True,
            "Expected the echoed capture-structured-outputs tool to normalize to CaptureStructuredOutputsTool. "
            + "Getting an opaque/unknown tool instead means the bridge is special-cased to Bing.");

        AssertNoOpaqueUnknownItems(response);

        // The structured-output item the tool produces must surface as the typed Azure subtype
        // directly off OutputItems, with no AsAgentResponseItem() conversion by the caller.
        AgentStructuredOutputsResponseItem structuredItem =
            response.OutputItems.OfType<AgentStructuredOutputsResponseItem>().FirstOrDefault();
        Assert.That(
            structuredItem,
            Is.Not.Null,
            "Expected a strongly-typed AgentStructuredOutputsResponseItem in OutputItems (normalization bridge). "
            + "Getting InternalUnknownItemResource instead means the bridge did not fire for this tool kind.");
        Assert.That(
            structuredItem.Output,
            Is.Not.Null,
            "The structured-output item should carry the captured output payload.");
    }

    // Test 9 (item-level agent attribution — the AGENT funnel): every test above targets a MODEL
    // (CreateResponseOptions.Model + a tool), so the service returns no per-item agent_reference /
    // response_id and those tests only ever asserted item TYPE. That is exactly why the silent loss
    // of these Azure-only @@copyProperties fields went uncaught. An AGENT-targeted response echoes,
    // on each output item, which agent produced it (agent_reference) and which response it belongs to
    // (response_id). This test drives that funnel and asserts the VALUES survive normalization.
    // Authored pending a live recording (the existing recordings are model calls without item-level
    // attribution), so it is [LiveOnly] until recorded.
    [RecordedTest]
    public async Task AgentResponseItemsCarryAgentAttribution()
    {
        ProjectResponsesClient responsesClient = GetTestProjectOpenAIClient()
            .GetProjectResponsesClientForAgent(new AgentReference(TestEnvironment.FOUNDRY_AGENT_NAME));

        ResponseResult response = await responsesClient.CreateResponseAsync(
            "What is the latest news about the Mars Perseverance rover?");

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        // The whole-response agent attribution (already surfaced pre-fix) anchors the expected value.
        Assert.That(response.Agent?.Name, Is.EqualTo(TestEnvironment.FOUNDRY_AGENT_NAME));
        Assert.That(response.OutputItems, Is.Not.Empty);

        // The crux: at least one output item must carry the per-item attribution that was dropped,
        // and any item that carries it must report the producing agent and the owning response.
        List<ResponseItem> attributedItems =
            response.OutputItems.Where(item => item.AgentReference is not null).ToList();
        Assert.That(
            attributedItems,
            Is.Not.Empty,
            "Expected at least one output item to carry per-item agent attribution (agent_reference). "
            + "Its absence is the regression this test guards against.");

        foreach (ResponseItem item in attributedItems)
        {
            Assert.That(
                item.AgentReference.Name,
                Is.EqualTo(TestEnvironment.FOUNDRY_AGENT_NAME),
                "Each attributed output item should name the agent that produced it (agent_reference).");
            Assert.That(
                item.ResponseId,
                Is.EqualTo(response.Id),
                "Each attributed output item should reference the response it was created on (response_id).");
        }
    }

    // Builds a minimal strict JSON-schema structured-output definition. Schema is a dictionary of
    // top-level JSON-schema keys to raw JSON values (see StructuredOutputDefinition serialization).
    private static CaptureStructuredOutputsTool CreateCapitalCaptureTool()
    {
        StructuredOutputDefinition definition = new(
            name: "capital_info",
            description: "Captures a country and its capital city.",
            schema: new Dictionary<string, BinaryData>
            {
                ["type"] = BinaryData.FromString("\"object\""),
                ["properties"] = BinaryData.FromString(
                    """{"country":{"type":"string"},"capital":{"type":"string"}}"""),
                ["required"] = BinaryData.FromString("""["country","capital"]"""),
                ["additionalProperties"] = BinaryData.FromString("false"),
            },
            isStrict: true);

        return new CaptureStructuredOutputsTool(definition);
    }

    private async Task<BingGroundingTool> GetBingGroundingToolAsync()
    {
        // Intentionally not guarded: a missing BING_CONNECTION_NAME must fail the test (via the
        // GetRecordedVariable exception), not silently skip it.
        string bingConnectionName = TestEnvironment.BING_CONNECTION_NAME;

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
            // Force a tool call so the Bing grounding item deterministically appears in the output;
            // without this the model may answer without grounding, making the item-level assertions
            // flaky in Live.
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
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
}
#pragma warning restore AAIP001
