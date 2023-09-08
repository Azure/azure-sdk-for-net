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
    public class StreamingChatCompletions : IDisposable
    {
        private readonly Response _baseResponse;
        private readonly SseReader _baseResponseReader;
        private readonly IList<ChatCompletions> _baseChatCompletions;
        private readonly object _baseCompletionsLock = new();
        private readonly IList<StreamingChatChoice> _streamingChatChoices;
        private readonly object _streamingChoicesLock = new();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;
        private bool _streamingTaskComplete;
        private bool _disposedValue;
        private Exception _pumpException;

        /// <summary>
        /// Gets the earliest Completion creation timestamp associated with this streamed response.
        /// </summary>
        public DateTimeOffset Created => GetLocked(() => _baseChatCompletions.Last().Created);

        /// <summary>
        /// Gets the unique identifier associated with this streaming Completions response.
        /// </summary>
        public string Id => GetLocked(() => _baseChatCompletions.Last().Id);

        internal StreamingChatCompletions(Response response)
        {
            _baseResponse = response;
            _baseResponseReader = new SseReader(response.ContentStream);
            _updateAvailableEvent = new AsyncAutoResetEvent();
            _baseChatCompletions = new List<ChatCompletions>();
            _streamingChatChoices = new List<StreamingChatChoice>();
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
                        ChatCompletions chatCompletionsFromSse = ChatCompletions.DeserializeChatCompletions(sseMessageJson.RootElement);

                        lock (_baseCompletionsLock)
                        {
                            _baseChatCompletions.Add(chatCompletionsFromSse);
                        }

                        foreach (ChatChoice chatChoiceFromSse in chatCompletionsFromSse.Choices)
                        {
                            lock (_streamingChoicesLock)
                            {
                                StreamingChatChoice existingStreamingChoice = _streamingChatChoices
                                    .FirstOrDefault(chatChoice => chatChoice.Index == chatChoiceFromSse.Index);
                                if (existingStreamingChoice == null)
                                {
                                    StreamingChatChoice newStreamingChatChoice = new(chatChoiceFromSse);
                                    _streamingChatChoices.Add(newStreamingChatChoice);
                                    _updateAvailableEvent.Set();
                                }
                                else
                                {
                                    existingStreamingChoice.UpdateFromEventStreamChatChoice(chatChoiceFromSse);
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
                        // If anything went wrong and a StreamingChatChoice didn't naturally determine it was complete
                        // based on a non-null finish reason, ensure that nothing's left incomplete (and potentially
                        // hanging!) now.
                        foreach (StreamingChatChoice streamingChatChoice in _streamingChatChoices)
                        {
                            streamingChatChoice.EnsureFinishStreaming(_pumpException);
                        }
                    }
                    _streamingTaskComplete = true;
                    _updateAvailableEvent.Set();
                }
            });
        }

        public async IAsyncEnumerable<StreamingChatChoice> GetChoicesStreaming(
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
                        doneWaiting = _streamingTaskComplete || i < _streamingChatChoices.Count;
                        isFinalIndex = _streamingTaskComplete && i >= _streamingChatChoices.Count - 1;
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

                StreamingChatChoice newChatChoice = null;
                lock (_streamingChoicesLock)
                {
                    if (i < _streamingChatChoices.Count)
                    {
                        newChatChoice = _streamingChatChoices[i];
                    }
                }

                if (newChatChoice != null)
                {
                    yield return newChatChoice;
                }
            }
        }

        internal StreamingChatCompletions(
            ChatCompletions baseChatCompletions = null,
            List<StreamingChatChoice> streamingChatChoices = null)
        {
            _baseChatCompletions.Add(baseChatCompletions);
            _streamingChatChoices = streamingChatChoices;
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
