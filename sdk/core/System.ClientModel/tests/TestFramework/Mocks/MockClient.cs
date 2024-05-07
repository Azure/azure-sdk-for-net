// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace ClientModel.Tests.Mocks;

public class MockClient
{
    public bool StreamingProtocolMethodCalled { get; private set; }

    public virtual ClientResult<MockJsonModel> GetModel(int intValue, string stringValue)
    {
        MockPipelineResponse response = new(200);
        MockJsonModel model = new MockJsonModel(intValue, stringValue);
        return ClientResult.FromValue(model, response);
    }

    public virtual ClientResult<MockJsonModel?> GetOptionalModel(int intValue, string stringValue, bool hasValue)
    {
        if (hasValue)
        {
            MockPipelineResponse response = new(200);
            MockJsonModel model = new MockJsonModel(intValue, stringValue);
            return ClientResult.FromOptionalValue(model, response);
        }
        else
        {
            MockPipelineResponse response = new(404);
            return ClientResult.FromOptionalValue<MockJsonModel?>(default, response);
        }
    }

    public virtual ClientResult<int> GetCount(int count)
    {
        MockPipelineResponse response = new(200);
        return ClientResult.FromValue(count, response);
    }

    public virtual ClientResult<int?> GetOptionalCount(int count, bool hasValue)
    {
        if (hasValue)
        {
            MockPipelineResponse response = new(200);
            return ClientResult.FromOptionalValue<int?>(count, response);
        }
        else
        {
            MockPipelineResponse response = new(404);
            return ClientResult.FromOptionalValue<int?>(default, response);
        }
    }

    // mock convenience method
    public virtual AsyncResultCollection<MockJsonModel> GetModelsStreamingAsync(string content)
    {
        return new MockJsonModelCollection(content, GetModelsStreamingAsync);
    }

    // mock protocol method
    public virtual ClientResult GetModelsStreamingAsync(string content, RequestOptions? options = default)
    {
        // This mocks sending a request and returns a respose containing
        // the passed-in content in the content stream.

        MockPipelineResponse response = new();
        response.SetContent(content);

        StreamingProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }

    private class MockJsonModelCollection : AsyncResultCollection<MockJsonModel>
    {
        private readonly string _content;
        private readonly Func<string, RequestOptions?, ClientResult> _protocolMethod;

        public MockJsonModelCollection(string content, Func<string, RequestOptions?, ClientResult> protocolMethod)
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
            private readonly Func<Task<ClientResult>> _getResultAsync;
            private readonly MockJsonModelCollection _enumerable;
            private readonly CancellationToken _cancellationToken;

            private IAsyncEnumerator<BinaryData>? _events;
            private MockJsonModel? _current;

            private bool _started;

            public AsyncMockJsonModelEnumerator(Func<Task<ClientResult>> getResultAsync, MockJsonModelCollection enumerable, CancellationToken cancellationToken)
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

                    AsyncResultCollection<BinaryData> events = Create(response, "[DONE]");
                    _events = events.GetAsyncEnumerator();
                    _started = true;
                }

                if (await _events.MoveNextAsync().ConfigureAwait(false))
                {
                    MockJsonModel? model = ModelReaderWriter.Read<MockJsonModel>(_events.Current);

                    // TODO: should we stop iterating if we can't deserialize?
                    if (model is null)
                    {
                        _current = default;
                        return false;
                    }

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
