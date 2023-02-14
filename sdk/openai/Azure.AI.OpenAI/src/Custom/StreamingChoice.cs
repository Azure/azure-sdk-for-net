// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Azure.AI.OpenAI.Custom
{
    public class StreamingChoice
    {
        private readonly IList<Choice> _baseChoices;
        private readonly object _baseChoicesLock = new object();
        private readonly AsyncAutoResetEvent _updateAvailableEvent;

        public int? Index => GetLocked(() => _baseChoices.Last().Index);

        public string FinishReason => GetLocked(() => _baseChoices.Last().FinishReason);

        public CompletionsLogProbability Logprobs => GetLocked(() => _baseChoices.Last().Logprobs);

        internal StreamingChoice(Choice originalBaseChoice)
        {
            _baseChoices = new List<Choice>() { originalBaseChoice };
            _updateAvailableEvent = new AsyncAutoResetEvent();
        }

        internal void UpdateFromEventStreamChoice(Choice streamingChoice)
        {
            lock (_baseChoicesLock)
            {
                _baseChoices.Add(streamingChoice);
            }
            _updateAvailableEvent.Set();
        }

        public async IAsyncEnumerable<string> GetTextStreaming(
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
                        Choice mostRecentChoice = _baseChoices.Last();
                        string mostRecentFinishReason = mostRecentChoice.FinishReason;
                        bool choiceIsComplete = !string.IsNullOrEmpty(mostRecentFinishReason);

                        doneWaiting = choiceIsComplete || i < _baseChoices.Count;
                        isFinalIndex = choiceIsComplete && i == _baseChoices.Count - 1;
                    }

                    if (!doneWaiting)
                    {
                        await _updateAvailableEvent.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                string newText = string.Empty;
                lock (_baseChoicesLock)
                {
                    if (i < _baseChoices.Count)
                    {
                        newText = _baseChoices[i].Text;
                    }
                }

                if (!string.IsNullOrEmpty(newText))
                {
                    yield return newText;
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
