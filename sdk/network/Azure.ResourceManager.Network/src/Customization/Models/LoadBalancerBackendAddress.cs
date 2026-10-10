// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the LoadBalancerBackendAddress type. </summary>
    public partial class LoadBalancerBackendAddress
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
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
