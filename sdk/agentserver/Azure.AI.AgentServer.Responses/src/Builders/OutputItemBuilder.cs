// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Base class for output item builders. Provides common fields, properties,
/// and <see cref="EmitAdded(T)"/> / <see cref="EmitDone(T)"/>
/// methods that handle event construction and output tracking.
/// Can also be used directly for output item types that have no streaming
/// sub-events (no deltas, no status transitions).
/// </summary>
/// <typeparam name="T">The concrete <see cref="OutputItem"/> subtype this builder handles.</typeparam>
public class OutputItemBuilder<T> where T : OutputItem
{
    private protected readonly ResponseEventStream _stream;
    private protected readonly long _outputIndex;
    private protected readonly string _itemId;

    /// <summary>Tracks the builder lifecycle state to prevent invalid transitions.</summary>
    private protected BuilderLifecycleState _lifecycleState;

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemBuilder{T}"/>.
    /// </summary>
    internal OutputItemBuilder(ResponseEventStream stream, long outputIndex, string itemId)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        _outputIndex = outputIndex;
        _itemId = itemId ?? throw new ArgumentNullException(nameof(itemId));
    }

    /// <summary>
    /// Initializes a new instance of <see cref="OutputItemBuilder{T}"/> for mocking.
    /// </summary>
    protected OutputItemBuilder()
    {
        _stream = null!;
        _itemId = string.Empty;
    }

    /// <summary>The auto-generated item ID for this output item.</summary>
    public string ItemId => _itemId;

    /// <summary>The output index assigned to this output item.</summary>
    public long OutputIndex => _outputIndex;

    /// <summary>
    /// Produces a <c>response.output_item.added</c> event wrapping the given item.
    /// </summary>
    /// <param name="item">The output item to include in the event.</param>
    /// <returns>A <see cref="ResponseOutputItemAddedEvent"/> for this output item.</returns>
    public virtual ResponseOutputItemAddedEvent EmitAdded(T item)
    {
        EnsureTransition(BuilderLifecycleState.NotStarted, BuilderLifecycleState.Added);
        ApplyAutoStamps(item);
        return new ResponseOutputItemAddedEvent(_stream.NextSequenceNumber(), _outputIndex, item);
    }

    /// <summary>
    /// Produces a <c>response.output_item.done</c> event wrapping the given item
    /// and tracks it in the response's output list.
    /// </summary>
    /// <param name="item">The completed output item to include in the event.</param>
    /// <returns>A <see cref="ResponseOutputItemDoneEvent"/> for this output item.</returns>
    public virtual ResponseOutputItemDoneEvent EmitDone(T item)
    {
        EnsureTransition(BuilderLifecycleState.Added, BuilderLifecycleState.Done);
        _stream.TrackCompletedOutputItem(item, _outputIndex);
        ApplyAutoStamps(item);
        return new ResponseOutputItemDoneEvent(_stream.NextSequenceNumber(), _outputIndex, item);
    }

    /// <summary>
    /// Validates and transitions the builder from an expected state to the next state.
    /// </summary>
    /// <param name="expectedState">The required current state.</param>
    /// <param name="newState">The state to transition to.</param>
    /// <exception cref="InvalidOperationException">The builder is not in the expected state.</exception>
    private protected void EnsureTransition(BuilderLifecycleState expectedState, BuilderLifecycleState newState)
    {
        if (_lifecycleState != expectedState)
        {
            throw new InvalidOperationException(
                $"Cannot transition to '{newState}' — builder is in '{_lifecycleState}' state (expected '{expectedState}').");
        }

        _lifecycleState = newState;
    }

    /// <summary>
    /// Validates the builder is in the <see cref="BuilderLifecycleState.Added"/> state,
    /// indicating that intermediate operations (deltas) are allowed.
    /// </summary>
    /// <exception cref="InvalidOperationException">The builder is not in the Added state.</exception>
    private protected void EnsureActive()
    {
        if (_lifecycleState != BuilderLifecycleState.Added)
        {
            throw new InvalidOperationException(
                $"Cannot perform this operation — builder is in '{_lifecycleState}' state (expected 'Added').");
        }
    }

    /// <summary>
    /// Auto-stamps <c>ResponseId</c> and <c>AgentReference</c> on the output item
    /// when the handler has not explicitly set them (Layer 1 stamping).
    /// </summary>
    private void ApplyAutoStamps(T item)
    {
        if (string.IsNullOrEmpty(item.ResponseId))
        {
            item.ResponseId = _stream.ResponseId;
        }

        if (item.AgentReference is null && _stream.AgentReference is not null)
        {
            item.AgentReference = _stream.AgentReference;
        }
    }
}
