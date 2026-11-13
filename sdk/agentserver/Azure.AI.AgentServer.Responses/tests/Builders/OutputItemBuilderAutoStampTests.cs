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
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.That(evt.Item.ResponseId, Is.EqualTo(responseId));
    }

    [Test]
    public void EmitDone_StampsResponseId_WhenNotSetByHandler()
    {
        var responseId = "resp_auto_002";
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        // Must go through Added lifecycle and add content
        builder.EmitAdded();
        var text = builder.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hello");
        text.EmitDone();

        var doneEvt = builder.EmitDone();

        Assert.That(doneEvt.Item.ResponseId, Is.EqualTo(responseId));
    }

    [Test]
    public void EmitAdded_PreservesHandlerSetResponseId()
    {
        var responseId = "resp_auto_003";
        var handlerResponseId = "handler-override-id";
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        // Create an item with handler-set ResponseId
        var item = new OutputItemMessage(
            id: builder.ItemId,
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress)
        {
            ResponseId = handlerResponseId,
        };
        var evt = builder.EmitAdded(item);

        Assert.That(evt.Item.ResponseId, Is.EqualTo(handlerResponseId));
    }

    // ── T029: AgentReference stamping ─────────────────────────

    [Test]
    public void EmitAdded_StampsAgentReference_WhenNotSetByHandler()
    {
        var responseId = "resp_auto_004";
        var agentRef = new AgentReference("my-agent") { Version = "1.0" };
        var request = new CreateResponse { Model = "test", AgentReference = agentRef };
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, request);
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.That(evt.Item.AgentReference, Is.Not.Null);
        Assert.That(evt.Item.AgentReference.Name, Is.EqualTo("my-agent"));
        Assert.That(evt.Item.AgentReference.Version, Is.EqualTo("1.0"));
    }

    [Test]
    public void EmitAdded_PreservesHandlerSetAgentReference()
    {
        var responseId = "resp_auto_005";
        var requestAgentRef = new AgentReference("request-agent");
        var handlerAgentRef = new AgentReference("handler-agent") { Version = "2.0" };
        var request = new CreateResponse { Model = "test", AgentReference = requestAgentRef };
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, request);
        var builder = stream.AddOutputItemMessage();

        var item = new OutputItemMessage(
            id: builder.ItemId,
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress)
        {
            AgentReference = handlerAgentRef,
        };
        var evt = builder.EmitAdded(item);

        // Handler-set value takes precedence
        Assert.That(evt.Item.AgentReference.Name, Is.EqualTo("handler-agent"));
        Assert.That(evt.Item.AgentReference.Version, Is.EqualTo("2.0"));
    }

    [Test]
    public void EmitAdded_SkipsAgentReference_WhenNoAgentRefOnRequest()
    {
        var responseId = "resp_auto_006";
        var ctx = new ResponseContext(responseId);
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        var builder = stream.AddOutputItemMessage();

        var evt = builder.EmitAdded();

        Assert.That(evt.Item.AgentReference, Is.Null);
    }
}
