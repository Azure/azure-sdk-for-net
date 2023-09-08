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
        private readonly IList<Completions> _baseCompletions;
        private readonly object _baseCompletionsLock = new();
        private readonly IList<StreamingChoice> _streamingChoices;
        private readonly object _streamingChoicesLock = new();
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
            _baseCompletions = new List<Completions>();
            _streamingChoices = new List<StreamingChoice>();
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
                        Completions completionsFromSse = Completions.DeserializeCompletions(sseMessageJson.RootElement);

                        lock (_baseCompletionsLock)
                        {
                            _baseCompletions.Add(completionsFromSse);
                        }

                        foreach (Choice choiceFromSse in completionsFromSse.Choices)
                        {
                            lock (_streamingChoicesLock)
                            {
                                StreamingChoice existingStreamingChoice = _streamingChoices
                                    .FirstOrDefault(choice => choice.Index == choiceFromSse.Index);
                                if (existingStreamingChoice == null)
                                {
                                    StreamingChoice newStreamingChoice = new(choiceFromSse);
                                    _streamingChoices.Add(newStreamingChoice);
                                    _updateAvailableEvent.Set();
                                }
                                else
                                {
                                    existingStreamingChoice.UpdateFromEventStreamChoice(choiceFromSse);
                                }
                            }
                        }
                    }
                }
                catch (Exception pumpException)
                {
                    _pumpException = pumpException;
                }
                finally
                {
                    lock (_streamingChoicesLock)
                    {
                        // If anything went wrong and a StreamingChoice didn't naturally determine it was complete
                        // based on a non-null finish reason, ensure that nothing's left incomplete (and potentially
                        // hanging!) now.
                        foreach (StreamingChoice streamingChoice in _streamingChoices)
                        {
                            streamingChoice.EnsureFinishStreaming(_pumpException);
                        }
                    }
                    _streamingTaskComplete = true;
                    _updateAvailableEvent.Set();
                }
            });
        }

        public async IAsyncEnumerable<StreamingChoice> GetChoicesStreaming(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            bool isFinalIndex = false;
            for (int i = 0; !isFinalIndex && !cancellationToken.IsCancellationRequested; i++)
            {
                bool doneWaiting = false;
                while (!doneWaiting)
                {
                    lock (_streamingChoicesLock)
                    {
                        doneWaiting = _streamingTaskComplete || i < _streamingChoices.Count;
                        isFinalIndex = _streamingTaskComplete && i >= _streamingChoices.Count - 1;
                    }

                    if (!doneWaiting)
                    {
                        await _updateAvailableEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                if (_pumpException != null)
                {
                    throw _pumpException;
                }

                StreamingChoice newChoice = null;
                lock (_streamingChoicesLock)
                {
                    if (i < _streamingChoices.Count)
                    {
                        newChoice = _streamingChoices[i];
                    }
                }

                if (newChoice != null)
                {
                    yield return newChoice;
                }
            }
        }

        internal StreamingCompletions(
            Completions baseCompletions = null,
            IList<StreamingChoice> streamingChoices = null)
        {
            _baseCompletions.Add(baseCompletions);
            _streamingChoices = streamingChoices;
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
