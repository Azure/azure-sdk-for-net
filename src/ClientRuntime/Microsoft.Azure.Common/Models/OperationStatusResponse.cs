// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Net;

namespace Microsoft.Azure
{
    /// <summary>
    /// The response body contains the status of the specified
    /// asynchronous operation, indicating whether it has succeeded, is i
    /// progress, or has failed. Note that this status is distinct from the
    /// HTTP status code returned for the Get Operation Status operation
    /// itself.  If the asynchronous operation succeeded, the response body
    /// includes the HTTP status code for the successful request.  If the
    /// asynchronous operation failed, the response body includes the HTTP
    /// status code for the failed request, and also includes error
    /// information regarding the failure.
    /// </summary>
    public class OperationStatusResponse : AzureOperationResponse
    {
        private OperationStatusResponse.ErrorDetails _error;
        
        /// <summary>
        /// If the asynchronous operation failed, the response body includes
        /// the HTTP status code for the failed request, and also includes
        /// error information regarding the failure.
        /// </summary>
        public OperationStatusResponse.ErrorDetails Error
        {
            get { return this._error; }
            set { this._error = value; }
        }
        
        private HttpStatusCode _httpStatusCode;
        
        /// <summary>
        /// The HTTP status code for the asynchronous request.
        /// </summary>
        public HttpStatusCode HttpStatusCode
        {
            get { return this._httpStatusCode; }
            set { this._httpStatusCode = value; }
        }
        
        private string _id;
        
        /// <summary>
        /// The request ID of the asynchronous request. This value is returned
        /// in the x-ms-request-id response header of the asynchronous request.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private OperationStatus _status;
        
        /// <summary>
        /// The status of the asynchronous request.
        /// </summary>
        public OperationStatus Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        /// <summary>
        /// If the asynchronous operation failed, the response body includes
        /// the HTTP status code for the failed request, and also includes
        /// error information regarding the failure.
        /// </summary>
        public partial class ErrorDetails
        {
            private string _code;
            
            /// <summary>
            /// The management service error code returned if the asynchronous
            /// request failed.
            /// </summary>
            public string Code
            {
                get { return this._code; }
                set { this._code = value; }
            }
            
            private string _message;
            
            /// <summary>
            /// The management service error message returned if the
            /// asynchronous request failed.
            /// </summary>
            public string Message
            {
                get { return this._message; }
                set { this._message = value; }
            }
            
            /// <summary>
            /// Initializes a new instance of the ErrorDetails class.
            /// </summary>
            public ErrorDetails()
            {
            }
        }
    }
}
