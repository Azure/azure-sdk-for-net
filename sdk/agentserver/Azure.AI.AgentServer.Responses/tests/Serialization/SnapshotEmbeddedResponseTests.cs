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
        _accumulator.Output.Add(new OutputItemMessage(
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
        var evt = new ResponseCreatedEvent(sequenceNumber: 0, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator), "Should be a deep copy");
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseInProgressEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseInProgressEvent(sequenceNumber: 1, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseCompletedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseCompletedEvent(sequenceNumber: 2, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseFailedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseFailedEvent(sequenceNumber: 3, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseIncompleteEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseIncompleteEvent(sequenceNumber: 4, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    [Test]
    public void SnapshotEmbeddedResponse_ResponseQueuedEvent_ReplacesWithSnapshot()
    {
        var original = new ResponseObject("original", "model");
        var evt = new ResponseQueuedEvent(sequenceNumber: 5, response: original);

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Id, Is.EqualTo("resp_snap"));
        Assert.That(evt.Response, Is.Not.SameAs(_accumulator));
    }

    // ── Snapshot independence: mutation isolation ───────────────────────

    [Test]
    public void SnapshotEmbeddedResponse_MutatingOriginal_DoesNotAffectSnapshotOnEvent()
    {
        var evt = new ResponseCompletedEvent(sequenceNumber: 0, response: new ResponseObject("x", "m"));

        evt.SnapshotEmbeddedResponse(_accumulator);

        // Mutate the accumulator after snapshot
        _accumulator.Model = "gpt-4o-mini";
        _accumulator.Output.Clear();

        // Snapshot on the event should be unaffected
        Assert.That(evt.Response.Model, Is.EqualTo("gpt-4o"));
        Assert.That(evt.Response.Output, Has.Count.EqualTo(1));
    }

    [Test]
    public void SnapshotEmbeddedResponse_SnapshotIncludesOutputItems()
    {
        var evt = new ResponseCreatedEvent(sequenceNumber: 0, response: new ResponseObject("x", "m"));

        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Response.Output, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<OutputItemMessage>(evt.Response.Output[0]);
        Assert.That(msg.Id, Is.EqualTo("msg_1"));
    }

    // ── Non-lifecycle events: left unchanged ───────────────────────────

    [Test]
    public void SnapshotEmbeddedResponse_NonLifecycleEvent_IsLeftUnchanged()
    {
        // ResponseOutputItemAddedEvent is NOT a lifecycle event — no Response property
        var outputMsg = new OutputItemMessage(
            id: "msg_out",
            status: MessageStatus.InProgress,
            role: MessageRole.Assistant,
            content: Array.Empty<MessageContent>());
        var evt = new ResponseOutputItemAddedEvent(
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
        var evt = new ResponseTextDeltaEvent(
            sequenceNumber: 20,
            itemId: "msg_1",
            outputIndex: 0,
            contentIndex: 0,
            delta: "Hello",
            logprobs: Array.Empty<ResponseLogProb>());

        // Should not throw — no lifecycle response to snapshot
        evt.SnapshotEmbeddedResponse(_accumulator);

        Assert.That(evt.Delta, Is.EqualTo("Hello"));
    }
}
