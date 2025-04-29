// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure.AI.Projects;

/// <summary>
/// Implementation of collection abstraction over streaming assistant updates.
/// </summary>
internal class StreamingUpdateCollection : CollectionResult<StreamingUpdate>
{
    private readonly Func<Response> _sendRequest;
    private readonly CancellationToken _cancellationToken;
    private readonly ToolCallsResolver? _toolCallsResolver;
    private readonly Func<ThreadRun, IEnumerable<ToolOutput>, int, CollectionResult<StreamingUpdate>> _submitToolOutputsToStream;
    private readonly int _maxRetry;
    private int _currRetry;
    private readonly Func<string, Response<ThreadRun>> _cancelRun;

    public StreamingUpdateCollection(
        CancellationToken cancellationToken,
        AutoFunctionCallOptions autoFunctionCallOptions,
        int currentRetry,
        Func<Response> sendRequest,
        Func<string, Response<ThreadRun>> cancelRun,
        Func<ThreadRun, IEnumerable<ToolOutput>, int, CollectionResult<StreamingUpdate>> submitToolOutputsToStream)
    {
        Argument.AssertNotNull(sendRequest, nameof(sendRequest));

        _cancellationToken = cancellationToken;
        _sendRequest = sendRequest;
        _submitToolOutputsToStream = submitToolOutputsToStream;
        if (autoFunctionCallOptions != null)
        {
            _toolCallsResolver = new(autoFunctionCallOptions.AutoFunctionCallDelegates);
            _maxRetry = autoFunctionCallOptions.MaxRetry;
        }
        _currRetry = currentRetry;
        _cancelRun = cancelRun;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        // Continuation is not supported for SSE streams.
        => null;

    public override IEnumerable<ClientResult> GetRawPages()
    {
        Response response = _sendRequest();
        PipelineResponse scmResponse = new ResponseAdapter(response);

        // We don't currently support resuming a dropped connection from the
        // last received event, so the response collection has a single element.
        yield return ClientResult.FromResponse(scmResponse);
    }
    protected override IEnumerable<StreamingUpdate> GetValuesFromPage(ClientResult page)
    {
        ThreadRun? streamRun = null;
        List<ToolOutput> toolOutputs = new();
        do
        {
            using IEnumerator<StreamingUpdate> enumerator = (toolOutputs.Count > 0 && streamRun != null) ?
                _submitToolOutputsToStream(streamRun, toolOutputs, _currRetry).GetEnumerator() :
                new StreamingUpdateEnumerator(page, _cancellationToken);
            toolOutputs.Clear();
            bool hasError = false;
            while (enumerator.MoveNext())
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
                var cancelRunResponse = _cancelRun(streamRun.Id);
                yield return new StreamingUpdate<ThreadRun>(cancelRunResponse.Value, StreamingUpdateReason.RunCancelled);
                yield break;
            }
        }
        while (toolOutputs.Count > 0);
    }

    private sealed class StreamingUpdateEnumerator : IEnumerator<StreamingUpdate>
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
        private IEnumerator<SseItem<byte[]>>? _events;
        private IEnumerator<StreamingUpdate>? _updates;

        private StreamingUpdate? _current;
        private bool _started;

        public StreamingUpdateEnumerator(ClientResult page, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(page, nameof(page));

            _response = page.GetRawResponse();
            _cancellationToken = cancellationToken;
        }

        StreamingUpdate IEnumerator<StreamingUpdate>.Current
            => _current!;

        object IEnumerator.Current => _current!;

        public bool MoveNext()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(StreamingUpdateEnumerator));
            }

            _cancellationToken.ThrowIfCancellationRequested();
            _events ??= CreateEventEnumerator();
            _started = true;

            if (_updates is not null && _updates.MoveNext())
            {
                _current = _updates.Current;
                return true;
            }

            if (_events.MoveNext())
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

        private IEnumerator<SseItem<byte[]>> CreateEventEnumerator()
        {
            if (_response.ContentStream is null)
            {
                throw new InvalidOperationException("Unable to create result from response with null ContentStream");
            }

            IEnumerable<SseItem<byte[]>> enumerable = SseParser.Create(_response.ContentStream, (_, bytes) => bytes.ToArray()).Enumerate();
            return enumerable.GetEnumerator();
        }

        public void Reset()
        {
            throw new NotSupportedException("Cannot seek back in an SSE stream.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _events is not null)
            {
                _events.Dispose();
                _events = null;

                // Dispose the response so we don't leave the network connection open.
                _response?.Dispose();
            }
        }
    }
}
