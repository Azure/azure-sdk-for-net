// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition;

    /// <summary>
    /// The entirety of the network security group definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithRule
    {
    }

    /// <summary>
    /// The stage allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage allowing to define a new security rule.
    /// When the security rule description is complete enough, use  Attachable.attach() to attach it to
    /// this network security group.
    /// </summary>
    public interface IWithRule 
    {
        /// <summary>
        /// Starts the definition of a new security rule.
        /// </summary>
        /// <param name="name">The name for the new security rule.</param>
        /// <return>The first stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> DefineRule(string name);
    }

    /// <summary>
    /// The first stage of the definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithGroup>
    {
    }
}