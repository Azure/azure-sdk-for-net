// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Maps dimension column names of a <see cref="DataFeed"/> to values. If values are assigned
    /// to all possible column names, this <see cref="DimensionKey"/> uniquely identifies a time
    /// series within a metric. However, if only a subset of column names is assigned, this instance
    /// uniquely identifies a group of time series instead.
    /// </summary>
    [CodeGenModel("DimensionGroupIdentity")]
    [CodeGenSuppress("DimensionKey", typeof(IDictionary<string, string>))]
    public partial class DimensionKey : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionKey"/> class.
        /// </summary>
        /// <param name="dimension">The dimension columns to initialize this dimension key with.</param>
        public DimensionKey(IEnumerable<KeyValuePair<string, string>> dimension)
        {
            Argument.AssertNotNull(dimension, nameof(dimension));

            Dimension = dimension.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        internal IDictionary<string, string> Dimension { get; }

        /// <summary>
        /// Gets the value associated with the specified dimension column.
        /// </summary>
        /// <param name="columnName">The name of the dimension column whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified dimension column, if it's found. Otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if this dimension key contains the specified column. Otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="columnName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName"/> is empty.</exception>
        public bool TryGetValue(string columnName, out string value)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            return Dimension.TryGetValue(columnName, out value);
        }

        /// <summary>
        /// Determines whether this dimension key contains a dimension column with the specified name.
        /// </summary>
        /// <param name="columnName">The name of the dimension column to locate in this key.</param>
        /// <returns><c>true</c> if this dimension key contains a column with the specified name. Otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="columnName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName"/> is empty.</exception>
        public bool Contains(string columnName)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            return Dimension.ContainsKey(columnName);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the columns of this dimension key.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the columns of this dimension key.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => Dimension.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the columns of this dimension key.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the columns of this dimension key.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal DimensionKey Clone() => new DimensionKey(Dimension);

        /// <summary>
        /// Converts this instance into an equivalent <see cref="SeriesIdentity"/>.
        /// </summary>
        /// <returns>The equivalent <see cref="SeriesIdentity"/>.</returns>
        /// <remarks>
        /// Currently, the swagger defines two types that are literally the same thing: SeriesIdentity and DimensionGroupIdentity.
        /// We're exposing both as a single type: <see cref="DimensionKey"/>. DimensionGroupIdentity was converted into
        /// <see cref="DimensionKey"/>, but the service client still requires a <see cref="SeriesIdentity"/> in its methods, though,
        /// so this method makes conversion easier.
        /// </remarks>
        internal SeriesIdentity ConvertToSeriesIdentity() => new SeriesIdentity(Clone().Dimension);
    }
}
