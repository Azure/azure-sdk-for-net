// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public partial class SuppressCondition
    {
        /// <summary> min point number, value range : [1, +∞). </summary>
        [CodeGenMember("MinNumber")]
        public int MinimumNumber { get; }

        /// <summary> min point ratio, value range : (0, 100]. </summary>
        [CodeGenMember("MinRatio")]
        public double MinimumRatio { get; }
    }
}
