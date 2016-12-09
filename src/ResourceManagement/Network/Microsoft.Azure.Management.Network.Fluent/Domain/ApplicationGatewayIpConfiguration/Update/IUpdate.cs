// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway IP configuration update allowing to modify the subnet the application gateway is part of.
    /// </summary>
    public interface IWithSubnet  :
        Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IUpdate>
    {
        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IUpdate WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies an existing subnet the application gateway should be part of and get its private IP address from.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IUpdate WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The entirety of an application gateway IP configuration update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IWithSubnet
    {
    }
}