// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.Subnet.UpdateDefinition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Network;
    /// <summary>
    /// The first stage of the subnet definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithAddressPrefix<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the subnet definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the subnet definition
    /// can be attached to the parent virtual network definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithNetworkSecurityGroup<ParentT>
    {
    }
    /// <summary>
    /// The stage of the subnet definition allowing to specify the network security group to assign to the subnet.
    /// @param <ParentT> the parent type
    /// </summary>
    public interface IWithNetworkSecurityGroup<ParentT> 
    {
        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of the network security group</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(string resourceId);

        /// <summary>
        /// Assigns an existing network security group to this subnet.
        /// </summary>
        /// <param name="nsg">nsg the network security group to assign</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.Subnet.UpdateDefinition.IWithAttach<ParentT> WithExistingNetworkSecurityGroup(INetworkSecurityGroup nsg);

    }
    /// <summary>
    /// The stage of the subnet definition allowing to specify the address space for the subnet.
    /// @param <ParentT> the parent type
    /// </summary>
    public interface IWithAddressPrefix<ParentT> 
    {
        /// <summary>
        /// Specifies the IP address space of the subnet, within the address space of the network.
        /// </summary>
        /// <param name="cidr">cidr the IP address space prefix using the CIDR notation</param>
        /// <returns>the next stage of the subnet definition</returns>
        Microsoft.Azure.Management.Fluent.Network.Subnet.UpdateDefinition.IWithAttach<ParentT> WithAddressPrefix(string cidr);

    }
    /// <summary>
    /// The entirety of a subnet definition as part of a virtual network update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAddressPrefix<ParentT>,
        IWithNetworkSecurityGroup<ParentT>,
        IWithAttach<ParentT>
    {
    }
}