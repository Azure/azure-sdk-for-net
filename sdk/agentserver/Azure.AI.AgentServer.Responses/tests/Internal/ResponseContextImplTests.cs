// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
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
        IResponsesProvider? provider = null,
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
        Assert.AreEqual(MessageStatus.Completed, msg.Status);
        Assert.AreEqual(MessageRole.User, msg.Role);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T045: Resolves ItemReferenceParam via IResponsesProvider.GetItemsAsync
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
        Assert.AreEqual("msg_existing", msg.Id);
        Assert.AreEqual(MessageRole.Assistant, msg.Role);
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

        Assert.AreSame(result1, result2);
        // Provider.GetItemsAsync should not be called at all (no references)
        Assert.AreEqual(0, provider.GetItemsCallCount);
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

        Assert.AreEqual(1, provider.GetItemsCallCount);
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

        Assert.AreEqual(3, items.Count);

        // First item: inline message
        var first = XAssert.IsType<OutputItemMessage>(items[0]);
        XAssert.StartsWith("msg_", first.Id);

        // Second item: resolved reference
        var second = XAssert.IsType<OutputItemMessage>(items[1]);
        Assert.AreEqual("ref_middle", second.Id);

        // Third item: inline message
        var third = XAssert.IsType<OutputItemMessage>(items[2]);
        XAssert.StartsWith("msg_", third.Id);

        // First and third should have different generated IDs
        Assert.AreNotEqual(first.Id, third.Id);
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

        Assert.IsEmpty(items);
    }

    [Test]
    public async Task GetInputItemsAsync_Returns_Empty_When_Input_Is_Null()
    {
        // CreateResponse with no input set at all
        var request = new CreateResponse { Model = "test" };

        var context = CreateContext(request);
        var items = await context.GetInputItemsAsync();

        Assert.IsEmpty(items);
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

        Assert.AreEqual(3, items.Count);
        var first = XAssert.IsType<OutputItemMessage>(items[0]);
        var second = XAssert.IsType<OutputItemMessage>(items[1]);
        var third = XAssert.IsType<OutputItemMessage>(items[2]);
        Assert.AreEqual("hist_1", first.Id);
        Assert.AreEqual("hist_2", second.Id);
        Assert.AreEqual("hist_3", third.Id);
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

        Assert.IsEmpty(items);
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

        Assert.AreSame(result1, result2);
        Assert.AreEqual(1, provider.GetHistoryItemIdsCallCount);
        Assert.AreEqual(1, provider.GetItemsCallCount);
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

        Assert.AreEqual(42, provider.LastHistoryLimit);
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

    private class StubProvider : IResponsesProvider
    {
        private readonly Dictionary<string, OutputItem> _items = new();
        private readonly Dictionary<string, string[]> _historyItemIds = new();

        public void AddItem(string id, OutputItem item) => _items[id] = item;

        public void SetHistoryItemIds(string previousResponseId, string[] ids)
            => _historyItemIds[previousResponseId] = ids;

        public Task CreateResponseAsync(Models.Response response, IEnumerable<OutputItem>? inputItems, IEnumerable<string>? historyItemIds, CancellationToken ct = default)
            => Task.CompletedTask;

        public Task<Models.Response> GetResponseAsync(string responseId, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");

        public Task UpdateResponseAsync(Models.Response response, CancellationToken ct = default)
            => Task.CompletedTask;

        public Task DeleteResponseAsync(string responseId, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");

        public Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public virtual Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, CancellationToken ct = default)
        {
            var results = itemIds.Select(id => _items.TryGetValue(id, out var item) ? item : null);
            return Task.FromResult(results);
        }

        public virtual Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, CancellationToken ct = default)
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

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, CancellationToken ct = default)
        {
            GetItemsCallCount++;
            return base.GetItemsAsync(itemIds, ct);
        }

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, CancellationToken ct = default)
        {
            GetHistoryItemIdsCallCount++;
            LastHistoryLimit = limit;
            return base.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, ct);
        }
    }
}
