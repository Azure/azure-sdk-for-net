// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Monitor.Query.Models
{
    // TODO: This probably be a public extensible enum
    public partial class TimeSeriesElement
    {
        private Dictionary<string,string> _metadata;
        private IReadOnlyList<MetadataValue> Metadatavalues { get; }

        /// <summary>
        /// The metadata values returned if <see cref="MetricsQueryOptions.Filter"/> was specified in the call.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata => _metadata ??= Metadatavalues.ToDictionary(m => m.Name.Value, m => m.Value);
    }
}