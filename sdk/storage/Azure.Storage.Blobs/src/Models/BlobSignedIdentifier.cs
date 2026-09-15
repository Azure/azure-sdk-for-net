// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobSignedIdentifier.
    /// </summary>
    // CUSTOM:
    // - Suppress generated primary constructor
    [CodeGenType("SignedIdentifier")]
    [CodeGenSuppress("BlobSignedIdentifier", typeof(string))]
    public partial class BlobSignedIdentifier
    {
        internal BlobSignedIdentifier(string id, BlobAccessPolicy accessPolicy)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            AccessPolicy = accessPolicy;
        }

        /// <summary>
        /// Creates a new BlobSignedIdentifier instance.
        /// </summary>
        public BlobSignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobSignedIdentifier instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobSignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                AccessPolicy = new Azure.Storage.Blobs.Models.BlobAccessPolicy();
            }
        }
    }
}
