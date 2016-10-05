// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    /// <summary>
    /// The final stage of a private frontend definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinitionAlt<ParentT>,
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>
    {
    }
    /// <summary>
    /// The first stage of a private frontend definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithSubnet<ParentT>
    {
    }
    /// <summary>
    /// The entirety of a private frontend definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithSubnet<ParentT>
    {
    }
    /// <summary>
    /// The stage of a private frontend definition allowing to specify a subnet from the selected network.
    /// @param <ParentT> the next stage of the parent definition
    /// </summary>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>>
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend of an internal load balancer.
        /// </summary>
        /// <param name="network">network the virtual network the subnet exists in</param>
        /// <param name="subnetName">subnetName the name of a subnet</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.PrivateFrontend.Definition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);

    }
}