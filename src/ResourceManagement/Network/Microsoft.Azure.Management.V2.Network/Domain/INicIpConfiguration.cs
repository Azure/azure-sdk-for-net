/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An IP configuration in a network interface.
    /// </summary>
    public interface INicIpConfiguration  :
        IWrapper<Microsoft.Azure.Management.Network.Models.NetworkInterfaceIPConfigurationInner>,
        IChildResource
    {
        /// <summary>
        /// Gets the resource id of the public IP address associated with this IP configuration.
        /// </summary>
        /// <returns>public IP resource ID or null if there is no public IP associated</returns>
        string PublicIpAddressId { get; }

        /// <summary>
        /// Gets the public IP address associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this IP configuration or null if there is no public IP associated</returns>
        IPublicIpAddress PublicIpAddress ();

        /// <returns>the resource id of the virtual network subnet associated with this IP configuration.</returns>
        string SubnetId { get; }

        /// <summary>
        /// Gets the virtual network associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the virtual network associated with this this IP configuration.</returns>
        INetwork Network ();

        /// <summary>
        /// Gets the private IP address allocated to this IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this IP configuration.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string PrivateIp { get; }

        /// <returns>the private IP allocation method (Dynamic, Static)</returns>
        string PrivateIpAllocationMethod { get; }

    }
}