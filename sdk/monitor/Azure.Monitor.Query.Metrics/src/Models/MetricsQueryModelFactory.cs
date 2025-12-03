// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Metrics.Models
{
    [CodeGenType("QueryMetricsModelFactory")]
    [CodeGenSuppress("MetricTimeSeriesElement", typeof(IEnumerable<MetadataValue>), typeof(IEnumerable<MetricValue>))]
    [CodeGenSuppress("MetricResult", typeof(DateTimeOffset), typeof(double?), typeof(double?), typeof(double?), typeof(double?), typeof(double?))]
    [CodeGenSuppress("MetricResult", typeof(string), typeof(string), typeof(LocalizableString), typeof(string), typeof(string), typeof(string), typeof(MetricUnit), typeof(IEnumerable<MetricTimeSeriesElement>))]
    public static partial class MetricsQueryModelFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="Models.MetricTimeSeriesElement"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="metadataValues"> A dictionary comprised of metric metadata values. </param>
        /// <param name="values"> A list of <see cref="Models.MetricValue"/> elements. </param>
        public static MetricTimeSeriesElement MetricTimeSeriesElement(IReadOnlyDictionary<string, string> metadataValues, IEnumerable<MetricValue> values)
        {
            var metadataValueList = new List<MetadataValue>();
            foreach (var value in metadataValues)
            {
                var metadataValue = new MetadataValue(new LocalizableString(value.Key), value.Value, additionalBinaryDataProperties: null);
                metadataValueList.Add(metadataValue);
            }
            return new MetricTimeSeriesElement(metadataValueList, values.ToList(), additionalBinaryDataProperties: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.MetricResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="id"> The metric ID. </param>
        /// <param name="resourceType"> The resource type of the metric resource. </param>
        /// <param name="name"> The name of the metric. </param>
        /// <param name="unit"> The unit of the metric. </param>
        /// <param name="timeSeries"> The time series returned when a data query is performed. </param>
        public static MetricResult MetricResult(string id, string resourceType, string name, MetricUnit unit, IEnumerable<MetricTimeSeriesElement> timeSeries)
        {
            return new MetricResult(id, resourceType, new LocalizableString(name), unit, timeSeries);
        }
    }
}
