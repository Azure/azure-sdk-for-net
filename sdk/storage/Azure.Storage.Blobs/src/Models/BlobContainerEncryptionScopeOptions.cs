// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Encryption scope options to be used when creating a container.
    /// </summary>
    public class BlobContainerEncryptionScopeOptions
    {
        /// <summary>
        /// Specifies the default encryption scope to set on the container and use for all future writes.
        /// </summary>
        public string DefaultEncryptionScope { get; set; }

        /// <summary>
        /// If true, prevents any request from specifying a different encryption scope than the scope set on the container.
        /// </summary>
        public bool PreventEncryptionScopeOverride { get; set; }
    }
}
