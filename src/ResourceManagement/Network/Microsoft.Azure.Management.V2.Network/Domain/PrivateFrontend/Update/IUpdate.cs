// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.PrivateFrontend.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network;
    /// <summary>
    /// The entirety of a private frontend update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        IWithSubnet,
        IWithPrivateIpAddress<Microsoft.Azure.Management.V2.Network.PrivateFrontend.Update.IUpdate>
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
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.PrivateFrontend.Update.IUpdate WithExistingSubnet (INetwork network, string subnetName);

    }
}