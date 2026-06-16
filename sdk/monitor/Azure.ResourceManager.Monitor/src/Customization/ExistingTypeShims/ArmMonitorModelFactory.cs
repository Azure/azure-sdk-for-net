// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete compatibility members.
    [CodeGenSuppress("MonitorMetricDefinition", typeof(bool?), typeof(string), typeof(string), typeof(MonitorLocalizableString), typeof(string), typeof(string), typeof(MonitorMetricClass?), typeof(MonitorMetricUnit?), typeof(MonitorAggregationType?), typeof(IEnumerable<MonitorAggregationType>), typeof(IEnumerable<MonitorMetricAvailability>), typeof(string), typeof(IEnumerable<MonitorLocalizableString>))]
    public static partial class ArmMonitorModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MonitorMetricDefinition"/>. </summary>
        /// <param name="isDimensionRequired"> Flag to indicate whether the dimension is required. </param>
        /// <param name="resourceId"> the resource identifier of the resource that emitted the metric. </param>
        /// <param name="namespace"> the namespace the metric belongs to. </param>
        /// <param name="name"> the name and the display name of the metric, i.e. it is a localizable string. </param>
        /// <param name="displayDescription"> Detailed description of this metric. </param>
        /// <param name="category"> Custom category name for this metric. </param>
        /// <param name="metricClass"> The class of the metric. </param>
        /// <param name="unit"> The unit of the metric. </param>
        /// <param name="primaryAggregationType"> the primary aggregation type value defining how to use the values for display. </param>
        /// <param name="supportedAggregationTypes"> the collection of what aggregation types are supported. </param>
        /// <param name="metricAvailabilities"> the collection of what aggregation intervals are available to be queried. </param>
        /// <param name="id"> the resource identifier of the metric definition. </param>
        /// <param name="dimensions"> the name and the display name of the dimension, i.e. it is a localizable string. </param>
        /// <returns> A new <see cref="Models.MonitorMetricDefinition"/> instance for mocking. </returns>
        [Obsolete("This API is no longer supported. Use the MonitorMetricDefinition overload that takes AggregationType primaryAggregationKind and IEnumerable<AggregationType> supportedAggregationKinds instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorMetricDefinition MonitorMetricDefinition(bool? isDimensionRequired = default, string resourceId = default, string @namespace = default, MonitorLocalizableString name = default, string displayDescription = default, string category = default, MonitorMetricClass? metricClass = default, MonitorMetricUnit? unit = default, MonitorAggregationType? primaryAggregationType = default, IEnumerable<MonitorAggregationType> supportedAggregationTypes = default, IEnumerable<MonitorMetricAvailability> metricAvailabilities = default, string id = default, IEnumerable<MonitorLocalizableString> dimensions = default)
            => MonitorMetricDefinition(
                isDimensionRequired,
                resourceId,
                @namespace,
                name,
                displayDescription,
                category,
                metricClass,
                unit,
                MonitorAggregationTypeHelper.FromLegacyAggregationType(primaryAggregationType),
                MonitorAggregationTypeHelper.FromLegacyAggregationTypes(supportedAggregationTypes),
                metricAvailabilities,
                id,
                dimensions);
    }
#pragma warning restore CS0618
}
