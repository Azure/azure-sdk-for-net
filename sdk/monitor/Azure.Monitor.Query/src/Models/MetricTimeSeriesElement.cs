// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("TimeSeriesElement")]
    public partial class MetricTimeSeriesElement
    {
        private Dictionary<string,string> _metadata;
        private IReadOnlyList<MetadataValue> Metadatavalues { get; }

        /// <summary>
        /// The metadata values returned if <see cref="MetricsQueryOptions.Filter"/> was specified in the call.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata => _metadata ??= Metadatavalues.ToDictionary(m => m.Name.Value, m => m.Value);

        /// <summary> An array of data points representing the metric values.  This is only returned if a result type of data is specified. </summary>
        [CodeGenMember("Data")]
        public IReadOnlyList<MetricValue> Values { get; }
    }
}
