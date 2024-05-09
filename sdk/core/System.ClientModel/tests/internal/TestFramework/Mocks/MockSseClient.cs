// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;

namespace ClientModel.Tests.Internal.Mocks;

// Note: keeping this mock client used to illustrate SSE usage patterns in
// Tests.Internal for now as it needs access to internal types. Once we are
// able to port to a solution that uses the public BCL SseParser type, this
// will no longer be needed.
public class MockSseClient
{
    public bool ProtocolMethodCalled { get; private set; }

    // mock convenience method
    public virtual AsyncResultCollection<MockJsonModel> GetModelsStreamingAsync(string content)
    {
        return new AsyncMockJsonModelCollection(content, GetModelsStreamingAsync);
    }

    // mock protocol method
    public virtual ClientResult GetModelsStreamingAsync(string content, RequestOptions? options = default)
    {
        // This mocks sending a request and returns a respose containing
        // the passed-in content in the content stream.

        MockPipelineResponse response = new();
        response.SetContent(content);

        ProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }

    // Internal client implementation of convenience-layer AsyncResultCollection.
    // This currently layers over an internal AsyncResultCollection<BinaryData>
    // representing the event.data values, but does not strictly have to.
    private class AsyncMockJsonModelCollection : AsyncResultCollection<MockJsonModel>
    {
        private readonly string _content;
        private readonly Func<string, RequestOptions?, ClientResult> _protocolMethod;

        public AsyncMockJsonModelCollection(string content, Func<string, RequestOptions?, ClientResult> protocolMethod)
        {
            _content = content;
            _protocolMethod = protocolMethod;
        }

        public override IAsyncEnumerator<MockJsonModel> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            async Task<ClientResult> getResultAsync()
            {
                // TODO: simulate async correctly
                await Task.Delay(0, cancellationToken);
                return _protocolMethod(_content, /*options:*/ default);
            }

            return new AsyncMockJsonModelEnumerator(getResultAsync, this, cancellationToken);
        }

        private sealed class AsyncMockJsonModelEnumerator : IAsyncEnumerator<MockJsonModel>
        {
            private const string _terminalData = "[DONE]";

            private readonly Func<Task<ClientResult>> _getResultAsync;
            private readonly AsyncMockJsonModelCollection _enumerable;
            private readonly CancellationToken _cancellationToken;

            private IAsyncEnumerator<ServerSentEvent>? _events;
            private MockJsonModel? _current;

            private bool _started;

            public AsyncMockJsonModelEnumerator(Func<Task<ClientResult>> getResultAsync, AsyncMockJsonModelCollection enumerable, CancellationToken cancellationToken)
            {
                Debug.Assert(getResultAsync is not null);
                Debug.Assert(enumerable is not null);

                _getResultAsync = getResultAsync!;
                _enumerable = enumerable!;
                _cancellationToken = cancellationToken;
            }

            MockJsonModel IAsyncEnumerator<MockJsonModel>.Current
                => _current!;

            async ValueTask<bool> IAsyncEnumerator<MockJsonModel>.MoveNextAsync()
            {
                if (_events is null && _started)
                {
                    throw new ObjectDisposedException(nameof(AsyncMockJsonModelEnumerator));
                }

                _cancellationToken.ThrowIfCancellationRequested();

                // TODO: refactor for clarity
                // Lazily initialize
                if (_events is null)
                {
                    ClientResult result = await _getResultAsync().ConfigureAwait(false);
                    PipelineResponse response = result.GetRawResponse();
                    _enumerable.SetRawResponse(response);

                    if (response.ContentStream is null)
                    {
                        throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
                    }

                    AsyncServerSentEventEnumerable enumerable = new(response.ContentStream);
                    _events = enumerable.GetAsyncEnumerator(_cancellationToken);
                    _started = true;
                }

                if (await _events.MoveNextAsync().ConfigureAwait(false))
                {
                    if (_events.Current.Data == _terminalData)
                    {
                        _current = default;
                        return false;
                    }

                    BinaryData data = BinaryData.FromString(_events.Current.Data);

                    MockJsonModel? model = ModelReaderWriter.Read<MockJsonModel>(data) ??
                        throw new JsonException($"Failed to deserialize expected type MockJsonModel from sse data payload '{_events.Current.Data}'.");

                    _current = model;
                    return true;
                }

                _current = default;
                return false;
            }

            ValueTask IAsyncDisposable.DisposeAsync() => new();
        }
    }
}
