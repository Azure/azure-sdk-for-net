// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayIPConfiguration : NetworkResourceData
    {
        // Internal in 1.15.0; unnecessarily exposed publicly during the 1.16.0 TypeSpec migration.
        // Retained for released 1.16/1.17 API compatibility; returns a new wrapper and copies only its ID.
        /// <summary> Compatibility member. </summary>
        public WritableSubResource Subnet
        {
            get => SubnetId is null ? default : new WritableSubResource { Id = SubnetId };
            set => SubnetId = value?.Id;
        }
    }
}
