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

using Hyak.Common;
using System;
using System.Net.Http;

namespace Microsoft.Azure
{
    public class CloudException : HttpOperationException<CloudError>
    {
        public CloudException(string message) : base(message)
        {
        }

        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static new CloudException Create(HttpRequestMessage request, string requestContent,
            HttpResponseMessage response,
            string responseContent, Exception innerException = null)
        {
            CloudError error;
            string exceptionMessage;
            if (CloudError.TryParseJsonOrXml(responseContent, out error))
            {
                exceptionMessage = error.Code + ": " + error.Message;
            }
            else if (!string.IsNullOrEmpty(responseContent))
            {
                exceptionMessage = responseContent;
            }
            else
            {
                if (response != null && response.ReasonPhrase != null)
                {
                    exceptionMessage = response.ReasonPhrase;
                }
                else if (response != null)
                {
                    exceptionMessage = response.StatusCode.ToString();
                }
                else
                {
                    exceptionMessage = new InvalidOperationException().Message;
                }
            }

            var exception = new CloudException(exceptionMessage, innerException);
            if (request != null)
            {
                exception.Request = HttpRequestErrorInfo.Create(request, requestContent);
            }

            if (response != null)
            {
                exception.Response = HttpResponseErrorInfo.Create(response, responseContent);
            }

            exception.Model = error;

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
