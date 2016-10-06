// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update
{

    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    /// <summary>
    /// The stage of the resource definition allowing to add or remove security rules.
    /// </summary>
    public interface IWithRule 
    {
        /// <summary>
        /// Removes an existing security rule.
        /// </summary>
        /// <param name="name">name the name of the security rule to remove</param>
        /// <returns>the next stage of the network security group description</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate WithoutRule(string name);

        /// <summary>
        /// Begins the definition of a new security rule to be added to this network security group.
        /// </summary>
        /// <param name="name">name the name of the new security rule</param>
        /// <returns>the first stage of the new security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> DefineRule(string name);

        /// <summary>
        /// Begins the description of an update of an existing security rule of this network security group.
        /// </summary>
        /// <param name="name">name the name of an existing security rule</param>
        /// <returns>the first stage of the security rule update description</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate UpdateRule(string name);

    }
    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>,
        IWithRule
    {
    }
}