// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    /// <summary>
    /// Tracks which function wrote each blob via blob metadata.
    /// </summary>
    /// <remarks>
    /// This may be risky because it does interfere with the function (and the user could tamper with it
    /// or accidentally remove it).
    /// An alternative mechanism would be to have a look-aside table. But that's risky because it's
    /// a separate object to manage and could get out of sync.
    /// </remarks>
    internal static class BlobCausalityManager
    {
        [DebuggerNonUserCode] // ignore the StorageClientException in debugger.
        public static void SetWriter(IDictionary<string, string> metadata, Guid function)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            Debug.Assert(!Guid.Equals(Guid.Empty, function));

            metadata[BlobMetadataKeys.ParentId] = function.ToString();
        }

        public static async Task<Guid?> GetWriterAsync(BlobBaseClient blob, CancellationToken cancellationToken)
        {
            BlobProperties blobProperties = await blob.FetchPropertiesOrNullIfNotExistAsync(cancellationToken).ConfigureAwait(false);
            if (blobProperties == null)
            {
                return null;
            }

            var metadata = blobProperties.Metadata;
            if (!metadata.ContainsKey(BlobMetadataKeys.ParentId))
            {
                return null;
            }

            string val = metadata[BlobMetadataKeys.ParentId];
            Guid result;
            if (Guid.TryParse(val, out result))
            {
                return result;
            }

            return null;
        }
    }
}
