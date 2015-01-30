// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.Net.Http;

namespace Microsoft.Azure
{
    /// <summary>
    /// An exception generated from an http response error message returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : HttpOperationException<CloudError>
    {
        /// <summary>
        /// Create a Cloud Exception with the given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message)
        {
        }

        /// <summary>
        /// Create a Cloud Exception caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Create a Cloud Exception with a given exception message and existing error model.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="errorModel">The model for the error response body.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, CloudError errorModel, Exception innerException = null) : this(message, innerException)
        {
            Model = errorModel;
        }

        /// <summary>
        /// Create a new CloudException using the given exception details
        /// </summary>
        /// <param name="request">The request message that generated the http error response</param>
        /// <param name="requestContent">The request body of the http request message as a string</param>
        /// <param name="response">The http error response returned by the Microsoft Azure service</param>
        /// <param name="responseContent">The response body of the http error response</param>
        /// <param name="innerException">The exception which caused this exception, if any</param>
        /// <returns>A new CloudException instance with the given details</returns>
        public static new CloudException Create(HttpRequestMessage request, string requestContent,
            HttpResponseMessage response,
            string responseContent, Exception innerException = null)
        {
            string exceptionMessage;
            CloudError errorModel = null;
            if (!string.IsNullOrEmpty(responseContent))
            {
                if (HttpOperationException<CloudError>.TryParseErrorModel(responseContent, out errorModel))
                {
                    if (!string.IsNullOrEmpty(errorModel.Code) && !string.IsNullOrEmpty(errorModel.Message))
                    {
                        exceptionMessage = string.Format("{0}: {1}", errorModel.Code, errorModel.Message);
                    }
                    else
                    {
                        exceptionMessage = errorModel.Code ?? errorModel.Message;
                    }
                }
                else
                {
                    exceptionMessage = responseContent;
                }
            }
            else if (response != null && response.ReasonPhrase != null)
            {
                exceptionMessage = response.ReasonPhrase;
            }
            else
            {
                exceptionMessage = new InvalidOperationException().Message;
            }

            // Create the exception
            var exception = new CloudException(exceptionMessage, innerException);
            if (request != null)
            {
                exception.Request = HttpRequestErrorInfo.Create(request, requestContent);
            }

            if (response != null)
            {
                exception.Response = HttpResponseErrorInfo.Create(response, responseContent);
            }

            exception.Model = errorModel;
            return exception;
        }

        /// <summary>
        /// Create a CloudException from a response string.
        /// </summary>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static new CloudException Create(
            string responseContent,
            Exception innerException = null)
        {
            return Create(null, null, null, responseContent, innerException);
        }
    }
}
