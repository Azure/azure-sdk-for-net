// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("Dimension")]
    public partial class MetricDimension
    {

        /// <summary>
        /// Creates a new instance of the <see cref="MetricDimension"/> class.
        /// </summary>
        public MetricDimension(string dimensionName)
        {
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            DimensionName = dimensionName;
        }

        /// <summary>
        /// </summary>
        public string DimensionName { get; }

        /// <summary>
        /// </summary>
        public string DimensionDisplayName { get; set; }
    }
}
