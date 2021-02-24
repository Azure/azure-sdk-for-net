using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;
using Proto.Network;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Proto.Network
{
    /// <summary>
    /// A class to add extension methods to an ArmClient.
    /// </summary>
    public static class ArmClientExtensions
    {

        /// <summary>
        /// Gets the NetworkInterfaceOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="NetworkInterfaceOperations" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a NetworkInterfaceOperations. </exception>
        public static NetworkInterfaceOperations GetNetworkInterfaceOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != NetworkInterfaceOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a Network Interface.");
            }
            var subOps = client.GetSubscriptionOperations(resourceId.Subscription);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroup);
            return rgOps.GetNetworkInterfaceOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the NetworkSecurityGroupOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="NetworkSecurityGroup" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a NetworkSecurityGroup. </exception>
        public static NetworkSecurityGroupOperations GetNetworkSecurityGroupOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != NetworkSecurityGroupOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a NetworkSecurityGroup.");
            }
            var subOps = client.GetSubscriptionOperations(resourceId.Subscription);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroup);
            return rgOps.GetNetworkSecurityGroupOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the PublicIpAddressOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="PublicIpAddress" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a PublicIpAddress. </exception>
        public static PublicIpAddressOperations GetPublicIpAddressOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != PublicIpAddressOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a PublicIpAddress.");
            }
            var subOps = client.GetSubscriptionOperations(resourceId.Subscription);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroup);
            return rgOps.GetPublicIpAddressOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the SubnetOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="Subnet" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a Subnet. </exception>
        public static SubnetOperations GetSubnetOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != SubnetOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a Subnet.");
            }
            var subOps = client.GetSubscriptionOperations(resourceId.Subscription);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroup);
            var vnetOps = rgOps.GetVirtualNetworkOperations(resourceId.Parent.Name);
            return vnetOps.GetSubnetOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the VirtualNetworkOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualNetwork" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a VirtualNetwork. </exception>
        public static VirtualNetworkOperations GetVirtualNetworkOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != VirtualNetworkOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a VirtualNetwork.");
            }
            var subOps = client.GetSubscriptionOperations(resourceId.Subscription);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroup);
            return rgOps.GetVirtualNetworkOperations(resourceId.Parent.Name);
        }
    }
}
