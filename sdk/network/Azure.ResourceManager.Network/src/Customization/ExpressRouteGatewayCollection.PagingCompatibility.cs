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
    /// <summary> Compatibility declaration for the ExpressRouteGatewayCollection type. </summary>
    public partial class ExpressRouteGatewayCollection
    {
        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRouteGatewayResource> GetAllAsync(CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ExpressRouteGatewayResource> GetAll(CancellationToken cancellationToken) => default;
    }
}
