// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareServiceProperties.
    /// </summary>
    [CodeGenModel("StorageServiceProperties")]
    public partial class ShareServiceProperties
    {
        /// <summary>
        /// The set of CORS rules.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<ShareCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Creates a new ShareServiceProperties instance.
        /// </summary>
        public ShareServiceProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareServiceProperties instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                HourMetrics = new Azure.Storage.Files.Shares.Models.ShareMetrics();
                MinuteMetrics = new Azure.Storage.Files.Shares.Models.ShareMetrics();
                Protocol = new Azure.Storage.Files.Shares.Models.ShareProtocolSettings();
            }
        }
    }
}
