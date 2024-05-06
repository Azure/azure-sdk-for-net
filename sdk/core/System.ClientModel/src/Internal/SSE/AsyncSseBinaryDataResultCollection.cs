// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class AsyncSseBinaryDataResultCollection : AsyncResultCollection<BinaryData>
{
    // Note: this one doesn't delay sending the request because it's used
    // with protocol methods.
    public AsyncSseBinaryDataResultCollection(PipelineResponse response) : base(response)
    {
        Argument.AssertNotNull(response, nameof(response));
    }

    public override IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        PipelineResponse response = GetRawResponse();

        // We validate that response.ContentStream is non-null in
        // AsyncResultCollection.Create factory method.
        Debug.Assert(response.ContentStream is not null);

        return new AsyncSseDataEnumerator(response.ContentStream!, cancellationToken);
    }

    private sealed class AsyncSseDataEnumerator : IAsyncEnumerator<BinaryData>
    {
        private AsyncServerSentEventEnumerator? _events;
        private BinaryData? _current;

        // TODO: is null supression the correct pattern here?
        public BinaryData Current { get => _current!; }

        public AsyncSseDataEnumerator(Stream contentStream, CancellationToken cancellationToken)
        {
            Debug.Assert(contentStream is not null);

            _events = new(contentStream!, cancellationToken);
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (_events is null)
            {
                throw new ObjectDisposedException(nameof(AsyncSseDataEnumerator));
            }

            if (await _events.MoveNextAsync().ConfigureAwait(false))
            {
                char[] chars = _events.Current.Data.ToArray();
                byte[] bytes = Encoding.UTF8.GetBytes(chars);
                _current = new BinaryData(bytes);
                return true;
            }

            _current = null;
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
