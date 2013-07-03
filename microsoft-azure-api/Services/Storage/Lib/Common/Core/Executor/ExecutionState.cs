//-----------------------------------------------------------------------
// <copyright file="ExecutionState.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

#if WINDOWS_RT
    using System.Net.Http;
#else
    using System.Net;
#endif

    // This class encapsulates a StorageCommand and stores state about its execution.
    // Note conceptually there is some overlap between ExecutionState and operationContext, however the 
    // operationContext is the user visible object and the ExecutionState is an internal object used to coordinate execution.
#if WINDOWS_RT
    internal class ExecutionState<T> : IDisposable
#else
    // If we are exposing APM then derive this class from the StorageCommandAsyncResult
    internal class ExecutionState<T> : StorageCommandAsyncResult
#endif
    {
        public ExecutionState(StorageCommandBase<T> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            this.Cmd = cmd;
            this.RetryPolicy = policy != null ? policy.CreateInstance() : new NoRetry();
            this.OperationContext = operationContext ?? new OperationContext();

#if WINDOWS_RT
            if (this.OperationContext.StartTime == DateTimeOffset.MinValue)
            {
                this.OperationContext.StartTime = DateTimeOffset.Now;
            }
#else
            if (this.OperationContext.StartTime == DateTime.MinValue)
            {
                this.OperationContext.StartTime = DateTime.Now;
            }
#endif
        }

#if WINDOWS_DESKTOP
        public ExecutionState(StorageCommandBase<T> cmd, IRetryPolicy policy, OperationContext operationContext, AsyncCallback callback, object asyncState)
            : base(callback, asyncState)
        {
            this.Cmd = cmd;
            this.RetryPolicy = policy != null ? policy.CreateInstance() : new NoRetry();
            this.OperationContext = operationContext ?? new OperationContext();

            if (this.OperationContext.StartTime == DateTime.MinValue)
            {
                this.OperationContext.StartTime = DateTime.Now;
            }
        }
#endif

        internal void Init()
        {
            this.Req = null;
            this.resp = null;

#if !WINDOWS_RT
            this.ReqTimedOut = false;
            this.CancelDelegate = null;
#endif
        }

#if WINDOWS_RT
        public void Dispose()
        {
            this.CheckDisposeSendStream();
        }
#else
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Timer backoffTimer = this.BackoffTimer;
                if (backoffTimer != null)
                {
                    this.BackoffTimer = null;
                    backoffTimer.Dispose();
                }

                this.CheckDisposeSendStream();
            }

            base.Dispose(disposing);
        }

        internal Timer BackoffTimer { get; set; }
#endif

        internal OperationContext OperationContext { get; set; }

        internal DateTime? OperationExpiryTime
        {
            get { return this.Cmd.OperationExpiryTime; }
        }

        internal IRetryPolicy RetryPolicy { get; set; }

        internal StorageCommandBase<T> Cmd { get; set; }

        internal RESTCommand<T> RestCMD
        {
            get
            {
                return this.Cmd as RESTCommand<T>;
            }
        }

        internal ExecutorOperation CurrentOperation { get; set; }

        internal TimeSpan RemainingTimeout
        {
            get
            {
                if (!this.OperationExpiryTime.HasValue || this.OperationExpiryTime.Value.Equals(DateTime.MaxValue))
                {
                    // User did not specify a timeout, so we will set the request timeout to avoid
                    // waiting for the response infinitely
                    return Constants.DefaultClientSideTimeout;
                }
                else
                {
                    TimeSpan potentialTimeout = this.OperationExpiryTime.Value - DateTime.Now;

                    if (potentialTimeout <= TimeSpan.Zero)
                    {
                        throw Exceptions.GenerateTimeoutException(this.Cmd.CurrentResult, null);
                    }

                    return potentialTimeout;
                }
            }
        }

        private int retryCount = 0;

        internal int RetryCount
        {
            get { return this.retryCount; }
            set { this.retryCount = value; }
        }

        internal Stream ReqStream { get; set; }

        private volatile Exception exceptionRef = null;

        internal Exception ExceptionRef
        {
            get
            {
                return this.exceptionRef;
            }

            set
            {
                this.exceptionRef = value;
                if (this.Cmd != null && this.Cmd.CurrentResult != null)
                {
                    this.Cmd.CurrentResult.Exception = value;
                }
            }
        }

        internal T Result { get; set; }

        private object timeoutLockerObj = new object();
        private bool reqTimedOut = false;

        internal bool ReqTimedOut
        {
            get
            {
                lock (this.timeoutLockerObj)
                {
                    return this.reqTimedOut;
                }
            }

            set
            {
                lock (this.timeoutLockerObj)
                {
                    this.reqTimedOut = value;
                }
            }
        }

        private void CheckDisposeSendStream()
        {
            RESTCommand<T> cmd = this.RestCMD;

            if ((cmd != null) && (cmd.StreamToDispose != null))
            {
                cmd.StreamToDispose.Dispose();
                cmd.StreamToDispose = null;
            }
        }

#if WINDOWS_RT
        internal HttpClient Client { get; set; }

        internal HttpRequestMessage Req { get; set; }

        private HttpResponseMessage resp = null;

        internal HttpResponseMessage Resp
        {
            get
            {
                return this.resp;
            }

            set
            {
                this.resp = value;

                if (value != null)
                {
                    this.Cmd.CurrentResult.ServiceRequestID = HttpResponseMessageUtils.GetHeaderSingleValueOrDefault(this.resp.Headers, Constants.HeaderConstants.RequestIdHeader);
                    this.Cmd.CurrentResult.ContentMd5 = this.resp.Content.Headers.ContentMD5 != null ? Convert.ToBase64String(this.resp.Content.Headers.ContentMD5) : null;
                    this.Cmd.CurrentResult.Etag = this.resp.Headers.ETag != null ? this.resp.Headers.ETag.ToString() : null;
                    this.Cmd.CurrentResult.RequestDate = this.resp.Headers.Date.HasValue ? this.resp.Headers.Date.Value.UtcDateTime.ToString("R", CultureInfo.InvariantCulture) : null;
                    this.Cmd.CurrentResult.HttpStatusMessage = this.resp.ReasonPhrase;
                    this.Cmd.CurrentResult.HttpStatusCode = (int)this.resp.StatusCode;
                }
            }
        }
#else
        internal HttpWebRequest Req { get; set; }

        private HttpWebResponse resp = null;

        internal HttpWebResponse Resp
        {
            get
            {
                return this.resp;
            }

            set
            {
                this.resp = value;

                if (this.resp != null)
                {
                    if (value.Headers != null)
                    {
#if WINDOWS_DESKTOP
                        this.Cmd.CurrentResult.ServiceRequestID = HttpWebUtility.TryGetHeader(this.resp, Constants.HeaderConstants.RequestIdHeader, null);
                        this.Cmd.CurrentResult.ContentMd5 = HttpWebUtility.TryGetHeader(this.resp, "Content-MD5", null);
                        string tempDate = HttpWebUtility.TryGetHeader(this.resp, "Date", null);
                        this.Cmd.CurrentResult.RequestDate = string.IsNullOrEmpty(tempDate) ? DateTime.Now.ToString("R", CultureInfo.InvariantCulture) : tempDate;
                        this.Cmd.CurrentResult.Etag = this.resp.Headers[HttpResponseHeader.ETag];
#endif
                    }

                    this.Cmd.CurrentResult.HttpStatusMessage = this.Cmd.CurrentResult.HttpStatusMessage ?? this.resp.StatusDescription;

                    if (this.Cmd.CurrentResult.HttpStatusCode == -1)
                    {
                        this.Cmd.CurrentResult.HttpStatusCode = (int)this.resp.StatusCode;
                    }
                }
            }
        }
#endif
    }
}
