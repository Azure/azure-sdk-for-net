// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareSignedIdentifier.
    /// </summary>
    [CodeGenModel("SignedIdentifier")]
    public partial class ShareSignedIdentifier
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareSignedIdentifier(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new ShareSignedIdentifier instance.
        /// </summary>
        public ShareSignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareSignedIdentifier instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareSignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                AccessPolicy = new Azure.Storage.Files.Shares.Models.ShareAccessPolicy();
            }
        }
    }
}
