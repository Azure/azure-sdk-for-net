//-----------------------------------------------------------------------
// <copyright file="TaskImplHelper.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the TaskImplHelper.cs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Diagnostics;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Implementation helper for task sequences.
    /// </summary>
    internal static class TaskImplHelper
    {
        /// <summary>
        /// Executes the impl.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="impl">The task implementation.</param>
        /// <returns>The result of the task.</returns>
        [DebuggerNonUserCode]
        internal static T ExecuteImpl<T>(Func<Action<T>, TaskSequence> impl)
        {
            CommonUtils.AssertNotNull("impl", impl);

            var invokerTask = new InvokeTaskSequenceTask<T>(impl);
            return invokerTask.ExecuteAndWait();
        }

        /// <summary>
        /// Begins the impl.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="impl">The task implementation.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>An asynchronous result representing the operation.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult BeginImpl<T>(Func<Action<T>, TaskSequence> impl, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("impl", impl);
            
            var invokerTask = new InvokeTaskSequenceTask<T>(impl);
            return invokerTask.ToAsyncResult(callback, state);
        }

        /// <summary>
        /// Ends the impl.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="asyncResult">The async result.</param>
        /// <returns>The task result.</returns>
        [DebuggerNonUserCode]
        internal static T EndImpl<T>(IAsyncResult asyncResult)
        {
            TaskAsyncResult<T> task = GetTaskFromAsyncResult<T>(asyncResult);
            var result = task.EndInvoke();
            task.Dispose();
            return result;
        }

        /// <summary>
        /// Executes the impl.
        /// </summary>
        /// <param name="impl">The task implemenetaion.</param>
        [DebuggerNonUserCode]
        internal static void ExecuteImpl(Func<TaskSequence> impl)
        {
            CommonUtils.AssertNotNull("impl", impl);
            
            InvokeTaskSequenceTask invokerTask = new InvokeTaskSequenceTask(impl);
            invokerTask.ExecuteAndWait();
        }

        /// <summary>
        /// Begins the impl.
        /// </summary>
        /// <param name="impl">The task implementation.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>An asynchronous result representing the operation.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult BeginImpl(Func<TaskSequence> impl, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("impl", impl);
            
            var invokerTask = new InvokeTaskSequenceTask(impl);
            return invokerTask.ToAsyncResult(callback, state);
        }

        /// <summary>
        /// Ends the impl.
        /// </summary>
        /// <param name="asyncResult">The async result.</param>
        [DebuggerNonUserCode]
        internal static void EndImpl(IAsyncResult asyncResult)
        {
            TaskAsyncResult<NullTaskReturn> task = GetTaskFromAsyncResult<NullTaskReturn>(asyncResult);
            task.EndInvoke();
            task.Dispose();
        }

        /// <summary>
        /// Executes the impl with retry.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>The task result.</returns>
        [DebuggerNonUserCode]
        internal static T ExecuteImplWithRetry<T>(Func<Action<T>, TaskSequence> impl, RetryPolicy policy)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            var retryableTask = GetRetryableAsyncTask(impl, policy);
            return retryableTask.ExecuteAndWait();
        }

        /// <summary>
        /// Begins the impl with retry.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>An asynchronous result representing the operation.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult BeginImplWithRetry<T>(Func<Action<T>, TaskSequence> impl, RetryPolicy policy, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            var retryableTask = GetRetryableAsyncTask(impl, policy);
            return retryableTask.ToAsyncResult(callback, state);
        }

        /// <summary>
        /// Ends the impl with retry.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="asyncResult">The async result.</param>
        /// <returns>The task result.</returns>
        [DebuggerNonUserCode]
        internal static T EndImplWithRetry<T>(IAsyncResult asyncResult)
        {
            return EndImpl<T>(asyncResult);
        }

        /// <summary>
        /// Executes the impl with retry.
        /// </summary>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        [DebuggerNonUserCode]
        internal static void ExecuteImplWithRetry(Func<TaskSequence> impl, RetryPolicy policy)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            var retryableTask = GetRetryableAsyncTask(impl, policy);
            retryableTask.ExecuteAndWait();
        }

        /// <summary>
        /// Executes the impl with retry.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="syncTask">The task implementation.</param>
        /// <returns>The task result.</returns>
        [DebuggerNonUserCode]
        internal static TResult ExecuteSyncTask<TResult>(SynchronousTask<TResult> syncTask)
        {
            CommonUtils.AssertNotNull("syncTask", syncTask);

            return syncTask.Execute();
        }

        /// <summary>
        /// Executes the impl with retry.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="syncTask">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>The task result.</returns>
        [DebuggerNonUserCode]
        internal static TResult ExecuteSyncTaskWithRetry<TResult>(SynchronousTask<TResult> syncTask, RetryPolicy policy)
        {
            CommonUtils.AssertNotNull("syncTask", syncTask);
            CommonUtils.AssertNotNull("policy", policy);
            var oracle = policy();

            return RequestWithRetry.RequestWithRetrySyncImpl<TResult>(oracle, syncTask);
        }

        /// <summary>
        /// Begins the impl with retry.
        /// </summary>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>An asynchronous result representing the operation.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult BeginImplWithRetry(Func<TaskSequence> impl, RetryPolicy policy, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            var retryableTask = GetRetryableAsyncTask(impl, policy);
            return retryableTask.ToAsyncResult(callback, state);
        }

        /// <summary>
        /// Ends the impl with retry.
        /// </summary>
        /// <param name="asyncResult">The async result.</param>
        [DebuggerNonUserCode]
        internal static void EndImplWithRetry(IAsyncResult asyncResult)
        {
            EndImpl(asyncResult);
        }

        /// <summary>
        /// Gets the retryable async task.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>The retryable task.</returns>
        [DebuggerNonUserCode]
        internal static Task<T> GetRetryableAsyncTask<T>(Func<Action<T>, TaskSequence> impl, RetryPolicy policy)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            ShouldRetry oracle = policy(); 

            InvokeTaskSequenceTask<T> retryableTask = new InvokeTaskSequenceTask<T>(
                (setResult) => RequestWithRetry.RequestWithRetryImpl<T>(oracle, impl, setResult));

            return retryableTask;
        }

        /// <summary>
        /// Gets the retryable async task.
        /// </summary>
        /// <param name="impl">The task implementation.</param>
        /// <param name="policy">The policy.</param>
        /// <returns>The retryable task.</returns>
        [DebuggerNonUserCode]
        internal static Task<NullTaskReturn> GetRetryableAsyncTask(Func<TaskSequence> impl, RetryPolicy policy)
        {
            CommonUtils.AssertNotNull("impl", impl);
            CommonUtils.AssertNotNull("policy", policy);
            
            ShouldRetry oracle = policy();

            InvokeTaskSequenceTask retryableTask = new InvokeTaskSequenceTask(
                () => RequestWithRetry.RequestWithRetryImpl<NullTaskReturn>(
                    oracle,
                    (setResult) => impl(),
                    (scratch) =>
                        {
                        }));

            return retryableTask;
        }

        /// <summary>
        /// Gets the task from async result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="asyncResult">The async result.</param>
        /// <returns>The asynchronous result.</returns>
        [DebuggerNonUserCode]
        private static TaskAsyncResult<T> GetTaskFromAsyncResult<T>(IAsyncResult asyncResult)
        {
            CommonUtils.AssertNotNull("asyncResult", asyncResult);

            var task = asyncResult as TaskAsyncResult<T>;

            if (task == null)
            {
                throw new ArgumentException("invalid asyncresult");
            }

            return task;
        } 
    }
}
