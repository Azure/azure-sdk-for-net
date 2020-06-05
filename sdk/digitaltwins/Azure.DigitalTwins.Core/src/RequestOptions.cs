// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// General request options that are applicable, but optional, for many APIs.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// An Etag object for the entity that this request performs an operation against, as per RFC7232. The request's operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the entity has not been modified since it was last retrieved.
        /// To force the operation to execute only if the entity exists, set the ETag to the wildcard character '*'. <code>new Etag("*")</code>. To force the operation to execute unconditionally, leave this value null.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/azure.etag?view=azure-dotnet">
        /// See the documentation for Etag.
        /// </see>
        /// <remarks>
        /// If this value is not set, it defaults to null, and the ifMatch header will not be sent with the request. This means that update and delete will be unconditional and the operation will execute regardless of the existence of the resource.
        /// </remarks>
        public ETag? IfMatch { get; set; }
    }
}
