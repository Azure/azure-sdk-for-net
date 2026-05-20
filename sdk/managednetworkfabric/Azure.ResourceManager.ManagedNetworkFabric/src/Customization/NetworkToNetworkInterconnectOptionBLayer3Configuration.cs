// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkToNetworkInterconnectOptionBLayer3Configuration
    {
        /// <summary> Initializes a new instance of <see cref="NetworkToNetworkInterconnectOptionBLayer3Configuration"/>. </summary>
        public NetworkToNetworkInterconnectOptionBLayer3Configuration()
        {
            PeLoopbackIpAddress = new ChangeTrackingList<string>();
            PrefixLimits = new ChangeTrackingList<OptionBLayer3PrefixLimitProperties>();
        }
    }
}
