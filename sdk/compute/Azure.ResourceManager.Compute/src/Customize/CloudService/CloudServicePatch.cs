// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServicePatch
    {
        /// <summary> Initializes a new instance of CloudServicePatch. </summary>
        public CloudServicePatch()
        {
        }

        /// <summary> The tags. </summary>
        public IDictionary<string, string> Tags { get; set; }
    }
}
