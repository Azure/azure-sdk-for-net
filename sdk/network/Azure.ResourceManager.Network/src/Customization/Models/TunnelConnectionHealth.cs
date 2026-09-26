// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Virtual network gateway tunnel connection health. </summary>
    public partial class TunnelConnectionHealth
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="LastConnectionEstablishedUtcTime"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use LastConnectionEstablishedUtcTime instead.")]
        public string LastConnectionEstablishedOn => LastConnectionEstablishedUtcTime;
    }
}
