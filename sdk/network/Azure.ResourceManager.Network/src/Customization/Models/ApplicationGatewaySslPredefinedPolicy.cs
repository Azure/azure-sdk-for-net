// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewaySslPredefinedPolicy type. </summary>
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        /// <summary> Gets or sets the ResourceType compatibility property. </summary>
        public new Azure.Core.ResourceType ResourceType => Id?.ResourceType ?? Type;

        /// <summary> Gets or sets the MinProtocolVersion compatibility property. </summary>
        public System.Nullable<ApplicationGatewaySslProtocol> MinProtocolVersion { get; set; }
    }
}
