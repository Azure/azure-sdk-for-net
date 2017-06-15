// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;

    /// <summary>
    /// The final stage of the application gateway IP configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway IP configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithSubnet<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway IP configuration definition allowing to specify the subnet the application gateway is on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithAttach<ParentT>>
    {
        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithAttach<ParentT> WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The first stage of an application gateway IP configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Definition.IWithSubnet<ParentT>
    {
    }
}