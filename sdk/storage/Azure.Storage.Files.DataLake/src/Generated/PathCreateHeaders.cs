// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace Azure.Storage.Files.DataLake
{
    internal partial class PathCreateHeaders
    {
        private readonly Response _response;
        public PathCreateHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time. </summary>
        public DateTimeOffset? LastModified => _response.Headers.TryGetValue("Last-Modified", out DateTimeOffset? value) ? value : null;
        /// <summary> The version of the REST protocol used to process the request. </summary>
        public string Version => _response.Headers.TryGetValue("x-ms-version", out string value) ? value : null;
        /// <summary> When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory. </summary>
        public string Continuation => _response.Headers.TryGetValue("x-ms-continuation", out string value) ? value : null;
        /// <summary> The size of the resource in bytes. </summary>
        public long? ContentLength => _response.Headers.TryGetValue("Content-Length", out long? value) ? value : null;
    }
}
