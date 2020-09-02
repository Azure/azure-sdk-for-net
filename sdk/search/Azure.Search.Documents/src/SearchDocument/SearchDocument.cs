// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#endif

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Represents an untyped document returned from a search or document
    /// lookup.  It can be accessed as either a dynamic object or a dictionary.
    /// </summary>
    [JsonConverter(typeof(SearchDocumentConverter))]
    public partial class SearchDocument
#if EXPERIMENTAL_DYNAMIC
        : DynamicData
#endif
    {
        /// <summary>
        /// Initializes a new instance of the SearchDocument class.
        /// </summary>
        public SearchDocument() : this(null) { }

#if EXPERIMENTAL_DYNAMIC
        /// <summary>
        /// Initializes a new instance of the SearchDocument class with initial
        /// values.
        /// </summary>
        /// <param name="values">Initial values of the document.</param>
        public SearchDocument(IDictionary<string, object> values) : base(values) { }
#else
        /// <summary>
        /// Initializes a new instance of the SearchDocument class with initial
        /// values.
        /// </summary>
        /// <param name="values">Initial values of the document.</param>
        public SearchDocument(IDictionary<string, object> values) =>
            _values = values != null ?
                new Dictionary<string, object>(values) :
                new Dictionary<string, object>();
#endif

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Nullable{Boolean}"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public bool? GetBoolean(string key) => GetValue<bool?>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Boolean"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<bool> GetBooleanCollection(string key) => GetValue<bool[]>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Nullable{Int32}"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public int? GetInt32(string key) => GetValue<int?>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Int32"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<int> GetInt32Collection(string key) => GetValue<int[]>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Nullable{Int64}"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public long? GetInt64(string key) => GetValue<long?>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Int64"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<long> GetInt64Collection(string key) => GetValue<long[]>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Nullable{Double}"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public double? GetDouble(string key) => GetValue<double?>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Double"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<double> GetDoubleCollection(string key) => GetValue<double[]>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="Nullable{DateTimeOffset}"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public DateTimeOffset? GetDateTimeOffset(string key) => GetValue<DateTimeOffset?>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="DateTimeOffset"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<DateTimeOffset> GetDateTimeOffsetCollection(string key) => GetValue<DateTimeOffset[]>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="String"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public string GetString(string key) => GetValue<string>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="String"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<string> GetStringCollection(string key) => GetValue<string[]>(key);

#if EXPERIMENTAL_SPATIAL
        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="PointGeometry"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public PointGeometry GetPoint(string key) => GetValue<PointGeometry>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// <see cref="PointGeometry"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<PointGeometry> GetPointCollection(string key) => GetValue<PointGeometry[]>(key);
#endif

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// complex <see cref="SearchDocument"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public SearchDocument GetObject(string key) => GetValue<SearchDocument>(key);

        /// <summary>
        /// Get the value of a <see cref="SearchDocument"/>'s
        /// complex <see cref="SearchDocument"/> collection property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public IReadOnlyList<SearchDocument> GetObjectCollection(string key) => GetValue<SearchDocument[]>(key);

        /// <inheritdoc />
        public override string ToString()
        {
            // Write the document as JSON.  This is expensive, but helpful.
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
            JsonSerialization.WriteSearchDocument(writer, this, JsonSerialization.SerializerOptions);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
