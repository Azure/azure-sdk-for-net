// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// In-process steering coordinator for a single steerable multi-turn chain. Mirrors the
/// persisted <c>_steering</c> payload object (<see cref="TaskWireKeys.PayloadSteering"/>):
/// a FIFO of queued inputs, a monotonic <c>next_input_seq</c> advanced only when an oversized
/// input is promoted to an attachment at append time (never reused), a drain-in-progress flag, and the currently-draining
/// <c>active_input</c>. The fixed capacity is 9 queued inputs (FR-012); a queue-exceeding
/// append fails with <see cref="SteeringQueueFullException"/>.
/// </summary>
/// <typeparam name="TOutput">The chain output type (shared by every turn).</typeparam>
internal sealed class SteeringQueue<TOutput>
{
    /// <summary>The fixed maximum number of concurrently queued steering inputs.</summary>
    public const int MaxDepth = 9;

    private readonly object _gate = new();
    private readonly LinkedList<QueuedInput<TOutput>> _pending = new();
    private int _nextSeq;

    /// <summary>Whether a queued input is currently being drained into a steered turn.</summary>
    public bool DrainInProgress { get; private set; }

    /// <summary>The input slot (inline value or attachment ref) of the draining input, or null.</summary>
    public JsonNode? ActiveInput { get; private set; }

    /// <summary>The number of queued inputs awaiting promotion.</summary>
    public int Count
    {
        get
        {
            lock (_gate)
            {
                return _pending.Count;
            }
        }
    }

    /// <summary>
    /// Appends an input to the FIFO. Throws <see cref="SteeringQueueFullException"/> when the
    /// queue already holds <see cref="MaxDepth"/> inputs.
    /// </summary>
    public QueuedInput<TOutput> Enqueue(QueuedInput<TOutput> input)
    {
        lock (_gate)
        {
            if (_pending.Count >= MaxDepth)
            {
                throw new SteeringQueueFullException(
                    $"The steering queue is full ({MaxDepth} queued inputs); back off and retry.");
            }

            _pending.AddLast(input);
            return input;
        }
    }

    /// <summary>
    /// Atomically allocates the next <c>next_input_seq</c>, forms the
    /// <c>_steering_input_&lt;seq&gt;</c> attachment key via <paramref name="promote"/>, and advances
    /// the counter <em>only</em> when an attachment was actually produced (small inputs never burn a
    /// seq, matching Python's attachment-branch bump). Holding the queue lock across the whole
    /// peek→promote→advance makes it a single critical section, so concurrent oversized appends on
    /// the same chain can never observe the same seq and clobber each other's attachment.
    /// </summary>
    public (System.Text.Json.Nodes.JsonNode? Slot, JsonObject? Attachments) PromoteInput(
        System.Func<int, (System.Text.Json.Nodes.JsonNode? Slot, JsonObject? Attachments)> promote)
    {
        lock (_gate)
        {
            (System.Text.Json.Nodes.JsonNode? slot, JsonObject? attachments) = promote(_nextSeq);
            if (attachments is not null)
            {
                _nextSeq++;
            }

            return (slot, attachments);
        }
    }

    /// <summary>
    /// Pops the head of the FIFO and marks it as the draining input. The head's attachment seq
    /// (if any) was already allocated at append time. Returns null when the queue is empty.
    /// </summary>
    public QueuedInput<TOutput>? Promote()
    {
        lock (_gate)
        {
            if (_pending.Count == 0)
            {
                return null;
            }

            QueuedInput<TOutput> input = _pending.First!.Value;
            _pending.RemoveFirst();
            DrainInProgress = true;
            ActiveInput = input.Slot;
            return input;
        }
    }

    /// <summary>Clears the drain markers once a steered turn has fully started.</summary>
    public void CompleteDrain()
    {
        lock (_gate)
        {
            DrainInProgress = false;
            ActiveInput = null;
        }
    }

    /// <summary>
    /// Overrides the draining input's persisted slot (e.g. with the attachment ref produced
    /// when an oversized active input is promoted) so <c>active_input</c> matches <c>payload.input</c>.
    /// </summary>
    public void SetActiveInput(JsonNode? slot)
    {
        lock (_gate)
        {
            ActiveInput = slot?.DeepClone();
        }
    }

    /// <summary>
    /// Restores the monotonic <c>next_input_seq</c> from a persisted record so attachment keys
    /// (<c>_steering_input_&lt;seq&gt;</c>) stay unique across suspend/resume and recovery.
    /// </summary>
    public void SeedNextSeq(int seq)
    {
        lock (_gate)
        {
            if (seq > _nextSeq)
            {
                _nextSeq = seq;
            }
        }
    }

    /// <summary>
    /// Removes a still-queued input (a queued caller cancelling its slot before promotion).
    /// Returns false when it has already been promoted or removed.
    /// </summary>
    public bool Remove(QueuedInput<TOutput> input)
    {
        lock (_gate)
        {
            return _pending.Remove(input);
        }
    }

    /// <summary>
    /// Builds the persisted <c>_steering</c> object from the current in-process state.
    /// </summary>
    public JsonObject ToPayload()
    {
        lock (_gate)
        {
            var pending = new JsonArray();
            foreach (QueuedInput<TOutput> input in _pending)
            {
                pending.Add(input.Slot is null ? null : input.Slot.DeepClone());
            }

            return new JsonObject
            {
                [TaskWireKeys.SteeringPendingInputs] = pending,
                [TaskWireKeys.SteeringNextInputSeq] = _nextSeq,
                [TaskWireKeys.SteeringCancelRequested] = false,
                [TaskWireKeys.SteeringDrainInProgress] = DrainInProgress,
                [TaskWireKeys.SteeringActiveInput] = ActiveInput?.DeepClone(),
            };
        }
    }
}

/// <summary>A single queued steering input plus the awaitable handle for its caller.</summary>
/// <typeparam name="TOutput">The chain output type.</typeparam>
internal sealed class QueuedInput<TOutput>
{
    public QueuedInput(JsonNode? slot, JsonObject? attachments, string inputId, bool inputIdSupplied, TaskRunState<TOutput> runState)
    {
        Slot = slot;
        Attachments = attachments;
        InputId = inputId;
        InputIdSupplied = inputIdSupplied;
        RunState = runState;
    }

    /// <summary>The input slot (inline value or attachment ref).</summary>
    public JsonNode? Slot { get; }

    /// <summary>The attachments produced when promoting this input, if any.</summary>
    public JsonObject? Attachments { get; }

    /// <summary>The input id assigned to this queued input.</summary>
    public string InputId { get; }

    /// <summary>Whether the caller explicitly supplied input_id (gates advancing last_input_id).</summary>
    public bool InputIdSupplied { get; }

    /// <summary>The awaitable handle resolved when this input's steered turn completes.</summary>
    public TaskRunState<TOutput> RunState { get; }
}
