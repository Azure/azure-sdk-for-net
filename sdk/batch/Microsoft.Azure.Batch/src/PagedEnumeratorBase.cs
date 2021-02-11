// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using Microsoft.Azure.Batch.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Implementents sync and async enumerator based on async calls to server.
    /// </summary>
    internal abstract class PagedEnumeratorBase<EnumerationType> : IPagedEnumerator<EnumerationType>, IEnumerator<EnumerationType>
    {
        private readonly IPagedEnumerator<EnumerationType> _implInstance; // simplifies complexities around explicit declarations

        // index into current batch
        internal int _currentIndex;

        // current batch of objects returned by last call
        internal object[] _currentBatch;

        // manages the skip token
        private SkipTokenHandler _skipHandler;

#region // constructors

        internal PagedEnumeratorBase()
        {
            _implInstance = this;

            // sets up state variables to trigger first call
            this.Reset();
        }

#endregion // constructors

#region // abstract methods that must be implemented by inheriting class

        // for IPagedEnumerator<T> and IEnumerator<T>
        public abstract EnumerationType Current  { get;}

        protected abstract System.Threading.Tasks.Task GetNextBatchFromServerAsync(SkipTokenHandler skipHandler, CancellationToken cancellationToken); // fetch another batch of objects from the server


#endregion // abstract methods

        object System.Collections.IEnumerator.Current // for IEnumerator
        {
            get
            {
                object cur = _implInstance.Current;

                return cur;
            }
        }

        public bool MoveNext()  // for IEnumerator and IEnumerator<T>
        {
            Task<bool> asyncTask = MoveNextAsync();
            bool result = asyncTask.WaitAndUnaggregateException();

            return result;
        }

        public async Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                // move to next item in current batch
                ++_currentIndex;

                // if the index fits in the current batch,  return true
                if ((null != _currentBatch) && (_currentIndex < _currentBatch.Length)) // we have results in memory, just advance index
                {
                    return true;
                }

                // if we are out of data then return false
                if (_skipHandler.AtLeastOneCallMade && !_skipHandler.ThereIsMoreData)
                {
                    return false;
                }

                // at this point we need to call for more data
                System.Threading.Tasks.Task asyncTask = this.GetNextBatchFromServerAsync(_skipHandler, cancellationToken);

                // wait for it to complete
                await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // if we have new data in cache, serve it up
                if ((null != _currentBatch) && (_currentBatch.Length > 0))
                {
                    _currentIndex = 0;

                    return true;
                }
            }
            catch
            {
                throw; // set breakpoint here
            }

            return false;
        }

        public void Reset()
        {
            Task asyncTask = ResetAsync();
            asyncTask.WaitAndUnaggregateException();
        }

        public Task ResetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            _skipHandler = new SkipTokenHandler();
            _currentIndex = -1;
            _currentBatch = null;
            return Async.CompletedTask;
        }

        // IDisposable
        public void Dispose()
        {
        }
    }

    internal class SkipTokenHandler
    {
        private string _skipToken;
        private bool _hasBeenCalled;

        public bool AtLeastOneCallMade { get { return _hasBeenCalled; } set { _hasBeenCalled = value; } }

        public string SkipToken
        {
            get
            {
                return _skipToken;
            }

            set
            {
                _skipToken = value;
                _hasBeenCalled = true;
            }
        }

        public bool ThereIsMoreData { get { return !string.IsNullOrEmpty(_skipToken); } }
    }
}
