// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Consumption;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Consumption.Models
{
    // Backward-compatibility: these collection properties existed in the old SDK but
    // the generated code no longer includes them (they were part of the Properties envelope
    // that is now flattened differently). Retained as read-only stubs.
    /// <summary> A management group aggregated cost resource. </summary>
    public partial class ConsumptionAggregatedCostResult
    {
        /// <summary> Children of a management group. </summary>
        public IReadOnlyList<ConsumptionAggregatedCostResult> Children { get; }
        /// <summary> List of subscription Guids included in the calculation of aggregated cost. </summary>
        public IReadOnlyList<string> IncludedSubscriptions { get; }
        /// <summary> List of subscription Guids excluded from the calculation of aggregated cost. </summary>
        public IReadOnlyList<string> ExcludedSubscriptions { get; }
    }
}
