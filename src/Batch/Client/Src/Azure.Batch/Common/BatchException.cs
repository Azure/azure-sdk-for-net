// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Protocol.Models;
    using BatchError = Batch.BatchError;

    /// <summary>
    /// Represents an exception for the Windows Azure Batch service.
    /// </summary>
    public class BatchException : Exception
    {
        /// <summary>
        /// Gets information about the request which failed.
        /// </summary>
        public RequestInformation RequestInformation { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchException"/> class by using the specified parameters.
        /// </summary>
        /// <param name="requestInformation">A <see cref="RequestInformation"/> object containing details about the request.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public BatchException(RequestInformation requestInformation, string message, Exception inner)
            : base(message, inner)
        {
            this.RequestInformation = requestInformation;
        }

        private static string TryGetSingleHeaderOrDefault(string headerName, IDictionary<string, IEnumerable<string>> headers)
        {
            string result = null;
            
            if (headers.ContainsKey(headerName))
            {
                if (headers[headerName] != null)
                {
                    result = headers[headerName].FirstOrDefault();
                }
            }

            return result;
        }

        /// <summary>
        /// Constructs a <see cref="BatchException"/> as a wrapper for a <see cref="BatchErrorException"/>.
        /// </summary>
        /// <param name="batchErrorException">The exception to wrap.</param>
        internal BatchException(BatchErrorException batchErrorException) : base(batchErrorException.Message, batchErrorException)
        {
            //Process client request id header
            string clientRequestIdString = TryGetSingleHeaderOrDefault(InternalConstants.ClientRequestIdHeader, batchErrorException.Response.Headers);

            //Process request id header
            string requestIdString = TryGetSingleHeaderOrDefault(InternalConstants.RequestIdHeader, batchErrorException.Response.Headers);

            this.RequestInformation = new RequestInformation()
                {
                    BatchError = batchErrorException.Body == null ? null : new BatchError(batchErrorException.Body),
                    ClientRequestId = string.IsNullOrEmpty(clientRequestIdString) ? default(Guid?) : new Guid(clientRequestIdString),
                    HttpStatusCode = batchErrorException.Response.StatusCode,
                    HttpStatusMessage = batchErrorException.Response.ReasonPhrase, //TODO: Is this right?
                    ServiceRequestId = requestIdString
                };
        }

        /// <summary>
        /// Generates a string which describes the exception.
        /// </summary>
        /// <returns>A string that represents the exception.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            if (this.RequestInformation != null)
            {
                sb.AppendLine("Request Information");
                sb.AppendLine("ClientRequestId:" + this.RequestInformation.ClientRequestId);
                //if (this.RequestInformation.ServiceUri != null)
                //{
                //    sb.AppendLine("ServiceUrl:" + this.RequestInformation.ServiceUri.ToString());
                //}
                sb.AppendLine("RequestId:" +  this.RequestInformation.ServiceRequestId);
                //sb.AppendLine("RequestDate:" + this.RequestInformation.RequestDate); //TODO: How to get this field?
                sb.AppendLine("HttpStatusCode:" + this.RequestInformation.HttpStatusCode);
                sb.AppendLine("StatusMessage:" + this.RequestInformation.HttpStatusMessage);

                if (this.RequestInformation.BatchError != null)
                {
                    sb.AppendFormat("\n\nError Code = {0},",
                        this.RequestInformation.BatchError.Code);
                    if (this.RequestInformation.BatchError.Message != null)
                    {
                        sb.AppendFormat(" Lang={0}, Message = {1}\nAdditional Values:\n",
                            this.RequestInformation.BatchError.Message.Language,
                            this.RequestInformation.BatchError.Message.Value);
                    }

                    if (this.RequestInformation.BatchError.Values != null)
                    {
                        foreach (var item in this.RequestInformation.BatchError.Values)
                        {
                            sb.AppendFormat("Error Details key={0} value={1}\n",
                                item.Key,
                                item.Value);
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}