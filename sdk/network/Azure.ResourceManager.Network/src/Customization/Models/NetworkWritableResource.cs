// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkWritableResource
    {
        // ApiCompat CP0002: 1.17.0 requires Type.get/set; retain a hidden alias of the writable native property.
        // The nullable null branch avoids string-to-ResourceType conversion creating a present default struct.
        /// <summary> Gets or sets the resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ResourceType instead.")]
        public string Type
        {
            get => ResourceType?.ToString();
            set => ResourceType = value is null ? (ResourceType?)null : new ResourceType(value);
        }
    }
}
