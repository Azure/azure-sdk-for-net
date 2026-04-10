// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceOSFamilyData : ResourceData
    {
        /// <summary> Initializes a new instance of CloudServiceOSFamilyData for deserialization. </summary>
        internal CloudServiceOSFamilyData()
        {
        }

        /// <summary> The OS family name. </summary>
        public string OSFamilyName { get; }

        /// <summary> The label. </summary>
        public string Label { get; }

        /// <summary> The location. </summary>
        public AzureLocation? Location { get; }

        /// <summary> The resource name. </summary>
        public string ResourceName { get; }

        /// <summary> The OS versions. </summary>
        public IReadOnlyList<OSVersionPropertiesBase> Versions { get; }
    }
}
