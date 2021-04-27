// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class DimensionKey : IEquatable<DimensionKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionKey"/> class.
        /// </summary>
        public DimensionKey()
        {
            Dimension = new ChangeTrackingDictionary<string, string>();
        }

        internal DimensionKey(IEnumerable<KeyValuePair<string, string>> dimension)
        {
            Dimension = dimension.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        internal IDictionary<string, string> Dimension { get; }

        /// <summary>
        /// Determines if two <see cref="DimensionKey"/> values are the same.
        /// </summary>
        /// <param name="left">The first value of comparison.</param>
        /// <param name="right">The second value of comparison.</param>
        /// <returns><c>true</c> if the <see cref="DimensionKey"/> instances represent the same dimension. Otherwise, <c>false</c>.</returns>
        public static bool operator ==(DimensionKey left, DimensionKey right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="DimensionKey"/> values are not the same.
        /// </summary>
        /// <param name="left">The first value of comparison.</param>
        /// <param name="right">The second value of comparison.</param>
        /// <returns><c>true</c> if the <see cref="DimensionKey"/> instances represent different dimensions. Otherwise, <c>false</c>.</returns>
        public static bool operator !=(DimensionKey left, DimensionKey right) => !left.Equals(right);

        /// <summary>
        /// Adds a new dimension column value to this <see cref="DimensionKey"/>.
        /// </summary>
        /// <param name="dimensionColumnName">The name of the dimension column.</param>
        /// <param name="dimensionColumnValue">The value of the dimension column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dimensionColumnName"/> or <paramref name="dimensionColumnValue"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dimensionColumnName"/> or <paramref name="dimensionColumnValue"/> is empty; or the dimension column was already present in the <see cref="DimensionKey"/>.</exception>
        public void AddDimensionColumn(string dimensionColumnName, string dimensionColumnValue)
        {
            Argument.AssertNotNullOrEmpty(dimensionColumnName, nameof(dimensionColumnName));
            Argument.AssertNotNullOrEmpty(dimensionColumnValue, nameof(dimensionColumnValue));

            Dimension.Add(dimensionColumnName, dimensionColumnValue);
        }

        /// <summary>
        /// Removes a new dimension column from this <see cref="DimensionKey"/>.
        /// </summary>
        /// <param name="dimensionColumnName">The name of the dimension column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dimensionColumnName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dimensionColumnName"/> is empty; or the dimension column was not present in the <see cref="DimensionKey"/>.</exception>
        public void RemoveDimensionColumn(string dimensionColumnName)
        {
            Argument.AssertNotNullOrEmpty(dimensionColumnName, nameof(dimensionColumnName));

            if (!Dimension.Remove(dimensionColumnName))
            {
                throw new ArgumentException($"Column {dimensionColumnName} was not present in this dimension key.", nameof(dimensionColumnName));
            }
        }

        /// <summary>
        /// Converts this <see cref="DimensionKey"/> instance into a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>An equivalent <see cref="Dictionary{TKey, TValue}"/>.</returns>
        public Dictionary<string, string> AsDictionary() =>
            Dimension.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        /// <inheritdoc />
        public bool Equals(DimensionKey other)
        {
            if (Dimension.Count != other.Dimension.Count)
            {
                return false;
            }

            foreach (KeyValuePair<string, string> kvp in Dimension)
            {
                bool isSameKvp = other.Dimension.TryGetValue(kvp.Key, out string value)
                    && kvp.Value == value;

                if (!isSameKvp)
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DimensionKey other && Equals(other);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public override int GetHashCode() => Dimension.GetHashCode();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

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
