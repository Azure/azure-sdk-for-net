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
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

#if RT
    using System.Linq;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Storage.Core.Util;
#else
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core.Util;
#endif
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    // This class encapsulates a StorageCommand and stores state about its execution.
    // Note conceptually there is some overlap between ExecutionState and operationContext, however the 
    // operationContext is the user visible object and the ExecutionState is an internal object used to coordinate execution.
    internal class ExecutionState<T>
#if RT
#elif !COMMON
        // If we are exposing APM then derive this class from the StorageCommandAsyncResult
        : StorageCommandAsyncResult, ICancellableAsyncResult
#endif
    {
        public ExecutionState(StorageCommandBase<T> cmd, IRetryPolicy policy, OperationContext operationContext)
        {
            this.Cmd = cmd;
            this.RetryPolicy = policy != null ? policy.CreateInstance() : new NoRetry();
            this.OperationContext = operationContext ?? new OperationContext();

            if (!this.OperationContext.OperationExpiryTime.HasValue && cmd != null && cmd.ClientMaxTimeout.HasValue)
            {
                this.OperationExpiryTime = DateTime.Now + cmd.ClientMaxTimeout.Value;
            }
            else if (this.OperationContext.OperationExpiryTime.HasValue)
            {
                // Override timeout for complex actions
#if RT
                this.OperationExpiryTime = this.OperationContext.OperationExpiryTime.Value.UtcDateTime;
#else
                this.OperationExpiryTime = this.OperationContext.OperationExpiryTime.Value;
#endif
            }
        }

#if DNCP
        public ExecutionState(StorageCommandBase<T> cmd, IRetryPolicy policy, OperationContext operationContext, AsyncCallback callback, object asyncState)
            : base(callback, asyncState)
        {
            this.Cmd = cmd;
            this.RetryPolicy = policy != null ? policy.CreateInstance() : new NoRetry();
            this.OperationContext = operationContext ?? new OperationContext();

            if (!this.OperationContext.OperationExpiryTime.HasValue && cmd != null && cmd.ClientMaxTimeout.HasValue)
            {
                this.OperationExpiryTime = DateTime.Now + cmd.ClientMaxTimeout.Value;
            }
            else if (this.OperationContext.OperationExpiryTime.HasValue)
            {
                // Override timeout for complex actions
                this.OperationExpiryTime = this.OperationContext.OperationExpiryTime.Value;
            }
        }
#endif

        internal void Init()
        {
            this.Req = null;
            this.resp = null;

#if !RT
            this.ReqTimedOut = false;
            this.CancelDelegate = null;
#endif
        }

        // Cancellation Suppport for DN35
#if !RT
        private object cancellationLockerObject = new object();

        internal object CancellationLockerObject
        {
            get { return this.cancellationLockerObject; }
            set { this.cancellationLockerObject = value; }
        }

        private volatile bool cancelRequested = false;

        internal bool CancelRequested
        {
            get { return this.cancelRequested; }
            set { this.cancelRequested = value; }
        }

        private Action cancelDelegate = null;

        internal Action CancelDelegate
        {
            get
            {
                lock (this.cancellationLockerObject)
                {
                    return this.cancelDelegate;
                }
            }

            set
            {
                lock (this.cancellationLockerObject)
                {
                    this.cancelDelegate = value;
                }
            }
        }

        public void Cancel()
        {
            lock (this.cancellationLockerObject)
            {
                this.cancelRequested = true;
                if (this.CancelDelegate != null)
                {
                    this.CancelDelegate();
                }
            }
        }
#endif

        private OperationContext operationContext = null;

        internal OperationContext OperationContext
        {
            get { return this.operationContext; }
            set { this.operationContext = value; }
        }

        private DateTime? operationExpiryTime = null;

        internal DateTime? OperationExpiryTime
        {
            get { return this.operationExpiryTime; }
            set { this.operationExpiryTime = value; }
        }

        private IRetryPolicy retryPolicy = null;

        internal IRetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
            set { this.retryPolicy = value; }
        }

        private StorageCommandBase<T> cmd = null;

        internal StorageCommandBase<T> Cmd
        {
            get { return this.cmd; }
            set { this.cmd = value; }
        }

        internal RESTCommand<T> RestCMD
        {
            get
            {
                return this.Cmd as RESTCommand<T>;
            }
        }

#if DNCP
        internal int RemainingTimeout
        {
            get
            {
                if (!this.OperationExpiryTime.HasValue || this.OperationExpiryTime.Value.Equals(DateTime.MaxValue))
                {
                    // User did not specify a timeout, so we will set the request timeout to avoid
                    // waiting for the response infinitely
                    return (int)Constants.DefaultClientSideTimeout.TotalMilliseconds;
                }
                else
                {
                    return (int)(this.OperationExpiryTime.Value - DateTime.Now).TotalMilliseconds;
                }
            }
        }
#endif

        private int retryCount = 0;

        internal int RetryCount
        {
            get { return this.retryCount; }
            set { this.retryCount = value; }
        }

        private Stream reqStream = null;

        internal Stream ReqStream
        {
            get { return this.reqStream; }
            set { this.reqStream = value; }
        }

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

        private volatile Exception exceptionRef = null;

        private T result = default(T);

        internal T Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

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

#if RT
        private HttpClient client = null;

        internal HttpClient Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        private HttpRequestMessage req = null;

        internal HttpRequestMessage Req
        {
            get { return this.req; }
            set { this.req = value; }
        }

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
        private HttpWebRequest req = null;

        internal HttpWebRequest Req
        {
            get { return this.req; }
            set { this.req = value; }
        }

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
#if DNCP
                        this.Cmd.CurrentResult.ServiceRequestID = HttpUtility.TryGetHeader(this.resp, Constants.HeaderConstants.RequestIdHeader, null);
                        this.Cmd.CurrentResult.ContentMd5 = HttpUtility.TryGetHeader(this.resp, "Content-MD5", null);
                        string tempDate = HttpUtility.TryGetHeader(this.resp, "Date", null);
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
