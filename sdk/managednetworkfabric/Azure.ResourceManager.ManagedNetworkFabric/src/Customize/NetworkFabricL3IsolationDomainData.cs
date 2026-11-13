// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricL3IsolationDomainData
    {
        // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> Connected Subnet RoutePolicy. </summary>
        public ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy
        {
            get => Properties?.ConnectedSubnetRoutePolicy;
            set
            {
                Properties ??= new L3IsolationDomainProperties();
                Properties.ConnectedSubnetRoutePolicy = value;
            }
        }
    }
}
