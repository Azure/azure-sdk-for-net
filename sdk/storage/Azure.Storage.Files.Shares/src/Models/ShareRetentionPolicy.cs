// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareRetentionPolicy.
    /// </summary>
    [CodeGenModel("RetentionPolicy")]
    public partial class ShareRetentionPolicy
    {
        /// <summary>
        /// Creates a new ShareRetentionPolicy instance.
        /// </summary>
        public ShareRetentionPolicy() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareRetentionPolicy(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
