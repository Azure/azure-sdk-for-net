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
using System.Net;
using Hyak.Common;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The Table operation context logger.
    /// </summary>
    internal class TableOperationContextLogger
    {
        private readonly string resourceUri;
        private readonly string operationName;
        private readonly string requestId;
        private readonly OperationContext operationContext;
        private readonly string accountName;

        /// <summary>
        /// Gets the operation context.
        /// </summary>
        public OperationContext OperationContext
        {
            get { return this.operationContext; }
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public HttpWebResponse Response
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableOperationContextLogger"/> class.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="operationName">Name of the operation.</param>
        public TableOperationContextLogger(string accountName, string resourceUri, string operationName)
            : this(accountName, resourceUri, operationName, Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableOperationContextLogger"/> class.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="requestId">The request id.</param>
        public TableOperationContextLogger(string accountName, string resourceUri, string operationName, string requestId)
        {
            this.accountName = accountName;
            this.resourceUri = resourceUri;
            this.operationName = operationName;
            this.requestId = requestId;

            this.operationContext = new OperationContext { ClientRequestID = requestId };
            this.operationContext.SendingRequest += this.OperationContextSendingRequest;
            this.operationContext.ResponseReceived += this.OperationContextResponseReceived;
        }

        private void OperationContextResponseReceived(object sender, RequestEventArgs e)
        {
            if (!TracingAdapter.IsEnabled)
            {
                return;
            }
        
            DateTime currentTime = DateTime.Now;

            double duration = 0;
            string httpStatusCode = null;
            string serviceRequestId = null;
            string exceptionString = null;
            string extendedInfoErrorCode = null;
            string extendedInfoErrorMessage = null;
            long contentLength = e.Response != null ? e.Response.ContentLength : 0;
            this.Response = e.Response;

            if (this.OperationContext.LastResult != null)
            {
                httpStatusCode = this.OperationContext.LastResult.HttpStatusCode.ToString(CultureInfo.InvariantCulture);
                serviceRequestId = this.OperationContext.LastResult.ServiceRequestID;

                // It should have been this.operationContext.LastResult.EndTime - this.operationContext.LastResult.StartTime
                // However, in the flow of control, the EndTime is not yet set in the operation context.
                duration = (currentTime - this.operationContext.LastResult.StartTime).TotalMilliseconds;

                if (this.operationContext.LastResult.Exception != null)
                {
                    exceptionString = this.operationContext.LastResult.Exception.ToString();

                    if (this.OperationContext.LastResult.ExtendedErrorInformation != null)
                    {
                        extendedInfoErrorCode = this.OperationContext.LastResult.ExtendedErrorInformation.ErrorCode;
                        extendedInfoErrorMessage = this.operationContext.LastResult.ExtendedErrorInformation.ErrorMessage;
                    }
                }
            }

            if (this.operationContext.LastResult != null && this.operationContext.LastResult.Exception != null)
            {
                this.LogTableStorageOperationError(
                    this.resourceUri, exceptionString, httpStatusCode, serviceRequestId, extendedInfoErrorCode, extendedInfoErrorMessage, contentLength, this.accountName);
            }
            else
            {
                this.LogTableStorageOperationCompletedInvoking(
                    this.resourceUri, string.Empty, (long)duration, httpStatusCode, serviceRequestId, contentLength, this.accountName);
            }
        }

        private void OperationContextSendingRequest(object sender, RequestEventArgs e)
        {
            if (!TracingAdapter.IsEnabled)
            {
                return;
            }

            long contentLength = e.Request != null ? e.Request.ContentLength : 0;
            this.LogTableStorageOperationInvoking(this.resourceUri, contentLength, this.accountName);
        }

        private void LogTableStorageOperationError(
            string tableUri, 
            string exception, 
            string httpStatusCode = default(string), 
            string serviceRequestId = default(string), 
            string errorCode = default(string), 
            string errorMessage = default(string), 
            long contentLength = default(long), 
            string storageAccountName = default(string))
        {
            string format = "For table '{0}, operation '{1}' found error '{2}', individualRequestId '{3}', httpStatusCode '{4}', serviceRequestId '{5}, errorCode '{6}, errorMessage '{7}', length '{8}', storage account '{9}'";
            
            string message = string.Format(
                CultureInfo.InvariantCulture, 
                format,
                tableUri,
                this.operationName,
                exception,
                this.requestId,
                httpStatusCode,
                serviceRequestId,
                errorCode,
                errorMessage,
                contentLength,
                storageAccountName);

            TracingAdapter.Information(message);
        }

        private void LogTableStorageOperationCompletedInvoking(
            string tableUri, 
            string result,
            long durationInMilliseconds, 
            string httpStatusCode = default(string),
            string serviceRequestId = default(string), 
            long contentLength = default(long),
            string storageAccountName = default(string))
        {
            string format = "For table '{0}', completed invoking operation '{1}' with result '{2}', individualRequestId '{3}', durationInMilliseconds '{4}', httpStatusCode '{5}, serviceRequestId '{6}', length '{7}', storage account '{8}'";
            
            string message = string.Format(
                CultureInfo.InvariantCulture,
                format,
                tableUri,
                this.operationName,
                result,
                this.requestId,
                durationInMilliseconds,
                httpStatusCode,
                serviceRequestId,
                contentLength,
                storageAccountName);

            TracingAdapter.Information(message);
        }

        private void LogTableStorageOperationInvoking(
            string tableUri, 
            long contentLength = default(long), 
            string storageAccountName = default(string))
        {
            string format = "For table '{0}', begin invoking operation '{1}', individualRequestId '{2}', length '{3}', storage account '{4}'";

            string message = string.Format(
                CultureInfo.InvariantCulture,
                format,
                tableUri,
                this.operationName,
                this.requestId,
                contentLength,
                storageAccountName);

            TracingAdapter.Information(message);
        }
    }
}
