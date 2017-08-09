// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent;

    /// <summary>
    /// The stage of a definition allowing to specify a frontend from to associate.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithFrontend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontendBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a definition allowing to specify a frontend from to associate.
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
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
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
    }
}