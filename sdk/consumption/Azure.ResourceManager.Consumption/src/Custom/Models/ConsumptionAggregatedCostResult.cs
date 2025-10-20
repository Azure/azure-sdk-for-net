// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Consumption.Models
{
    // In the same situation as swagger, the generation of 'IReadOnlyList<T>' is missing and needs to be filled in manually.
    public partial class ConsumptionAggregatedCostResult
    {
        /// <summary> Children of a management group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ConsumptionAggregatedCostResult> Children => (IReadOnlyList<ConsumptionAggregatedCostResult>)LocalChildren;

        /// <summary> List of subscription Guids included in the calculation of aggregated cost. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> IncludedSubscriptions => (IReadOnlyList<string>)LocalIncludedSubscriptions;

        /// <summary> List of subscription Guids excluded from the calculation of aggregated cost. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> ExcludedSubscriptions => (IReadOnlyList<string>)LocalExcludedSubscriptions;
    }
}
