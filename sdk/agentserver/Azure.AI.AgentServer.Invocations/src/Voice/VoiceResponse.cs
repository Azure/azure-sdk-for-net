// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.AI.AgentServer.Invocations.Voice.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Library-owned response helper bound to an immutable input prefix or an
/// accepted proactive response. It owns response and output-item identifiers,
/// wire ordering, output budgets, and terminal transitions.
/// </summary>
public class VoiceResponse
{
    private readonly IVoiceConnection _connection;
    private readonly object _stateSync = new();
    private readonly SemaphoreSlim _operationGate = new(1, 1);
    private readonly List<VoiceTextItem> _items = new();
    private readonly CancellationTokenSource _responseCancellation;
    private readonly VoiceResponseResources _outputResources;
    private Guid[] _releasedItemIds = [];
    private CancellationTokenRegistration _connectionCancellationRegistration;
    private int _connectionCancellationRegistrationDisposed;
    private VoiceTextItem? _simpleItem;
    private int _responseBytes;
    private bool _advancedItems;
    private bool _wireOpened;
    private bool _accepted;
    private bool _terminal;
    private bool _sealed;
    private bool _cancelPending;
    private long _generation;

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceResponse"/> class for mocking.
    /// </summary>
    protected VoiceResponse()
    {
        _connection = null!;
        _responseCancellation = new CancellationTokenSource();
        _outputResources = new VoiceResourceGovernor().CreateResponseResources();
        ResponseId = string.Empty;
        InReplyTo = null;
    }

    internal VoiceResponse(
        IVoiceConnection connection,
        string responseId,
        IReadOnlyList<string>? inReplyTo,
        bool wireOpened,
        bool accepted,
        CancellationToken connectionCancellationToken)
        : this(
            connection,
            responseId,
            inReplyTo,
            wireOpened,
            accepted,
            connectionCancellationToken,
            new VoiceResourceGovernor())
    {
    }

    internal VoiceResponse(
        IVoiceConnection connection,
        string responseId,
        IReadOnlyList<string>? inReplyTo,
        bool wireOpened,
        bool accepted,
        CancellationToken connectionCancellationToken,
        VoiceResourceGovernor resourceGovernor)
    {
        _connection = connection;
        ResponseId = responseId;
        InReplyTo = inReplyTo is null ? null : Array.AsReadOnly(inReplyTo.ToArray());
        _wireOpened = wireOpened;
        _accepted = accepted;
        _responseCancellation = new CancellationTokenSource();
        _outputResources = resourceGovernor.CreateResponseResources();
        if (connectionCancellationToken.CanBeCanceled)
        {
            _connectionCancellationRegistration = connectionCancellationToken.UnsafeRegister(
                static state => ((VoiceResponse)state!).OnConnectionCancelled(),
                this);
        }
    }

    /// <summary>Gets the library-allocated response ID with the <c>r_</c> prefix.</summary>
    public virtual string ResponseId { get; }

    /// <summary>Gets the immutable input prefix, or <see langword="null"/> when proactive.</summary>
    public virtual IReadOnlyList<string>? InReplyTo { get; }

    /// <summary>Gets a value indicating whether the response no longer accepts output.</summary>
    public virtual bool IsTerminal
    {
        get
        {
            lock (_stateSync)
            {
                return _terminal;
            }
        }
    }

    /// <summary>Gets a value indicating whether self-cancel is awaiting a playback outcome.</summary>
    public virtual bool IsCancelPending
    {
        get
        {
            lock (_stateSync)
            {
                return _cancelPending;
            }
        }
    }

    /// <summary>
    /// Gets a cooperative token cancelled by timeout, barge-in, session end,
    /// or transport close.
    /// </summary>
    public virtual CancellationToken CancellationToken => _responseCancellation.Token;

    internal bool IsWireOpened
    {
        get
        {
            lock (_stateSync)
            {
                return _wireOpened;
            }
        }
    }

    internal bool IsAccepted
    {
        get
        {
            lock (_stateSync)
            {
                return _accepted;
            }
        }
    }

    internal int RetainedOutputChunkCount
    {
        get
        {
            lock (_stateSync)
            {
                return _items.Sum(item => item.ChunkCount);
            }
        }
    }

    internal bool IsConnectionCancellationRegistrationDisposed =>
        Volatile.Read(ref _connectionCancellationRegistrationDisposed) != 0;

    internal readonly record struct SendReservation(long Generation, bool OpensResponse);

    internal SendReservation ReserveSend(bool opensResponse)
    {
        lock (_stateSync)
        {
            EnsureWritableLocked();
            if (opensResponse == _wireOpened)
            {
                throw new InvalidOperationException(
                    opensResponse
                        ? "The response is already open."
                        : "The response must be opened before this frame.");
            }

            return new SendReservation(_generation, opensResponse);
        }
    }

    internal bool TryCommitSend(
        SendReservation reservation,
        Action commit,
        bool terminal)
    {
        var releaseConnectionRegistration = false;
        ArgumentNullException.ThrowIfNull(commit);
        lock (_stateSync)
        {
            if (_generation != reservation.Generation || _terminal || _sealed)
            {
                return false;
            }

            if (reservation.OpensResponse)
            {
                _wireOpened = true;
            }

            commit();
            if (terminal)
            {
                _terminal = true;
                _sealed = true;
                _generation++;
                releaseConnectionRegistration = true;
            }
        }

        if (releaseConnectionRegistration)
        {
            ReleaseConnectionCancellationRegistration();
        }

        return true;
    }

    internal void ReserveCancellation()
    {
        lock (_stateSync)
        {
            EnsureWritableLocked();
            if (!_wireOpened)
            {
                throw new InvalidOperationException("Cannot cancel before response.created.");
            }

            if (_cancelPending)
            {
                throw new InvalidOperationException("Response cancellation is already pending.");
            }

            _cancelPending = true;
        }
    }

    /// <summary>
    /// Creates the next ordered output item. Complete the previous item before
    /// creating another, and do not mix this API with the simple send helpers.
    /// </summary>
    /// <returns>A library-owned text item.</returns>
    public virtual VoiceTextItem CreateTextItem()
    {
        lock (_stateSync)
        {
            EnsureLocallyWritableLocked();
            if (_simpleItem is not null)
            {
                throw new InvalidOperationException("Cannot mix simple response helpers with CreateTextItem.");
            }

            if (_items.Count > 0 && !_items[^1].IsDone)
            {
                throw new InvalidOperationException("Complete the previous response item first.");
            }

            if (_items.Count >= VoiceProtocolConstants.MaxResponseItems)
            {
                throw new ArgumentOutOfRangeException(nameof(_items), "A response cannot exceed 1024 output items.");
            }

            _advancedItems = true;
            using var outputReservation = _outputResources.Reserve(items: 1);
            var item = new VoiceTextItem(this, VoiceIds.New(VoiceProtocolConstants.OutputItemPrefix));
            _items.Add(item);
            outputReservation.Commit();
            return item;
        }
    }

    /// <summary>Sends one complete non-streamed item through the simple helper.</summary>
    /// <param name="text">Complete text to synthesize.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextAsync(string text, CancellationToken cancellationToken = default) =>
        SendTextAsync(text, voice: null, cancellationToken);

    /// <summary>Sends one complete non-streamed item with an optional voice merge patch.</summary>
    /// <param name="text">Complete text to synthesize.</param>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextAsync(
        string text,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        SendSimpleItemTextAsync(text, voice, cancellationToken);

    /// <summary>Streams one increment through the simple output item.</summary>
    /// <param name="delta">The next text fragment.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDeltaAsync(string delta, CancellationToken cancellationToken = default) =>
        SendTextDeltaAsync(delta, voice: null, cancellationToken);

    /// <summary>Streams one increment with an optional per-segment voice merge patch.</summary>
    /// <param name="delta">The next text fragment.</param>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDeltaAsync(
        string delta,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        SendSimpleItemDeltaAsync(delta, voice, cancellationToken);

    /// <summary>
    /// Completes the streamed simple item. The library emits the full
    /// concatenation of all preceding deltas as required by the wire contract.
    /// </summary>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDoneAsync(CancellationToken cancellationToken = default) =>
        SendTextDoneAsync(voice: null, cancellationToken);

    /// <summary>Completes the streamed simple item with an optional voice merge patch.</summary>
    /// <param name="voice">An optional non-empty Voice Live voice merge patch.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task SendTextDoneAsync(
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken = default) =>
        SendSimpleItemDoneAsync(voice, cancellationToken);

    /// <summary>Explicitly resolves this input prefix without opening a response.</summary>
    /// <param name="reason">An optional open-enum decline reason.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task DeclineAsync(string? reason = null, CancellationToken cancellationToken = default)
    {
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            IReadOnlyList<string> inReplyTo;
            lock (_stateSync)
            {
                EnsureWritableLocked();
                inReplyTo = InReplyTo ?? throw new InvalidOperationException("A proactive response cannot be declined.");
                if (_wireOpened || _items.Any(item => item.IsStarted))
                {
                    throw new InvalidOperationException("Cannot decline after opening a response.");
                }
            }

            await _connection.DeclineResponseAsync(this, inReplyTo, reason, cancellationToken).ConfigureAwait(false);
            lock (_stateSync)
            {
                MarkTerminalLocked();
            }
        }
        finally
        {
            _operationGate.Release();
        }
    }

    /// <summary>Terminates this response with a sanitized response-scoped error.</summary>
    /// <param name="code">A bounded machine-readable open-enum code.</param>
    /// <param name="message">Diagnostic detail that must not contain sensitive content.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task FailAsync(
        string code,
        string message,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(message);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                EnsureWritableLocked();
            }

            var fields = new Dictionary<string, object?>
            {
                ["code"] = VoiceValidation.SafeCode(code, "agent_error"),
                ["message"] = VoiceValidation.SafeMessage(message, "Agent response failed"),
                ["response_id"] = ResponseId,
            };
            await _connection.SendResponseFrameAsync(
                this,
                "error",
                fields,
                static () => { },
                terminal: true,
                terminalKind: "error",
                cancellationToken).ConfigureAwait(false);

            CancelResponseWork();
        }
        finally
        {
            _operationGate.Release();
        }
    }

    /// <summary>Requests self-cancel and awaits the winning playback terminal.</summary>
    /// <param name="reason">An optional open-enum cancellation reason.</param>
    /// <param name="cancellationToken">Cancels only this await; wire arbitration continues.</param>
    /// <returns>The bridge-selected <c>cancelled</c> or racing <c>barge_in</c> outcome.</returns>
    public virtual async Task<ResponseCancellationOutcome> CancelAsync(
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        Task<ResponseCancellationOutcome> outcome;
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                EnsureWritableLocked();
                if (!_wireOpened)
                {
                    throw new InvalidOperationException("Cannot cancel before response.created.");
                }

                if (_cancelPending)
                {
                    throw new InvalidOperationException("Response cancellation is already pending.");
                }
            }

            outcome = await _connection.BeginCancelAsync(this, reason, CancellationToken.None).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }

        try
        {
            return await outcome.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            ObserveOutcomeFaults(outcome);
            throw;
        }
        finally
        {
            if (outcome.IsCompleted)
            {
                lock (_stateSync)
                {
                    _cancelPending = false;
                }
            }
        }
    }

    /// <summary>Requests terminal handoff to a same-project hosted text agent.</summary>
    /// <param name="target">The stable target agent name.</param>
    /// <param name="message">An optional bridge-owned transition line.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task HandoffAsync(
        string target,
        string? message = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(target);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                EnsureWritableLocked();
            }

            var fields = new Dictionary<string, object?>
            {
                ["response_id"] = ResponseId,
                ["target"] = target,
            };
            if (message is not null)
            {
                fields["message"] = message;
            }

            await _connection.SendResponseFrameAsync(
                this,
                "handoff",
                fields,
                static () => { },
                terminal: true,
                terminalKind: "handoff",
                cancellationToken).ConfigureAwait(false);

            CancelResponseWork();
        }
        finally
        {
            _operationGate.Release();
        }
    }

    /// <summary>
    /// Explicitly completes normal generation. Callback-bound replies are
    /// completed automatically; proactive responses call this method.
    /// </summary>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                EnsureWritableLocked();
                EnsureCompleteOutputLocked();
            }

            await _connection.SendResponseFrameAsync(
                this,
                "response.done",
                new Dictionary<string, object?> { ["response_id"] = ResponseId },
                static () => { },
                terminal: true,
                terminalKind: "done",
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    internal async Task SendItemTextAsync(
        VoiceTextItem item,
        string text,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(text);
        var textBytes = Encoding.UTF8.GetByteCount(text);
        var escapedTextBytes = VoiceSendTransaction.MeasureEscapedStringBytes(text);
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await SendItemTextCoreAsync(
                item,
                text,
                textBytes,
                escapedTextBytes,
                voicePayload,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendSimpleItemTextAsync(
        string text,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(text);
        var textBytes = Encoding.UTF8.GetByteCount(text);
        var escapedTextBytes = VoiceSendTransaction.MeasureEscapedStringBytes(text);
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var item = GetSimpleItem();
            await SendItemTextCoreAsync(
                item,
                text,
                textBytes,
                escapedTextBytes,
                voicePayload,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendItemTextCoreAsync(
        VoiceTextItem item,
        string text,
        int textBytes,
        int escapedTextBytes,
        IReadOnlyDictionary<string, object?>? voicePayload,
        CancellationToken cancellationToken)
    {
        VoiceOutputReservation outputReservation;
        lock (_stateSync)
        {
            PrepareItemLocked(item);
            if (item.IsStarted || item.IsDone)
            {
                throw new InvalidOperationException("The response item has already started.");
            }

            ValidateTextBudgetLocked(item, textBytes, escapedTextBytes, additionalChunk: true);
            outputReservation = _outputResources.Reserve(
                bytes: EstimateRetainedTextBytes(text),
                chunks: 1,
                writes: 1);
        }

        using (outputReservation)
        {
            var fields = new Dictionary<string, object?>
            {
                ["response_id"] = ResponseId,
                ["item_id"] = item.ItemId,
                ["text"] = text,
            };
            AddVoice(fields, voicePayload);
            await _connection.SendResponseFrameAsync(
                this,
                "response.output_text.done",
                fields,
                () =>
                {
                    item.CommitCompleteText(text, textBytes, escapedTextBytes);
                    _responseBytes += textBytes;
                    outputReservation.Commit();
                },
                terminal: false,
                terminalKind: null,
                cancellationToken).ConfigureAwait(false);
        }
    }

    internal async Task SendItemDeltaAsync(
        VoiceTextItem item,
        string delta,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(delta);
        if (delta.Length == 0)
        {
            throw new ArgumentException("A streamed text delta cannot be empty.", nameof(delta));
        }

        var deltaBytes = Encoding.UTF8.GetByteCount(delta);
        var escapedDeltaBytes = VoiceSendTransaction.MeasureEscapedStringBytes(delta);
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await SendItemDeltaCoreAsync(
                item,
                delta,
                deltaBytes,
                escapedDeltaBytes,
                voicePayload,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendSimpleItemDeltaAsync(
        string delta,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(delta);
        if (delta.Length == 0)
        {
            throw new ArgumentException("A streamed text delta cannot be empty.", nameof(delta));
        }

        var deltaBytes = Encoding.UTF8.GetByteCount(delta);
        var escapedDeltaBytes = VoiceSendTransaction.MeasureEscapedStringBytes(delta);
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var item = GetSimpleItem();
            await SendItemDeltaCoreAsync(
                item,
                delta,
                deltaBytes,
                escapedDeltaBytes,
                voicePayload,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendItemDeltaCoreAsync(
        VoiceTextItem item,
        string delta,
        int deltaBytes,
        int escapedDeltaBytes,
        IReadOnlyDictionary<string, object?>? voicePayload,
        CancellationToken cancellationToken)
    {
        VoiceOutputReservation outputReservation;
        lock (_stateSync)
        {
            PrepareItemLocked(item);
            if (item.IsDone)
            {
                throw new InvalidOperationException("The response item is already complete.");
            }

            ValidateTextBudgetLocked(item, deltaBytes, escapedDeltaBytes, additionalChunk: true);
            outputReservation = _outputResources.Reserve(
                bytes: EstimateRetainedTextBytes(delta),
                chunks: 1,
                writes: 1);
        }

        using (outputReservation)
        {
            var fields = new Dictionary<string, object?>
            {
                ["response_id"] = ResponseId,
                ["item_id"] = item.ItemId,
                ["delta"] = delta,
            };
            AddVoice(fields, voicePayload);
            await _connection.SendResponseFrameAsync(
                this,
                "response.output_text.delta",
                fields,
                () =>
                {
                    item.CommitDelta(delta, deltaBytes, escapedDeltaBytes);
                    _responseBytes += deltaBytes;
                    outputReservation.Commit();
                },
                terminal: false,
                terminalKind: null,
                cancellationToken).ConfigureAwait(false);
        }
    }

    internal async Task SendItemDoneAsync(
        VoiceTextItem item,
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await SendItemDoneCoreAsync(item, voicePayload, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendSimpleItemDoneAsync(
        IReadOnlyDictionary<string, object?>? voice,
        CancellationToken cancellationToken)
    {
        var voicePayload = VoiceValidation.NormalizeVoice(voice);
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var item = GetSimpleItem(create: false);
            await SendItemDoneCoreAsync(item, voicePayload, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    private async Task SendItemDoneCoreAsync(
        VoiceTextItem item,
        IReadOnlyDictionary<string, object?>? voicePayload,
        CancellationToken cancellationToken)
    {
        string fullText;
        VoiceOutputReservation writeReservation;
        VoiceOutputReservation textCopyReservation;
        lock (_stateSync)
        {
            PrepareItemLocked(item);
            if (!item.IsStarted || item.ChunkCount == 0)
            {
                throw new InvalidOperationException("SendTextDoneAsync requires at least one preceding delta.");
            }

            if (item.IsDone)
            {
                throw new InvalidOperationException("The response item is already complete.");
            }

            writeReservation = _outputResources.Reserve(writes: 1);
            try
            {
                textCopyReservation = _outputResources.Reserve(bytes: item.RetainedTextBytes);
            }
            catch
            {
                writeReservation.Dispose();
                throw;
            }
        }

        using (writeReservation)
        using (textCopyReservation)
        {
            fullText = item.GetFullText();
            var fields = new Dictionary<string, object?>
            {
                ["response_id"] = ResponseId,
                ["item_id"] = item.ItemId,
                ["text"] = fullText,
            };
            AddVoice(fields, voicePayload);
            await _connection.SendResponseFrameAsync(
                this,
                "response.output_text.done",
                fields,
                () =>
                {
                    item.MarkDone();
                    writeReservation.Commit();
                },
                terminal: false,
                terminalKind: null,
                cancellationToken).ConfigureAwait(false);
        }
    }

    internal async Task CompleteCallbackAsync(CancellationToken cancellationToken)
    {
        var terminalKind = "done";
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                if (_terminal || _connection.Ending)
                {
                    _sealed = true;
                    return;
                }

                if (_cancelPending)
                {
                    _sealed = true;
                    return;
                }

                if (!_wireOpened || _items.Count == 0 || _items.Any(item => !item.IsDone))
                {
                    terminalKind = "error";
                }
            }

            if (terminalKind == "error")
            {
                await EmitSdkErrorAsync(
                    "Voice turn callback returned without complete output or decline.",
                    cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await _connection.SendResponseFrameAsync(
                    this,
                    "response.done",
                    new Dictionary<string, object?> { ["response_id"] = ResponseId },
                    static () => { },
                    terminal: true,
                    terminalKind: "done",
                    cancellationToken).ConfigureAwait(false);
            }
        }
        finally
        {
            _operationGate.Release();
        }
    }

    internal async Task FailCallbackAsync(CancellationToken cancellationToken)
    {
        await _operationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            lock (_stateSync)
            {
                if (_terminal || _connection.Ending)
                {
                    _sealed = true;
                    return;
                }

                if (_cancelPending)
                {
                    _sealed = true;
                    return;
                }
            }

            await EmitSdkErrorAsync("Voice turn callback failed.", cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _operationGate.Release();
        }
    }

    internal Task MarkTerminalAsync()
    {
        lock (_stateSync)
        {
            MarkTerminalLocked();
        }

        CancelResponseWork();

        return Task.CompletedTask;
    }

    internal void MarkAccepted()
    {
        lock (_stateSync)
        {
            if (_terminal)
            {
                throw new VoiceBridgeConnectionClosedException("The proactive response is terminal.");
            }

            _accepted = true;
        }
    }

    internal async Task DrainPendingSendAsync()
    {
        await _operationGate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        _operationGate.Release();
    }

    internal bool OwnsItem(string itemId)
    {
        lock (_stateSync)
        {
            if (_items.Any(item => item.ItemId == itemId && item.IsStarted))
            {
                return true;
            }

            return TryParseOutputItemId(itemId, out var parsed) &&
                Array.BinarySearch(_releasedItemIds, parsed) >= 0;
        }
    }

    internal void ReleaseOutputBuffers()
    {
        lock (_stateSync)
        {
            if (_items.Count == 0)
            {
                return;
            }

            var itemIds = new List<Guid>(_items.Count);
            foreach (var item in _items)
            {
                item.ReleaseText();
                if (item.IsStarted && TryParseOutputItemId(item.ItemId, out var itemId))
                {
                    itemIds.Add(itemId);
                }
            }

            itemIds.Sort();
            _releasedItemIds = itemIds.ToArray();
            var unstartedItems = _items.Count - itemIds.Count;
            _items.Clear();
            _items.TrimExcess();
            _simpleItem = null;
            _outputResources.ReleaseContent();
            if (unstartedItems > 0)
            {
                _outputResources.ReleaseItems(unstartedItems);
            }
        }
    }

    internal void ReleaseRetainedIdentities()
    {
        lock (_stateSync)
        {
            _releasedItemIds = [];
            _outputResources.ReleaseAll();
        }
    }

    private static bool TryParseOutputItemId(string itemId, out Guid value)
    {
        const string Prefix = "it_";
        if (!itemId.StartsWith(Prefix, StringComparison.Ordinal))
        {
            value = default;
            return false;
        }

        return Guid.TryParseExact(itemId.AsSpan(Prefix.Length), "N", out value);
    }

    private VoiceTextItem GetSimpleItem(bool create = true)
    {
        lock (_stateSync)
        {
            EnsureLocallyWritableLocked();
            if (_advancedItems)
            {
                throw new InvalidOperationException("Cannot mix simple response helpers with CreateTextItem.");
            }

            if (_simpleItem is null)
            {
                if (!create)
                {
                    throw new InvalidOperationException("SendTextDoneAsync requires at least one preceding delta.");
                }

                using var outputReservation = _outputResources.Reserve(items: 1);
                _simpleItem = new VoiceTextItem(this, VoiceIds.New(VoiceProtocolConstants.OutputItemPrefix));
                _items.Add(_simpleItem);
                outputReservation.Commit();
            }

            return _simpleItem;
        }
    }

    private async Task EnsureOpenAsync(CancellationToken cancellationToken)
    {
        lock (_stateSync)
        {
            if (_wireOpened)
            {
                return;
            }
        }

        var opened = await _connection.OpenResponseAsync(this, InReplyTo, cancellationToken).ConfigureAwait(false);
        lock (_stateSync)
        {
            if (opened)
            {
                _wireOpened = true;
            }
            else
            {
                MarkTerminalLocked();
            }
        }

        if (!opened)
        {
            CancelResponseWork();
            throw new VoiceBridgeConnectionClosedException("The voice response lost terminal arbitration.");
        }
    }

    private async Task EmitSdkErrorAsync(string message, CancellationToken cancellationToken)
    {
        await _connection.SendResponseFrameAsync(
            this,
            "error",
            new Dictionary<string, object?>
            {
                ["code"] = "handler_error",
                ["message"] = message,
                ["response_id"] = ResponseId,
            },
            static () => { },
            terminal: true,
            terminalKind: "error",
            cancellationToken).ConfigureAwait(false);

        CancelResponseWork();
    }

    private void CancelResponseWork(bool disposeConnectionRegistration = true)
    {
        if (disposeConnectionRegistration)
        {
            ReleaseConnectionCancellationRegistration();
        }

        // Customer cancellation callbacks must never run inline: a terminal can
        // be applied while the connection holds the send gate or a response
        // operation gate, and a callback that re-enters the send path would
        // otherwise deadlock. CancelAsync dispatches the registered callbacks
        // off the current stack. The terminal state itself is already committed
        // synchronously by the caller, so the deferred notification is safe.
        var cancelTask = _responseCancellation.CancelAsync();
        if (!cancelTask.IsCompleted)
        {
            ObserveCancelFaults(cancelTask);
        }
        else if (cancelTask.IsFaulted)
        {
            _ = cancelTask.Exception;
        }
    }

    private void OnConnectionCancelled()
    {
        lock (_stateSync)
        {
            // A normal response terminal that committed before the connection
            // cancellation owns the outcome. Unregister cannot recall a callback
            // already queued by CancellationTokenSource, so that callback must
            // re-arbitrate against terminal state under the response lock.
            if (_terminal)
            {
                return;
            }

            _sealed = true;
            _generation++;
        }

        CancelResponseWork(disposeConnectionRegistration: false);
    }

    private void ReleaseConnectionCancellationRegistration()
    {
        if (Interlocked.Exchange(ref _connectionCancellationRegistrationDisposed, 1) == 0)
        {
            // Unregister is deliberately non-blocking. The parent token may be
            // cancelling concurrently, and waiting for its callback while the
            // response or connection send gate is held could deadlock teardown.
            _connectionCancellationRegistration.Unregister();
        }
    }

    private static void ObserveCancelFaults(Task cancelTask) =>
        _ = cancelTask.ContinueWith(
            static completed => { _ = completed.Exception; },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);

    private static void ObserveOutcomeFaults(Task outcomeTask) =>
        _ = outcomeTask.ContinueWith(
            static completed => { _ = completed.Exception; },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);

    private void PrepareItemLocked(VoiceTextItem item)
    {
        EnsureWritableLocked();
        var index = _items.IndexOf(item);
        if (index < 0)
        {
            throw new InvalidOperationException("The text item does not belong to this response.");
        }

        for (var previous = 0; previous < index; previous++)
        {
            if (!_items[previous].IsDone)
            {
                throw new InvalidOperationException("Complete the previous response item first.");
            }
        }
    }

    private void ValidateTextBudgetLocked(
        VoiceTextItem item,
        int additionalBytes,
        int additionalEscapedBytes,
        bool additionalChunk)
    {
        if (additionalBytes > VoiceProtocolConstants.MaxOutputItemBytes ||
            item.TextBytes + additionalBytes > VoiceProtocolConstants.MaxOutputItemBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(additionalBytes), "An output item exceeds the maximum encoded text size.");
        }

        if (additionalChunk && item.ChunkCount >= VoiceProtocolConstants.MaxOutputItemChunks)
        {
            throw new ArgumentOutOfRangeException(nameof(additionalChunk), "An output item cannot exceed 4096 text chunks.");
        }

        if (_responseBytes + additionalBytes > VoiceProtocolConstants.MaxResponseBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(additionalBytes), "A response exceeds the maximum cumulative encoded text size.");
        }

        if (item.EscapedTextBytes + additionalEscapedBytes > VoiceProtocolConstants.MaxOutputItemEscapedBytes)
        {
            throw new ArgumentOutOfRangeException(
                nameof(additionalEscapedBytes),
                "An output item cannot fit in the required JSON-encoded done frame.");
        }
    }

    private static long EstimateRetainedTextBytes(string text) =>
        checked((long)text.Length * sizeof(char));

    private void EnsureCompleteOutputLocked()
    {
        if (!_wireOpened || _items.Count == 0)
        {
            throw new InvalidOperationException("response.done requires at least one completed output item.");
        }

        if (_items.Any(item => !item.IsDone))
        {
            throw new InvalidOperationException("Complete every response item before response.done.");
        }
    }

    private void EnsureWritableLocked()
    {
        EnsureLocallyWritableLocked();
        if (!_accepted)
        {
            throw new InvalidOperationException("Proactive output is unavailable before response.accepted.");
        }
    }

    private void MarkTerminalLocked()
    {
        if (!_terminal)
        {
            _terminal = true;
            _generation++;
        }

        _sealed = true;
        _cancelPending = false;
    }

    private void EnsureLocallyWritableLocked()
    {
        if (_terminal || _sealed || _connection.Ending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice response is terminal.");
        }

        if (_cancelPending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice response is awaiting cancellation.");
        }
    }

    private static void AddVoice(
        IDictionary<string, object?> fields,
        IReadOnlyDictionary<string, object?>? voice)
    {
        if (voice is not null)
        {
            fields["voice"] = voice;
        }
    }
}
