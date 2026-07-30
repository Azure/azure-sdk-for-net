// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRequestRoutingRule type. </summary>
    public partial class ApplicationGatewayRequestRoutingRule
    {
        /// <summary> Entra JWT validation configuration resource of the application gateway. </summary>
        [WirePath("properties.entraJWTValidationConfig")]
        public ResourceIdentifier EntraJwtValidationConfigId
        {
            get => EntraJWTValidationConfig;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
