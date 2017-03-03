// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Hyak.Common;
using Hyak.Common.Internals;
using Newtonsoft.Json.Linq;

namespace Hyak.Common
{
    /// <summary>
    /// Exception thrown for any invalid response.
    /// </summary>
    public class CloudException : Exception
    {
        /// <summary>
        /// Gets the error returned from the server.
        /// </summary>
        public CloudError Error { get; set; }

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
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static CloudException Create(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException = null)
        {
            // Get the error code and message
            CloudError cloudError = ParseXmlOrJsonError(responseContent);
            string code = cloudError.Code;
            string message = cloudError.Message;

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
            exception.Error = cloudError;
            exception.Request = CloudHttpRequestErrorInfo.Create(request, requestContent);
            exception.Response = CloudHttpResponseErrorInfo.Create(response, responseContent);

            return exception;
        }

        /// <summary>
        /// Create a CloudException from a failed response.
        /// This method is obsolete. Use Create without defaultTo parameter.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="defaultTo">The content type to default to if none of the types matches.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        [Obsolete("This method is obsolete. Use Create without defaultTo parameter.")]
        public static CloudException Create(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            CloudExceptionType defaultTo,
            Exception innerException = null)
        {
            return Create(request, requestContent, response, responseContent, innerException);
        }

        /// <summary>
        /// Create a CloudException from a failed response sending XML content.
        /// This method is obsolete. Use Create without defaultTo parameter.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        [Obsolete("This method is obsolete. Use Create without defaultTo parameter.")]
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
                innerException);
        }

        /// <summary>
        /// Create a CloudException from a failed response sending JSON content.
        /// This method is obsolete. Use Create without defaultTo parameter.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        [Obsolete("This method is obsolete. Use Create without defaultTo parameter.")]
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
                innerException);
        }

        /// <summary>
        /// Parse the response content as either an XML or JSON error message.
        /// </summary>
        /// <param name="content">The response content.</param>
        /// <returns>
        /// An object containing the parsed error code and message.
        /// </returns>
        public static CloudError ParseXmlOrJsonError(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new CloudError {OriginalMessage = content};
            }
            else
            {
                if (CloudException.IsJson(content))
                {
                    return ParseJsonError(content);
                } 
                else if (CloudException.IsXml(content))
                {
                    return ParseXmlError(content);
                }
                else
                {
                    return new CloudError { OriginalMessage = content };
                }
            }
        }

        /// <summary>
        /// Parse the response content as an XML error message.
        /// </summary>
        /// <param name="content">The response content.</param>
        /// <returns>
        /// An object containing the parsed error code and message.
        /// </returns>
        public static CloudError ParseXmlError(string content)
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
                        if ("Code".Equals(element.Name.LocalName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            code = element.Value;
                        }
                        else if ("Message".Equals(element.Name.LocalName, StringComparison.CurrentCultureIgnoreCase))
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

            return new CloudError { Code = code, Message = message, OriginalMessage = content };
        }

        /// <summary>
        /// Parse the response content as an JSON error message.
        /// </summary>
        /// <param name="content">The response content.</param>
        /// <returns>
        /// An object containing the parsed error code and message.
        /// </returns>
        public static CloudError ParseJsonError(string content)
        {
            string code = null;
            string message = null;

            if (content != null)
            {
                try
                {
                    var response = JObject.Parse(content);
                    
                    if (response.GetValue("error", StringComparison.CurrentCultureIgnoreCase) != null)
                    {
                        var errorToken =
                            response.GetValue("error", StringComparison.CurrentCultureIgnoreCase) as JObject;
                        message = errorToken.GetValue("message", StringComparison.CurrentCultureIgnoreCase).ToString();
                        code = errorToken.GetValue("code", StringComparison.CurrentCultureIgnoreCase).ToString();
                    }
                    else
                    {
                        message = response.GetValue("message", StringComparison.CurrentCultureIgnoreCase).ToString();
                        code = response.GetValue("code", StringComparison.CurrentCultureIgnoreCase).ToString();
                    }
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            return new CloudError { Code = code, Message = message, OriginalMessage = content };
        }

        /// <summary>
        /// Checks if content is possibly an XML.
        /// </summary>
        /// <param name="content">String to check.</param>
        /// <param name="validate">If set to true will validate entire XML for validity 
        /// otherwise will just check the first character.</param>
        /// <returns>True is content is possibly an XML otherwise false.</returns>
        public static bool IsXml(string content, bool validate = false)
        {
            var firstCharacter = FirstNonWhitespaceCharacter(content);
            if (!validate)
            {
                return firstCharacter == '<';
            }
            else
            {
                if (firstCharacter != '<')
                {
                    return false;
                }

                try
                {
                    XDocument.Parse(content);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks if content is possibly a JSON.
        /// </summary>
        /// <param name="content">String to check.</param>
        /// <param name="validate">If set to true will validate entire JSON for validity 
        /// otherwise will just check the first character.</param>
        /// <returns>True is content is possibly an JSON otherwise false.</returns>
        public static bool IsJson(string content, bool validate = false)
        {
            var firstCharacter = FirstNonWhitespaceCharacter(content);
            if (!validate)
            {
                return firstCharacter == '{';
            }
            else
            {
                if (firstCharacter != '{')
                {
                    return false;
                }

                try
                {
                    JObject.Parse(content);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns first non whitespace character
        /// </summary>
        /// <param name="content">Text to search in</param>
        /// <returns>Non whitespace or default char</returns>
        private static char FirstNonWhitespaceCharacter(string content)
        {
            if (content != null)
            {
                content = content.Trim();
            }

            return string.IsNullOrEmpty(content) ? default(char) : content[0];
        }
    }
}
