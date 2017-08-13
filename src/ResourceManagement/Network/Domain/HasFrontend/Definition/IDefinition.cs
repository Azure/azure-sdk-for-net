// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of a definition allowing to specify a load balancer frontend.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithFrontend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontendBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a definition allowing to specify a load balancer frontend.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithFrontendBeta<ReturnT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromExistingSubnet(INetwork network, string subnetName);

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="networkResourceId">The resource ID of an existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromExistingSubnet(string networkResourceId, string subnetName);

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies the frontend to receive network traffic from.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromFrontend(string frontendName);

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress);

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromExistingPublicIPAddress(string resourceId);

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// in the same region and resource group but under the provided leaf DNS label, assuming it is available.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address, so make
        /// sure to use a unique DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">A unique leaf DNS label to create the public IP address under.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromNewPublicIPAddress(string leafDnsLabel);

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// based on the provided definition.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <param name="pipDefinition">A definition for the new public IP.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT FromNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> pipDefinition);

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be automatically created woth default settings
        /// along with the load balancer.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT FromNewPublicIPAddress();
    }
}