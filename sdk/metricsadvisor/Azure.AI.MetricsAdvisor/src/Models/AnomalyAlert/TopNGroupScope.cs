// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    public partial class TopNGroupScope
    {
        /// <summary>
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// </summary>
        public int Period { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("MinTopCount")]
        public int MinimumTopCount { get; }
    }
}
