// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The application gateway private link IP configuration. </summary>
    public partial class ApplicationGatewayPrivateLinkIPConfiguration
    {
        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="IsPrimary"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsPrimary instead.")]
        public bool? Primary
        {
            get => IsPrimary;
            set => IsPrimary = value;
        }
    }
}
