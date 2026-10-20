// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class LoadBalancerBackendAddress
    {
        // This alias was absent in 1.15.0 but shipped in 1.17.0; the 1.15.0 name already had the Id suffix.
        /// <inheritdoc cref="LoadBalancerFrontendIPConfigurationId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use LoadBalancerFrontendIPConfigurationId instead.")]
        [WirePath("properties.loadBalancerFrontendIPConfiguration")]
        public ResourceIdentifier LoadBalancerFrontendIPConfiguration
        {
            get => LoadBalancerFrontendIPConfigurationId;
            set => LoadBalancerFrontendIPConfigurationId = value;
        }
    }
}
