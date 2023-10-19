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
    /// Represents a streaming source of <see cref="Completions"/> instances that allow an application to incrementally
    /// use and display text and other information as it becomes available during a generation operation.
    /// </summary>
    public class StreamingCompletions : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private readonly List<Completions> _cachedCompletions;
        private bool _disposedValue;

        /// <summary>
        /// Creates a new instance of <see cref="StreamingCompletions"/> that will generate updates from a
        /// service response stream.
        /// </summary>
        /// <param name="response">
        /// The <see cref="Response"/> instance from which server-sent events will be parsed.
        /// </param>
        internal StreamingCompletions(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
            _cachedCompletions = new();
        }

        /// <summary>
        /// Creates a new instance of <see cref="StreamingCompletions"/> that will yield instances from a provided set
        /// of <see cref="Completions"/> instances. Typically used for tests and mocking.
        /// </summary>
        /// <param name="completions">
        /// An existing set of <see cref="Completions"/> instances to use.
        /// </param>
        internal StreamingCompletions(IEnumerable<Completions> completions)
        {
            _cachedCompletions = new(completions);
        }

        /// <summary>
        /// Returns an asynchronous enumeration of <see cref="Completions"/> instances as they
        /// become available via the associated network response or other data source.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This collection may be iterated over using the "await foreach" statement.
        /// </para>
        /// <para>
        /// Note that, in contrast to <see cref="StreamingChatCompletions"/>, streamed <see cref="Completions"/> share
        /// the same underlying representation and object model as their non-streamed counterpart. The
        /// <see cref="Choice.Text"/> property on a streamed <see cref="Completions"/> instanced will only contain a
        /// small number of new tokens and must be combined with other <see cref="Choice.Text"/> values to represent
        /// a full, reconsistuted message.
        /// </para>
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
        /// An asynchronous enumeration of <see cref="Completions"/> instances.
        /// </returns>
        /// <exception cref="InvalidDataException">
        /// Thrown when an underlying data source provided data in an unsupported format, e.g. server-sent events not
        /// prefixed with the expected 'data:' tag.
        /// </exception>
        public async IAsyncEnumerable<Completions> EnumerateCompletions(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (_cachedCompletions.Any())
            {
                foreach (Completions completions in _cachedCompletions)
                {
                    yield return completions;
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
                Completions sseCompletions = Completions.DeserializeCompletions(sseMessageJson.RootElement);
                _cachedCompletions.Add(sseCompletions);
                yield return sseCompletions;
            }
            _baseResponse?.ContentStream?.Dispose();
        }

        /// <inheritdoc/>
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
                    _baseResponseReader?.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
