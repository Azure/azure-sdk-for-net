// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// A standard service response including request ID.
    /// </summary>
    public interface IAzureOperationResponse : IHttpOperationResponse
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        string RequestId { get; set; }
    }

    /// <summary>
    /// A standard service response including request ID.
    /// </summary>
    public class AzureOperationResponse : HttpOperationResponse, IAzureOperationResponse
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
    public class AzureOperationResponse<T> : HttpOperationResponse<T>, IAzureOperationResponse
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }
    }

    public class AzureOperationHeaderResponse<THeader> : HttpOperationHeaderResponse<THeader>, IAzureOperationResponse
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
    public class AzureOperationResponse<TBody, THeader> : HttpOperationResponse<TBody, THeader>, IAzureOperationResponse
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }
    }
}