// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition
{

    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.UpdateDefinition;
    /// <summary>
    /// The stage of a private frontend definition allowing to specify a subnet from the selected network.
    /// @param <ParentT> the next stage of the parent definition
    /// </summary>
    public interface IWithSubnet<ParentT> 
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend of the internal load balancer.
        /// </summary>
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);

    }
    /// <summary>
    /// The final stage of an internal frontend definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdateAlt<ParentT>,
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }
    /// <summary>
    /// The entirety of a private frontend definition as part of a load balancer update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithSubnet<ParentT>
    {
    }
    /// <summary>
    /// The first stage of a private frontend definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithSubnet<ParentT>
    {
    }
}