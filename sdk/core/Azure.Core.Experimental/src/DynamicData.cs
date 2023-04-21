// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A dynamic abstraction over content data, such as JSON.
    ///
    /// This and related types are not intended to be mocked.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [JsonConverter(typeof(JsonConverter))]
    public sealed partial class DynamicData : IDisposable
    {
        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicData).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicData).GetMethod(nameof(SetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetEnumerableMethod = typeof(DynamicData).GetMethod(nameof(GetEnumerable), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicData).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;

        private MutableJsonElement _element;
        private DynamicJsonOptions _options;

        internal DynamicData(MutableJsonElement element, DynamicJsonOptions options = default)
        {
            _element = element;
            _options = options;
        }

        internal void WriteTo(Stream stream)
        {
            using Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer);
        }

        private object? GetProperty(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_element.TryGetProperty(name, out MutableJsonElement element))
            {
                return new DynamicData(element, _options);
            }

            if (PascalCaseGetters() && char.IsUpper(name[0]))
            {
                if (_element.TryGetProperty(GetAsCamelCase(name), out element))
                {
                    return new DynamicData(element, _options);
                }
            }

            return null;
        }

        private bool PascalCaseGetters()
        {
            return
                _options.PropertyNameCasing == DynamicDataNameMapping.PascalCaseGetters ||
                _options.PropertyNameCasing == DynamicDataNameMapping.PascalCaseGettersCamelCaseSetters;
        }

        private bool CamelCaseSetters()
        {
            return _options.PropertyNameCasing == DynamicDataNameMapping.PascalCaseGettersCamelCaseSetters;
        }

        private static string GetAsCamelCase(string value)
        {
            if (value.Length < 2)
            {
                return value.ToLowerInvariant();
            }

            return $"{char.ToLowerInvariant(value[0])}{value.Substring(1)}";
        }

        private object? GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    return GetProperty(propertyName);
                case int arrayIndex:
                    return new DynamicData(_element.GetIndexElement(arrayIndex), _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private IEnumerable GetEnumerable()
        {
            return _element.ValueKind switch
            {
                JsonValueKind.Array => new ArrayEnumerator(_element.EnumerateArray(), _options),
                JsonValueKind.Object => new ObjectEnumerator(_element.EnumerateObject(), _options),
                _ => throw new InvalidCastException($"Unable to enumerate JSON element of kind {_element.ValueKind}.  Cannot cast value to IEnumerable."),
            };
        }

        private object? SetProperty(string name, object value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_options.PropertyNameCasing == DynamicDataNameMapping.None)
            {
                _element = _element.SetProperty(name, value);
                return null;
            }

            if (!char.IsUpper(name[0]))
            {
                // Lookup name is camelCase, so set unchanged.
                _element = _element.SetProperty(name, value);
                return null;
            }

            // Other mappings have PascalCase getters, and lookup name is PascalCase.
            // So, if it exists in either form, we'll set it in that form.
            if (_element.TryGetProperty(name, out MutableJsonElement element))
            {
                element.Set(value);
                return null;
            }

            if (_element.TryGetProperty(GetAsCamelCase(name), out element))
            {
                element.Set(value);
                return null;
            }

            // It's a new property, so set according to the mapping.
            name = CamelCaseSetters() ? GetAsCamelCase(name) : name;
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
                    return new DynamicData(element, _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T ConvertTo<T>()
        {
            JsonElement element = _element.GetJsonElement();

            try
            {
#if NET6_0_OR_GREATER
                return JsonSerializer.Deserialize<T>(element, MutableJsonDocument.DefaultJsonSerializerOptions)!;
#else
                Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(element);
                return JsonSerializer.Deserialize<T>(ref reader, MutableJsonDocument.DefaultJsonSerializerOptions);
#endif
            }
            catch (JsonException e)
            {
                throw new InvalidCastException($"Unable to convert value of kind {element.ValueKind} to type {typeof(T)}.", e);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _element.ToString();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _element.DisposeRoot();
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return _element.ValueKind == JsonValueKind.Null;
            }

            if (_element.ValueKind == JsonValueKind.Null)
            {
                return obj is null || obj is DynamicData d && Equals(d);
            }

            return obj switch
            {
                string s =>
                    _element.ValueKind == JsonValueKind.String &&
                    _element.GetString() == s,

                bool b =>
                    (_element.ValueKind == JsonValueKind.True ||
                     _element.ValueKind == JsonValueKind.False) &&
                    _element.GetBoolean() == b,

                double d =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetDouble(out double od) && d == od,

                float f =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetSingle(out float of) && f == of,

                long l =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetInt64(out long ol) && l == ol,

                int i =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetInt32(out int oi) && i == oi,

                DynamicData data => Equals(data),

                _ => base.Equals(obj),
            };
        }

        internal bool Equals(DynamicData other)
        {
            if (other is null)
            {
                return _element.ValueKind == JsonValueKind.Null;
            }

            if (_element.ValueKind != other._element.ValueKind)
            {
                return false;
            }

            return _element.ValueKind switch
            {
                JsonValueKind.String => _element.GetString() == other._element.GetString(),
                JsonValueKind.Number => NumberEqual(other),
                JsonValueKind.True => true,
                JsonValueKind.False => true,
                JsonValueKind.Null => true,
                _ => base.Equals(other)
            };
        }

        private bool NumberEqual(DynamicData other)
        {
            if (_element.TryGetDouble(out double d))
            {
                return other._element.TryGetDouble(out Double od) && d == od;
            }

            if (_element.TryGetInt64(out long l))
            {
                return other._element.TryGetInt64(out long ol) && l == ol;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _element.GetHashCode();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => _element.DebuggerDisplay;

        private class JsonConverter : JsonConverter<DynamicData>
        {
            public override DynamicData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new DynamicData(new MutableJsonDocument(document).RootElement);
            }

            public override void Write(Utf8JsonWriter writer, DynamicData value, JsonSerializerOptions options)
            {
                value._element.WriteTo(writer);
            }
        }
    }
}
