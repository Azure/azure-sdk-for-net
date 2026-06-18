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
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringResource type. </summary>
    public partial class ExpressRouteCircuitPeeringResource
    {
        /// <summary> Invokes the GetArpTableExpressRouteCircuitAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetArpTableExpressRouteCircuit compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetPeeringStatsExpressRouteCircuitAsync compatibility operation. </summary>
        public virtual Task<Response<ExpressRouteCircuitStats>> GetPeeringStatsExpressRouteCircuitAsync(CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetPeeringStatsExpressRouteCircuit compatibility operation. </summary>
        public virtual Response<ExpressRouteCircuitStats> GetPeeringStatsExpressRouteCircuit(CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetRoutesTableExpressRouteCircuitAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetRoutesTableExpressRouteCircuit compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetRoutesTableSummaryExpressRouteCircuitAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetRoutesTableSummaryExpressRouteCircuit compatibility operation. </summary>
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
    }
}
