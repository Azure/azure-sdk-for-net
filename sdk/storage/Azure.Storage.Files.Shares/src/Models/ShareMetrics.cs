// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareMetrics.
    /// </summary>
    [CodeGenType("Metrics")]
    public partial class ShareMetrics
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareMetrics(string version, bool enabled)
        {
            Version = version;
            Enabled = enabled;
        }

        /// <summary>
        /// Creates a new ShareMetrics instance.
        /// </summary>
        public ShareMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareMetrics instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Files.Shares.Models.ShareRetentionPolicy();
            }
        }
    }
}
