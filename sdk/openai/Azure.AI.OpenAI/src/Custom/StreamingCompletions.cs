// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Sse;

namespace Azure.AI.OpenAI.Custom
{
    public class StreamingCompletions : IDisposable
    {
        private Response _baseResponse;
        private bool _disposedValue;
        private SseReader _reader;

        internal StreamingCompletions(Response response)
        {
            _baseResponse = response;
            _reader = new SseReader(response.ContentStream);
        }

        public async IAsyncEnumerable<string> GetAsyncMessages()
        {
            while (true)
            {
                SseLine? sseEvent = await _reader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
                if (sseEvent == null)
                {
                    _baseResponse.ContentStream.Dispose();
                    // await _baseResponse.ContentStream!.DisposeAsync().ConfigureAwait(false);
                    break;
                }

                var name = sseEvent.Value.FieldName;
                if (!name.Span.SequenceEqual("data".AsSpan()))
                    throw new InvalidDataException();

                var value = sseEvent.Value.FieldValue;
                if (value.Span.SequenceEqual("[DONE]".AsSpan()))
                {
                    _baseResponse.ContentStream.Dispose();
                    // await _baseResponse.ContentStream!.DisposeAsync().ConfigureAwait(false);
                    break;
                }

                yield return sseEvent.Value.FieldValue.ToString();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~StreamingCompletions()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
