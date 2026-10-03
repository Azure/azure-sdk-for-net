// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRequestRoutingRule type. </summary>
    public partial class ApplicationGatewayRequestRoutingRule
    {
        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="EntraJwtValidationConfigId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use EntraJwtValidationConfigId instead.")]
        [WirePath("properties.entraJWTValidationConfig")]
        public ResourceIdentifier EntraJWTValidationConfig
        {
            get => EntraJwtValidationConfigId;
            set => EntraJwtValidationConfigId = value;
        }
    }
}
