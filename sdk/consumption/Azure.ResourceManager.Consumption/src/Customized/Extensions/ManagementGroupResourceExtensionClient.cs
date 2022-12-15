// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.ManagementGroups;

namespace Azure.ResourceManager.Consumption
{
    /// <summary> A class to add extension methods to ManagementGroupResource. </summary>
    [CodeGenSuppress("GetAggregatedCostWithBillingPeriodAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAggregatedCostWithBillingPeriod", typeof(string), typeof(CancellationToken))]
    internal partial class ManagementGroupResourceExtensionClient : ArmResource
    {
    }
}
