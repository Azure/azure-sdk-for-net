// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Search.Documents.Models
{
    public partial class FacetResult : IReadOnlyDictionary<string, object>
    {
        /// <summary>
        /// Gets the type of this facet.  Value facets count documents with a
        /// particular field value and Range facets count documents with a
        /// field value in a particular range.
        /// </summary>
        public FacetType FacetType
        {
            get
            {
                if (Value != null) return FacetType.Value;
                if (From != null || To != null) return FacetType.Range;
                if (Sum.HasValue) return FacetType.Sum;
                if (Avg.HasValue) return FacetType.Average;
                if (Min.HasValue) return FacetType.Minimum;
                if (Max.HasValue) return FacetType.Maximum;
                if (Cardinality.HasValue) return FacetType.Cardinality;

                // Default to Value if no specific facet type can be determined
                return FacetType.Value;
            }
        }

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's
        /// an interval facet.
        /// </summary>
        public object Value => GetValue(Constants.ValueKey);

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's
        /// range, or null to indicate that there is no lower bound (i.e. --
        /// for the first bucket).
        /// </summary>
        public object From => GetValue(Constants.FromKey);

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's
        /// range, or null to indicate that there is no upper bound (i.e. --
        /// for the last bucket).
        /// </summary>
        public object To => GetValue(Constants.ToKey);

        /// <summary>
        /// Get the value of a key like "value" or return null if not found.
        /// </summary>
        /// <param name="key">The name of the key to lookup.</param>
        /// <returns>The value of the key or null.</returns>
        private object GetValue(string key) =>
            AdditionalProperties.TryGetValue(key, out object value) ? value : null;

        /// <summary>
        /// Attempts to convert the facet to a range facet of the given type.
        /// </summary>
        /// <typeparam name="T">
        /// A type that matches the type of the field to which the facet was
        /// applied. Valid types include <see cref="DateTimeOffset"/>,
        /// <see cref="Double"/>, and <see cref="Int64"/>.
        /// </typeparam>
        /// <returns>A new strongly-typed range facet instance.</returns>
        /// <exception cref="InvalidCastException">
        /// This instance is not a range facet of the given type.
        /// </exception>
        public RangeFacetResult<T> AsRangeFacetResult<T>() where T : struct
        {
            if (FacetType != FacetType.Range) { throw new InvalidCastException(); }
            return new RangeFacetResult<T>(Count.GetValueOrDefault(), (T?)From, (T?)To);
        }

        /// <summary>
        /// Attempts to convert the facet to a value facet of the given type.
        /// </summary>
        /// <typeparam name="T">
        /// A type that matches the type of the field to which the facet was
        /// applied.
        /// </typeparam>
        /// <returns>A new strongly-typed value facet instance.</returns>
        /// <exception cref="InvalidCastException">
        /// This instance is not a value facet of the given type.
        /// </exception>
        public ValueFacetResult<T> AsValueFacetResult<T>()
        {
            if (FacetType != FacetType.Value) { throw new InvalidCastException(); }
            return new ValueFacetResult<T>(Count.GetValueOrDefault(), (T)Value);
        }

        internal IReadOnlyDictionary<string, object> AdditionalProperties { get; }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => AdditionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => AdditionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public IEnumerable<string> Keys => AdditionalProperties.Keys;
        /// <inheritdoc />
        public IEnumerable<object> Values => AdditionalProperties.Values;
        /// <inheritdoc cref="IReadOnlyCollection{T}.Count"/>
        int IReadOnlyCollection<KeyValuePair<string, object>>.Count => AdditionalProperties.Count;
        /// <inheritdoc />
        public object this[string key]
        {
            get => AdditionalProperties[key];
        }

        // TODO: Remove this method once additionalProperties issue is fixed in generator
        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static FacetResult DeserializeFacetResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long? count = default;
            double? avg = default;
            double? min = default;
            double? max = default;
            double? sum = default;
            long? cardinality = default;
            IReadOnlyDictionary<string, IList<FacetResult>> facets = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("count"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    count = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("avg"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    avg = prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("min"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    min = prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("max"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    max = prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("sum"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sum = prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("cardinality"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cardinality = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("@search.facets"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, IList<FacetResult>> dictionary = new Dictionary<string, IList<FacetResult>>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            List<FacetResult> array = new List<FacetResult>();
                            foreach (var item in prop0.Value.EnumerateArray())
                            {
                                array.Add(DeserializeFacetResult(item, options));
                            }
                            dictionary.Add(prop0.Name, array);
                        }
                    }
                    facets = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FacetResult(
                count,
                avg,
                min,
                max,
                sum,
                cardinality,
                facets ?? new ChangeTrackingDictionary<string, IList<FacetResult>>(),
                additionalProperties);
        }
    }
}
