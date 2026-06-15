// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class ApplicationGatewayResource
    {
        public virtual AsyncPageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResourcesAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResources(CancellationToken cancellationToken) => default;
    }
}
