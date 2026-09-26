// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes a connection monitor endpoint filter item. </summary>
    public partial class ConnectionMonitorEndpointFilterItem
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ItemType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ItemType instead.")]
        public ConnectionMonitorEndpointFilterItemType? Type
        {
            get => ItemType;
            set => ItemType = value;
        }
    }
}
