// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceLoadBalancerConfiguration
    {
        /// <summary> Initializes a new instance of CloudServiceLoadBalancerConfiguration. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="frontendIPConfigurations"> The frontend IP configurations. </param>
        public CloudServiceLoadBalancerConfiguration(string name, IEnumerable<LoadBalancerFrontendIPConfiguration> frontendIPConfigurations)
        {
            Name = name;
            FrontendIPConfigurations = frontendIPConfigurations != null ? new List<LoadBalancerFrontendIPConfiguration>(frontendIPConfigurations) : new List<LoadBalancerFrontendIPConfiguration>();
        }

        /// <summary> The resource ID. </summary>
        public ResourceIdentifier Id { get; set; }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The frontend IP configurations. </summary>
        public IList<LoadBalancerFrontendIPConfiguration> FrontendIPConfigurations { get; }
    }
}
