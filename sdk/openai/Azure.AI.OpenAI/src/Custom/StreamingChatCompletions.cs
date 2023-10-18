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
    public class StreamingChatCompletions : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private List<StreamingChatCompletionsUpdate> _cachedUpdates;
        private bool _disposedValue;

        internal StreamingChatCompletions(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
            _cachedUpdates = new();
        }

        internal StreamingChatCompletions(IEnumerable<StreamingChatCompletionsUpdate> updates)
        {
            _cachedUpdates.AddRange(updates);
        }

        public async IAsyncEnumerable<StreamingChatCompletionsUpdate> EnumerateChatUpdates(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (_cachedUpdates.Any())
            {
                foreach (StreamingChatCompletionsUpdate update in _cachedUpdates)
                {
                    yield return update;
                }
                yield break;
            }

            // Open clarification points:
            //  - Is it acceptable (or even desirable) that we won't pump the content stream until enumeration is requested?
            //      - What should happen if the stream is held too long and it times out?
            //  - Should enumeration be concurrency-protected, i.e. possible and correct on two threads concurrently?
            while (!cancellationToken.IsCancellationRequested)
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
                    _cachedUpdates.Add(streamingChatCompletionsUpdate);
                    yield return streamingChatCompletionsUpdate;
                }
            }
            _baseResponse?.ContentStream?.Dispose();
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
