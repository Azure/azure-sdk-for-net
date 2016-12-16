// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent;

    /// <summary>
    /// The entirety of a private frontend update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        IWithSubnet,
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of a private frontend update allowing to specify a subnet from the selected network.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update.IUpdate WithExistingSubnet(INetwork network, string subnetName);
    }
}