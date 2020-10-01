// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("RootCause")]
    public partial class IncidentRootCause
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("RootCause")]
        public DimensionKey DimensionKey { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("Path")]
        public IReadOnlyList<string> Paths { get; }
    }
}
