// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent.Telemetry;

#nullable enable

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Implementation of collection abstraction over streaming assistant updates.
/// </summary>
internal class AsyncStreamingUpdateCollection : AsyncCollectionResult<StreamingUpdate>
{
    private readonly Func<Task<Response>> _sendRequestAsync;
    private readonly CancellationToken _cancellationToken;
    private readonly OpenTelemetryScope? _scope;
    private readonly ToolCallsResolver? _toolCallsResolver;
    private readonly Func<ThreadRun, IEnumerable<ToolOutput>, IEnumerable<ToolApproval>, int, AsyncCollectionResult<StreamingUpdate>> _submitToolOutputsToStreamAsync;
    private readonly int _maxRetry;
    private int _currRetry;
    private readonly Func<string, Task<Response<ThreadRun>>> _cancelRunAsync;

    public AsyncStreamingUpdateCollection(
        CancellationToken cancellationToken,
        AutoFunctionCallOptions autoFunctionCallOptions,
        int currentRetry,
        Func<Task<Response>> sendRequestAsync,
        Func<string, Task<Response<ThreadRun>>> cancelRunAsync,
        Func<ThreadRun, IEnumerable<ToolOutput>, IEnumerable<ToolApproval>, int, AsyncCollectionResult<StreamingUpdate>> submitToolOutputsToStreamAsync,
        OpenTelemetryScope? scope = null)
    {
        Argument.AssertNotNull(sendRequestAsync, nameof(sendRequestAsync));

        _cancellationToken = cancellationToken;
        _scope = scope;
        _sendRequestAsync = sendRequestAsync;
        _submitToolOutputsToStreamAsync = submitToolOutputsToStreamAsync;
        if (autoFunctionCallOptions != null)
        {
            _toolCallsResolver = new(autoFunctionCallOptions.AutoFunctionCallDelegates);
            _maxRetry = autoFunctionCallOptions.MaxRetry;
        }
        _currRetry = currentRetry;
        _cancelRunAsync = cancelRunAsync;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        // Continuation is not supported for SSE streams.
        => null;

    public async override IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        Response response = await _sendRequestAsync().ConfigureAwait(false);
        PipelineResponse scmResponse = new ResponseAdapter(response);

        // We don't currently support resuming a dropped connection from the
        // last received event, so the response collection has a single element.
        yield return ClientResult.FromResponse(scmResponse);
    }

    protected async override IAsyncEnumerable<StreamingUpdate> GetValuesFromPageAsync(ClientResult page)
    {
        ThreadRun? streamRun = null;
        List<ToolOutput> toolOutputs = new();
        do
        {
            IAsyncEnumerator<StreamingUpdate> enumerator = (toolOutputs.Count > 0 && streamRun != null) ?
                _submitToolOutputsToStreamAsync(streamRun, toolOutputs, [], _currRetry).GetAsyncEnumerator(_cancellationToken) :
                new AsyncStreamingUpdateEnumerator(page, _cancellationToken, _scope);

            toolOutputs.Clear();

            try
            {
                bool hasError = false;
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var streamingUpdate = enumerator.Current;
                    if (streamingUpdate is RequiredActionUpdate newActionUpdate && _toolCallsResolver != null)
                    {
                        ToolOutput toolOutput;
                        try
                        {
                            toolOutput = _toolCallsResolver.GetResolvedToolOutput(
                                newActionUpdate.FunctionName,
                                newActionUpdate.ToolCallId,
                                newActionUpdate.FunctionArguments
                            );
                        }
                        catch (Exception ex)
                        {
                            string errorJson = JsonSerializer.Serialize(
                                new SerializableError(ex.GetBaseException().Message),
                                SourceGenerationContext.Default.SerializableError
                            );
                            toolOutput = new ToolOutput(newActionUpdate.ToolCallId, errorJson);
                            hasError = true;
                        }
                        toolOutputs.Add(toolOutput);

                        streamRun = newActionUpdate.Value;
                    }
                    else
                    {
                        // Send to telemetry (if needed)
                        _scope?.RecordStreamingUpdate(streamingUpdate);
                        yield return streamingUpdate;
                    }
                }
                _currRetry = hasError ? _currRetry + 1 : _currRetry;

                if (streamRun != null && _currRetry > _maxRetry)
                {
                    // Cancel the run if the max retry is reached
                    var cancelRunResponse =  await _cancelRunAsync(streamRun.Id).ConfigureAwait(false);
                    yield return new StreamingUpdate<ThreadRun>(cancelRunResponse.Value, StreamingUpdateReason.RunCancelled);
                    yield break;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }
        while (toolOutputs.Count > 0);
    }

    private sealed class AsyncStreamingUpdateEnumerator : IAsyncEnumerator<StreamingUpdate>
    {
        private static ReadOnlySpan<byte> TerminalData => "[DONE]"u8;

        private readonly CancellationToken _cancellationToken;
        private readonly PipelineResponse _response;

        // These enumerators represent what is effectively a doubly-nested
        // loop over the outer event collection and the inner update collection,
        // i.e.:
        //   foreach (var sse in _events) {
        //       // get _updates from sse event
        //       foreach (var update in _updates) { ... }
        //   }
        private IAsyncEnumerator<SseItem<byte[]>>? _events;
        private IEnumerator<StreamingUpdate>? _updates;

        private StreamingUpdate? _current;
        private OpenTelemetryScope? _scope;
        private bool _started;
        private bool _hasYieldedUpdate; // Track if any updates have been yielded

        public AsyncStreamingUpdateEnumerator(ClientResult page, CancellationToken cancellationToken, OpenTelemetryScope? scope = null)
        {
            Argument.AssertNotNull(page, nameof(page));

            _scope = scope;
            _response = page.GetRawResponse();
            _cancellationToken = cancellationToken;
            _hasYieldedUpdate = false;
        }

        StreamingUpdate IAsyncEnumerator<StreamingUpdate>.Current
            => _current!;

        async ValueTask<bool> IAsyncEnumerator<StreamingUpdate>.MoveNextAsync()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(AsyncStreamingUpdateEnumerator));
            }

            if (_cancellationToken.IsCancellationRequested)
            {
                _scope?.RecordCancellation();
                _scope?.Dispose();
                _scope = null;
            }

            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
	            _events ??= CreateEventEnumeratorAsync();
	            _started = true;

	            if (_updates is not null && _updates.MoveNext())
	            {
	                _current = _updates.Current;
                    _hasYieldedUpdate = true;
	                return true;
	            }

	            if (await _events.MoveNextAsync().ConfigureAwait(false))
	            {
	                if (_events.Current.Data.AsSpan().SequenceEqual(TerminalData))
	                {
	                    _current = default;
                        if (_scope != null && _started && !_hasYieldedUpdate)
                        {
                            _scope.RecordError(new InvalidOperationException("No events were received from the stream."));
                            _scope.Dispose();
                            _scope = null;
                        }
	                    return false;
	                }

	                IEnumerable<StreamingUpdate> updates = StreamingUpdate.FromEvent(_events.Current);
                    if (updates is null)
                    {
                        StreamingUpdateReason updateKind = StreamingUpdateReasonExtensions.FromSseEventLabel(_events.Current.EventType);
                        throw new InvalidOperationException($"Unknown streaming update reason {updateKind}");
                    }
                    _updates = updates.GetEnumerator();

	                if (_updates.MoveNext())
	                {
	                    _current = _updates.Current;
                        _hasYieldedUpdate = true;
	                    return true;
	                }
	            }

	            _current = default;
                if (_scope != null && _started && !_hasYieldedUpdate)
                {
                    _scope.RecordError(new InvalidOperationException("No events were received from the stream."));
                    _scope.Dispose();
                    _scope = null;
                }
	            return false;
            }
            catch (Exception ex)
            {
                _scope?.RecordError(ex);
                _scope?.Dispose();
                _scope = null;
                throw;
            }
        }

        private IAsyncEnumerator<SseItem<byte[]>> CreateEventEnumeratorAsync()
        {
            if (_response.ContentStream is null)
            {
                throw new InvalidOperationException("Unable to create result from response with null ContentStream");
            }

            IAsyncEnumerable<SseItem<byte[]>> enumerable = SseParser.Create(_response.ContentStream, (_, bytes) => bytes.ToArray()).EnumerateAsync();
            return enumerable.GetAsyncEnumerator(_cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);

            GC.SuppressFinalize(this);
        }

        private async ValueTask DisposeAsyncCore()
        {
            if (_events is not null)
            {
                _scope?.Dispose();
                await _events.DisposeAsync().ConfigureAwait(false);
                _events = null;

                // Dispose the response so we don't leave the network connection open.
                _response?.Dispose();
            }
        }
    }
}
