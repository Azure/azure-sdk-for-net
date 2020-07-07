// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
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
                throw new ArgumentNullException("metadata");
            }

            Debug.Assert(!Guid.Equals(Guid.Empty, function));
            
            metadata[BlobMetadataKeys.ParentId] = function.ToString();
        }

        public static async Task<Guid?> GetWriterAsync(ICloudBlob blob, CancellationToken cancellationToken)
        {
            if (!await blob.TryFetchAttributesAsync(cancellationToken))
            {
                return null;
            }

            if (!blob.Metadata.ContainsKey(BlobMetadataKeys.ParentId))
            {
                return null;
            }

            string val = blob.Metadata[BlobMetadataKeys.ParentId];
            Guid result;
            if (Guid.TryParse(val, out result))
            {
                return result;
            }

            return null;
        }
    }
}
