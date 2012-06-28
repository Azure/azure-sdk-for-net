//-----------------------------------------------------------------------
// <copyright file="RequestWithRetry.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//    Contains code for the RequestWithRetry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Data.Services.Client;
    using System.Net;
    using System.Threading;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;
    
    /// <summary>
    /// Utility functions that does the heavy lifting of carrying out retries on a IRetrayableRequest.
    /// </summary>
    /// <remarks>
    /// Both synchrous and asynchrous request styles are supported.
    /// They are used to implement the corresponding XXX, BeginXXX, EndXXX calls where XXX
    /// is something like GetBlobInfo.
    /// State passing for return value in the sync call (GetBlobInfo) and out parameters for the async calls
    /// (EndBlobInfo) is achieved by member variables in the implementation class of IRetryableRequest.
    /// </remarks>
    internal static class RequestWithRetry
    {
        /// <summary>
        /// Synchronouses the request with retry.
        /// </summary>
        /// <typeparam name="T">The result type of the task.</typeparam>
        /// <param name="oracle">The oracle to use.</param>
        /// <param name="impl">The task implementation.</param>
        /// <returns>The result of the task.</returns>
        internal static T SynchronousRequestWithRetry<T>(ShouldRetry oracle, Func<Action<T>, TaskSequence> impl)
        {
            return TaskImplHelper.ExecuteImpl<T>((setResult) => RequestWithRetryImpl<T>(oracle, impl, setResult));
        }

        /// <summary>
        /// Begins the asynchronous request with retry.
        /// </summary>
        /// <typeparam name="T">The result type of the task.</typeparam>
        /// <param name="oracle">The oracle to use.</param>
        /// <param name="impl">The task implementation.</param>
        /// <param name="callback">The asynchronous callback.</param>
        /// <param name="state">The asynchronous state.</param>
        /// <returns>An <see cref="IAsyncResult"/> that represents the asynchronous operation.</returns>
        internal static IAsyncResult BeginAsynchronousRequestWithRetry<T>(
            ShouldRetry oracle,
            Func<Action<T>, TaskSequence> impl,
            AsyncCallback callback,
            object state)
        {
            return TaskImplHelper.BeginImpl<T>((setResult) => RequestWithRetryImpl<T>(oracle, impl, setResult), callback, state);
        }

        /// <summary>
        /// Ends the asynchronous request with retry.
        /// </summary>
        /// <typeparam name="T">The result type of the task.</typeparam>
        /// <param name="asyncResult">The asynchronous result.</param>
        /// <returns>The result of the completed task.</returns>
        internal static T EndAsynchronousRequestWithRetry<T>(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<T>(asyncResult);
        }

        /// <summary>
        /// Implementation of the *RequestWithRetry methods.
        /// </summary>
        /// <typeparam name="T">The result type of the task.</typeparam>
        /// <param name="retryOracle">The retry oracle.</param>
        /// <param name="impl">The task implementation.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that performs the request with retries.</returns>
        internal static TaskSequence RequestWithRetryImpl<T>(ShouldRetry retryOracle, Func<Action<T>, TaskSequence> impl, Action<T> setResult)
        {
            int retryCount = 0;
            bool succeeded = false;
            bool shouldRetry = false;
            do
            {
                var task = new InvokeTaskSequenceTask<T>(impl);
                yield return task;
                
                TimeSpan delay = TimeSpan.FromMilliseconds(-1);

                try
                {
                    var result = task.Result;
                    succeeded = true;
                    setResult(result);
                }
                catch (TimeoutException e)
                {
                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }
                catch (StorageServerException e)
                {
                    if (e.StatusCode == HttpStatusCode.NotImplemented || e.StatusCode == HttpStatusCode.HttpVersionNotSupported)
                    {
                        throw;
                    }

                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }
                catch (InvalidOperationException e)
                {
                    DataServiceClientException dsce = CommonUtils.FindInnerDataServiceClientException(e);

                    // rethrow 400 class errors immediately as they can't be retried
                    // 501 (Not Implemented) and 505 (HTTP Version Not Supported) shouldn't be retried either.
                    if (dsce != null &&
                        ((dsce.StatusCode >= 400 && dsce.StatusCode < 500)
                          || dsce.StatusCode == (int)HttpStatusCode.NotImplemented
                          || dsce.StatusCode == (int)HttpStatusCode.HttpVersionNotSupported))
                    {
                        throw;
                    }

                    // If it is BlobTypeMismatchExceptionMessage, we should throw without retry
                    if (e.Message == SR.BlobTypeMismatchExceptionMessage)
                    {
                        throw;
                    }

                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }

                if (!succeeded && shouldRetry && delay > TimeSpan.Zero)
                {
                    using (DelayTask delayTask = new DelayTask(delay))
                    {
                        yield return delayTask;

                        // Materialize exceptions
                        var scratch = delayTask.Result;
                    }
                }
            }
            while (!succeeded && shouldRetry);
        }

        /// <summary>
        /// Implementation of the *RequestWithRetry methods.
        /// </summary>
        /// <typeparam name="TResult">The result type of the task.</typeparam>
        /// <param name="retryOracle">The retry oracle.</param>
        /// <param name="syncTask">The task implementation.</param>
        /// <returns>A <see cref="TaskSequence"/> that performs the request with retries.</returns>
        internal static TResult RequestWithRetrySyncImpl<TResult>(ShouldRetry retryOracle, SynchronousTask<TResult> syncTask)
        {
            int retryCount = 0;
            bool shouldRetry = false;

            do
            {
                TimeSpan delay = TimeSpan.FromMilliseconds(-1);

                try
                {
                    return syncTask.Execute();
                }
                catch (TimeoutException e)
                {
                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }
                catch (StorageServerException e)
                {
                    if (e.StatusCode == HttpStatusCode.NotImplemented || e.StatusCode == HttpStatusCode.HttpVersionNotSupported)
                    {
                        throw;
                    }

                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }
                catch (InvalidOperationException e)
                {
                    DataServiceClientException dsce = CommonUtils.FindInnerDataServiceClientException(e);

                    // rethrow 400 class errors immediately as they can't be retried
                    // 501 (Not Implemented) and 505 (HTTP Version Not Supported) shouldn't be retried either.
                    if (dsce != null &&
                        ((dsce.StatusCode >= 400 && dsce.StatusCode < 500)
                          || dsce.StatusCode == (int)HttpStatusCode.NotImplemented
                          || dsce.StatusCode == (int)HttpStatusCode.HttpVersionNotSupported))
                    {
                        throw;
                    }

                    // If it is BlobTypeMismatchExceptionMessage, we should throw without retry
                    if (e.Message == SR.BlobTypeMismatchExceptionMessage)
                    {
                        throw;
                    }

                    shouldRetry = retryOracle != null ? retryOracle(retryCount++, e, out delay) : false;

                    // We should just throw out the exception if we are not retrying
                    if (!shouldRetry)
                    {
                        throw;
                    }
                }

                if (shouldRetry && delay > TimeSpan.Zero)
                {
                    Thread.Sleep(delay);
                }
            }
            while (shouldRetry);

            throw new StorageClientException(
                StorageErrorCode.None,
                "Unexpected internal storage client error.",
                System.Net.HttpStatusCode.Unused,
                null,
                null)
            {
                HelpLink = "http://go.microsoft.com/fwlink/?LinkID=182765"
            };
        }
    }
}
