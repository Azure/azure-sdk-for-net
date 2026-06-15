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
    [CodeGenSuppress("GetResourceNavigationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetResourceNavigationLinks", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinks", typeof(CancellationToken))]
    public partial class SubnetResource
    {
        public virtual AsyncPageable<ResourceNavigationLink> GetResourceNavigationLinksAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ResourceNavigationLink> GetResourceNavigationLinks(CancellationToken cancellationToken = default) => default;
        public virtual AsyncPageable<ServiceAssociationLink> GetServiceAssociationLinksAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ServiceAssociationLink> GetServiceAssociationLinks(CancellationToken cancellationToken = default) => default;
    }
}
