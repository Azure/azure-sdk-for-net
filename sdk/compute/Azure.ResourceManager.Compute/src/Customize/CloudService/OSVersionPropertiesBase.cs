// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class OSVersionPropertiesBase
    {
        /// <summary> Initializes a new instance of OSVersionPropertiesBase for deserialization. </summary>
        internal OSVersionPropertiesBase()
        {
        }

        /// <summary> The version. </summary>
        public string Version { get; }

        /// <summary> The label. </summary>
        public string Label { get; }

        /// <summary> Whether this version is default. </summary>
        public bool? IsDefault { get; }

        /// <summary> Whether this version is active. </summary>
        public bool? IsActive { get; }
    }
}
