// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("MetricSeriesItem")]
    public partial class MetricSeriesDefinition
    {
        /// <summary>
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyDictionary<string, string> Dimension { get; }
    }
}
