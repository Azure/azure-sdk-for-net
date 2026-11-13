// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Monitor.Query.Metrics.Models
{
    public partial class MetricTimeSeriesElement
    {
        private Dictionary<string, string> _metadata;
        private IList<MetadataValue> Metadatavalues { get; }

        /// <summary>
        /// The metadata values returned if <see cref="MetricsQueryResourcesOptions.Filter"/> was specified in the call.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata => _metadata ??= Metadatavalues.ToDictionary(m => m.Name.Value, m => m.Value);
    }
}
