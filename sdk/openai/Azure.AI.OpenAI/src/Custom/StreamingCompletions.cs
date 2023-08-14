// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Sse;

namespace Azure.AI.OpenAI
{
    public class StreamingCompletions : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private readonly IList<CompletionsChunk> _baseCompletions;
        private readonly object _baseCompletionsLock = new();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;
        private bool _streamingTaskComplete;
        private bool _disposedValue;
        private Exception _pumpException;

        /// <summary>
        /// Gets the earliest Completion creation timestamp associated with this streamed response.
        /// </summary>
        public DateTimeOffset Created => GetLocked(() => _baseCompletions.Last().Created);

        /// <summary>
        /// Gets the unique identifier associated with this streaming Completions response.
        /// </summary>
        public string Id => GetLocked(() => _baseCompletions.Last().Id);

        internal StreamingCompletions(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
            _updateAvailableEvent = new AsyncAutoResetEvent();
            _baseCompletions = new List<CompletionsChunk>();
            _streamingTaskComplete = false;
            _ = Task.Run(async () =>
            {
                try
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
                        CompletionsChunk completionsFromSse = CompletionsChunk.DeserializeCompletionsChunk(sseMessageJson.RootElement);

                        lock (_baseCompletionsLock)
                        {
                            _baseCompletions.Add(completionsFromSse);
                            _updateAvailableEvent.Set();
                        }
                    }
                }
                catch (Exception pumpException)
                {
                    _pumpException = pumpException;
                }
                finally
                {
                    _streamingTaskComplete = true;
                    _updateAvailableEvent.Set();
                }
            });
        }

        public async IAsyncEnumerable<CompletionsChunk> GetCompletionsChunks(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            bool isFinalIndex = false;
            for (int i = 0; !isFinalIndex && !cancellationToken.IsCancellationRequested; i++)
            {
                if (_pumpException != null)
                {
                    throw _pumpException;
                }

                bool doneWaiting = false;
                while (!doneWaiting)
                {
                    lock (_baseCompletionsLock)
                    {
                        doneWaiting = _streamingTaskComplete || i < _baseCompletions.Count;
                        isFinalIndex = _streamingTaskComplete && i >= _baseCompletions.Count - 1;
                    }

                    if (!doneWaiting)
                    {
                        await _updateAvailableEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                CompletionsChunk newChunk = null;
                lock (_baseCompletionsLock)
                {
                    if (i < _baseCompletions.Count)
                    {
                        newChunk = _baseCompletions[i];
                    }
                }

                if (newChunk != null)
                {
                    yield return newChunk;
                }
            }
        }

        internal StreamingCompletions(
            CompletionsChunk chunk = null)
        {
            _baseCompletions.Add(chunk);
            _streamingTaskComplete = true;
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

        private T GetLocked<T>(Func<T> func)
        {
            lock (_baseCompletionsLock)
            {
                return func.Invoke();
            }
        }
    }
}
