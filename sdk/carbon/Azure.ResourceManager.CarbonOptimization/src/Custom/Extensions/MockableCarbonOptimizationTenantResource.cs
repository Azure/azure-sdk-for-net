// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.CarbonOptimization.Models;

namespace Azure.ResourceManager.CarbonOptimization.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    [CodeGenSuppress("QueryCarbonEmissionReportsCarbonServicesAsync", typeof(QueryFilter), typeof(CancellationToken))]  // Exclude this operation because CodeGen does not support post list.
    [CodeGenSuppress("QueryCarbonEmissionReportsCarbonServices", typeof(QueryFilter), typeof(CancellationToken))]       // Exclude this operation because CodeGen does not support post list.
    public partial class MockableCarbonOptimizationTenantResource : ArmResource
    {
    }
}
