// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkResourceData
    {
        /// <summary> Gets the resource type. Setting this property has no effect. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Type instead. The setter no longer works and has no effect.")]
        public ResourceType? ResourceType
        {
            get => Type is null ? (ResourceType?)null : new ResourceType(Type);
            set { }
        }
    }
}
