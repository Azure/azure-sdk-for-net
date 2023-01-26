// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over MutableJsonDocument.
    /// </summary>
    //[DebuggerDisplay("{DebuggerDisplay,nq}")]
    //[DebuggerTypeProxy(typeof(JsonDataDebuggerProxy))]
    public partial class DynamicJson : DynamicData
    {
        // TODO: Decide whether or not to support equality

        private readonly MutableJsonDocument _document;

        internal DynamicJson(MutableJsonDocument document)
        {
            _document = document;
        }

        internal DynamicJsonElement RootElement => new DynamicJsonElement(_document.RootElement);

        /// <summary>
        /// Writes the document to the provided writer as a JSON value.
        /// </summary>
        /// <param name="stream"></param>
        internal override void WriteTo(Stream stream) => _document.WriteTo(stream, default);

        // TODO: Feature: support specifying serializer options
        // TODO: Feature: support cast to type T
        ///// <summary>
        ///// Converts the given JSON value into an instance of a given type.
        ///// </summary>
        ///// <typeparam name="T">The type to convert the value into.</typeparam>
        ///// <returns>A new instance of <typeparamref name="T"/> constructed from the underlying JSON value.</returns>
        //internal T To<T>() => To<T>(MutableJsonDocument.DefaultJsonSerializerOptions);

        ///// <summary>
        ///// Deserializes the given JSON value into an instance of a given type.
        ///// </summary>
        ///// <typeparam name="T">The type to deserialize the value into</typeparam>
        ///// <param name="options">Options to control the conversion behavior.</param>
        ///// <returns>A new instance of <typeparamref name="T"/> constructed from the underlying JSON value.</returns>
        //internal T To<T>(JsonSerializerOptions options)
        //{
        //    return JsonSerializer.Deserialize<T>(ToJsonString(), options);
        //}

        ///// <summary>
        ///// Returns the names of all the properties of this object.
        ///// </summary>
        ///// <remarks>If <see cref="Kind"/> is not <see cref="JsonValueKind.Object"/> this methods throws <see cref="InvalidOperationException"/>.</remarks>
        //internal IEnumerable<string> Properties
        //{
        //    get => EnsureObject().Keys;
        //}

        ///// <summary>
        ///// Returns all the elements in this array.
        ///// </summary>
        ///// <remarks>If<see cref="Kind"/> is not<see cref="JsonValueKind.Array"/> this methods throws <see cref = "InvalidOperationException" />.</remarks>
        //internal IEnumerable<JsonData> Items
        //{
        //    get { return this.EnumerateArray(); }
        //}

        //private IEnumerable<JsonData> EnumerateArray()
        //{
        //    EnsureArray();

        //    foreach (var item in _element.EnumerateArray())
        //    {
        //        yield new JsonData(item);
        //    };
        //}

        // TODO: Support ToString()
        ///// <inheritdoc />
        //public override string ToString()
        //{
        //    if (Kind == JsonValueKind.Object || Kind == JsonValueKind.Array)
        //    {
        //        return ToJsonString();
        //    }

        //    return (_value ?? "<null>").ToString();
        //}

        ///// <summary>
        ///// Returns a stringified version of the JSON for this value.
        ///// </summary>
        ///// <returns>Returns a stringified version of the JSON for this value.</returns>
        //internal string ToJsonString()
        //{
        //    using var stream = new MemoryStream();
        //    WriteTo(stream);
        //    return Encoding.UTF8.GetString(stream.ToArray());
        //}

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            //if (obj is string)
            //{
            //    return this == ((string?)obj);
            //}

            //if (obj is JsonData)
            //{
            //    return Equals((JsonData)obj);
            //}

            return base.Equals(obj);
        }

        /// <inheritdoc />
        public bool Equals(MutableJsonDocument? other)
        {
            if (other is null)
            {
                return false;
            }

            return _document.RootElement.Equals(other.RootElement);

            // TODO: pass this through to the RootElement
            //if (Kind != other.Kind)
            //{
            //    return false;
            //}

            // TODO: JsonElement doesn't implement equality, per
            // https://github.com/dotnet/runtime/issues/62585
            // We could implement this by comparing _utf8 values;
            // depends on getting those from JsonElement.
            //return _element.Equals(other._element);
        }

        /// <inheritdoc />
        public override int GetHashCode() => _document.RootElement.GetHashCode();

        // TODO: Handle array length separately - but do we need to?
        ///// <summary>
        ///// Used by the dynamic meta object to fetch properties. We can't use GetPropertyValue because when the underlying
        ///// value is an array, we want `.Length` to mean "the length of the array" and not "treat the array as an object
        ///// and get the Length property", and we also want the return type to be "int" and not a JsonData wrapping the int.
        ///// </summary>
        ///// <param name="propertyName">The name of the property to get the value of.</param>
        ///// <returns></returns>
        //private object? GetDynamicPropertyValue(string propertyName)
        //{
        //    if (Kind == JsonValueKind.Array && propertyName == nameof(Length))
        //    {
        //        return Length;
        //    }

        //    if (Kind == JsonValueKind.Object)
        //    {
        //        return GetPropertyValue(propertyName);
        //    }

        //    throw new InvalidOperationException($"Cannot get property on JSON element with kind {Kind}.");
        //}

        // TODO: Multiplex indexer for properties and arrays
        //private JsonData? GetViaIndexer(object index)
        //{
        //    switch (index)
        //    {
        //        case string propertyName:
        //            return GetPropertyValue(propertyName);
        //        case int arrayIndex:
        //            return GetValueAt(arrayIndex);
        //    }

        //    throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        //}

        //private JsonData SetValue(string propertyName, object value)
        //{
        //    if (!(value is JsonData json))
        //    {
        //        json = new JsonData(value);
        //    }

        //    EnsureObject()[propertyName] = json;
        //    return json;
        //}

        //private JsonData SetViaIndexer(object index, object value)
        //{
        //    switch (index)
        //    {
        //        case string propertyName:
        //            return SetValue(propertyName, value);
        //        case int arrayIndex:
        //            return SetValueAt(arrayIndex, value);
        //    }

        //    throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        //}

        //private JsonData SetValueAt(int index, object value)
        //{
        //    if (!(value is JsonData json))
        //    {
        //        json = new JsonData(value);
        //    }

        //    EnsureArray()[index] = json;
        //    return json;
        //}

        //private IEnumerable GetDynamicEnumerable()
        //{
        //    if (Kind == JsonValueKind.Array)
        //    {
        //        return EnsureArray();
        //    }

        //    return EnsureObject();
        //}

        // TODO: Implement debugger support
        //private string DebuggerDisplay => ToJsonString();
    }
}
