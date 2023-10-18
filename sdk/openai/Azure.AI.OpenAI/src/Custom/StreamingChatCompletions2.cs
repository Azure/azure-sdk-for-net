// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Azure.Core.Sse;

namespace Azure.AI.OpenAI
{
    public class StreamingChatCompletions2 : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private bool _disposedValue;

        internal StreamingChatCompletions2(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
        }

        public async IAsyncEnumerable<StreamingChatCompletionsUpdate> EnumerateChatUpdates(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            while (true)
            {
                SseLine? sseEvent = await _baseResponseReader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
                if (sseEvent == null)
                {
                    _baseResponse.ContentStream?.Dispose();
                    break;
                }

                ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
                if (!name.Span.SequenceEqual("data".AsSpan()))
                    throw new InvalidDataException();

                ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
                if (value.Span.SequenceEqual("[DONE]".AsSpan()))
                {
                    _baseResponse.ContentStream?.Dispose();
                    break;
                }

                JsonDocument sseMessageJson = JsonDocument.Parse(sseEvent.Value.FieldValue);
                foreach (StreamingChatCompletionsUpdate streamingChatCompletionsUpdate
                    in StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates(sseMessageJson.RootElement))
                {
                    yield return streamingChatCompletionsUpdate;
                }
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _baseResponseReader.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
