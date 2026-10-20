// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
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

        // The following five references were internal in 1.15.0 and unnecessarily exposed publicly
        // during the 1.16.0 TypeSpec migration. Retained for released 1.16/1.17 API compatibility;
        // each returns a new wrapper and copies only its ID.
        /// <summary> Compatibility member. </summary>
        public WritableSubResource BackendAddressPool
        {
            get => BackendAddressPoolId is null ? default : new WritableSubResource { Id = BackendAddressPoolId };
            set => BackendAddressPoolId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource BackendHttpSettings
        {
            get => BackendHttpSettingsId is null ? default : new WritableSubResource { Id = BackendHttpSettingsId };
            set => BackendHttpSettingsId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource HttpListener
        {
            get => HttpListenerId is null ? default : new WritableSubResource { Id = HttpListenerId };
            set => HttpListenerId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource RedirectConfiguration
        {
            get => RedirectConfigurationId is null ? default : new WritableSubResource { Id = RedirectConfigurationId };
            set => RedirectConfigurationId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource UrlPathMap
        {
            get => UrlPathMapId is null ? default : new WritableSubResource { Id = UrlPathMapId };
            set => UrlPathMapId = value?.Id;
        }
    }
}
