// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricAccessControlListData
    {
        /// <summary> Input method to configure Access Control List. </summary>
        public NetworkFabricConfigurationType? ConfigurationType { get; set; }
    }
}
