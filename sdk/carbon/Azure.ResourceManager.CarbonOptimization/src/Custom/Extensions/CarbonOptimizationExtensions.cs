// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CarbonOptimization
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.CarbonOptimization. </summary>
    [CodeGenSuppress("QueryCarbonEmissionReportsCarbonServicesAsync", typeof(TenantResource), typeof(QueryFilter), typeof(CancellationToken))]  // Exclude this operation because CodeGen does not support post list.
    [CodeGenSuppress("QueryCarbonEmissionReportsCarbonServices", typeof(TenantResource), typeof(QueryFilter), typeof(CancellationToken))]       // Exclude this operation because CodeGen does not support post list.
    public static partial class CarbonOptimizationExtensions
    {
    }
}
