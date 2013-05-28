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
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.Diagnostics.CodeAnalysis;

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
            ExecutionState<T> executionState = new ExecutionState<T>(cmd, policy, operationContext);
            bool shouldRetry = false;
            TimeSpan delay = TimeSpan.FromMilliseconds(0);

            // Steps 1-4
            HttpClient client = cmd.BuildClient(cmd, operationContext);

            if (executionState.OperationExpiryTime.HasValue)
            {
                client.Timeout = executionState.OperationExpiryTime.Value - DateTime.Now;
            }
            else
            {
                client.Timeout = TimeSpan.FromDays(15);
            }

            // Setup token
            CancellationTokenSource cts = new CancellationTokenSource(client.Timeout);
            CancellationToken tokenWithTimeout = cts.Token;

            // Hookup users token
            token.Register(() => cts.Cancel());

            do
            {
                Executor.StartRequestAttempt(executionState);

                // Enter Retryable Section of execution
                try
                {
                    // Typically this would be out of the try, but do to the unique need for RTMD to translate exception it is included.
                    if (executionState.OperationExpiryTime.HasValue && executionState.Cmd.CurrentResult.StartTime.CompareTo(executionState.OperationExpiryTime.Value) > 0)
                    {
                        throw Exceptions.GenerateTimeoutException(executionState.Cmd.CurrentResult, null);
                    }

                    // Content is re-created every retry, as HttpClient disposes it after a successful request
                    HttpContent content = cmd.BuildContent != null ? cmd.BuildContent(cmd, operationContext) : null;

                    // This is so the old auth header etc is cleared out, the content is where serialization occurs which is the major perf hit
                    executionState.Req = cmd.BuildRequest(cmd, content, operationContext);

                    // User Headers
                    Executor.ApplyUserHeaders(executionState);

                    Executor.FireSendingRequest(executionState);

                    // Send Request 
                    executionState.Resp = await client.SendAsync(executionState.Req, HttpCompletionOption.ResponseHeadersRead, tokenWithTimeout);

                    // Since HttpClient wont throw for non success, manually check and populate an exception
                    if (!executionState.Resp.IsSuccessStatusCode)
                    {
                        executionState.ExceptionRef = await Exceptions.PopulateStorageExceptionFromHttpResponseMessage(executionState.Resp, executionState.Cmd.CurrentResult);
                    }

                    Executor.FireResponseReceived(executionState);

                    // 7. Do Response parsing (headers etc, no stream available here)
                    if (cmd.PreProcessResponse != null)
                    {
                        executionState.Result = cmd.PreProcessResponse(cmd, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);

                        // clear exception
                        executionState.ExceptionRef = null;
                    }

                    // 8. (Potentially reads stream from server)
                    cmd.ResponseStream = await executionState.Resp.Content.ReadAsStreamAsync();

                    if (!cmd.RetrieveResponseStream)
                    {
                        cmd.DestinationStream = Stream.Null;
                    }

                    if (cmd.DestinationStream != null)
                    {
                        try
                        {
                            if (cmd.StreamCopyState == null)
                            {
                                cmd.StreamCopyState = new StreamDescriptor();
                            }

                            await cmd.ResponseStream.WriteToAsync(cmd.DestinationStream, null /* MaxLength */, cmd.CalculateMd5ForResponseStream, executionState.OperationContext, cmd.StreamCopyState, tokenWithTimeout);
                        }
                        finally
                        {
                            cmd.ResponseStream.Flush();
                            cmd.ResponseStream.Dispose();
                            cmd.ResponseStream = null;
                        }
                    }

                    // 9. Evaluate Response & Parse Results, (Stream potentially available here) 
                    if (cmd.PostProcessResponse != null)
                    {
                        executionState.Result = await cmd.PostProcessResponse(cmd, executionState.Resp, executionState.ExceptionRef, executionState.OperationContext);
                    }

                    Executor.FinishRequestAttempt(executionState);

                    return executionState.Result;
                }
                catch (Exception e)
                {
                    Executor.FinishRequestAttempt(executionState);

                    if (e is TaskCanceledException && (executionState.OperationExpiryTime.HasValue && DateTime.Now.CompareTo(executionState.OperationExpiryTime.Value) > 0))
                    {
                        e = new TimeoutException(SR.TimeoutExceptionMessage, e);
                    }

                    StorageException translatedException = StorageException.TranslateException(e, executionState.Cmd.CurrentResult);
                    executionState.ExceptionRef = translatedException;

                    delay = TimeSpan.FromMilliseconds(0);
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
#if RTMD
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
                        await Task.Delay(delay);
                    }
                }
            }
            while (shouldRetry);

            // should never get here
            throw new NotImplementedException(SR.InternalStorageError);
        }
    }
}
