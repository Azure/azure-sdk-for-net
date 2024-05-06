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
    // TODO: delay sending request
    public AsyncSseValueResultCollection(PipelineResponse response) : base(response)
    {
    }

    public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        PipelineResponse response = GetRawResponse();

        // We validate that response.ContentStream is non-null in
        // AsyncResultCollection.Create method.
        Debug.Assert(response.ContentStream is not null);

        ServerSentEventReader reader = new(response.ContentStream!);
        AsyncServerSentEventEnumerator sseEnumerator = new(reader, cancellationToken);
        return new AsyncSseValueEnumerator(sseEnumerator);
    }

    // TODO: probably change the name back to AsyncSseJsonModelEnumerator.
    // Right now, I want to reason about it as "the thing that enumerates values."
    private class AsyncSseValueEnumerator : IAsyncEnumerator<T>, IDisposable, IAsyncDisposable
    {
        private readonly AsyncServerSentEventEnumerator _eventEnumerator;

        private T? _current;

        // TODO: is null supression the correct pattern here?
        public T Current { get => _current!; }

        public AsyncSseValueEnumerator(AsyncServerSentEventEnumerator eventEnumerator)
        {
            Argument.AssertNotNull(eventEnumerator, nameof(eventEnumerator));

            _eventEnumerator = eventEnumerator;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (await _eventEnumerator.MoveNextAsync().ConfigureAwait(false))
            {
                using JsonDocument eventDocument = JsonDocument.Parse(_eventEnumerator.Current.Data);
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
            await _eventEnumerator.DisposeAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            _eventEnumerator.Dispose();
        }
    }
}
