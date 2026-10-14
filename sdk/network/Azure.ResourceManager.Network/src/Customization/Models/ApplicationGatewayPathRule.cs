// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayPathRule
    {
        // The following two references were internal in 1.15.0 and unnecessarily exposed publicly
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
    }
}
