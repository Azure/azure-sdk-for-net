// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the load balancer resource settings. </summary>
    public partial class LoadBalancerResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of LoadBalancerResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        public LoadBalancerResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            FrontendIPConfigurations = new ChangeTrackingList<LoadBalancerFrontendIPConfigurationResourceSettings>();
            BackendAddressPools = new ChangeTrackingList<LoadBalancerBackendAddressPoolResourceSettings>();
            ResourceType = "Microsoft.Network/loadBalancers";
        }
    }
}
