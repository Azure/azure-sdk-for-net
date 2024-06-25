// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Internal.Mocks;

public static class MockSseClientExtensions
{
    public static AsyncCollectionResult<BinaryData> EnumerateDataEvents(this PipelineResponse response)
    {
        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result collection from PipelineResponse with null ContentStream", nameof(response));
        }

        return new AsyncSseDataEventCollection(response, "[DONE]");
    }

    private class AsyncSseDataEventCollection : AsyncCollectionResult<BinaryData>
    {
        private readonly string _terminalData;

        public AsyncSseDataEventCollection(PipelineResponse response, string terminalData) : base(response)
        {
            Argument.AssertNotNull(response, nameof(response));

            _terminalData = terminalData;
        }

        public override IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            PipelineResponse response = GetRawResponse();

            // We validate that response.ContentStream is non-null in outer extension method.
            Debug.Assert(response.ContentStream is not null);

            return new AsyncSseDataEventEnumerator(response.ContentStream!, _terminalData, cancellationToken);
        }

        private sealed class AsyncSseDataEventEnumerator : IAsyncEnumerator<BinaryData>
        {
            private readonly string _terminalData;

            private IAsyncEnumerator<ServerSentEvent>? _events;
            private BinaryData? _current;

            public BinaryData Current { get => _current!; }

            public AsyncSseDataEventEnumerator(Stream contentStream, string terminalData, CancellationToken cancellationToken)
            {
                Debug.Assert(contentStream is not null);

                AsyncServerSentEventEnumerable enumerable = new(contentStream!);
                _events = enumerable.GetAsyncEnumerator(cancellationToken);

                _terminalData = terminalData;
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_events is null)
                {
                    throw new ObjectDisposedException(nameof(AsyncSseDataEventEnumerator));
                }

                if (await _events.MoveNextAsync().ConfigureAwait(false))
                {
                    if (_events.Current.Data == _terminalData)
                    {
                        _current = default;
                        return false;
                    }

                    _current = BinaryData.FromString(_events.Current.Data);
                    return true;
                }

                _current = default;
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
}
