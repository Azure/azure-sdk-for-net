// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Network Configuration
    /// </summary>
    public class NetworkConfiguration
    {
        /// <summary>
        /// IP Assignment Type
        /// </summary>
        public IPAssignmentType IpAssignmentType { get; set; }

        /// <summary>
        /// IP Address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// IP Address Range
        /// </summary>
        public IPAddressRange IpAddressRange { get; set; }

        /// <summary>
        /// Gateway
        /// </summary>
        public string Gateway { get; set; }

        /// <summary>
        /// Subnet Mask
        /// </summary>
        public string SubnetMask { get; set; }

        /// <summary>
        /// Dns Address List
        /// </summary>
        public IList<string> DnsAddressArray { get; set; }

        /// <summary>
        /// Vlan Id
        /// </summary>
        public string VlanId { get; set; }

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(IpAssignmentType)}={IpAssignmentType}, {nameof(IpAddress)}={IpAddress}, {nameof(IpAddressRange)}={IpAddressRange}, {nameof(Gateway)}={Gateway}, {nameof(SubnetMask)}={SubnetMask}, {nameof(DnsAddressArray)}={DnsAddressArray.ExpandToString()}, {nameof(VlanId)}={VlanId}}}";
        }
    }
}
