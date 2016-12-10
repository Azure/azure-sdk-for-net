// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent;

    /// <summary>
    /// The final stage of an internal frontend definition.
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdateAlt<ParentT>,
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The entirety of a private frontend definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The stage of a private frontend definition allowing to specify a subnet from the selected network.
    /// </summary>
    /// <typeparam name="Parent">The next stage of the parent definition.</typeparam>
    public interface IWithSubnet<ParentT> 
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The first stage of a private frontend definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithSubnet<ParentT>
    {
    }
}