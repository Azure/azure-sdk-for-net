// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayRequestRoutingRule
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendAddressPool
        {
            get => BackendAddressPoolId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendAddressPoolId };
            set => BackendAddressPoolId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource BackendHttpSettings
        {
            get => BackendHttpSettingsId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = BackendHttpSettingsId };
            set => BackendHttpSettingsId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource HttpListener
        {
            get => HttpListenerId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = HttpListenerId };
            set => HttpListenerId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RedirectConfiguration
        {
            get => RedirectConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RedirectConfigurationId };
            set => RedirectConfigurationId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource UrlPathMap
        {
            get => UrlPathMapId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = UrlPathMapId };
            set => UrlPathMapId = value?.Id;
        }
    }
}
