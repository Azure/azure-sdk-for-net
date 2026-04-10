// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceOSVersionData : ResourceData
    {
        /// <summary> Initializes a new instance of CloudServiceOSVersionData for deserialization. </summary>
        internal CloudServiceOSVersionData()
        {
        }

        /// <summary> The OS family. </summary>
        public string Family { get; }

        /// <summary> The family label. </summary>
        public string FamilyLabel { get; }

        /// <summary> The version. </summary>
        public string Version { get; }

        /// <summary> The label. </summary>
        public string Label { get; }

        /// <summary> Whether this is the default version. </summary>
        public bool? IsDefault { get; }

        /// <summary> Whether this version is active. </summary>
        public bool? IsActive { get; }

        /// <summary> The location. </summary>
        public AzureLocation? Location { get; }
    }
}
