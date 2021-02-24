// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class to add extension methods to resource group.
    /// </summary>
    public static class ResourceGroupExtensions
    {
        #region Virtual Network Operations
        /// <summary>
        /// Gets a <see cref="VirtualNetworkOperations"/> for a given resource under a <see cref="ResourceGroup"/>. 
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <param name="virtualNetwork"> The resource id of <see cref="GetVirtualNetworkOperations" /> data model. </param>
        /// <returns> An instance of <see cref="VirtualNetworkOperations" />. </returns>
        public static VirtualNetworkOperations GetVirtualNetworkOperations(this ResourceGroupOperations resourceGroup, string virtualNetwork)
        {
            return new VirtualNetworkOperations(resourceGroup, virtualNetwork);
        }

        /// <summary>
        /// Gets a <see cref="VirtualNetworkContainer"/> under a <see cref="ResourceGroup"/>. 
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> An instance of <see cref="VirtualNetworkContainer" />. </returns>
        public static VirtualNetworkContainer GetVirtualNetworkContainer(this ResourceGroupOperations resourceGroup)
        {
            return new VirtualNetworkContainer(resourceGroup);
        }
        #endregion

        #region Public IP Address Operations
        /// <summary>
        /// Gets a <see cref="PublicIpAddressOperations"/> under a <see cref="ResourceGroup"/>. 
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <param name="publicIpAddress"> The resource id of <see cref="GetPublicIpAddressOperations" /> data model. </param>
        /// <returns> An instance of <see cref="PublicIpAddressOperations" />. </returns>
        public static PublicIpAddressOperations GetPublicIpAddressOperations(this ResourceGroupOperations resourceGroup, string publicIpAddress)
        {
            return new PublicIpAddressOperations(resourceGroup, publicIpAddress);
        }

        /// <summary>
        /// Gets a <see cref="PublicIpAddressContainer"/> under a <see cref="ResourceGroup"/>. 
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> An instance of <see cref="PublicIpAddressContainer" />. </returns>
        public static PublicIpAddressContainer GetPublicIpAddressContainer(this ResourceGroupOperations resourceGroup)
        {
            return new PublicIpAddressContainer(resourceGroup);
        }
        #endregion

        #region Network Interface (NIC) operations
        /// <summary>
        /// Gets the operations over a specific <see cref="NetworkInterfaceOperations"/>
        /// </summary>
        /// <param name="resourceGroup"> The operations over a specific resource group. </param>
        /// <param name="networkInterface"> The network interface to target for operations. </param>
        /// <returns> A <see cref="NetworkInterface"/> including the operations that can be peformed on it. </returns>
        public static NetworkInterfaceOperations GetNetworkInterfaceOperations(this ResourceGroupOperations resourceGroup, string networkInterface)
        {
            return new NetworkInterfaceOperations(resourceGroup, networkInterface);
        }

        /// <summary>
        /// Gets the operations over the collection of <see cref="NetworkInterface"/> contained in the resource group.
        /// </summary>
        /// <param name="resourceGroup"> The operations over a specific resource group. </param>
        /// <returns> A <see cref="NetworkInterfaceContainer"/> representing the collection of <see cref="NetworkInterface"/> </returns>
        public static NetworkInterfaceContainer GetNetworkInterfaceContainer(this ResourceGroupOperations resourceGroup)
        {
            return new NetworkInterfaceContainer(resourceGroup);
        }

        /// <summary>
        /// Gets the operations over the collection of <see cref="NetworkInterface"/> contained in the resource group.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <param name="networkSecurityGroup"> The resource id of <see cref="GetNetworkSecurityGroupOperations" /> data model. </param>
        /// <returns> An instance of <see cref="NetworkSecurityGroup" />. </returns>
        public static NetworkSecurityGroupOperations GetNetworkSecurityGroupOperations(this ResourceGroupOperations resourceGroup, string networkSecurityGroup)
        {
            return new NetworkSecurityGroupOperations(resourceGroup, networkSecurityGroup);
        }

        /// <summary>
        /// Gets a <see cref="NetworkSecurityGroupContainer"/> under a <see cref="ResourceGroup"/>.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> An instance of <see cref="NetworkSecurityGroupContainer" />. </returns>
        public static NetworkSecurityGroupContainer GetNetworkSecurityGroupContainer(this ResourceGroupOperations resourceGroup)
        {
            return new NetworkSecurityGroupContainer(resourceGroup);
        }
        #endregion
    }
}
