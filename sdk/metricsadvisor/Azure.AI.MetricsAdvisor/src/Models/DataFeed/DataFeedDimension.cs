// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A categorical value that characterizes the metrics of a <see cref="DataFeed"/>. The combination of multiple dimensions
    /// identify a particular univariate time series.
    /// </summary>
    [CodeGenModel("Dimension")]
    public partial class DataFeedDimension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedDimension"/> class.
        /// </summary>
        /// <param name="name">The name of the dimension as it appears in its corresponding <see cref="DataFeedSource"/> column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public DataFeedDimension(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The name of the dimension as it appears in its corresponding <see cref="DataFeedSource"/> column.
        /// </summary>
        [CodeGenMember("DimensionName")]
        public string Name { get; }

        /// <summary>
        /// The dimension name to be displayed on the web portal. Defaults to the original column name, <see cref="Name"/>.
        /// </summary>
        /// <remarks>
        /// Once the <see cref="DataFeed"/> containing this dimension is created, this property cannot be changed anymore.
        /// </remarks>
        [CodeGenMember("DimensionDisplayName")]
        public string DisplayName { get; set; }
    }
}
