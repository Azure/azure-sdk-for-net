//-----------------------------------------------------------------------
// <copyright file="ExecutorBase.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal abstract class ExecutorBase
    {
        protected static void ApplyUserHeaders<T>(ExecutionState<T> executionState)
        {
#if !COMMON
            if (!string.IsNullOrEmpty(executionState.OperationContext.ClientRequestID))
            {
                executionState.Req.Headers.Add(Constants.HeaderConstants.ClientRequestIdHeader, executionState.OperationContext.ClientRequestID);
            }

            if (executionState.OperationContext.UserHeaders != null && executionState.OperationContext.UserHeaders.Count > 0)
            {
                foreach (string key in executionState.OperationContext.UserHeaders.Keys)
                {
                    executionState.Req.Headers.Add(key, executionState.OperationContext.UserHeaders[key]);
                }
            }
#endif
        }

        protected static void StartRequestAttempt<T>(ExecutionState<T> executionState)
        {
            executionState.Cmd.CurrentResult = new RequestResult();

            // Need to clear this explicitly for retries
            executionState.ExceptionRef = null;

            lock (executionState.OperationContext.RequestResults)
            {
                executionState.OperationContext.RequestResults.Add(executionState.Cmd.CurrentResult);
            }

            executionState.Cmd.CurrentResult.StartTime = DateTime.Now;
        }

        protected static void FinishRequestAttempt<T>(ExecutionState<T> executionState)
        {
            executionState.Cmd.CurrentResult.EndTime = DateTime.Now;
        }

        protected static void FireSendingRequest<T>(ExecutionState<T> executionState)
        {
            RequestEventArgs args = new RequestEventArgs(executionState.Cmd.CurrentResult);
#if RT
            args.RequestUri = executionState.Req.RequestUri;
#else
            args.Request = executionState.Req;
#endif
            executionState.OperationContext.FireSendingRequest(args);
        }

        protected static void FireResponseReceived<T>(ExecutionState<T> executionState)
        {
            RequestEventArgs args = new RequestEventArgs(executionState.Cmd.CurrentResult);
#if RT
            args.RequestUri = executionState.Req.RequestUri;
#else
            args.Request = executionState.Req;
            args.Response = executionState.Resp;
#endif
            executionState.OperationContext.FireResponseReceived(args);
        }

        protected static bool CheckTimeout<T>(ExecutionState<T> executionState, bool throwOnTimeout)
        {
            if (executionState.ReqTimedOut || (executionState.OperationExpiryTime.HasValue && executionState.Cmd.CurrentResult.StartTime.CompareTo(executionState.OperationExpiryTime.Value) > 0))
            {
                executionState.ReqTimedOut = true;

                StorageException storageEx = Exceptions.GenerateTimeoutException(executionState.Cmd.CurrentResult, null);
                executionState.ExceptionRef = storageEx;

                if (throwOnTimeout)
                {
                    throw executionState.ExceptionRef;
                }

                return true;
            }

            return false;
        }

#if DNCP
        protected static bool CheckCancellation<T>(ExecutionState<T> executionState)
        {
            if (executionState.CancelRequested)
            {
                executionState.ExceptionRef = Exceptions.GenerateCancellationException(executionState.Cmd.CurrentResult, null);
            }

            return executionState.CancelRequested;
        }
#endif
    }
}
