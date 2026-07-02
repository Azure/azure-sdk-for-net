// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCrossConnectionPeeringResource type. </summary>
    public partial class ExpressRouteCrossConnectionPeeringResource
    {
        /// <summary> Invokes the GetArpTableExpressRouteCrossConnectionAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetArpTableExpressRouteCrossConnection compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetRoutesTableExpressRouteCrossConnectionAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetRoutesTableExpressRouteCrossConnection compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetRoutesTableSummaryExpressRouteCrossConnectionAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetRoutesTableSummaryExpressRouteCrossConnection compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
