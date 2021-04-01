// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using System;

namespace Proto.Network
{
    /// <summary>
    /// A class to add extension methods to Azure subscription.
    /// </summary>
    public static class SubscriptionExtensions
    {
        #region Virtual Network Operations

        private static NetworkManagementClient GetNetworkClient(Uri baseUri, string subscriptionGuid, TokenCredential credential, ArmClientOptions clientOptions)
        {
            return new NetworkManagementClient(
                subscriptionGuid,
                baseUri,
                credential,
                clientOptions.Convert<NetworkManagementClientOptions>());
        }

        /// <summary>
        /// Lists the virtual networks for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> A collection of <see cref="VirtualNetwork" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualNetwork> ListVnets(this SubscriptionOperations subscription)
        {
            return subscription.ListResources(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var vmOperations = networkClient.VirtualNetworks;
                    var result = vmOperations.ListAll();
                    return new PhWrappingPageable<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork>(
                        result,
                        s => new VirtualNetwork(subscription, new VirtualNetworkData(s)));
                }
            );
        }

        /// <summary>
        /// Lists the virtual networks for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> An async collection of <see cref="VirtualNetwork" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualNetwork> ListVnetsAsync(this SubscriptionOperations subscription)
        {
            return subscription.ListResourcesAsync(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var vmOperations = networkClient.VirtualNetworks;
                    var result = vmOperations.ListAllAsync();
                    return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.VirtualNetwork, VirtualNetwork>(
                        result,
                        s => new VirtualNetwork(subscription, new VirtualNetworkData(s)));
                }
            );
        }

        #endregion

        #region Public IP Address Operations

        /// <summary>
        /// Lists the public IPs for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> A collection of <see cref="PublicIpAddress" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<PublicIpAddress> ListPublicIps(this SubscriptionOperations subscription)
        {
            return subscription.ListResources(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var publicIPAddressesOperations = networkClient.PublicIPAddresses;
                    var result = publicIPAddressesOperations.ListAll();
                    return new PhWrappingPageable<Azure.ResourceManager.Network.Models.PublicIPAddress, PublicIpAddress>(
                        result,
                        s => new PublicIpAddress(subscription, new PublicIPAddressData(s)));
                }
            );
        }

        /// <summary>
        /// Lists the public IP addresses for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> An async collection of <see cref="PublicIpAddress" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PublicIpAddress> ListPublicIpsAsync(this SubscriptionOperations subscription)
        {
            return subscription.ListResourcesAsync(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var publicIPAddressesOperations = networkClient.PublicIPAddresses;
                    var result = publicIPAddressesOperations.ListAllAsync();
                    return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.PublicIPAddress, PublicIpAddress>(
                        result,
                        s => new PublicIpAddress(subscription, new PublicIPAddressData(s)));
                }
            );
        }

        #endregion

        #region Network Interface (NIC) operations

        /// <summary>
        /// Lists the <see cref="NetworkInterface"/> for this <see cref="Subscription"/>.
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription"/> to target for listing. </param>
        /// <returns> A collection of <see cref="NetworkInterface"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<NetworkInterface> ListNics(this SubscriptionOperations subscription)
        {
            return subscription.ListResources(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var networkInterfacesOperations = networkClient.NetworkInterfaces;
                    var result = networkInterfacesOperations.ListAll();
                    return new PhWrappingPageable<Azure.ResourceManager.Network.Models.NetworkInterface, NetworkInterface>(
                        result,
                        s => new NetworkInterface(subscription, new NetworkInterfaceData(s)));
                }
            );
        }

        /// <summary>
        /// Lists the <see cref="NetworkInterface"/> for this <see cref="Subscription"/>.
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription"/> to target for listing. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<NetworkInterface> ListNicsAsync(this SubscriptionOperations subscription)
        {
            return subscription.ListResourcesAsync(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var networkInterfacesOperations = networkClient.NetworkInterfaces;
                    var result = networkInterfacesOperations.ListAllAsync();
                    return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.NetworkInterface, NetworkInterface>(
                        result,
                        s => new NetworkInterface(subscription, new NetworkInterfaceData(s)));
                }
            );
        }

        #endregion

        #region Network Security Group operations

        /// <summary>
        /// Lists the network security groups for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> A collection of <see cref="NetworkSecurityGroup" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<NetworkSecurityGroup> ListNsgs(this SubscriptionOperations subscription)
        {
            return subscription.ListResources(
                (baseUri, credential, options) =>
                {
                    NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                    var networkSecurityGroupsOperations = networkClient.NetworkSecurityGroups;
                    var result = networkSecurityGroupsOperations.ListAll();
                    return new PhWrappingPageable<Azure.ResourceManager.Network.Models.NetworkSecurityGroup, NetworkSecurityGroup>(
                        result,
                        s => new NetworkSecurityGroup(subscription, new NetworkSecurityGroupData(s)));
                }
            );
        }

        /// <summary>
        /// Lists the network security groups for this subscription.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> An async collection of <see cref="NetworkSecurityGroup" /> resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<NetworkSecurityGroup> ListNsgsAsync(this SubscriptionOperations subscription)
        {
            return subscription.ListResourcesAsync(
               (baseUri, credential, options) =>
               {
                   NetworkManagementClient networkClient = GetNetworkClient(baseUri, subscription.Id.SubscriptionId, credential, options);
                   var networkSecurityGroupsOperations = networkClient.NetworkSecurityGroups;
                   var result = networkSecurityGroupsOperations.ListAllAsync();
                   return new PhWrappingAsyncPageable<Azure.ResourceManager.Network.Models.NetworkSecurityGroup, NetworkSecurityGroup>(
                       result,
                       s => new NetworkSecurityGroup(subscription, new NetworkSecurityGroupData(s)));
               }
           );
        }

        #endregion
    }
}
