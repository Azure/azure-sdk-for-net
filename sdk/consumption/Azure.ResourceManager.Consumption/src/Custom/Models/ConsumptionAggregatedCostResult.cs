// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // Shipped v1.x exposed Children/IncludedSubscriptions/ExcludedSubscriptions as IReadOnlyList<T>
    // because the AutoRest emitter inferred them as read-only flatten projections.
    // The new TypeSpec emitter materializes them as IList<T> regardless of usage.
    // Spec-side @@visibility(...Lifecycle.Read) would alter the OpenAPI shape, so we keep them
    // mutable on the inner properties bag (still IList<T>) but expose IReadOnlyList<T> on the
    // resource-level flatten accessors to preserve the shipped public surface.
    [CodeGenSuppress("Children")]
    [CodeGenSuppress("IncludedSubscriptions")]
    [CodeGenSuppress("ExcludedSubscriptions")]
    public partial class ConsumptionAggregatedCostResult
    {
        /// <summary> Children of a management group. </summary>
        public IReadOnlyList<ConsumptionAggregatedCostResult> Children
        {
            get
            {
                return Properties is null ? null : (IReadOnlyList<ConsumptionAggregatedCostResult>)Properties.Children;
            }
        }

        /// <summary> List of subscription Guids included in the calculation of aggregated cost. </summary>
        public IReadOnlyList<string> IncludedSubscriptions
        {
            get
            {
                return Properties is null ? null : (IReadOnlyList<string>)Properties.IncludedSubscriptions;
            }
        }

        /// <summary> List of subscription Guids excluded from the calculation of aggregated cost. </summary>
        public IReadOnlyList<string> ExcludedSubscriptions
        {
            get
            {
                return Properties is null ? null : (IReadOnlyList<string>)Properties.ExcludedSubscriptions;
            }
        }
    }
}
