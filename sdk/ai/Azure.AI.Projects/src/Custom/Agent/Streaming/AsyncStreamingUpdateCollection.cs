// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure.AI.Projects;

/// <summary>
/// Implementation of collection abstraction over streaming assistant updates.
/// </summary>
internal class AsyncStreamingUpdateCollection : AsyncCollectionResult<StreamingUpdate>
{
    private readonly Func<Task<Response>> _sendRequestAsync;
    private readonly CancellationToken _cancellationToken;
    private readonly ToolCallsResolver? _toolCallsResolver;
    private readonly Func<ThreadRun, IEnumerable<ToolOutput>, int, AsyncCollectionResult<StreamingUpdate>> _submitToolOutputsToStreamAsync;
    private readonly int _maxRetry;
    private int _currRetry;
    private readonly Func<string, Task<Response<ThreadRun>>> _cancelRunAsync;

    public AsyncStreamingUpdateCollection(
        CancellationToken cancellationToken,
        AutoFunctionCallOptions autoFunctionCallOptions,
        int currentRetry,
        Func<Task<Response>> sendRequestAsync,
        Func<string, Task<Response<ThreadRun>>> cancelRunAsync,
        Func<ThreadRun, IEnumerable<ToolOutput>, int, AsyncCollectionResult<StreamingUpdate>> submitToolOutputsToStreamAsync)
    {
        Argument.AssertNotNull(sendRequestAsync, nameof(sendRequestAsync));

        _cancellationToken = cancellationToken;
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
                _submitToolOutputsToStreamAsync(streamRun, toolOutputs, _currRetry).GetAsyncEnumerator(_cancellationToken) :
                new AsyncStreamingUpdateEnumerator(page, _cancellationToken);

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
                            string errorJson = JsonSerializer.Serialize(new { error = ex.GetBaseException().Message });
                            toolOutput = new ToolOutput(newActionUpdate.ToolCallId, errorJson);
                            hasError = true;
                        }
                        toolOutputs.Add(toolOutput);

                        streamRun = newActionUpdate.Value;
                    }
                    else
                    {
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
        private bool _started;

        public AsyncStreamingUpdateEnumerator(ClientResult page, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(page, nameof(page));

            _response = page.GetRawResponse();
            _cancellationToken = cancellationToken;
        }

        StreamingUpdate IAsyncEnumerator<StreamingUpdate>.Current
            => _current!;

        async ValueTask<bool> IAsyncEnumerator<StreamingUpdate>.MoveNextAsync()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(AsyncStreamingUpdateEnumerator));
            }

            _cancellationToken.ThrowIfCancellationRequested();
            _events ??= CreateEventEnumeratorAsync();
            _started = true;

            if (_updates is not null && _updates.MoveNext())
            {
                _current = _updates.Current;
                return true;
            }

            if (await _events.MoveNextAsync().ConfigureAwait(false))
            {
                if (_events.Current.Data.AsSpan().SequenceEqual(TerminalData))
                {
                    _current = default;
                    return false;
                }

                var updates = StreamingUpdate.FromEvent(_events.Current);
                _updates = updates.GetEnumerator();

                if (_updates.MoveNext())
                {
                    _current = _updates.Current;
                    return true;
                }
            }

            _current = default;
            return false;
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
                await _events.DisposeAsync().ConfigureAwait(false);
                _events = null;

                // Dispose the response so we don't leave the network connection open.
                _response?.Dispose();
            }
        }
    }
}
