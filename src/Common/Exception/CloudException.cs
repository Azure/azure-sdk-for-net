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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Exception thrown for any invalid response.
    /// </summary>
    public class CloudException : Exception
    {
        /// <summary>
        /// Gets the error message returned from the server.
        /// </summary>
        /// <remarks>
        /// This is included by default in the Message property.
        /// </remarks>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets the error code returned from the server.
        /// </summary>
        /// <remarks>
        /// This is included by default in the Message property.
        /// </remarks>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public CloudHttpRequestErrorInfo Request { get; protected set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public CloudHttpResponseErrorInfo Response { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public CloudException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CloudException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Create a CloudException from a failed response.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="defaultTo">The content type to default to if none of the types matches.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static CloudException Create(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            CloudExceptionType defaultTo,
            Exception innerException = null)
        {
            if (response.Content != null && response.Content.Headers.ContentType != null)
            {
                if (response.Content.Headers.ContentType.MediaType.Equals("application/json") ||
                    response.Content.Headers.ContentType.MediaType.Equals("text/json"))
                {
                    return CreateFromJson(request, requestContent, response, responseContent, innerException);
                } 
                else if (response.Content.Headers.ContentType.MediaType.Equals("application/xml") ||
                       response.Content.Headers.ContentType.MediaType.Equals("text/xml"))
                {
                    return CreateFromXml(request, requestContent, response, responseContent, innerException);
                }
            }

            if (defaultTo == CloudExceptionType.Json)
            {
                return CreateFromJson(request, requestContent, response, responseContent, innerException);
            }
            else
            {
                return CreateFromXml(request, requestContent, response, responseContent, innerException);
            }
        }
 
        /// <summary>
        /// Create a CloudException from a failed response sending XML content.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static CloudException CreateFromXml(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException = null)
        {
            return Create(
                request,
                requestContent,
                response,
                responseContent,
                innerException,
                ParseXmlError);
        }

        /// <summary>
        /// Create a CloudException from a failed response sending JSON content.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static CloudException CreateFromJson(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException = null)
        {
            return Create(
                request,
                requestContent,
                response,
                responseContent,
                innerException,
                ParseJsonError);
        }

        /// <summary>
        /// Create a CloudException from a failed response.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <param name="parseError">
        /// Function to parse the response content and return the error code
        /// and error message as a Tuple.
        /// </param>
        /// <returns>A CloudException representing the failure.</returns>
        private static CloudException Create(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException,
            Func<string, Tuple<string, string>> parseError)
        {
            // Get the error code and message
            Tuple<string, string> tuple = parseError(responseContent);
            string code = tuple.Item1;
            string message = tuple.Item2;
            
            // Get the most descriptive message that we can
            string exceptionMessage =
                (code != null && message != null) ? code + ": " + message :
                (message != null) ? message :
                (code != null) ? code :
                !string.IsNullOrEmpty(responseContent) ? responseContent :
                (response != null && response.ReasonPhrase != null) ? response.ReasonPhrase :
                (response != null) ? response.StatusCode.ToString() :
                new InvalidOperationException().Message;

            // Create the exception
            CloudException exception = new CloudException(exceptionMessage, innerException);
            exception.ErrorCode = code;
            exception.ErrorMessage = message;
            exception.Request = CloudHttpRequestErrorInfo.Create(request, requestContent);
            exception.Response = CloudHttpResponseErrorInfo.Create(response, responseContent);

            return exception;
        }

        /// <summary>
        /// Parse the response content as an XML error message.
        /// </summary>
        /// <param name="content">The response content.</param>
        /// <returns>
        /// A tuple containing the parsed error code and message.
        /// </returns>
        private static Tuple<string, string> ParseXmlError(string content)
        {
            string code = null;
            string message = null;

            if (content != null)
            {
                try
                {
                    XElement root = XDocument.Parse(content).Root;
                    foreach (XElement element in root.Elements())
                    {
                        // Check local names only because some services will
                        // use different namespaces or no namespace at all
                        if (element.Name.LocalName == "Code")
                        {
                            code = element.Value;
                        }
                        else if (element.Name.LocalName == "Message")
                        {
                            message = element.Value;
                        }
                    }
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            return Tuple.Create(code, message);
        }

        /// <summary>
        /// Parse the response content as an JSON error message.
        /// </summary>
        /// <param name="content">The response content.</param>
        /// <returns>
        /// A tuple containing the parsed error code and message.
        /// </returns>
        private static Tuple<string, string> ParseJsonError(string content)
        {
            string code = null;
            string message = null;

            if (content != null)
            {
                try
                {
                    JObject response = JObject.Parse(content);
                    code = response.GetValue("Code", StringComparison.CurrentCultureIgnoreCase).ToString();
                    message = response.GetValue("Message", StringComparison.CurrentCultureIgnoreCase).ToString();
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            return Tuple.Create(code, message);
        }
    }
}
