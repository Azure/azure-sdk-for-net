// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        public new Azure.Core.ResourceType ResourceType => Id?.ResourceType ?? Type;

        public System.Nullable<ApplicationGatewaySslProtocol> MinProtocolVersion
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
