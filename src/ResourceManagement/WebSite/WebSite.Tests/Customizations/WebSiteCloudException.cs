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
using System.Net.Http;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.WebSites
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

        //public new CloudHttpRequestErrorInfo Request { get; private set; }
        //public new CloudHttpResponseErrorInfo Response { get; private set; }

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

        //public WebSiteCloudException(
        //    string message,
        //    string code,
        //    Exception innerException)
        //    : base(message, innerException)
        //{
        //}

        /// <summary>
        /// Create a CloudException from a failed response.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="requestContent">The HTTP request content.</param>
        /// <param name="response">The HTTP response.</param>
        /// <param name="responseContent">The HTTP response content.</param>
        /// <param name="innerException">Optional inner exception.</param>
        /// <returns>A CloudException representing the failure.</returns>
        public static /*new*/ CloudException CreateResourceCloudExceptionTemporaryImplementation(
            HttpRequestMessage request,
            string requestContent,
            HttpResponseMessage response,
            string responseContent,
            Exception innerException = null)
        {
            Tuple<string, string> tuple = ParseResourceProviderJsonError(responseContent);
            string code = tuple.Item1;
            string message = tuple.Item2;

            // Get the most descriptive message that we can
            string exceptionMessage =
                (code != null && message != null) ? code + ": " + message :
                (message != null) ? message :
                (code != null) ? code :
                (responseContent != null) ? responseContent :
                (response != null && response.ReasonPhrase != null) ? response.ReasonPhrase :
                (response != null) ? response.StatusCode.ToString() :
                new InvalidOperationException().Message;

            // Create the exception
            CloudException exception = new WebSiteCloudException(
                exceptionMessage,
                innerException);
            return exception;

        }

        private static Tuple<string, string> ParseResourceProviderJsonError(string content)
        {
            //{"error":{"code":"InvalidResourceType","message":"The ResourceType is invalid."}}
            string code = null;
            string message = null;

            if (content != null)
            {
                try
                {
                    JObject response = JObject.Parse(content);
                    if (response != null)
                    {
                        JToken error = response["error"];
                        if (error != null)
                        {
                            code = (string)error["code"];
                            message = (string)error["message"];

                            // target
                            // details: code, target, message
                            // innererror: trace, context
                            // TODO: see: Resource Group Manager API spec!!!
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
    }
}
