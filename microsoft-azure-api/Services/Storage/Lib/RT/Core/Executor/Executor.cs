// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Executor
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Executor : ExecutorBase
    {
        #region IAsyncAction
        public static Task ExecuteAsyncNullReturn(RESTCommand<NullType> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            return ExecuteAsyncNullReturn(cmd, policy, operationContext, CancellationToken.None);
        }

        public static Task ExecuteAsyncNullReturn(RESTCommand<NullType> cmd, IRetryPolicy policy, OperationContext operationContext, CancellationToken token)
        {
            return ExecuteAsyncInternal(cmd, policy, operationContext, token);
        }
        #endregion

        #region IAsyncOperation
        public static Task<T> ExecuteAsync<T>(RESTCommand<T> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            return ExecuteAsync(cmd, policy, operationContext, CancellationToken.None);
        }

        public static Task<T> ExecuteAsync<T>(RESTCommand<T> cmd, IRetryPolicy policy, OperationContext operationContext, CancellationToken token)
        {
            return ExecuteAsyncInternal(cmd, policy, operationContext, token);
        }
        #endregion

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        private async static Task<T> ExecuteAsyncInternal<T>(RESTCommand<T> cmd, IRetryPolicy policy, OperationContext operationContext, CancellationToken token)
        {
            // Note all code below will reference state, not params directly, this will allow common code with multiple executors (APM, Sync, Async)
            using (ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext))
            {
                bool shouldRetry = false;
                TimeSpan delay = TimeSpan.Zero;

                // Create a new client
                HttpClient client = cmd.BuildClient(cmd, executionState.OperationContext);
                client.Timeout = TimeSpan.FromMilliseconds(int.MaxValue);

                do
                {
                    try
                    {
                        executionState.Init();

                        // 0. Begin Request 
                        Executor.StartRequestAttempt(executionState);

                        // 1. Build request and content
                        executionState.CurrentOperation = ExecutorOperation.BeginOperation;

                        // Content is re-created every retry, as HttpClient disposes it after a successful request
                        HttpContent content = cmd.BuildContent != null ? cmd.BuildContent(cmd, executionState.OperationContext) : null;

                        // This is so the old auth header etc is cleared out, the content is where serialization occurs which is the major perf hit
                        Logger.LogInformational(executionState.OperationContext, SR.TraceStartRequestAsync, cmd.Uri);
                        executionState.Req = cmd.BuildRequest(cmd, content, executionState.OperationContext);

                        // 2. Set Headers
                        Executor.ApplyUserHeaders(executionState);

                        // Let the user know we are ready to send
                        Executor.FireSendingRequest(executionState);

                        // 3. Sign Request is not needed, as HttpClient will call us

                        // 4. Set timeout
                        if (executionState.OperationExpiryTime.HasValue)
                        {
                            client.Timeout = executionState.RemainingTimeout;
                        }

                        Executor.CheckTimeout<T>(executionState, true);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(executionState.OperationContext, SR.TraceInitRequestError, ex.Message);

                        // Store exception and throw here. All operations in this try would be non-retryable by default
                        StorageException storageEx = StorageException.TranslateException(ex, executionState.Cmd.CurrentResult);
                        storageEx.IsRetryable = false;
                        executionState.ExceptionRef = storageEx;
#if WINDOWS_RT
                        // Need to throw wrapped Exception with message as serialized exception info stuff. 
                        int hResult = WrappedStorageException.GenerateHResult(executionState.ExceptionRef, executionState.Cmd.CurrentResult);
                        throw new WrappedStorageException(executionState.Cmd.CurrentResult.WriteAsXml(), executionState.ExceptionRef, hResult);
#else
                    throw executionState.ExceptionRef; // throw base exception for desktop
#endif
                    }

                    // Enter Retryable Section of execution
                    try
                    {
                        // Send Request 
                        executionState.CurrentOperation = ExecutorOperation.BeginGetResponse;
                        Logger.LogInformational(executionState.OperationContext, SR.TraceGetResponse);
                        executionState.Resp = await client.SendAsync(executionState.Req, HttpCompletionOption.ResponseHeadersRead, token);
                        executionState.CurrentOperation = ExecutorOperation.EndGetResponse;

                        // Since HttpClient wont throw for non success, manually check and populate an exception
                        if (!executionState.Resp.IsSuccessStatusCode)
                        {
                            executionState.ExceptionRef = await Exceptions.PopulateStorageExceptionFromHttpResponseMessage(executionState.Resp, executionState.Cmd.CurrentResult);
                        }

                        Logger.LogInformational(executionState.OperationContext, SR.TraceResponse, executionState.Cmd.CurrentResult.HttpStatusCode, executionState.Cmd.CurrentResult.ServiceRequestID, executionState.Cmd.CurrentResult.ContentMd5, executionState.Cmd.CurrentResult.Etag);
                        Executor.FireResponseReceived(executionState);

                        // 7. Do Response parsing (headers etc, no stream available here)
                        if (cmd.PreProcessResponse != null)
                        {
                            executionState.CurrentOperation = ExecutorOperation.PreProcess;
                            executionState.Result = cmd.PreProcessResponse(cmd, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);

                            // clear exception
                            executionState.ExceptionRef = null;
                            Logger.LogInformational(executionState.OperationContext, SR.TracePreProcessDone);
                        }

                        // 8. (Potentially reads stream from server)
                        executionState.CurrentOperation = ExecutorOperation.GetResponseStream;
                        cmd.ResponseStream = await executionState.Resp.Content.ReadAsStreamAsync();

                        if (!cmd.RetrieveResponseStream)
                        {
                            cmd.DestinationStream = Stream.Null;
                        }

                        if (cmd.DestinationStream != null)
                        {
                            if (cmd.StreamCopyState == null)
                            {
                                cmd.StreamCopyState = new StreamDescriptor();
                            }

                            try
                            {
                                executionState.CurrentOperation = ExecutorOperation.BeginDownloadResponse;
                                Logger.LogInformational(executionState.OperationContext, SR.TraceDownload);
                                await cmd.ResponseStream.WriteToAsync(cmd.DestinationStream, null /* copyLength */, null /* maxLength */, cmd.CalculateMd5ForResponseStream, executionState, cmd.StreamCopyState, token);
                            }
                            finally
                            {
                                cmd.ResponseStream.Dispose();
                                cmd.ResponseStream = null;
                            }
                        }

                        // 9. Evaluate Response & Parse Results, (Stream potentially available here) 
                        if (cmd.PostProcessResponse != null)
                        {
                            executionState.CurrentOperation = ExecutorOperation.PostProcess;
                            Logger.LogInformational(executionState.OperationContext, SR.TracePostProcess);
                            executionState.Result = await cmd.PostProcessResponse(cmd, executionState.Resp, executionState.OperationContext);
                        }

                        executionState.CurrentOperation = ExecutorOperation.EndOperation;
                        Logger.LogInformational(executionState.OperationContext, SR.TraceSuccess);
                        Executor.FinishRequestAttempt(executionState);

                        return executionState.Result;
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning(executionState.OperationContext, SR.TraceGenericError, e.Message);
                        Executor.FinishRequestAttempt(executionState);

                        if (e is TaskCanceledException && (executionState.OperationExpiryTime.HasValue && DateTime.Now.CompareTo(executionState.OperationExpiryTime.Value) > 0))
                        {
                            e = new TimeoutException(SR.TimeoutExceptionMessage, e);
                        }

                        StorageException translatedException = StorageException.TranslateException(e, executionState.Cmd.CurrentResult);
                        executionState.ExceptionRef = translatedException;
                        Logger.LogInformational(executionState.OperationContext, SR.TraceRetryCheck, executionState.RetryCount, executionState.Cmd.CurrentResult.HttpStatusCode, translatedException.IsRetryable ? "yes" : "no", translatedException.Message);

                        shouldRetry = false;
                        if (translatedException.IsRetryable && (executionState.RetryPolicy != null))
                        {
                            shouldRetry = executionState.RetryPolicy.ShouldRetry(
                                executionState.RetryCount++,
                                executionState.Cmd.CurrentResult.HttpStatusCode,
                                executionState.ExceptionRef,
                                out delay,
                                executionState.OperationContext);

                            if ((delay < TimeSpan.Zero) || (delay > Constants.MaximumRetryBackoff))
                            {
                                delay = Constants.MaximumRetryBackoff;
                            }
                        }
                    }
                    finally
                    {
                        if (executionState.Resp != null)
                        {
                            executionState.Resp.Dispose();
                            executionState.Resp = null;
                        }
                    }

                    // potentially backoff
                    if (!shouldRetry || (executionState.OperationExpiryTime.HasValue && (DateTime.Now + delay).CompareTo(executionState.OperationExpiryTime.Value) > 0))
                    {
                        Logger.LogError(executionState.OperationContext, shouldRetry ? SR.TraceRetryDecisionTimeout : SR.TraceRetryDecisionPolicy, executionState.ExceptionRef.Message);
#if WINDOWS_RT
                        // Need to throw wrapped Exception with message as serialized exception info stuff. 
                        int hResult = WrappedStorageException.GenerateHResult(executionState.ExceptionRef, executionState.Cmd.CurrentResult);
                        throw new WrappedStorageException(executionState.Cmd.CurrentResult.WriteAsXml(), executionState.ExceptionRef, hResult);
#else
                    throw executionState.ExceptionRef; // throw base exception for desktop
#endif
                    }
                    else
                    {
                        if (cmd.RecoveryAction != null)
                        {
                            // I.E. Rewind stream etc.
                            cmd.RecoveryAction(cmd, executionState.Cmd.CurrentResult.Exception, executionState.OperationContext);
                        }

                        if (delay > TimeSpan.Zero)
                        {
                            await Task.Delay(delay, token);
                        }

                        Logger.LogInformational(executionState.OperationContext, SR.TraceRetry);
                    }
                }
                while (shouldRetry);

                // should never get here
                throw new NotImplementedException(SR.InternalStorageError);
            }
        }
    }
}
