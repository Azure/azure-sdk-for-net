//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.Properties;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// Handles the execution and retries of the user-initiated task.
    /// </summary>
    /// <typeparam name="TResult">The result type of the user-initiated task.</typeparam>
    internal class AsyncExecution<TResult>
    {
        private readonly Func<Task<TResult>> _taskFunc;
        private readonly ShouldRetry _shouldRetry;
        private readonly Func<Exception, bool> _isTransient;
        private readonly Action<int, Exception, TimeSpan> _onRetrying;
        private readonly bool _fastFirstRetry;
        private readonly CancellationToken _cancellationToken;
        
        private Task<TResult> _previousTask;
        private int _retryCount;

        public AsyncExecution(
            Func<Task<TResult>> taskFunc,
            ShouldRetry shouldRetry,
            Func<Exception, bool> isTransient,
            Action<int, Exception, TimeSpan> onRetrying,
            bool fastFirstRetry,
            CancellationToken cancellationToken)
        {
            this._taskFunc = taskFunc;
            this._shouldRetry = shouldRetry;
            this._isTransient = isTransient;
            this._onRetrying = onRetrying;
            this._fastFirstRetry = fastFirstRetry;
            this._cancellationToken = cancellationToken;
        }

        internal Task<TResult> ExecuteAsync()
        {
            return this.ExecuteAsyncImpl(null);
        }

        private Task<TResult> ExecuteAsyncImpl(Task ignore)
        {
            if (this._cancellationToken.IsCancellationRequested)
            {
                // if retry was canceled before retrying after a failure, return the failed task.
                if (this._previousTask != null)
                {
                    return this._previousTask;
                }
                else
                {
                    var tcs = new TaskCompletionSource<TResult>();
                    tcs.TrySetCanceled();
                    return tcs.Task;
                }
            }

            // This is a little different from ExecuteAction using APM. If an exception occurs synchronously when
            // starting the task, then the exception is checked for transient errors and if the exception is not
            // transient, it will bubble up synchronously. Otherwise it will be retried. The reason for bubbling up
            // synchronously -instead of returning a failed task- is that TAP design guidelines dictate that task 
            // creation should only fail synchronously in response to a usage error, which can be avoided by changing 
            // the code that calls the method, and hence should not be considered transient. Nevertheless, as this is
            // a general purpose transient error detection library, we cannot guarantee that other libraries or user
            // code will follow the design guidelines.
            Task<TResult> task;
            try
            {
                task = this._taskFunc.Invoke();
            }
            catch (Exception ex)
            {
                if (this._isTransient(ex))
                {
                    var tcs = new TaskCompletionSource<TResult>();
                    tcs.TrySetException(ex);
                    task = tcs.Task;
                }
                else
                {
                    throw;
                }
            }

            if (task == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, Resources.TaskCannotBeNull, "taskFunc"),
                    "taskFunc");
            }

            // Fast path if the user-initiated task is already completed.
            if (task.Status == TaskStatus.RanToCompletion)
            {
                return task;
            }

            if (task.Status == TaskStatus.Created)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, Resources.TaskMustBeScheduled, "taskFunc"),
                    "taskFunc");
            }

            return task
                .ContinueWith<Task<TResult>>(this.ExecuteAsyncContinueWith, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default)
                .Unwrap();
        }

        private Task<TResult> ExecuteAsyncContinueWith(Task<TResult> runningTask)
        {
            if (!runningTask.IsFaulted || this._cancellationToken.IsCancellationRequested)
            {
                return runningTask;
            }

            TimeSpan delay = TimeSpan.Zero;
            // should assert that it contain only 1 exception?
            Exception lastError = runningTask.Exception.InnerException;

#pragma warning disable 0618
            if (lastError is RetryLimitExceededException)
#pragma warning restore 0618
            {
                // This is here for backwards compatibility only. The correct way to force a stop is by using cancelation tokens.
                // The user code can throw a RetryLimitExceededException to force the exit from the retry loop.
                // The RetryLimitExceeded exception can have an inner exception attached to it. This is the exception
                // which we will have to throw up the stack so that callers can handle it.
                var tcs = new TaskCompletionSource<TResult>();
                if (lastError.InnerException != null)
                {
                    tcs.TrySetException(lastError.InnerException);
                }
                else
                {
                    tcs.TrySetCanceled();
                }

                return tcs.Task;
            }

            if (!(this._isTransient(lastError) && this._shouldRetry(this._retryCount++, lastError, out delay)))
            {
                // if not transient, return the faulted running task.
                return runningTask;
            }

            // Perform an extra check in the delay interval.
            if (delay < TimeSpan.Zero)
            {
                delay = TimeSpan.Zero;
            }

            this._onRetrying(this._retryCount, lastError, delay);

            this._previousTask = runningTask;
            if (delay > TimeSpan.Zero && (this._retryCount > 1 || !this._fastFirstRetry))
            {
                return TaskEx.Delay(delay)
                    .ContinueWith<Task<TResult>>(this.ExecuteAsyncImpl, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default)
                    .Unwrap();
            }

            return this.ExecuteAsyncImpl(null);
        }
    }

    /// <summary>
    /// Provides a wrapper for a non-generic <see cref="Task"/> and calls into the pipeline
    /// to retry only the generic version of the <see cref="Task"/>.
    /// </summary>
    internal class AsyncExecution : AsyncExecution<bool>
    {
        private static Task<bool> cachedBoolTask;

        public AsyncExecution(
            Func<Task> taskAction,
            ShouldRetry shouldRetry,
            Func<Exception, bool> isTransient,
            Action<int, Exception, TimeSpan> onRetrying,
            bool fastFirstRetry,
            CancellationToken cancellationToken)
            : base(() => StartAsGenericTask(taskAction), shouldRetry, isTransient, onRetrying, fastFirstRetry, cancellationToken)
        {
        }

        /// <summary>
        /// Wraps the non-generic <see cref="Task"/> into a generic <see cref="Task"/>.
        /// </summary>
        /// <param name="taskAction">The task to wrap.</param>
        /// <returns>A <see cref="Task"/> that wraps the non-generic <see cref="Task"/>.</returns>
        private static Task<bool> StartAsGenericTask(Func<Task> taskAction)
        {
            var task = taskAction.Invoke();
            if (task == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, Resources.TaskCannotBeNull, "taskAction"),
                    "taskAction");
            }

            if (task.Status == TaskStatus.RanToCompletion)
            {
                // Fast path if the user-initiated task is already completed.
                return GetCachedTask();
            }

            if (task.Status == TaskStatus.Created)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, Resources.TaskMustBeScheduled, "taskAction"),
                    "taskAction");
            }

            var tcs = new TaskCompletionSource<bool>();
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    tcs.TrySetException(t.Exception.InnerExceptions);
                }
                else if (t.IsCanceled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(true);
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
            return tcs.Task;
        }

        private static Task<bool> GetCachedTask()
        {
            if (cachedBoolTask == null)
            {
                var tcs = new TaskCompletionSource<bool>();
                tcs.TrySetResult(true);
                cachedBoolTask = tcs.Task;
            }

            return cachedBoolTask;
        }
    }
}
