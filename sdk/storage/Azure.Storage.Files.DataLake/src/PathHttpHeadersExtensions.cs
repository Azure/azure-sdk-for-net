// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class PathHttpHeadersExtensions
    {
        internal static BlobHttpHeaders ToBlobHttpHeaders(this PathHttpHeaders pathHttpHeaders) =>
             new BlobHttpHeaders()
             {
                 ContentType = pathHttpHeaders.ContentType,
                 ContentHash = pathHttpHeaders.ContentHash,
                 ContentEncoding = new string[] { pathHttpHeaders.ContentEncoding },
                 ContentLanguage = new string[] { pathHttpHeaders.ContentLanguage },
                 ContentDisposition = pathHttpHeaders.ContentDisposition,
                 CacheControl = pathHttpHeaders.CacheControl
             };
    }
}
