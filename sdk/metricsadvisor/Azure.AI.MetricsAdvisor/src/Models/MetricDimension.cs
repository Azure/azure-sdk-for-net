// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS: hard to explain.
    /// <summary>
    /// </summary>
    [CodeGenModel("Dimension")]
    public partial class MetricDimension
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MetricDimension"/> class.
        /// </summary>
        /// <param name="dimensionName">The name of the data source's column to be used as a dimension. Values of this dimension will be read only from the specified column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dimensionName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dimensionName"/> is empty.</exception>
        public MetricDimension(string dimensionName)
        {
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            DimensionName = dimensionName;
        }

        /// <summary>
        /// The name of the data source's column to be used as a dimension. Values of
        /// this dimension will be read only from the specified column.
        /// </summary>
        public string DimensionName { get; }

        /// <summary>
        /// The name to be displayed on the web portal instead of the original column name.
        /// </summary>
        public string DimensionDisplayName { get; set; }
    }
}
