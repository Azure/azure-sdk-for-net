// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRequestRoutingRule type. </summary>
    public partial class ApplicationGatewayRequestRoutingRule
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendAddressPool
        {
            get => BackendAddressPoolId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendAddressPoolId };
            set => BackendAddressPoolId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendHttpSettings
        {
            get => BackendHttpSettingsId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendHttpSettingsId };
            set => BackendHttpSettingsId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource HttpListener
        {
            get => HttpListenerId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = HttpListenerId };
            set => HttpListenerId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RedirectConfiguration
        {
            get => RedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RedirectConfigurationId };
            set => RedirectConfigurationId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource UrlPathMap
        {
            get => UrlPathMapId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = UrlPathMapId };
            set => UrlPathMapId = value?.Id;
        }
    }
}
