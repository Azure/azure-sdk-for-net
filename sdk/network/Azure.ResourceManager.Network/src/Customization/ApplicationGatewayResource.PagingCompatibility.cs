// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ApplicationGatewayResource type. </summary>
    public partial class ApplicationGatewayResource
    {
        /// <summary> Invokes the GetApplicationGatewayPrivateLinkResourcesAsync compatibility operation. </summary>
        public virtual AsyncPageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResourcesAsync(CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetApplicationGatewayPrivateLinkResources compatibility operation. </summary>
        public virtual Pageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResources(CancellationToken cancellationToken) => default;
    }
}
