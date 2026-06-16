// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete compatibility members.
    public partial class SubscriptionScopeMetricDefinition
    {
        // The generated extensible aggregation type is intentionally renamed to MonitorAggregationKind.
        // Keep the stable enum-typed aggregation properties backed by the generated properties.
        /// <summary> The primary aggregation type value defining how to use the values for display. </summary>
        [Obsolete("This API is no longer supported. Use PrimaryAggregationKind instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitorAggregationType? PrimaryAggregationType => MonitorAggregationTypeHelper.ToLegacyAggregationType(PrimaryAggregationKind);

        /// <summary> The collection of what aggregation types are supported. </summary>
        [Obsolete("This API is no longer supported. Use SupportedAggregationKinds instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<MonitorAggregationType> SupportedAggregationTypes => MonitorAggregationTypeHelper.ToLegacyAggregationTypes(SupportedAggregationKinds);
    }
#pragma warning restore CS0618
}
