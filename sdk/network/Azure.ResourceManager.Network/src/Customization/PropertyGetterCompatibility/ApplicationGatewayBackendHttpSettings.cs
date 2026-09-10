// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayBackendHttpSettings type. </summary>
    public partial class ApplicationGatewayBackendHttpSettings
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource Probe
        {
            get => ProbeId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = ProbeId };
            set => ProbeId = value?.Id;
        }
    }
}
