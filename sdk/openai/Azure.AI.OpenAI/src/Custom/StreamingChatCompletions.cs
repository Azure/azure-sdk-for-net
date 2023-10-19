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
    /// <summary>
    /// Represents a streaming source of <see cref="StreamingChatCompletionsUpdate"/> instances that allow an
    /// application to incrementally use and display text and other information as it becomes available during a
    /// generation operation.
    /// </summary>
    public class StreamingChatCompletions : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private readonly List<StreamingChatCompletionsUpdate> _cachedUpdates;
        private bool _disposedValue;

        /// <summary>
        /// Creates a new instance of <see cref="StreamingChatCompletions"/> based on a REST response stream.
        /// </summary>
        /// <param name="response">
        /// The <see cref="Response"/> from which server-sent events will be consumed.
        /// </param>
        internal StreamingChatCompletions(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
            _cachedUpdates = new();
        }

        /// <summary>
        /// Creates a new instance of <see cref="StreamingChatCompletions"/> based on an existing set of
        /// <see cref="StreamingChatCompletionsUpdate"/> instances. Typically used for tests or mocking.
        /// </summary>
        /// <param name="updates">
        /// An existing collection of <see cref="StreamingChatCompletionsUpdate"/> instances to use. Update enumeration
        /// will yield these instances instead of instances derived from a response stream.
        /// </param>
        internal StreamingChatCompletions(IEnumerable<StreamingChatCompletionsUpdate> updates)
        {
            _cachedUpdates = new(updates);
        }

        /// <summary>
        /// Returns an asynchronous enumeration of <see cref="StreamingChatCompletionsUpdate"/> instances as they
        /// become available via the associated network response or other data source.
        /// </summary>
        /// <remarks>
        /// This collection may be iterated over using the "await foreach" statement.
        /// </remarks>
        /// <param name="cancellationToken">
        /// <para>
        /// An optional <see cref="CancellationToken"/> used to end enumeration before it would normally complete.
        /// </para>
        /// <para>
        /// Cancellation will immediately close any underlying network response stream and may consequently limit
        /// incurred token generation and associated cost.
        /// </para>
        /// </param>
        /// <returns>
        /// An asynchronous enumeration of <see cref="StreamingChatCompletionsUpdate"/> instances.
        /// </returns>
        /// <exception cref="InvalidDataException">
        /// Thrown when an underlying data source provided data in an unsupported format, e.g. server-sent events not
        /// prefixed with the expected 'data:' tag.
        /// </exception>
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
                    _baseResponse?.ContentStream?.Dispose();
                    break;
                }

                ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
                if (!name.Span.SequenceEqual("data".AsSpan()))
                    throw new InvalidDataException();

                ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
                if (value.Span.SequenceEqual("[DONE]".AsSpan()))
                {
                    _baseResponse?.ContentStream?.Dispose();
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

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _baseResponseReader?.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
