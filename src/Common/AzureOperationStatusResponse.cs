// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class AzureOperationStatusResponse<T> : AzureOperationResponse<T>
    {
        /// <summary>
        /// If the asynchronous operation failed, the response body includes
        /// the HTTP status code for the failed request, and also includes
        /// error information regarding the failure.
        /// </summary>
        public CloudError Error { get; set; }
        
        /// <summary>
        /// The HTTP status code for the asynchronous request.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
        
        /// <summary>
        /// The request ID of the asynchronous request. This value is returned
        /// in the x-ms-request-id response header of the asynchronous request.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The status of the asynchronous request.
        /// </summary>
        public OperationStatus Status { get; set; }
    }
}
