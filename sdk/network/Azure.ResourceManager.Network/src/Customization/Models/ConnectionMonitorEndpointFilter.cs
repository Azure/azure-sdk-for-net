// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes the behavior of a connection monitor endpoint filter. </summary>
    public partial class ConnectionMonitorEndpointFilter
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="FilterType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use FilterType instead.")]
        public ConnectionMonitorEndpointFilterType? Type
        {
            get => FilterType;
            set => FilterType = value;
        }
    }
}
