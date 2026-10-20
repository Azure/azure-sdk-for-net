// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectionMonitorEndpoint
    {
        // Preserve the name introduced by the TypeSpec migration without separate state.
        /// <summary> Gets or sets the endpoint type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use EndpointType instead.")]
        public EndpointType? Type
        {
            get => EndpointType is null ? (Models.EndpointType?)null : new Models.EndpointType(EndpointType.Value);
            set => EndpointType = value?.Value;
        }
    }
}
