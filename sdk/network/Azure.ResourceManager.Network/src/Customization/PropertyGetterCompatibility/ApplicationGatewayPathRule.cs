// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayPathRule type. </summary>
    public partial class ApplicationGatewayPathRule
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
    }
}
