// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("DimensionGroupIdentity")]
    [CodeGenSuppress("DimensionKey", typeof(IDictionary<string, string>))]
    public partial class DimensionKey : IEquatable<DimensionKey>
    {
        /// <summary>
        /// </summary>
        public DimensionKey()
        {
            Dimension = new Dictionary<string, string>();
        }

        internal DimensionKey(IEnumerable<KeyValuePair<string, string>> dimension)
        {
            Dimension = new Dictionary<string, string>();

            if (dimension != default)
            {
                foreach (KeyValuePair<string, string> kvp in dimension)
                {
                    Dimension.Add(kvp);
                }
            }
        }

        internal IDictionary<string, string> Dimension { get; }

        /// <summary>
        /// </summary>
        public static bool operator ==(DimensionKey left, DimensionKey right) => left.Equals(right);

        /// <summary>
        /// </summary>
        public static bool operator !=(DimensionKey left, DimensionKey right) => !left.Equals(right);

        /// <summary>
        /// </summary>
        public void AddDimensionColumn(string dimensionColumnName, string dimensionColumnValue) =>
            Dimension.Add(dimensionColumnName, dimensionColumnValue);

        /// <summary>
        /// </summary>
        public void RemoveDimensionColumn(string dimensionColumnName) =>
            Dimension.Remove(dimensionColumnName);

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
        public override int GetHashCode() => throw new NotImplementedException();
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
