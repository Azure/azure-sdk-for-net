// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    internal static class NetworkManagerExtensions
    {
        /// Internal utility function
        internal static IList<ISubnet> ListAssociatedSubnets(this INetworkManager manager, IList<SubnetInner> subnetRefs)
        {
            IDictionary<string, INetwork> networks = new Dictionary<string, INetwork>();
            IList<ISubnet> subnets = new List<ISubnet>();
            if (subnetRefs != null)
            {
                foreach (SubnetInner subnetRef in subnetRefs)
                {
                    string networkId = ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
                    INetwork network;
                    if (!networks.TryGetValue(networkId, out network))
                    {
                        network = manager.Networks.GetById(networkId);
                        networks[networkId] = network;
                    }
                    if (network != null)
                    {
                        string subnetName = ResourceUtils.NameFromResourceId(subnetRef.Id);
                        ISubnet subnet;
                        if (network.Subnets.TryGetValue(subnetName, out subnet))
                        {
                            subnets.Add(subnet);
                        }
                    }
                }
            }
            return subnets;
        }
    }
}
