// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkResourceData
    {
        // ApiCompat CP0002: 1.17.0 requires ResourceType.set; native read-only metadata alone would remove it.
        // Map this property so generated constructors and serialization use the same typed storage.
        /// <summary> Gets or sets the resource type. </summary>
        [CodeGenMember("ResourceType")]
        public ResourceType? ResourceType { get; set; }

        // ApiCompat CP0002: 1.17.0 requires Type.get; keep the hidden string alias connected to native metadata.
        /// <summary> Gets the resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ResourceType instead.")]
        public string Type => ResourceType?.ToString();
    }
}
