// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// PathContentInfo
    /// </summary>
    public class PathContentInfo
    {
        /// <summary>
        /// An hash of the request content. This header is only returned for "Flush" operation.
        /// This header is returned so that the client can check for message content integrity.
        /// This header refers to the content of the request, not actual file content.
        /// </summary>
        public string ContentHash { get; internal set; }

        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified
        /// Write operations on the file or directory update the last modified time.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// If the Content-Disposition request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Content-Language request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the file by
        /// setting the Range request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The content type specified for the resource. If no content type was specified, the default content
        /// type is application/octet-stream.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Metadata for the path
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathContentInfo instances.
        /// You can use DataLakeModelFactory.PathContentInfo instead.
        /// </summary>
        internal PathContentInfo() { }
    }
}
