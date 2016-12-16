// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of a private frontend definition allowing to specify a subnet from the selected network.
    /// </summary>
    /// <typeparam name="Parent">The next stage of the parent definition.</typeparam>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend of an internal load balancer.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The entirety of a private frontend definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a private frontend definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a private frontend definition.
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinitionAlt<ParentT>,
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>
    {
    }
}