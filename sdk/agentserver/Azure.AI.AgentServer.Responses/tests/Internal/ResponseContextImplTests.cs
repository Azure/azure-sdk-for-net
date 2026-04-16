// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// Unit tests for <see cref="ResponseContextImpl"/>.GetInputItemsAsync and GetHistoryAsync.
/// </summary>
public class ResponseContextImplTests
{
    private ResponseContextImpl CreateContext(
        CreateResponse request,
        ResponsesProvider? provider = null,
        IOptions<ResponsesServerOptions>? options = null)
    {
        return new ResponseContextImpl(
            "resp_test",
            provider ?? new StubProvider(),
            request,
            options);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T044: Resolves inline ItemMessage to OutputItemMessage
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetInputItemsAsync_Resolves_Inline_ItemMessage_To_OutputItemMessage()
    {
        var request = CreateRequestWithJsonInput(
            """[{"type":"message","role":"user","content":[{"type":"input_text","text":"Hello, world!"}]}]""");

        var context = CreateContext(request);
        var items = await context.GetInputItemsAsync();

        XAssert.Single(items);
        var msg = XAssert.IsType<OutputItemMessage>(items[0]);
        XAssert.StartsWith("msg_", msg.Id);
        Assert.That(msg.Status, Is.EqualTo(MessageStatus.Completed));
        Assert.That(msg.Role, Is.EqualTo(MessageRole.User));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T045: Resolves ItemReferenceParam via ResponsesProvider.GetItemsAsync
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetInputItemsAsync_Resolves_ItemReferenceParam_Via_Provider()
    {
        var referencedItem = new OutputItemMessage(
            "msg_existing",
            MessageStatus.Completed,
            MessageRole.Assistant,
            new List<MessageContent>
            {
                new MessageContentInputTextContent("I'm a resolved item")
            });

        var provider = new StubProvider();
        provider.AddItem("msg_existing", referencedItem);

        var request = CreateRequestWithJsonInput(
            """[{"type":"item_reference","id":"msg_existing"}]""");

        var context = CreateContext(request, provider);
        var items = await context.GetInputItemsAsync();

        XAssert.Single(items);
        var msg = XAssert.IsType<OutputItemMessage>(items[0]);
        Assert.That(msg.Id, Is.EqualTo("msg_existing"));
        Assert.That(msg.Role, Is.EqualTo(MessageRole.Assistant));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T046: Returns cached singleton on second call
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetInputItemsAsync_Returns_Cached_Result_On_Second_Call()
    {
        var provider = new RecordingProvider();

        var request = CreateRequestWithJsonInput(
            """[{"type":"message","role":"user","content":[{"type":"input_text","text":"First call"}]}]""");

        var context = CreateContext(request, provider);

        var result1 = await context.GetInputItemsAsync();
        var result2 = await context.GetInputItemsAsync();

        Assert.That(result2, Is.SameAs(result1));
        // Provider.GetItemsAsync should not be called at all (no references)
        Assert.That(provider.GetItemsCallCount, Is.EqualTo(0));
    }

    [Test]
    public async Task GetInputItemsAsync_With_References_Calls_Provider_Only_Once()
    {
        var provider = new RecordingProvider();
        provider.AddItem("ref_1", new OutputItemMessage(
            "ref_1", MessageStatus.Completed, MessageRole.User,
            new List<MessageContent> { new MessageContentInputTextContent("ref") }));

        var request = CreateRequestWithJsonInput(
            """[{"type":"item_reference","id":"ref_1"}]""");

        var context = CreateContext(request, provider);

        await context.GetInputItemsAsync();
        await context.GetInputItemsAsync();

        Assert.That(provider.GetItemsCallCount, Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T047: Preserves input item order
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetInputItemsAsync_Preserves_Input_Item_Order()
    {
        var provider = new StubProvider();
        provider.AddItem("ref_middle", new OutputItemMessage(
            "ref_middle", MessageStatus.Completed, MessageRole.Assistant,
            new List<MessageContent> { new MessageContentInputTextContent("middle ref") }));

        var request = CreateRequestWithJsonInput("""
            [
                {"type":"message","role":"user","content":[{"type":"input_text","text":"first"}]},
                {"type":"item_reference","id":"ref_middle"},
                {"type":"message","role":"user","content":[{"type":"input_text","text":"third"}]}
            ]
            """);

        var context = CreateContext(request, provider);
        var items = await context.GetInputItemsAsync();

        Assert.That(items.Count, Is.EqualTo(3));

        // First item: inline message
        var first = XAssert.IsType<OutputItemMessage>(items[0]);
        XAssert.StartsWith("msg_", first.Id);

        // Second item: resolved reference
        var second = XAssert.IsType<OutputItemMessage>(items[1]);
        Assert.That(second.Id, Is.EqualTo("ref_middle"));

        // Third item: inline message
        var third = XAssert.IsType<OutputItemMessage>(items[2]);
        XAssert.StartsWith("msg_", third.Id);

        // First and third should have different generated IDs
        Assert.That(third.Id, Is.Not.EqualTo(first.Id));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T048: Returns empty list when request has no input
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetInputItemsAsync_Returns_Empty_When_No_Input()
    {
        var request = CreateRequestWithJsonInput("[]");

        var context = CreateContext(request);
        var items = await context.GetInputItemsAsync();

        Assert.That(items, Is.Empty);
    }

    [Test]
    public async Task GetInputItemsAsync_Returns_Empty_When_Input_Is_Null()
    {
        // CreateResponse with no input set at all
        var request = new CreateResponse { Model = "test" };

        var context = CreateContext(request);
        var items = await context.GetInputItemsAsync();

        Assert.That(items, Is.Empty);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T054: GetHistoryAsync returns history items in ascending order
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetHistoryAsync_Returns_History_Items_In_Ascending_Order()
    {
        var provider = new StubProvider();
        provider.SetHistoryItemIds("prev_resp_1", new[] { "hist_1", "hist_2", "hist_3" });
        provider.AddItem("hist_1", MakeMessage("hist_1", "First"));
        provider.AddItem("hist_2", MakeMessage("hist_2", "Second"));
        provider.AddItem("hist_3", MakeMessage("hist_3", "Third"));

        var request = new CreateResponse { Model = "test", PreviousResponseId = "prev_resp_1" };
        var context = CreateContext(request, provider);

        var items = await context.GetHistoryAsync();

        Assert.That(items.Count, Is.EqualTo(3));
        var first = XAssert.IsType<OutputItemMessage>(items[0]);
        var second = XAssert.IsType<OutputItemMessage>(items[1]);
        var third = XAssert.IsType<OutputItemMessage>(items[2]);
        Assert.That(first.Id, Is.EqualTo("hist_1"));
        Assert.That(second.Id, Is.EqualTo("hist_2"));
        Assert.That(third.Id, Is.EqualTo("hist_3"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T055: GetHistoryAsync returns empty when no conversation context
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetHistoryAsync_Returns_Empty_When_No_PreviousResponseId_And_No_Conversation()
    {
        var request = new CreateResponse { Model = "test" };
        var context = CreateContext(request);

        var items = await context.GetHistoryAsync();

        Assert.That(items, Is.Empty);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T056: GetHistoryAsync returns cached singleton on second call
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetHistoryAsync_Returns_Cached_Result_On_Second_Call()
    {
        var provider = new RecordingProvider();
        provider.SetHistoryItemIds("prev_resp_1", new[] { "hist_1" });
        provider.AddItem("hist_1", MakeMessage("hist_1", "cached"));

        var request = new CreateResponse { Model = "test", PreviousResponseId = "prev_resp_1" };
        var context = CreateContext(request, provider);

        var result1 = await context.GetHistoryAsync();
        var result2 = await context.GetHistoryAsync();

        Assert.That(result2, Is.SameAs(result1));
        Assert.That(provider.GetHistoryItemIdsCallCount, Is.EqualTo(1));
        Assert.That(provider.GetItemsCallCount, Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T057: GetHistoryAsync uses DefaultFetchHistoryCount from options
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task GetHistoryAsync_Uses_DefaultFetchHistoryCount_As_Limit()
    {
        var provider = new RecordingProvider();
        provider.SetHistoryItemIds("prev_resp_1", new[] { "hist_1" });
        provider.AddItem("hist_1", MakeMessage("hist_1", "item"));

        var options = Options.Create(new ResponsesServerOptions { DefaultFetchHistoryCount = 42 });
        var request = new CreateResponse { Model = "test", PreviousResponseId = "prev_resp_1" };
        var context = CreateContext(request, provider, options);

        await context.GetHistoryAsync();

        Assert.That(provider.LastHistoryLimit, Is.EqualTo(42));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    private static CreateResponse CreateRequestWithJsonInput(string inputJson)
    {
        return new CreateResponse
        {
            Model = "test",
            Input = BinaryData.FromString(inputJson),
        };
    }

    private static OutputItemMessage MakeMessage(string id, string text)
    {
        return new OutputItemMessage(
            id, MessageStatus.Completed, MessageRole.User,
            new List<MessageContent> { new MessageContentInputTextContent(text) });
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Stub/Recording Providers
    // ═══════════════════════════════════════════════════════════════════════

    private class StubProvider : ResponsesProvider
    {
        private readonly Dictionary<string, OutputItem> _items = new();
        private readonly Dictionary<string, string[]> _historyItemIds = new();

        public void AddItem(string id, OutputItem item) => _items[id] = item;

        public void SetHistoryItemIds(string previousResponseId, string[] ids)
            => _historyItemIds[previousResponseId] = ids;

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken ct = default)
            => Task.CompletedTask;

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");

        public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken ct = default)
            => Task.CompletedTask;

        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, IsolationContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken ct = default)
        {
            var results = itemIds.Select(id => _items.TryGetValue(id, out var item) ? item : null);
            return Task.FromResult(results);
        }

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, IsolationContext isolation, CancellationToken ct = default)
        {
            if (previousResponseId is not null && _historyItemIds.TryGetValue(previousResponseId, out var ids))
            {
                return Task.FromResult<IEnumerable<string>>(ids);
            }
            return Task.FromResult(Enumerable.Empty<string>());
        }
    }

    private sealed class RecordingProvider : StubProvider
    {
        public int GetItemsCallCount { get; private set; }
        public int GetHistoryItemIdsCallCount { get; private set; }
        public int LastHistoryLimit { get; private set; }

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken ct = default)
        {
            GetItemsCallCount++;
            return base.GetItemsAsync(itemIds, isolation, ct);
        }

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, IsolationContext isolation, CancellationToken ct = default)
        {
            GetHistoryItemIdsCallCount++;
            LastHistoryLimit = limit;
            return base.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, isolation, ct);
        }
    }
}
