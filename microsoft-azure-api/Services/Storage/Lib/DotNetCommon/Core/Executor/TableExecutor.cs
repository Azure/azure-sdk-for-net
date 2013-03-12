//-----------------------------------------------------------------------
// <copyright file="TableExecutor.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Executor
{
    using System;
    using System.Net;
    using System.Threading;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table;
    using Microsoft.WindowsAzure.Storage.Table.DataServices;

    internal class TableExecutor : ExecutorBase
    {
        #region Async

        #region Begin / End
        // Cancellation is handeld by TableServiceContext
        public static ICancellableAsyncResult BeginExecuteAsync<T, INTERMEDIATE_TYPE>(TableCommand<T, INTERMEDIATE_TYPE> cmd, IRetryPolicy policy, OperationContext operationContext, AsyncCallback callback, object asyncState)
        {
            // Note all code below will reference state, not params directly, this will allow common code with async executor
            ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext, callback, asyncState);
            TableExecutor.AcquireContext(cmd.Context, executionState);
            InitRequest<T, INTERMEDIATE_TYPE>(executionState);
            return executionState;
        }

        public static T EndExecuteAsync<T, INTERMEDIATE_TYPE>(IAsyncResult result)
        {
            ExecutionState<T> executionState = result as ExecutionState<T>;

            CommonUtils.AssertNotNull("result", executionState);

            executionState.End();

            TableCommand<T, INTERMEDIATE_TYPE> tableCommandRef = executionState.Cmd as TableCommand<T, INTERMEDIATE_TYPE>;
            ReleaseContext(tableCommandRef.Context);

            if (executionState.ExceptionRef != null)
            {
                throw executionState.ExceptionRef;
            }

            return executionState.Result;
        }

        #endregion

        #region Setup Request
        public static void InitRequest<T, INTERMEDIATE_TYPE>(ExecutionState<T> executionState)
        {
            try
            {
                executionState.Init();

                // 0. Begin Request 
                TableExecutor.StartRequestAttempt(executionState);

                if (TableExecutor.CheckTimeout<T>(executionState, false))
                {
                    TableExecutor.EndOperation<T, INTERMEDIATE_TYPE>(executionState);
                    return;
                }

                lock (executionState.CancellationLockerObject)
                {
                    if (TableExecutor.CheckCancellation(executionState))
                    {
                        TableExecutor.EndOperation<T, INTERMEDIATE_TYPE>(executionState);
                        return;
                    }

                    TableCommand<T, INTERMEDIATE_TYPE> tableCommandRef = executionState.Cmd as TableCommand<T, INTERMEDIATE_TYPE>;

                    // Execute Call
                    tableCommandRef.Begin(
                        (res) =>
                        {
                            executionState.UpdateCompletedSynchronously(res.CompletedSynchronously);
                            INTERMEDIATE_TYPE tResult = default(INTERMEDIATE_TYPE);

                            try
                            {
                                tResult = tableCommandRef.End(res);

                                executionState.Result = tableCommandRef.ParseResponse(tResult, executionState.Cmd.CurrentResult, tableCommandRef);

                                // Attempt to populate response headers
                                if (executionState.Req != null)
                                {
                                    executionState.Resp = GetResponseForRequest(executionState.Req);
                                    FireResponseReceived(executionState);
                                }
                            }
                            catch (Exception ex)
                            {
                                lock (executionState.CancellationLockerObject)
                                {
                                    if (executionState.CancelRequested)
                                    {
                                        // Ignore DSC exception if request was canceled.
                                        return;
                                    }
                                }

                                // Store exception and invoke callback here. All operations in this try would be non-retryable by default
                                if (executionState.ExceptionRef == null || !(executionState.ExceptionRef is StorageException))
                                {
                                    executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                                }

                                try
                                {
                                    // Attempt to populate response headers
                                    if (executionState.Req != null)
                                    {
                                        executionState.Resp = GetResponseForRequest(executionState.Req);
                                        FireResponseReceived(executionState);
                                    }

                                    executionState.Result = tableCommandRef.ParseResponse(tResult, executionState.Cmd.CurrentResult, tableCommandRef);

                                    // clear exception
                                    executionState.ExceptionRef = null;
                                }
                                catch (Exception parseEx)
                                {
                                    executionState.ExceptionRef = parseEx;
                                }
                            }
                            finally
                            {
                                EndOperation<T, INTERMEDIATE_TYPE>(executionState);
                            }
                        },
                        null);

                    if (tableCommandRef.Context != null)
                    {
                        executionState.CancelDelegate = tableCommandRef.Context.InternalCancel;
                    }
                }
            }
            catch (Exception ex)
            {
                // Store exception and invoke callback here. All operations in this try would be non-retryable by default
                if (executionState.ExceptionRef == null || !(executionState.ExceptionRef is StorageException))
                {
                    executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                }

                executionState.OnComplete();
            }
        }
        #endregion

        #region Parse Response
        private static void EndOperation<T, INTERMEDIATE_TYPE>(ExecutionState<T> executionState)
        {
            TableCommand<T, INTERMEDIATE_TYPE> tableCommandRef = executionState.Cmd as TableCommand<T, INTERMEDIATE_TYPE>;
            
            TableExecutor.FinishRequestAttempt(executionState);

            lock (executionState.CancellationLockerObject)
            {
                executionState.CancelDelegate = null;

                TableExecutor.CheckCancellation(executionState);

                // Handle Success
                if (executionState.ExceptionRef == null)
                {
                    // Signal event handled and mark response
                    executionState.OnComplete();
                    return;
                }
            }

            // Handle Retry
            try
            {
                StorageException translatedException = StorageException.TranslateException(executionState.ExceptionRef, executionState.Cmd.CurrentResult);
                executionState.ExceptionRef = translatedException;

                TimeSpan delay = TimeSpan.FromMilliseconds(0);
                bool shouldRetry = translatedException.IsRetryable &&
                                   executionState.RetryPolicy != null ?
                                        executionState.RetryPolicy.ShouldRetry(
                                                                        executionState.RetryCount++,
                                                                        executionState.Cmd.CurrentResult.HttpStatusCode,
                                                                        executionState.ExceptionRef,
                                                                        out delay,
                                                                        executionState.OperationContext)
                                        : false;
                
                delay = delay.TotalMilliseconds < 0 || delay > Constants.MaximumRetryBackoff ? Constants.MaximumRetryBackoff : delay;

                if (!shouldRetry || (executionState.OperationExpiryTime.HasValue && (DateTime.Now + delay).CompareTo(executionState.OperationExpiryTime.Value) > 0))
                {
                    // No Retry
                    executionState.OnComplete();
                }
                else
                {
                    if (executionState.Cmd.RecoveryAction != null)
                    {
                        // I.E. Rewind stream etc.
                        executionState.Cmd.RecoveryAction(executionState.Cmd, executionState.ExceptionRef, executionState.OperationContext);
                    }

                    if (delay > TimeSpan.Zero)
                    {
                        Timer backoffTimer = null;

                        backoffTimer = new Timer(
                            (obj) =>
                            {
                                backoffTimer.Change(Timeout.Infinite, Timeout.Infinite);
                                backoffTimer.Dispose();
                                InitRequest<T, INTERMEDIATE_TYPE>(executionState);
                            },
                            null /* state */,
                            (int)delay.TotalMilliseconds,
                            Timeout.Infinite);
                    }
                    else
                    {
                        // Start Next Request Immediately
                        InitRequest<T, INTERMEDIATE_TYPE>(executionState);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch all ( i.e. users retry policy throws etc.)
                executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                executionState.OnComplete();
            }
        }
        #endregion

        #endregion

        #region Sync

        public static T ExecuteSync<T, INTERMEDIATE_TYPE>(TableCommand<T, INTERMEDIATE_TYPE> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            // Note all code below will reference state, not params directly, this will allow common code with async executor
            ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext);
            TableExecutor.AcquireContext(cmd.Context, executionState);
            bool shouldRetry = false;

            try
            {
                // Enter Retryable Section of execution
                do
                {
                    executionState.Init();

                    // 0. Begin Request
                    TableExecutor.StartRequestAttempt(executionState);

                    TableExecutor.CheckTimeout<T>(executionState, true);

                    try
                    {
                        INTERMEDIATE_TYPE tempResult = default(INTERMEDIATE_TYPE);

                        try
                        {
                            tempResult = cmd.ExecuteFunc();

                            executionState.Result = cmd.ParseResponse(tempResult, executionState.Cmd.CurrentResult, cmd);

                            // Attempt to populate response headers
                            if (executionState.Req != null)
                            {
                                executionState.Resp = GetResponseForRequest(executionState.Req);
                                TableExecutor.FireResponseReceived(executionState);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Store exception and invoke callback here. All operations in this try would be non-retryable by default
                            if (executionState.ExceptionRef == null || !(executionState.ExceptionRef is StorageException))
                            {
                                executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                            }

                            // Attempt to populate response headers
                            if (executionState.Req != null)
                            {
                                executionState.Resp = GetResponseForRequest(executionState.Req);
                                TableExecutor.FireResponseReceived(executionState);
                            }

                            executionState.Result = cmd.ParseResponse(tempResult, executionState.Cmd.CurrentResult, cmd);

                            // clear exception
                            executionState.ExceptionRef = null;
                        }

                        TableExecutor.FinishRequestAttempt(executionState);

                        return executionState.Result;
                    }
                    catch (Exception e)
                    {
                        TableExecutor.FinishRequestAttempt(executionState);

                        StorageException translatedException = StorageException.TranslateException(e, executionState.Cmd.CurrentResult);
                        executionState.ExceptionRef = translatedException;

                        TimeSpan delay = TimeSpan.FromMilliseconds(0);
                        shouldRetry = translatedException.IsRetryable &&
                                            executionState.RetryPolicy != null ?
                                                    executionState.RetryPolicy.ShouldRetry(
                                                                                            executionState.RetryCount++,
                                                                                            executionState.Cmd.CurrentResult.HttpStatusCode,
                                                                                            executionState.ExceptionRef,
                                                                                            out delay,
                                                                                            executionState.OperationContext)
                                            : false;

                        delay = delay.TotalMilliseconds < 0 || delay > Constants.MaximumRetryBackoff ? Constants.MaximumRetryBackoff : delay;

                        if (!shouldRetry || (executionState.OperationExpiryTime.HasValue && (DateTime.Now + delay).CompareTo(executionState.OperationExpiryTime.Value) > 0))
                        {
                            throw executionState.ExceptionRef;
                        }
                        else
                        {
                            if (executionState.Cmd.RecoveryAction != null)
                            {
                                // I.E. Rewind stream etc.
                                executionState.Cmd.RecoveryAction(executionState.Cmd, executionState.ExceptionRef, executionState.OperationContext);
                            }

                            if (delay > TimeSpan.Zero)
                            {
                                Thread.Sleep(delay);
                            }
                        }
                    }
                } 
                while (shouldRetry);

                // should never get here, either return, or throw;
                throw new NotImplementedException(SR.InternalStorageError);
            }
            finally
            {
                ReleaseContext(cmd.Context);
            }
        }

        #endregion

        #region TableServiceContext Interop

        private static void Context_SendingSignedRequest<T>(ExecutionState<T> executionState, HttpWebRequest req)
        {
            // Handle multiple astoria transactions per execute
            if (executionState.Req != null)
            {
                executionState.Resp = GetResponseForRequest(executionState.Req);

                TableExecutor.FireResponseReceived(executionState);

                executionState.Req = null;

                // Finish previous attempt
                TableExecutor.FinishRequestAttempt(executionState);

                // on successes for multiple Astoria operations start new request
                if ((int)executionState.Resp.StatusCode < 300)
                {
                    // 0. Setup Next RequestResult
                    TableExecutor.StartRequestAttempt(executionState);
                }

                TableExecutor.CheckTimeout<T>(executionState, true);
            }

            executionState.Req = req;
            TableExecutor.ApplyUserHeaders(executionState);
            TableExecutor.FireSendingRequest(executionState);
        }

        internal static void AcquireContext<T>(TableServiceContext ctx, ExecutionState<T> executionState)
        {
            // This is a fail safe against deadlock in case a callback is ever lost etc and the context is not released
            if (!ctx.ContextSemaphore.WaitOne(20000))
            {
                throw new TimeoutException(SR.ConcurrentOperationsNotSupported);
            }

            ctx.SendingSignedRequestAction = (request) => Context_SendingSignedRequest(executionState, request);
        }

        internal static void ReleaseContext(TableServiceContext ctx)
        {
            ctx.SendingSignedRequestAction = null;
            ctx.ResetCancellation();
            ctx.ContextSemaphore.Release();
        }

        internal static HttpWebResponse GetResponseForRequest(HttpWebRequest req)
        {
            try
            {
                return (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }
        #endregion
    }
}
