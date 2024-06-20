// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines load balancer frontend IP configuration properties. </summary>
    public partial class LoadBalancerFrontendIPConfigurationResourceSettings
    {
        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only specified if a specific
        /// private IP address shall be allocated from the subnet specified in subnetRef.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PrivateIPAddress
        {
            get => IPAddress.TryParse(PrivateIPAddressStringValue, out IPAddress ipAddress) ? ipAddress : null;
            set => PrivateIPAddressStringValue = value.ToString();
        }
    }
}
