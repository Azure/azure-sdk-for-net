// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent.Telemetry;

#nullable enable

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Implementation of collection abstraction over streaming agent updates.
/// </summary>
internal class AsyncStreamingUpdateCollection : AsyncCollectionResult<StreamingUpdate>
{
    private readonly Func<Task<Response>> _sendRequestAsync;
    private readonly CancellationToken _cancellationToken;
    private readonly OpenTelemetryScope? _scope;

    public AsyncStreamingUpdateCollection(
        Func<Task<Response>> sendRequestAsync,
        CancellationToken cancellationToken,
        OpenTelemetryScope? scope = null)
    {
        Argument.AssertNotNull(sendRequestAsync, nameof(sendRequestAsync));

        _sendRequestAsync = sendRequestAsync;
        _cancellationToken = cancellationToken;
        _scope = scope;
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
#pragma warning disable AZC0100 // ConfigureAwait(false) must be used.
        await using IAsyncEnumerator<StreamingUpdate> enumerator = new AsyncStreamingUpdateEnumerator(page, _cancellationToken, _scope);
#pragma warning restore AZC0100 // ConfigureAwait(false) must be used.
        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
        {
            var update = enumerator.Current;
            // Send to telemetry (if needed)
            _scope?.RecordStreamingUpdate(update);
            yield return update;
        }
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

	                var updates = StreamingUpdate.FromEvent(_events.Current);
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
