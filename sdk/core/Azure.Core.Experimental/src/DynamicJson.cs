// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over MutableJsonDocument.
    /// </summary>
    [JsonConverter(typeof(JsonConverter))]
    public partial class DynamicJson : DynamicData
    {
        // TODO: Decide whether or not to support equality

        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(SetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetEnumerableMethod = typeof(DynamicJson).GetMethod(nameof(GetEnumerable), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;

        private MutableJsonElement _element;

        internal DynamicJson(MutableJsonElement element)
        {
            _element = element;
        }

        internal override void WriteTo(Stream stream)
        {
            Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer);
            writer.Flush();
        }

        private object GetProperty(string name)
        {
            return new DynamicJson(_element.GetProperty(name));
        }

        private object GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    return GetProperty(propertyName);
                case int arrayIndex:
                    return new DynamicJson(_element.GetIndexElement(arrayIndex));
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private IEnumerable GetEnumerable()
        {
            return new ArrayEnumerator(_element.EnumerateArray());
        }

        private object? SetProperty(string name, object value)
        {
            _element = _element.SetProperty(name, value);

            // Binding machinery expects the call site signature to return an object
            return null;
        }

        private object? SetViaIndexer(object index, object value)
        {
            switch (index)
            {
                case string propertyName:
                    return SetProperty(propertyName, value);
                case int arrayIndex:
                    MutableJsonElement element = _element.GetIndexElement(arrayIndex);
                    element.Set(value);
                    return new DynamicJson(element);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T ConvertTo<T>()
        {
            // TODO: Respect user-provided serialization options

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(_element.GetJsonElement(), MutableJsonDocument.DefaultJsonSerializerOptions)!;
#else
            // TODO: Could we optimize this by serializing from the byte array instead?  We don't currently slice into this in WriteTo(), but could look at storing that.
            return JsonSerializer.Deserialize<T>(_element.ToString(), MutableJsonDocument.DefaultJsonSerializerOptions);
#endif
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _element.ToString();
        }

        private class JsonConverter : JsonConverter<DynamicJson>
        {
            public override DynamicJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new DynamicJson(new MutableJsonDocument(document).RootElement);
            }

            public override void Write(Utf8JsonWriter writer, DynamicJson value, JsonSerializerOptions options)
            {
                value._element.WriteTo(writer);
            }
        }
    }
}
