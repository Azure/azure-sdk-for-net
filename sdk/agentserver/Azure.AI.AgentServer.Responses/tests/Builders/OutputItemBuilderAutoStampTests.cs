// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// Unit tests for auto-stamp logic in <see cref="OutputItemBuilder{T}"/>.
/// Validates that <c>ResponseId</c> and <c>AgentReference</c> are automatically
/// stamped when the handler has not set them.
/// </summary>
public class OutputItemBuilderAutoStampTests
{
    // ── T017: ResponseId stamping ─────────────────────────────

    [Test]
    public void EmitAdded_StampsResponseId_WhenNotSetByHandler()
    {
        var responseId = "resp_auto_001";
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.AreEqual(responseId, evt.Item.ResponseId);
    }

    [Test]
    public void EmitDone_StampsResponseId_WhenNotSetByHandler()
    {
        var responseId = "resp_auto_002";
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        // Must go through Added lifecycle and add content
        builder.EmitAdded();
        var text = builder.AddTextContent();
        text.EmitAdded();
        text.EmitDone("Hello");
        builder.EmitContentDone(text);

        var doneEvt = builder.EmitDone();

        Assert.AreEqual(responseId, doneEvt.Item.ResponseId);
    }

    [Test]
    public void EmitAdded_PreservesHandlerSetResponseId()
    {
        var responseId = "resp_auto_003";
        var handlerResponseId = "handler-override-id";
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        // Create an item with handler-set ResponseId
        var item = new OutputItemOutputMessage(
            id: builder.ItemId,
            content: Array.Empty<OutputMessageContent>(),
            status: OutputItemOutputMessageStatus.InProgress)
        {
            ResponseId = handlerResponseId,
        };
        var evt = builder.EmitAdded(item);

        Assert.AreEqual(handlerResponseId, evt.Item.ResponseId);
    }

    // ── T029: AgentReference stamping ─────────────────────────

    [Test]
    public void EmitAdded_StampsAgentReference_WhenNotSetByHandler()
    {
        var responseId = "resp_auto_004";
        var agentRef = new AgentReference("my-agent") { Version = "1.0" };
        var request = new CreateResponse { Model = "test", AgentReference = agentRef };
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, request);
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.IsNotNull(evt.Item.AgentReference);
        Assert.AreEqual("my-agent", evt.Item.AgentReference.Name);
        Assert.AreEqual("1.0", evt.Item.AgentReference.Version);
    }

    [Test]
    public void EmitAdded_PreservesHandlerSetAgentReference()
    {
        var responseId = "resp_auto_005";
        var requestAgentRef = new AgentReference("request-agent");
        var handlerAgentRef = new AgentReference("handler-agent") { Version = "2.0" };
        var request = new CreateResponse { Model = "test", AgentReference = requestAgentRef };
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, request);
        var builder = stream.AddOutputItemMessage();

        var item = new OutputItemOutputMessage(
            id: builder.ItemId,
            content: Array.Empty<OutputMessageContent>(),
            status: OutputItemOutputMessageStatus.InProgress)
        {
            AgentReference = handlerAgentRef,
        };
        var evt = builder.EmitAdded(item);

        // Handler-set value takes precedence
        Assert.AreEqual("handler-agent", evt.Item.AgentReference.Name);
        Assert.AreEqual("2.0", evt.Item.AgentReference.Version);
    }

    [Test]
    public void EmitAdded_SkipsAgentReference_WhenNoAgentRefOnRequest()
    {
        var responseId = "resp_auto_006";
        var ctx = new TestResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.IsNull(evt.Item.AgentReference);
    }

    // ── Test helpers ──────────────────────────────────────────

    private sealed class TestResponseContext : IResponseContext
    {
        public TestResponseContext(string responseId) => ResponseId = responseId;
        public string ResponseId { get; }
        public bool IsShutdownRequested { get; set; }
        public System.Text.Json.JsonElement RawBody => default;
        public Task<IReadOnlyList<OutputItem>> GetInputItemsAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());
        public Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());
    }
}
