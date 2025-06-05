// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Compute.Batch.Custom
{
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
        /*
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

            //Process retry-after header
            string retryAfterString = TryGetSingleHeaderOrDefault(InternalConstants.RetryAfterHeader, batchErrorException.Response.Headers);
            var retryAfter = ExtractRetryAfterHeader(retryAfterString);

            this.RequestInformation = new RequestInformation()
            {
                BatchError = batchErrorException.Body == null ? null : new BatchError(batchErrorException.Body),
                ClientRequestId = string.IsNullOrEmpty(clientRequestIdString) ? default(Guid?) : new Guid(clientRequestIdString),
                HttpStatusCode = batchErrorException.Response.StatusCode,
                HttpStatusMessage = batchErrorException.Response.ReasonPhrase, //TODO: Is this right?
                ServiceRequestId = requestIdString,
                RetryAfter = retryAfter
            };
        }
       */

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
                sb.AppendLine("RequestId:" + this.RequestInformation.ServiceRequestId);
                //sb.AppendLine("RequestDate:" + this.RequestInformation.RequestDate); //TODO: How to get this field?
                sb.AppendLine("HttpStatusCode:" + this.RequestInformation.HttpStatusCode);
                sb.AppendLine("StatusMessage:" + this.RequestInformation.HttpStatusMessage);

                if (this.RequestInformation.BatchError != null)
                {
                    sb.Append($"\n\nError Code = {this.RequestInformation.BatchError.Code},");
                    if (this.RequestInformation.BatchError.Message != null)
                    {
                        sb.Append($" Lang={this.RequestInformation.BatchError.Message.Lang}, Message = {this.RequestInformation.BatchError.Message.Value}\nAdditional Values:\n");
                    }

                    if (this.RequestInformation.BatchError.Values != null)
                    {
                        foreach (var item in this.RequestInformation.BatchError.Values)
                        {
                            sb.Append($"Error Details key={item.Key} value={item.Value}\n");
                        }
                    }
                }
            }

            return sb.ToString();
        }

        private static TimeSpan? ExtractRetryAfterHeader(string retryAfterHeader)
        {
            TimeSpan? retryAfter = null;
            if (!string.IsNullOrEmpty(retryAfterHeader))
            {
                int retryAfterSeconds;
                bool parsed = int.TryParse(retryAfterHeader, out retryAfterSeconds);
                if (parsed)
                {
                    retryAfter = TimeSpan.FromSeconds(retryAfterSeconds);
                }
                else
                {
                    // Try RFC1123 format
                    DateTime retryAfterDate;
                    parsed = DateTime.TryParse(retryAfterHeader, out retryAfterDate);
                    if (parsed)
                    {
                        DateTime now = DateTime.UtcNow;
                        retryAfterDate = retryAfterDate.ToUniversalTime();
                        retryAfter = now >= retryAfterDate ? TimeSpan.Zero : retryAfterDate.Subtract(DateTime.UtcNow);
                    }
                }
            }

            return retryAfter;
        }
    }
}
