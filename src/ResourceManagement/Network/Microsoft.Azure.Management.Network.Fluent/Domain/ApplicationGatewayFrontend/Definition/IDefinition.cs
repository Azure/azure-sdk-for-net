// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The first stage of an application gateway frontend definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithSubnet<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend definition allowing to specify a subnet from the selected network to make this
    /// application gateway visible to.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithAttach<ParentT>>
    {
        /// <summary>
        /// Assigns the specified subnet to this private frontend.
        /// </summary>
        /// <param name="network">The virtual network the subnet exists in.</param>
        /// <param name="subnetName">The name of a subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of an application gateway frontend definition allowing to specify the private IP address this application gateway
    /// should be available at within the selected subnet.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithPrivateIp<ParentT>  :
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend definition allowing to specify an existing public IP address to make
    /// the application gateway available at as Internet-facing.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithPublicIpAddress<ParentT>  :
        IWithExistingPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The entirety of an application gateway frontend definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithPublicIpAddress<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway frontend definition.
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinitionAlt<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Definition.IWithSubnet<ParentT>,
        IWithPrivateIp<ParentT>
    {
    }
}