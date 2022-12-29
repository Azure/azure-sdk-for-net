// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    internal class MultipleTimesTaskCompletionSource<T>
    {
        private readonly List<TaskCompletionSource<T>> _cts = new List<TaskCompletionSource<T>>();
        private readonly TaskCompletionSource<T> _noMoreCallsTcs = new TaskCompletionSource<T>();
        private readonly object _resetLock = new object();
        private int _currentTimes = 0;
        private volatile bool _isVerifyNoMoreCalls = false;

        public MultipleTimesTaskCompletionSource(int totalTimes)
        {
            _cts.Add(null);
            for (var i = 0; i < totalTimes; i++)
            {
                _cts.Add(new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously));
            }

            Debug.Assert(_cts.Count == totalTimes + 1);
        }

        public Task<T> VerifyCalledTimesAsync(int times)
        {
            return _cts[times].Task;
        }

        public void IncreaseCallTimes(T obj = default)
        {
            lock (_resetLock)
            {
                _currentTimes++;

                if (_currentTimes < _cts.Count)
                {
                    _cts[_currentTimes].TrySetResult(obj);
                }

                if (_isVerifyNoMoreCalls)
                {
                    _noMoreCallsTcs.TrySetResult(obj);
                }
            }
        }

        public void AssertNoMoreCalls()
        {
            _isVerifyNoMoreCalls = true;
            TestUtils.AssertTimeout(_noMoreCallsTcs.Task);
        }

        public void Reset()
        {
            lock (_resetLock)
            {
                for (var i = 0; i < _cts.Count; i++)
                {
                    _cts[i] = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
                }
                _currentTimes = 0;
            }
        }
    }
}
