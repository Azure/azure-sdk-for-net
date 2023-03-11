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
        private readonly object _baseCompletionsLock = new object();
        private readonly IList<StreamingChatChoice> _streamingChatChoices;
        private readonly object _streamingChoicesLock = new object();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;
        private bool _streamingTaskComplete;
        private bool _disposedValue;

        /// <summary>
        /// Gets the earliest Completion creation timestamp associated with this streamed response.
        /// </summary>
        public DateTime Created => GetLocked(() => _baseChatCompletions.First().Created);

        /// <summary>
        /// Gets the unique identifier associated with this streaming Completions response.
        /// </summary>
        public string Id => GetLocked(() => _baseChatCompletions.First().Id);

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
                                StreamingChatChoice newStreamingChatChoice = new StreamingChatChoice(chatChoiceFromSse);
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

                _streamingTaskComplete = true;
                _updateAvailableEvent.Set();
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
