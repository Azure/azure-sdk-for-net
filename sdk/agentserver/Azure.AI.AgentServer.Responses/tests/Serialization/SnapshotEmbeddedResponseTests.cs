// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// Tests for <see cref="ResponseSnapshotExtensions.SnapshotEmbeddedResponse"/>.
/// Verifies that lifecycle events get their embedded <see cref="ResponseObject"/>
/// replaced with an independent deep copy of the accumulator, and that non-lifecycle
/// events are left unchanged.
/// </summary>
public class SnapshotEmbeddedResponseTests
{
    private ResponseObject _accumulator = null!;

    [SetUp]
    public void SetUp()
    {
        _accumulator = new ResponseObject("resp_snap", "gpt-4o");
        _accumulator.Status = ResponseStatus.InProgress;
        _accumulator.OutputItems.Add(TestModels.OutputItemMessage(
            id: "msg_1",
            status: MessageStatus.Completed,
            role: MessageRole.Assistant,
            content: new List<MessageContent>
            {
                new MessageContentOutputTextContent(
                    text: "Hello",
                    annotations: Array.Empty<Annotation>(),
                    logprobs: Array.Empty<LogProb>()),
            }));
    }

    // ── Lifecycle events: Response is replaced with snapshot ────────────

    [Test]
    public void SnapshotEmbeddedResponse_ResponseCreatedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseCreatedEvent { SequenceNumber = checked((int)(0)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator), "Should be a deep copy");
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseInProgressEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseInProgressEvent { SequenceNumber = checked((int)(1)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseCompletedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseCompletedEvent { SequenceNumber = checked((int)(2)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseFailedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseFailedEvent { SequenceNumber = checked((int)(3)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseIncompleteEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseIncompleteEvent { SequenceNumber = checked((int)(4)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseQueuedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseQueuedEvent { SequenceNumber = checked((int)(5)), Response = original };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    // ── Snapshot independence: mutation isolation ───────────────────────

    [Test]
    public void SnapshotEmbeddedResponse_MutatingOriginal_DoesNotAffectSnapshotOnEvent()
    {
        var evt = new ResponseCompletedEvent { SequenceNumber = 0, Response = new ResponseObject("x", "m") };

        evt.SnapshotEmbeddedResponse(_accumulator);

        // Mutate the accumulator after snapshot
        _accumulator.Model = "gpt-4o-mini";
        _accumulator.OutputItems.Clear();

        // Snapshot on the event should be unaffected
        Assert.That(evt.Response.Model, Is.EqualTo("gpt-4o"));
        Assert.That(evt.Response.OutputItems, Has.Count.EqualTo(1));
    }

    [Test]
    public void SnapshotEmbeddedResponse_SnapshotIncludesOutputItems()
    {
        var evt = new ResponseCreatedEvent { SequenceNumber = 0, Response = new ResponseObject("x", "m") };

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.OutputItems, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<OutputItemMessage>(evt.Response.OutputItems[0]);
        Assert.That(msg.Id, Is.EqualTo("msg_1"));
    }

    // ── Non-lifecycle events: left unchanged ───────────────────────────

    [Test]
    public void SnapshotEmbeddedResponse_NonLifecycleEvent_IsLeftUnchanged()
    {
        // ResponseOutputItemAddedEvent is NOT a lifecycle event — no Response property
        var outputMsg = TestModels.OutputItemMessage(
            id: "msg_out",
            status: MessageStatus.InProgress,
            role: MessageRole.Assistant,
            content: Array.Empty<MessageContent>());
        var evt = TestModels.ResponseOutputItemAddedEvent(
            sequenceNumber: 10,
            outputIndex: 0,
            item: outputMsg);

        // Should not throw or modify anything
        evt.SnapshotEmbeddedResponse(_accumulator);

        // The event should still have its original item
        Assert.That(((ResponseOutputItemAddedEvent)evt).Item, Is.SameAs(outputMsg));
    }

    [Test]
    public void SnapshotEmbeddedResponse_TextDeltaEvent_IsLeftUnchanged()
    {
        var evt = new ResponseTextDeltaEvent
        {
            SequenceNumber = 20,
            ItemId = "msg_1",
            OutputIndex = 0,
            ContentIndex = 0,
            Delta = "Hello",
        };

        // Should not throw — no lifecycle response to snapshot
        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Delta.ToString(), Is.EqualTo("Hello"));
    }
}
