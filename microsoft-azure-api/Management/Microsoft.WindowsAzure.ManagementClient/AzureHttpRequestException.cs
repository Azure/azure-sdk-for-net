//-----------------------------------------------------------------------
// <copyright file="AzureHttpRequestException.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the AzureHttpRequestException class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// An exception used to capture additional error information
    /// from Azure API calls.
    /// </summary>
    [Serializable]
    public class AzureHttpRequestException : HttpRequestException
    {
        private AzureHttpRequestException() { }
        private AzureHttpRequestException(string message): base(message) { }
        private AzureHttpRequestException(string message, Exception inner) : base(message, inner) { }

        internal AzureHttpRequestException(HttpResponseMessage response)
        {
            this.RequestUri = response.RequestMessage.RequestUri;

            this.StatusCode = response.StatusCode;
            try
            {
                ErrorInfo info = response.Content.ReadAsSync<ErrorInfo>(new XmlMediaTypeFormatter { UseXmlSerializer = false });
                this.AzureErrorInfo = info;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Constructor used to extract error information from a failed OperationStatusInfo
        /// </summary>
        /// <param name="statusInfo"></param>
        public AzureHttpRequestException(OperationStatusInfo statusInfo)
        {
            this.StatusCode = statusInfo.HttpStatusCode.Value;

            this.AzureErrorInfo = statusInfo.ErrorInfo;

        }

        /// <summary>
        /// Override to return extended error information returned from Windows Azure
        /// </summary>
        public override string Message
        {
            get
            {
                if (_message == null)
                {
                    ConstructMessage();
                }
                return _message;
            }
        }

        /// <summary>
        /// The <see cref="Uri"/> of failed request.
        /// </summary>
        public Uri RequestUri { get; private set; } 

        /// <summary>
        /// The status code returned from the failed request
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Azure error info returned in the response of the failed request.
        /// </summary>
        public ErrorInfo AzureErrorInfo
        {
            get;
            private set;
        }

        private void ConstructMessage()
        {
            string message = string.Format(Resources.AzureRequestExceptionBaseMessage, RequestUri, (int)StatusCode, StatusCode.ToString());
            if (AzureErrorInfo != null)
            {
                message = message + string.Format(Resources.AzureRequestExceptionAdditionalInfo, AzureErrorInfo.Code, AzureErrorInfo.Message);
            }

            _message = message;
        }

        private string _message;
    }
}
