using Azure.ResourceManager.Core;
using System;

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
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="NetworkInterfaceOperations" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a NetworkInterfaceOperations. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static NetworkInterfaceOperations GetNetworkInterfaceOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != NetworkInterfaceOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a NetworkInterface.", nameof(resourceId.ResourceType));

            var subOps = client.GetSubscriptionOperations(resourceId.SubscriptionId);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroupName);
            return rgOps.GetNetworkInterfaceOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the NetworkSecurityGroupOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="NetworkSecurityGroup" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a NetworkSecurityGroup. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static NetworkSecurityGroupOperations GetNetworkSecurityGroupOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != NetworkSecurityGroupOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a NetworkSecurityGroup.", nameof(resourceId.ResourceType));

            var subOps = client.GetSubscriptionOperations(resourceId.SubscriptionId);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroupName);
            return rgOps.GetNetworkSecurityGroupOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the PublicIpAddressOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="PublicIpAddress" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a PublicIpAddress. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static PublicIpAddressOperations GetPublicIpAddressOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != PublicIpAddressOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a PublicIpAddress.", nameof(resourceId.ResourceType));

            var subOps = client.GetSubscriptionOperations(resourceId.SubscriptionId);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroupName);
            return rgOps.GetPublicIpAddressOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the SubnetOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="Subnet" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a Subnet. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static SubnetOperations GetSubnetOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != SubnetOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a Subnet.", nameof(resourceId.ResourceType));
            var subOps = client.GetSubscriptionOperations(resourceId.SubscriptionId);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroupName);
            var vnetOps = rgOps.GetVirtualNetworkOperations(resourceId.Parent.Name);
            return vnetOps.GetSubnetOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the VirtualNetworkOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualNetwork" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a VirtualNetwork. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static VirtualNetworkOperations GetVirtualNetworkOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != VirtualNetworkOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a VirtualNetwork.", nameof(resourceId.ResourceType));

            var subOps = client.GetSubscriptionOperations(resourceId.SubscriptionId);
            var rgOps = subOps.GetResourceGroupOperations(resourceId.ResourceGroupName);
            return rgOps.GetVirtualNetworkOperations(resourceId.Parent.Name);
        }
    }
}
