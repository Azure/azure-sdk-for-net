// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// One ordered text output item in a <see cref="VoiceResponse"/>. Instances are
/// created by <see cref="VoiceResponse.CreateTextItem"/>.
/// </summary>
public class VoiceTextItem
{
    private readonly VoiceResponse _response;
    private readonly List<string> _chunks = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceTextItem"/> class for mocking.
    /// </summary>
    protected VoiceTextItem()
    {
        _response = null!;
        ItemId = string.Empty;
    }

    internal VoiceTextItem(VoiceResponse response, string itemId)
    {
        _response = response;
        ItemId = itemId;
    }

    /// <summary>Gets the SDK-allocated output item ID with the <c>it_</c> prefix.</summary>
    public virtual string ItemId { get; }

    /// <summary>Sends this item as one complete non-streamed message.</summary>
    /// <param name="text">Complete text to synthesize.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextAsync(string text, CancellationToken cancellationToken = default) =>
        SendTextAsync(text, voice: null, cancellationToken);

    /// <summary>Sends this item as one complete message with an optional voice merge patch.</summary>
    /// <param name="text">Complete text to synthesize.</param>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextAsync(
        string text,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        _response.SendItemTextAsync(this, text, voice, cancellationToken);

    /// <summary>Streams one text increment for this item.</summary>
    /// <param name="delta">The next text fragment.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDeltaAsync(string delta, CancellationToken cancellationToken = default) =>
        SendTextDeltaAsync(delta, voice: null, cancellationToken);

    /// <summary>Streams one text increment with an optional voice merge patch.</summary>
    /// <param name="delta">The next text fragment.</param>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDeltaAsync(
        string delta,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        _response.SendItemDeltaAsync(this, delta, voice, cancellationToken);

    /// <summary>Completes this streamed item with its accumulated full text.</summary>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDoneAsync(CancellationToken cancellationToken = default) =>
        SendTextDoneAsync(voice: null, cancellationToken);

    /// <summary>Completes this streamed item with an optional voice merge patch.</summary>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDoneAsync(
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        _response.SendItemDoneAsync(this, voice, cancellationToken);

    internal bool IsStarted { get; private set; }

    internal bool IsDone { get; private set; }

    internal int TextBytes { get; private set; }

    internal int EscapedTextBytes { get; private set; }

    internal int ChunkCount => _chunks.Count;

    internal void CommitCompleteText(string text, int textBytes, int escapedTextBytes)
    {
        _chunks.Add(text);
        TextBytes = textBytes;
        EscapedTextBytes = escapedTextBytes;
        IsStarted = true;
        IsDone = true;
    }

    internal void CommitDelta(string delta, int deltaBytes, int escapedDeltaBytes)
    {
        _chunks.Add(delta);
        TextBytes += deltaBytes;
        EscapedTextBytes += escapedDeltaBytes;
        IsStarted = true;
    }

    internal string GetFullText() => string.Concat(_chunks);

    internal void MarkDone() => IsDone = true;

    internal void ReleaseText() => _chunks.Clear();
}
