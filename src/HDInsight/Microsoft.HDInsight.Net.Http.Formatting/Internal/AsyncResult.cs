// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Internal
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "_manualResetEvent is disposed in End<TAsyncResult>")]
    internal abstract class AsyncResult : IAsyncResult
    {
        private AsyncCallback _callback;
        private object _state;

        private bool _isCompleted;
        private bool _completedSynchronously;
        private bool _endCalled;

        private Exception _exception;

        protected AsyncResult(AsyncCallback callback, object state)
        {
            this._callback = callback;
            this._state = state;
        }

        public object AsyncState
        {
            get { return this._state; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                Contract.Assert(false, "AsyncWaitHandle is not supported -- use callbacks instead.");
                return null;
            }
        }

        public bool CompletedSynchronously
        {
            get { return this._completedSynchronously; }
        }

        public bool HasCallback
        {
            get { return this._callback != null; }
        }

        public bool IsCompleted
        {
            get { return this._isCompleted; }
        }

        protected void Complete(bool completedSynchronously)
        {
            if (this._isCompleted)
            {
                throw Error.InvalidOperation(Resources.AsyncResult_MultipleCompletes, this.GetType().Name);
            }

            this._completedSynchronously = completedSynchronously;
            this._isCompleted = true;

            if (this._callback != null)
            {
                try
                {
                    this._callback(this);
                }
                catch (Exception e)
                {
                    throw Error.InvalidOperation(e, Resources.AsyncResult_CallbackThrewException);
                }
            }
        }

        protected void Complete(bool completedSynchronously, Exception exception)
        {
            this._exception = exception;
            this.Complete(completedSynchronously);
        }

        protected static TAsyncResult End<TAsyncResult>(IAsyncResult result) where TAsyncResult : AsyncResult
        {
            if (result == null)
            {
                throw Error.ArgumentNull("result");
            }

            TAsyncResult thisPtr = result as TAsyncResult;

            if (thisPtr == null)
            {
                throw Error.Argument("result", Resources.AsyncResult_ResultMismatch);
            }

            if (!thisPtr._isCompleted)
            {
                thisPtr.AsyncWaitHandle.WaitOne();
            }

            if (thisPtr._endCalled)
            {
                throw Error.InvalidOperation(Resources.AsyncResult_MultipleEnds);
            }

            thisPtr._endCalled = true;

            if (thisPtr._exception != null)
            {
                throw thisPtr._exception;
            }

            return thisPtr;
        }
    }
}
