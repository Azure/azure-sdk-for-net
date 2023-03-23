// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Azure.AI.OpenAI
{
    public class StreamingChatChoice
    {
        private readonly IList<ChatChoice> _baseChoices;
        private readonly object _baseChoicesLock = new object();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;

        /// <summary>
        /// Gets the response index associated with this StreamingChoice as represented relative to other Choices
        /// in the same Completions response.
        /// </summary>
        /// <remarks>
        /// Indices may be used to correlate individual Choices within a Completions result to their configured
        /// prompts as provided in the request. As an example, if two Choices are requested for each of four prompts,
        /// the Choices with indices 0 and 1 will correspond to the first prompt, 2 and 3 to the second, and so on.
        /// </remarks>
        public int? Index => GetLocked(() => _baseChoices.Last().Index);

        /// <summary>
        /// Gets a value representing why response generation ended when producing this StreamingChoice.
        /// </summary>
        /// <remarks>
        /// Normal termination typically provides "stop" and encountering token limits in a request typically
        /// provides "length." If no value is present, this StreamingChoice is still in progress.
        /// </remarks>
        public CompletionsFinishReason FinishReason => GetLocked(() => _baseChoices.Last().FinishReason);

        internal ChatMessage StreamingDeltaMessage { get; set; }

        internal bool StreamingDoneSignalReceived
        {
            get => _streamingDoneSignalReceived;
            set
            {
                _streamingDoneSignalReceived = value;
                _updateAvailableEvent.Set();
            }
        }
        private bool _streamingDoneSignalReceived;

        internal StreamingChatChoice(ChatChoice originalBaseChoice)
        {
            _baseChoices = new List<ChatChoice>() { originalBaseChoice };
            _updateAvailableEvent = new AsyncAutoResetEvent();
        }

        internal void UpdateFromEventStreamChatChoice(ChatChoice streamingChatChoice)
        {
            lock (_baseChoicesLock)
            {
                _baseChoices.Add(streamingChatChoice);
            }
            _updateAvailableEvent.Set();
        }

        /// <summary>
        /// Gets an asynchronous enumeration that will retrieve the Completion text associated with this Choice as it
        /// becomes available. Each string will provide one or more tokens, including whitespace, and a full
        /// concatenation of all enumerated strings is functionally equivalent to the single Text property on a
        /// non-streaming Completions Choice.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<ChatMessage> GetMessageStreaming(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            bool isFinalIndex = false;
            for (int i = 0; !isFinalIndex && !cancellationToken.IsCancellationRequested; i++)
            {
                bool doneWaiting = false;
                while (!doneWaiting)
                {
                    lock (_baseChoicesLock)
                    {
                        ChatChoice mostRecentChoice = _baseChoices.Last();
                        bool choiceIsComplete = mostRecentChoice.FinishReason != CompletionsFinishReason.None
                            || StreamingDoneSignalReceived;

                        doneWaiting = choiceIsComplete || i < _baseChoices.Count;
                        isFinalIndex = choiceIsComplete && i >= _baseChoices.Count - 1;
                    }

                    if (!doneWaiting)
                    {
                        await _updateAvailableEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                ChatMessage message = null;

                lock (_baseChoicesLock)
                {
                    if (i < _baseChoices.Count)
                    {
                        message = _baseChoices[i].InternalStreamingDeltaMessage;
                        message.Role = _baseChoices.First().InternalStreamingDeltaMessage.Role;
                    }
                }

                if (message != null)
                {
                    yield return message;
                }
            }
        }

        private T GetLocked<T>(Func<T> func)
        {
            lock (_baseChoicesLock)
            {
                return func.Invoke();
            }
        }
    }
}
