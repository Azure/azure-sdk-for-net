// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.GroupableResource.Definition;
    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        IDefinitionWithTags<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IWithCreate>,
        IWithRule
    {
    }
    /// <summary>
    /// The entirety of the network security group definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IBlank,
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IWithGroup,
        IWithCreate
    {
    }
    /// <summary>
    /// The first stage of the definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The stage allowing to define a new security rule.
    /// <p>
    /// When the security rule description is complete enough, use {@link Attachable#attach()} to attach it to
    /// this network security group.
    /// </summary>
    public interface IWithRule 
    {
        /// <summary>
        /// Starts the definition of a new security rule.
        /// </summary>
        /// <param name="name">name the name for the new security rule</param>
        /// <returns>the first stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IWithCreate> DefineRule (string name);

    }
    /// <summary>
    /// The stage allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Fluent.Resource.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IWithCreate>
    {
    }
}