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
        public ShareSignedIdentifier() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareSignedIdentifier(string id)
        {
            Id = id;
        }
    }
}
