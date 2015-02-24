// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

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
        public CloudException(string message, CloudError errorModel, Exception innerException = null) : 
            this(message, innerException)
        {
            Body = errorModel;
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
                if (TryParseErrorModel(responseContent, out errorModel))
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
                exception.Request = request;
            }

            if (response != null)
            {
                exception.Response = response;
            }

            exception.Body = errorModel;
            return exception;
        }

        /// <summary>
        /// Try to parse an error response body as Json or Xml.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <param name="errorModel">The model, if parsing is successful.</param>
        /// <returns>True if the model was successfully parsed, otherwise false</returns>
        private static bool TryParseErrorModel(string responseContent, out CloudError errorModel)
        {
            return TryParseJsonModel(responseContent, out errorModel)
                || TryParseXmlModel(responseContent, out errorModel);
        }

        /// <summary>
        /// Try to parse an error response body as Json.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <param name="errorModel">The model, if parsing was successful.</param>
        /// <returns>True if the content was successfully parsed, otherwise false.</returns>
        private static bool TryParseJsonModel(string responseContent, out CloudError errorModel)
        {
            try
            {
                var jsonToken = JToken.Parse(responseContent);
                errorModel = new CloudError();
                errorModel.DeserializeJson(jsonToken);
                return true;
            }
            catch (Exception)
            {
            }

            errorModel = new CloudError();
            return false;
        }

        /// <summary>
        /// Try to parse an error response body as Xml.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <param name="errorModel">The model, if parsing was successful.</param>
        /// <returns>True if the content was successfully parsed, otherwise false.</returns>
        private static bool TryParseXmlModel(string responseContent, out CloudError errorModel)
        {
            try
            {
                var xmlDocument = System.Xml.Linq.XDocument.Parse(responseContent);
                errorModel = new CloudError();
                errorModel.DeserializeXml(xmlDocument);
                return true;
            }
            catch (Exception)
            {
            }

            errorModel = new CloudError();
            return false;
        }
    }
}
