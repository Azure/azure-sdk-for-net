// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class InstanceSku
    {
        /// <summary> Initializes a new instance of InstanceSku for deserialization. </summary>
        internal InstanceSku()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; }

        /// <summary> The tier. </summary>
        public string Tier { get; }
    }
}
