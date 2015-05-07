// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System.Net.Http;

namespace Microsoft.Azure
{
    /// <summary>
    /// A standard service response including request ID.
    /// </summary>
    public class AzureOperationResponse<T> : HttpOperationResponse<T>
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }
    }

    /// <summary>
    /// A standard service response including request ID.
    /// </summary>
    public class AzureOperationResponse : HttpOperationResponse
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }
    }
}