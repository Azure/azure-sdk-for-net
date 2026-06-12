// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayPathRule
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
    }
}
