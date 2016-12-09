// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of an application gateway IP configuration definition allowing to specify the subnet the application gateway is on.
    /// </summary>
    public interface IWithSubnet<ParentT>  :
        Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>>
    {
        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ParentT> WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IWithAttach<ParentT> WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The entirety of an application gateway IP configuration definition as part of an application gateway update.
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IWithSubnet<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway IP configuration definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway IP configuration definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IWithSubnet<ParentT>
    {
    }
}