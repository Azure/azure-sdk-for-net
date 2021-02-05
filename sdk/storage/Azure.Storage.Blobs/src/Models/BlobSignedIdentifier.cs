// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobSignedIdentifier.
    /// </summary>
    [CodeGenModel("SignedIdentifier")]
    public partial class BlobSignedIdentifier
    {
        /// <summary>
        /// Creates a new BlobSignedIdentifier instance.
        /// </summary>
        public BlobSignedIdentifier() { }

        internal BlobSignedIdentifier(string id, BlobAccessPolicy accessPolicy)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (accessPolicy == null)
            {
                throw new ArgumentNullException(nameof(accessPolicy));
            }

            Id = id;
            AccessPolicy = accessPolicy;
        }
    }
}
