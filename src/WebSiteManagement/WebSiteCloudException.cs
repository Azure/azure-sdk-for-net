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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Common;

namespace Microsoft.WindowsAzure.Management.WebSites
{
    /// <summary>
    /// Exception thrown for any invalid response from a WebSite operation.
    /// </summary>
    public class WebSiteCloudException
        : CloudException
    {
        /// <summary>
        /// Gets an extended error code that is a numeric value unique to this
        /// error type. For a list of extended codes, see
        /// WebSiteExtendedErrorCodes.
        /// </summary>
        public string ExtendedErrorCode { get; protected set; }

        /// <summary>
        /// Gets a template of the actual message presented to the user, with
        /// place holders that are filled with information from the Parameters
        /// element.
        /// </summary>
        public string ErrorMessageFormat { get; protected set; }

        /// <summary>
        /// A container for strings that fill the place holders in the message
        /// template. These strings contain information unique to the user's
        /// scenario.
        /// </summary>
        public IList<string> ErrorMessageArguments { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the WebSiteCloudException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public WebSiteCloudException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the WebSiteCloudException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public WebSiteCloudException(string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorMessageArguments = new List<string>();
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
        public static new CloudException CreateFromXml(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException = null)
        {
            string code = null;
            string message = null;
            string extendedErrorCode = null;
            string errorMessageFormat = null;
            List<string> errorMessageArguments = null;

            if (responseContent != null)
            {
                try
                {
                    XElement root = XDocument.Parse(responseContent).Root;

                    XElement codeElement = root.Element(XName.Get("Code", "http://schemas.microsoft.com/windowsazure"));
                    if (codeElement != null)
                    {
                        code = codeElement.Value;
                    }

                    XElement messageElement = root.Element(XName.Get("Message", "http://schemas.microsoft.com/windowsazure"));
                    if (messageElement != null)
                    {
                        message = messageElement.Value;
                    }

                    XElement extendedCodeElement = root.Element(XName.Get("ExtendedCode", "http://schemas.microsoft.com/windowsazure"));
                    if (extendedCodeElement != null)
                    {
                        extendedErrorCode = extendedCodeElement.Value;
                    }

                    XElement messageTemplateElement = root.Element(XName.Get("MessageTemplate", "http://schemas.microsoft.com/windowsazure"));
                    if (messageTemplateElement != null)
                    {
                        errorMessageFormat = messageTemplateElement.Value;
                    }

                    XElement parametersElement = root.Element(XName.Get("Parameters", "http://schemas.microsoft.com/windowsazure"));
                    if (parametersElement != null)
                    {
                        errorMessageArguments =
                            parametersElement
                            .Elements(XName.Get("string", "http://schemas.microsoft.com/2003/10/Serialization/Arrays"))
                            .Select(e => e.Value)
                            .ToList();
                    }
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            // Get the exception message
            string exceptionMessage = null;
            if (code != null || message != null || extendedErrorCode != null)
            {                
                StringBuilder text = new StringBuilder();
                if (code != null)
                {
                    text.Append(code);
                }
                if (extendedErrorCode != null)
                {
                    text.AppendFormat(
                        code != null ? " ({0})" : "{0}",
                        extendedErrorCode);
                }
                if (code != null || extendedErrorCode != null && message != null)
                {
                    text.Append(": ");
                }
                if (message != null)
                {
                    text.Append(message);
                }
                exceptionMessage = text.ToString();
            }
            else
            {
                // Otherwise use the best default that we can come up with
                exceptionMessage =
                    (responseContent != null) ? responseContent :
                    (response != null && response.ReasonPhrase != null) ? response.ReasonPhrase :
                    (response != null) ? response.StatusCode.ToString() :
                    new InvalidOperationException().Message;
            }

            // Create the exception
            WebSiteCloudException exception = new WebSiteCloudException(exceptionMessage, innerException);
            exception.ErrorCode = code;
            exception.ErrorMessage = message;
            exception.Request = CloudHttpRequestErrorInfo.Create(request, requestContent);
            exception.Response = CloudHttpResponseErrorInfo.Create(response, responseContent);
            exception.ExtendedErrorCode = extendedErrorCode;
            exception.ErrorMessageFormat = errorMessageFormat;
            exception.ErrorMessageArguments = errorMessageArguments ?? new List<string>();

            return exception;
        }
    }
}
