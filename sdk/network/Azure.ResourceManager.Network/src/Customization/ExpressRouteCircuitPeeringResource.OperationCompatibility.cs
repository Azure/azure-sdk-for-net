// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class ExpressRouteCircuitPeeringResource
    {
        public virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<Response<ExpressRouteCircuitStats>> GetPeeringStatsExpressRouteCircuitAsync(CancellationToken cancellationToken) => default;
        public virtual Response<ExpressRouteCircuitStats> GetPeeringStatsExpressRouteCircuit(CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
    }
}
