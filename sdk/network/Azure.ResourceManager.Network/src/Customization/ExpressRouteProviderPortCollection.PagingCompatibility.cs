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
    /// <summary> Compatibility declaration for the ExpressRouteProviderPortCollection type. </summary>
    public partial class ExpressRouteProviderPortCollection
    {
        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRouteProviderPortResource> GetAllAsync(string expand, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ExpressRouteProviderPortResource> GetAll(string expand, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
