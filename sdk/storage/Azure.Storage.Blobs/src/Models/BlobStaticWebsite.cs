// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobStaticWebsite.
    /// </summary>
    [CodeGenType("StaticWebsite")]
    public partial class BlobStaticWebsite
    {
        /// <summary>
        /// Creates a new BlobStaticWebsite instance.
        /// </summary>
        public BlobStaticWebsite() { }

        internal BlobStaticWebsite(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
