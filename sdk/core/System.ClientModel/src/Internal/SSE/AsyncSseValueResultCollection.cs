// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class AsyncSseValueResultCollection<T> : AsyncResultCollection<T>
    where T : IJsonModel<T>
{
    private readonly Func<Task<ClientResult>> _getResultAsync;

    public AsyncSseValueResultCollection(Func<Task<ClientResult>> getResultAsync) : base()
    {
        Debug.Assert(getResultAsync is not null);

        _getResultAsync = getResultAsync!;
    }

    public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncSseValueEnumerator(_getResultAsync, this, cancellationToken);
    }

    private sealed class AsyncSseValueEnumerator : IAsyncEnumerator<T>
    {
        private readonly Func<Task<ClientResult>> _getResultAsync;
        private readonly AsyncSseValueResultCollection<T> _resultCollection;
        private readonly CancellationToken _cancellationToken;

        private AsyncServerSentEventEnumerator? _events;
        private T? _current;

        private bool _started;

        // TODO: is null supression the correct pattern here?
        public T Current { get => _current!; }

        public AsyncSseValueEnumerator(Func<Task<ClientResult>> getResultAsync, AsyncSseValueResultCollection<T> resultCollection, CancellationToken cancellationToken)
        {
            Debug.Assert(getResultAsync is not null);
            Debug.Assert(resultCollection is not null);

            _getResultAsync = getResultAsync!;
            _resultCollection = resultCollection!;
            _cancellationToken = cancellationToken;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(AsyncSseValueEnumerator));
            }

            if (_cancellationToken.IsCancellationRequested)
            {
                // TODO: correct to return false in this case?
                // Or do we throw TaskCancelledException?
                return false;
            }

            // TODO: refactor for clarity
            // Lazily initialize
            if (_events is null)
            {
                // TODO: show that cancellation token can be handled as part of
                // the closure and doesn't need to be passed?  Or ... no?
                ClientResult result = await _getResultAsync().ConfigureAwait(false);
                PipelineResponse response = result.GetRawResponse();
                _resultCollection.SetRawResponse(response);

                if (response.ContentStream is null)
                {
                    throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
                }

                _events = new(response.ContentStream, _cancellationToken);
                _started = true;
            }

            if (await _events.MoveNextAsync().ConfigureAwait(false))
            {
                using JsonDocument eventDocument = JsonDocument.Parse(_events.Current.Data);
                BinaryData eventData = BinaryData.FromObjectAsJson(eventDocument.RootElement);
                T? jsonData = ModelReaderWriter.Read<T>(eventData);

                // TODO: should we stop iterating if we can't deserialize?
                if (jsonData is null)
                {
                    _current = default;
                    return false;
                }

                if (jsonData is T singleInstanceData)
                {
                    _current = singleInstanceData;
                    return true;
                }
            }

            return false;
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
            }
        }
    }
}
