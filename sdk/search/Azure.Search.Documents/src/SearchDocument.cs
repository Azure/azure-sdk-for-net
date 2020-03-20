// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Represents an untyped document returned from a search or document
    /// lookup.  It can be accessed as either a dynamic object or a dictionary.
    /// </summary>
    [JsonConverter(typeof(SearchDocumentConverter))]
    public class SearchDocument : DynamicObject, IDictionary<string, object>
    {
        /// <summary>
        /// The document properties.
        /// </summary>
        private readonly IDictionary<string, object> _values = null;

        /// <summary>
        /// Initializes a new instance of the SearchDocument class.
        /// </summary>
        public SearchDocument() : this(null) { }

        /// <summary>
        /// Initializes a new instance of the SearchDocument class with initial
        /// values.
        /// </summary>
        /// <param name="values">Initial values of the document.</param>
        public SearchDocument(IDictionary<string, object> values) =>
            _values = values != null ?
                new Dictionary<string, object>(values) :
                new Dictionary<string, object>();

        /// <inheritdoc />
        public object this[string key]
        {
            get => _values[key];
            set => _values[key] = value;
        }

        #region DynamicObject
        /// <inheritdoc />
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Argument.AssertNotNull(binder, nameof(binder));
            Argument.AssertNotNullOrEmpty(binder.Name, $"{nameof(binder)}.{nameof(binder.Name)}");

            // Get the property value
            if (!TryGetValue(binder.Name, out result))
            {
                Debug.Assert(!binder.IgnoreCase, "We haven't implemented case-insensitive lookup!");
                return false;
            }

            // Try to convert it to the desired type
            if (result.GetType() != binder.ReturnType)
            {
                try
                {
                    // TODO: #10591 Investigate more robust conversions for dynamic objects
                    result = Convert.ChangeType(result, binder.ReturnType, CultureInfo.InvariantCulture);
                }
                catch
                {
                }
            }

            return true;
        }

        /// <inheritdoc />
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Argument.AssertNotNull(binder, nameof(binder));
            this[binder.Name] = value;
            return true;
        }
        #endregion DynamicObject

        #region IDictionary
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) =>
            _values.TryGetValue(key, out value);

        /// <inheritdoc />
        public ICollection<string> Keys => _values.Keys;

        /// <inheritdoc />
        public ICollection<object> Values => _values.Values;

        /// <inheritdoc />
        public int Count => _values.Count;

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => _values.IsReadOnly;

        /// <inheritdoc />
        public void Add(string key, object value) => _values.Add(key, value);

        /// <inheritdoc />
        public bool ContainsKey(string key) => _values.ContainsKey(key);

        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) =>
            _values.Add(item);

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) =>
            _values.Contains(item);

        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) =>
            _values.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
            _values.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public bool Remove(string key) => _values.Remove(key);

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) =>
            _values.Remove(item);

        /// <inheritdoc />
        public void Clear() => _values.Clear();
        #endregion IDictionary

        /// <inheritdoc />
        public override string ToString()
        {
            // Write the document as JSON.  This is expensive but helpful.
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
            JsonExtensions.WriteSearchDocument(writer, this, JsonExtensions.SerializerOptions);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }

    /// <summary>
    /// Convert JSON to and from a SearchDocument.
    /// </summary>
    internal class SearchDocumentConverter : JsonConverter<SearchDocument>
    {
        public static SearchDocumentConverter Shared { get; } =
            new SearchDocumentConverter();

        /// <summary>
        /// Write a SearchDocument as JSON.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The document.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(
            Utf8JsonWriter writer,
            SearchDocument value,
            JsonSerializerOptions options)
        {
            Argument.AssertNotNull(writer, nameof(writer));
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(options, nameof(options));
            JsonExtensions.WriteSearchDocument(
                writer,
                value,
                options);
        }

        /// <summary>
        /// Parse JSON into a SearchDocument.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>A deserialized SearchDocument.</returns>
        public override SearchDocument Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Argument.AssertNotNull(typeToConvert, nameof(typeToConvert));
            Argument.AssertNotNull(options, nameof(options));
            return JsonExtensions.ReadSearchDocument(
                ref reader,
                typeToConvert,
                options);
        }
    }
}
