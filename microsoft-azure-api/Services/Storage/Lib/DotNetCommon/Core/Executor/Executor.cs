//-----------------------------------------------------------------------
// <copyright file="Executor.cs" company="Microsoft">
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

    internal class Executor : ExecutorBase
    {
        #region Async

        #region Begin / End
        // Cancellation will be handled by a flag in the return type ( CancellationToken in .net4+ )
        public static ICancellableAsyncResult BeginExecuteAsync<T>(RESTCommand<T> cmd, IRetryPolicy policy, OperationContext operationContext, AsyncCallback callback, object asyncState)
        {
            // Note all code below will reference state, not params directly, this will allow common code with async executor
            ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext, callback, asyncState);
            InitRequest(executionState);
            return executionState;
        }

        public static T EndExecuteAsync<T>(IAsyncResult result)
        {
            CommonUtils.AssertNotNull("result", result);

            ExecutionState<T> executionState = (ExecutionState<T>)result;

            executionState.End();
            if (executionState.ExceptionRef != null)
            {
                throw executionState.ExceptionRef;
            }

            return executionState.Result;
        }

        #endregion

        #region Steps 0 - 4 Setup Request
        public static void InitRequest<T>(ExecutionState<T> executionState)
        {
            try
            {
                executionState.Init();

                // 0. Begin Request 
                Executor.StartRequestAttempt(executionState);

                // Steps 1 - 4
                Executor.ProcessStartOfRequest(executionState);

                if (Executor.CheckTimeout<T>(executionState, false))
                {
                    Executor.EndOperation(executionState);
                    return;
                }

                lock (executionState.CancellationLockerObject)
                {
                    if (Executor.CheckCancellation(executionState))
                    {
                        EndOperation(executionState);
                        return;
                    }

                    // 5. potentially upload data
                    if (executionState.RestCMD.SendStream != null)
                    {
                        BeginGetRequestStream(executionState);
                    }
                    else
                    {
                        BeginGetResponse(executionState);
                    }
                }
            }
            catch (Exception ex)
            {
                // Store exception and invoke callback here. All operations in this try would be non-retryable by default
                StorageException storageEx = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                storageEx.IsRetryable = false;
                executionState.ExceptionRef = storageEx;
                executionState.OnComplete();
            }
        }
        #endregion

        #region Step 5 Get Request Stream & upload
        private static void BeginGetRequestStream<T>(ExecutionState<T> executionState)
        {
            try
            {
                APMWithTimeout.RunWithTimeout(
                    executionState.Req.BeginGetRequestStream,
                    (getRequestStreamResp) =>
                    {
                        executionState.UpdateCompletedSynchronously(getRequestStreamResp.CompletedSynchronously);

                        try
                        {
                            executionState.ReqStream = executionState.Req.EndGetRequestStream(getRequestStreamResp);

                            // don't calculate md5 here as we should have already set this for auth purposes
                            executionState.RestCMD.SendStream.WriteToAsync(executionState.ReqStream, null /* maxLength */, executionState.OperationExpiryTime, false, executionState, executionState.OperationContext, null /* streamCopyState */, EndSendStreamCopy);
                        }
                        catch (WebException ex)
                        {
                            if (ex.Status == WebExceptionStatus.RequestCanceled)
                            {
                                // If the below condition is true, ExceptionRef is set anyway, so don't touch it
                                if (!Executor.CheckCancellation(executionState))
                                {
                                    executionState.ExceptionRef = Exceptions.GenerateTimeoutException(executionState.Cmd.CurrentResult, null);
                                }
                            }
                            else
                            {
                                executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                            }

                            EndOperation(executionState);
                        }
                        catch (Exception ex)
                        {
                            executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                            EndOperation(executionState);
                        }
                    },
                    null,
                    executionState.RemainingTimeout,
                    (getRequestStreamResp) =>
                    {
                        try
                        {
                            executionState.ReqTimedOut = true;
                            executionState.Req.Abort();
                        }
                        catch (Exception)
                        {
                            // no op
                        }
                    });
            }
            catch (Exception ex)
            {
                executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                EndOperation(executionState);
            }
        }

        private static void EndSendStreamCopy<T>(ExecutionState<T> executionState)
        {
            lock (executionState.CancellationLockerObject)
            {
                if (Executor.CheckCancellation(executionState))
                {
                    if (executionState.Req != null)
                    {
                        try
                        {
                            executionState.Req.Abort();
                        }
                        catch (Exception)
                        {
                            // No op
                        }
                    }
                }

                if (executionState.ExceptionRef != null)
                {
                    EndOperation(executionState);
                }
                else
                {
                    try
                    {
                        executionState.ReqStream.Flush();
                        executionState.ReqStream.Dispose();
                        executionState.ReqStream = null;
                    }
                    catch (Exception)
                    {
                        // If we could not flush/dispose the request stream properly,
                        // BeginGetResponse will fail with a more meaningful error anyway.
                    }

                    BeginGetResponse(executionState);
                }
            }
        }

        #endregion

        #region Steps 6-8 Get Response & Potentially Send
        private static void BeginGetResponse<T>(ExecutionState<T> executionState)
        {
            try
            {
                APMWithTimeout.RunWithTimeout(
                    executionState.Req.BeginGetResponse,
                    (getRespRes) =>
                    {
                        try
                        {
                            executionState.UpdateCompletedSynchronously(getRespRes.CompletedSynchronously);

                            try
                            {
                                executionState.Resp = executionState.Req.EndGetResponse(getRespRes) as HttpWebResponse;
                            }
                            catch (WebException ex)
                            {
                                executionState.Resp = (HttpWebResponse)ex.Response;

                                if (executionState.Resp == null)
                                {
                                    throw;
                                }
                                else
                                {
                                    executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                                }
                            }

                            FireResponseReceived(executionState);

                            // 7. Do Response parsing (headers etc, no stream available here)
                            if (executionState.RestCMD.PreProcessResponse != null)
                            {
                                executionState.Result = executionState.RestCMD.PreProcessResponse(executionState.RestCMD, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);

                                // clear exception
                                executionState.ExceptionRef = null;
                            }

                            CheckCancellation(executionState);

                            // 8. (Potentially reads stream from server)
                            if (executionState.RestCMD.RetrieveResponseStream && executionState.ExceptionRef == null)
                            {
                                executionState.RestCMD.ResponseStream = executionState.Resp.GetResponseStream();

                                if (executionState.RestCMD.DestinationStream != null)
                                {
                                    if (executionState.RestCMD.StreamCopyState == null)
                                    {
                                        executionState.RestCMD.StreamCopyState = new StreamDescriptor();
                                    }

                                    executionState.RestCMD.ResponseStream.WriteToAsync(executionState.RestCMD.DestinationStream, null /* maxLength */, executionState.OperationExpiryTime, executionState.RestCMD.CalculateMd5ForResponseStream, executionState, executionState.OperationContext, executionState.RestCMD.StreamCopyState, EndResponseStreamCopy);
                                }
                                else
                                {
                                    // Dont want to copy stream, just want to consume it so end
                                    EndOperation(executionState);
                                }
                            }
                            else
                            {
                                // End
                                EndOperation(executionState);
                            }
                        }
                        catch (Exception ex)
                        {
                            executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                            EndOperation(executionState);
                        }
                    },
                    null,
                    executionState.RemainingTimeout,
                    (getRespRes) =>
                    {
                        try
                        {
                            executionState.ReqTimedOut = true;
                            executionState.Req.Abort();
                        }
                        catch (Exception)
                        {
                            // no op
                        }
                    });
            }
            catch (Exception ex)
            {
                executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                EndOperation(executionState);
            }
        }

        private static void EndResponseStreamCopy<T>(ExecutionState<T> executionState)
        {
            EndOperation(executionState);
        }
        #endregion

        #region Step 9 - Parse Response
        private static void EndOperation<T>(ExecutionState<T> executionState)
        {
            Executor.FinishRequestAttempt(executionState);

            lock (executionState.CancellationLockerObject)
            {
                try
                {
                    // If an operation has been canceled of timed out this should overwtie any exception
                    Executor.CheckCancellation(executionState);
                    Executor.CheckTimeout(executionState, true);

                    // Success
                    if (executionState.ExceptionRef == null)
                    {
                        // Step 9 - This will not be called if an exception is raised during stream copying
                        Executor.ProcessEndOfRequest(executionState, executionState.ExceptionRef);
                        executionState.OnComplete();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                }
                finally
                {
                    try
                    {
                        if (executionState.Resp != null)
                        {
                            executionState.Resp.Close();
                            executionState.Resp = null;
                        }
                    }
                    catch (Exception)
                    {
                        // no op
                    }
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
                                executionState.UpdateCompletedSynchronously(false);
                                backoffTimer.Change(Timeout.Infinite, Timeout.Infinite);
                                backoffTimer.Dispose();
                                InitRequest(executionState);
                            },
                            null /* state */,
                            (int)delay.TotalMilliseconds,
                            Timeout.Infinite);
                    }
                    else
                    {
                        // Start Next Request Immediately
                        InitRequest(executionState);
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

        public static T ExecuteSync<T>(StorageCommandBase<T> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            // Note all code below will reference state, not params directly, this will allow common code with async executor
            ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext);
            bool shouldRetry = false;

            do
            {
                try
                {
                    executionState.Init();

                    // 0. Begin Request 
                    Executor.StartRequestAttempt(executionState);

                    // Steps 1-4
                    Executor.ProcessStartOfRequest(executionState);

                    Executor.CheckTimeout<T>(executionState, true);

                    // Enter Retryable Section of execution
                    // 5. potentially upload data
                    if (executionState.RestCMD.SendStream != null)
                    {
                        // Reset timeout
                        executionState.Req.Timeout = executionState.RemainingTimeout;
                        executionState.ReqStream = executionState.Req.GetRequestStream();
                        executionState.RestCMD.SendStream.WriteToSync(executionState.ReqStream, null /* maxLength */, executionState.OperationExpiryTime, false, true, executionState.OperationContext, null /* streamCopyState */); // don't calculate md5 here as we should have already set this for auth purposes
                        executionState.ReqStream.Flush();
                        executionState.ReqStream.Dispose();
                        executionState.ReqStream = null;
                    }

                    // 6. Get response 
                    try
                    {
                        // Reset timeout
                        executionState.Req.Timeout = executionState.RemainingTimeout;
                        executionState.Resp = (HttpWebResponse)executionState.Req.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        executionState.Resp = (HttpWebResponse)ex.Response;
                        if (executionState.Resp == null)
                        {
                            throw;
                        }
                        else
                        {
                            executionState.ExceptionRef = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                        }
                    }

                    // Response
                    Executor.FireResponseReceived(executionState);

                    // 7. Do Response parsing (headers etc, no stream available here)
                    if (executionState.RestCMD.PreProcessResponse != null)
                    {
                        executionState.Result = executionState.RestCMD.PreProcessResponse(executionState.RestCMD, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);

                        // clear exception
                        executionState.ExceptionRef = null;
                    }

                    // 8. (Potentially reads stream from server)
                    if (executionState.RestCMD.RetrieveResponseStream)
                    {
                        executionState.RestCMD.ResponseStream = executionState.Resp.GetResponseStream();
                    }

                    if (executionState.RestCMD.DestinationStream != null)
                    {
                        try
                        {
                            if (executionState.RestCMD.StreamCopyState == null)
                            {
                                executionState.RestCMD.StreamCopyState = new StreamDescriptor();
                            }

                            executionState.RestCMD.ResponseStream.WriteToSync(executionState.RestCMD.DestinationStream, null /* maxLength */, executionState.OperationExpiryTime, executionState.RestCMD.CalculateMd5ForResponseStream, false, executionState.OperationContext, executionState.RestCMD.StreamCopyState);
                        }
                        finally
                        {
                            executionState.RestCMD.ResponseStream.Dispose();
                        }
                    }

                    // Step 9 - This will not be called if an exception is raised during stream copying
                    Executor.ProcessEndOfRequest(executionState, executionState.ExceptionRef);

                    Executor.FinishRequestAttempt(executionState);

                    return executionState.Result;
                }
                catch (Exception e)
                {
                    Executor.FinishRequestAttempt(executionState);

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
                finally
                {
                    if (executionState.Resp != null)
                    {
                        executionState.Resp.Close();
                        executionState.Resp = null;
                    }
                }
            }
            while (shouldRetry);

            // should never get here, either return, or throw;
            throw new NotImplementedException(SR.InternalStorageError);
        }

        #endregion

        #region Common

        private static void ProcessStartOfRequest<T>(ExecutionState<T> executionState)
        {
            // 1. Build request
            executionState.Req = executionState.RestCMD.BuildRequestDelegate(executionState.Cmd.Uri, executionState.Cmd.Builder, executionState.Cmd.ServerTimeoutInSeconds, executionState.OperationContext);

            // User Headers
            Executor.ApplyUserHeaders(executionState);

            executionState.CancelDelegate = executionState.Req.Abort;

            // 2. Set Headers
            if (executionState.RestCMD.SetHeaders != null)
            {
                executionState.RestCMD.SetHeaders(executionState.Req, executionState.OperationContext);
            }

            if (executionState.RestCMD.SendStream != null)
            {
                CommonUtils.ApplyRequestOptimizations(executionState.Req, executionState.RestCMD.SendStream.Length - executionState.RestCMD.SendStream.Position);
            }
            else
            {
                CommonUtils.ApplyRequestOptimizations(executionState.Req, -1);
            }

            Executor.FireSendingRequest(executionState);

            // 3. Sign Request
            if (executionState.RestCMD.SignRequest != null)
            {
                executionState.RestCMD.SignRequest(executionState.Req, executionState.OperationContext);
            }

            // 4. Set timeout (this is actually not honored by asynchronous requests)
            executionState.Req.Timeout = executionState.RemainingTimeout;
        }

        private static void ProcessEndOfRequest<T>(ExecutionState<T> executionState, Exception ex)
        {
            // 9. Evaluate Response & Parse Results, (Stream potentially available here) 
            if (executionState.RestCMD.PostProcessResponse != null)
            {
                executionState.Result = executionState.RestCMD.PostProcessResponse(executionState.RestCMD, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);
            }

            executionState.CancelDelegate = null;
        }
        #endregion
    }
}