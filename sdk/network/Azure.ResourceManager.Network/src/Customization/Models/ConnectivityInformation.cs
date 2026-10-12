// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ConnectivityInformation type. </summary>
    public partial class ConnectivityInformation
    {
        /// <summary> Compatibility member. </summary>
        public NetworkConnectionStatus? NetworkConnectionStatus => ConnectionStatus;
    }
}
