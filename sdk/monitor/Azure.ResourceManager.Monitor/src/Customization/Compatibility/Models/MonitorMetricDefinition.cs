// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete compatibility members.
    public partial class MonitorMetricDefinition
    {
        // The generated aggregation type is intentionally renamed away from MonitorAggregationType.
        // Keep the stable enum-typed aggregation properties backed by the generated properties.
        /// <summary> The primary aggregation type value defining how to use the values for display. </summary>
        [Obsolete("This API is no longer supported. Use PrimaryAggregationKind instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitorAggregationType? PrimaryAggregationType => MonitorAggregationTypeHelper.ToLegacyAggregationType(PrimaryAggregationKind);

        /// <summary> The collection of what aggregation types are supported. </summary>
        [Obsolete("This API is no longer supported. Use SupportedAggregationKinds instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MonitorAggregationType> SupportedAggregationTypes
        {
            get
            {
                if (SupportedAggregationKinds is null)
                {
                    return default;
                }

                List<MonitorAggregationType> result = new List<MonitorAggregationType>();
                foreach (MonitorMetricAggregationType value in SupportedAggregationKinds)
                {
                    result.Add(MonitorAggregationTypeHelper.ToLegacyAggregationType(value));
                }
                return result;
            }
        }
    }
#pragma warning restore CS0618
}
