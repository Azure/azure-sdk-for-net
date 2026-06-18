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
    /// <summary> Compatibility declaration for the SubnetResource type. </summary>
    [CodeGenSuppress("GetResourceNavigationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetResourceNavigationLinks", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinks", typeof(CancellationToken))]
    public partial class SubnetResource
    {
        /// <summary> Invokes the GetResourceNavigationLinksAsync compatibility operation. </summary>
        public virtual AsyncPageable<ResourceNavigationLink> GetResourceNavigationLinksAsync(CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetResourceNavigationLinks compatibility operation. </summary>
        public virtual Pageable<ResourceNavigationLink> GetResourceNavigationLinks(CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetServiceAssociationLinksAsync compatibility operation. </summary>
        public virtual AsyncPageable<ServiceAssociationLink> GetServiceAssociationLinksAsync(CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetServiceAssociationLinks compatibility operation. </summary>
        public virtual Pageable<ServiceAssociationLink> GetServiceAssociationLinks(CancellationToken cancellationToken = default) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
