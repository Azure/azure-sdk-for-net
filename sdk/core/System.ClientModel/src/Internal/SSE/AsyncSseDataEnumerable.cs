// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class AsyncSseDataResultCollection : AsyncResultCollection<BinaryData>
{
    // Note: this one doesn't delay sending the request because it's used
    // with protocol methods.
    public AsyncSseDataResultCollection(PipelineResponse response) : base(response)
    {
        Argument.AssertNotNull(response, nameof(response));
    }

    public override IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        PipelineResponse response = GetRawResponse();

        // We validate that response.ContentStream is non-null in
        // AsyncResultCollection.Create method.
        Debug.Assert(response.ContentStream is not null);

        ServerSentEventReader reader = new(response.ContentStream!);
        AsyncServerSentEventEnumerator sseEnumerator = new(reader, cancellationToken);
        return new AsyncSseDataEnumerator(sseEnumerator);
    }

    // TODO: probably change the name back to AsyncSseBinaryDataEnumerator.
    // Right now, I want to reason about it as "the thing that enumerates data elements as BinaryData."
    private class AsyncSseDataEnumerator : IAsyncEnumerator<BinaryData>, IDisposable, IAsyncDisposable
    {
        private readonly AsyncServerSentEventEnumerator _eventEnumerator;

        private BinaryData? _current;

        // TODO: is null supression the correct pattern here?
        public BinaryData Current { get => _current!; }

        public AsyncSseDataEnumerator(AsyncServerSentEventEnumerator eventEnumerator)
        {
            Argument.AssertNotNull(eventEnumerator, nameof(eventEnumerator));

            _eventEnumerator = eventEnumerator;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (await _eventEnumerator.MoveNextAsync().ConfigureAwait(false))
            {
                char[] chars = _eventEnumerator.Current.Data.ToArray();
                byte[] bytes = Encoding.UTF8.GetBytes(chars);
                _current = new BinaryData(bytes);
                return true;
            }

            _current = null;
            return false;
        }

        // TODO: implement this pattern correctly.
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
