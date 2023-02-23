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
        private static readonly DateTime s_epochStartUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private readonly IList<Completions> _baseCompletions;
        private readonly object _baseCompletionsLock = new object();
        private readonly IList<StreamingChoice> _streamingChoices;
        private readonly object _streamingChoicesLock = new object();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;
        private bool _streamingTaskComplete;
        private bool _disposedValue;

        /// <summary>
        /// Gets the earliest Completion creation timestamp associated with this streamed response.
        /// </summary>
        public DateTime Created
        {
            get
            {
                int baseSecondsAfterEpoch = GetLocked(() => _baseCompletions.First().Created.Value);
                return s_epochStartUtc.AddSeconds(baseSecondsAfterEpoch);
            }
        }

        /// <summary>
        /// Gets the unique identifier associated with this streaming Completions response.
        /// </summary>
        public string Id => GetLocked(() => _baseCompletions.First().Id);

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
                while (true)
                {
                    SseLine? sseEvent = await _baseResponseReader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
                    if (sseEvent == null)
                    {
                        _baseResponse.ContentStream.Dispose();
                        break;
                    }

                    ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
                    if (!name.Span.SequenceEqual("data".AsSpan()))
                        throw new InvalidDataException();

                    ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
                    if (value.Span.SequenceEqual("[DONE]".AsSpan()))
                    {
                        _baseResponse.ContentStream.Dispose();
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
                                StreamingChoice newStreamingChoice = new StreamingChoice(choiceFromSse);
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

                _streamingTaskComplete = true;
                _updateAvailableEvent.Set();
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
                        isFinalIndex = _streamingTaskComplete && i == _streamingChoices.Count - 1;
                    }

                    if (!doneWaiting)
                    {
                        await _updateAvailableEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
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
