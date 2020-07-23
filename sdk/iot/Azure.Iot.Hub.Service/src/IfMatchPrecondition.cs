// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// The condition on which an operation will be executed against a service resource. Each value maps to a possible use of the If-Match header. The If-Match header is described in RFC7232.
    /// </summary>
    public enum IfMatchPrecondition
    {
        /// <summary>
        /// Perform this operation as long as the provided resource exists in the service. This will cause the HTTP request to be sent with an ifMatch header with value "*". For create or update
        /// operations, if the resource does not exist, then the service will not execute the operation and will respond to the request with a 412 error code. For delete operations, if the resource
        /// does not exist, then the service will respond to the request with a 412 status code.
        /// </summary>
        UnconditionalIfMatch,

        /// <summary>
        /// Perform this operation only if the resource exists in the service, and the provided resource's ETag
        /// matches the service's ETag. This enum will cause the HTTP request to be sent with an ifMatch header with value equal to the provided resource's ETag.
        /// If the request's provided ETag is out of date, or incorrect, the service will not carry out this operation and will respond to the reqeust with a 412 error code.
        /// In order to get the latest ETag for a resource, get the resource from the service.
        /// </summary>
        IfMatch
    }
}
