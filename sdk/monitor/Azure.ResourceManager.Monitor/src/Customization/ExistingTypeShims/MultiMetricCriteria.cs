// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Monitor;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Models
{
    // Work around https://github.com/microsoft/typespec/issues/10996: the back-compat generator keeps this
    // discriminator base concrete but exposes the discriminator value in a public constructor.
    [CodeGenSuppress("MultiMetricCriteria", typeof(CriterionType), typeof(string), typeof(string), typeof(MetricCriteriaTimeAggregationType))]
    public partial class MultiMetricCriteria
    {
        internal MultiMetricCriteria(CriterionType criterionType, string name, string metricName, MetricCriteriaTimeAggregationType timeAggregation)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(metricName, nameof(metricName));

            CriterionType = criterionType;
            Name = name;
            MetricName = metricName;
            TimeAggregation = timeAggregation;
            Dimensions = new ChangeTrackingList<MetricDimension>();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="MultiMetricCriteria"/>. </summary>
        /// <param name="name"> Name of the criteria. </param>
        /// <param name="metricName"> Name of the metric. </param>
        /// <param name="timeAggregation"> The criteria time aggregation types. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="metricName"/> is null. </exception>
        public MultiMetricCriteria(string name, string metricName, MetricCriteriaTimeAggregationType timeAggregation)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(metricName, nameof(metricName));

            Name = name;
            MetricName = metricName;
            TimeAggregation = timeAggregation;
            Dimensions = new ChangeTrackingList<MetricDimension>();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
