// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly DynamicDataOptions _options;
        private readonly JsonSerializerOptions _serializerOptions;

        internal DynamicData(MutableJsonElement element, DynamicDataOptions options)
        {
            _element = element;
            _options = options;
            _serializerOptions = GetSerializerOptions(options);
        }

        internal static JsonSerializerOptions GetSerializerOptions(DynamicDataOptions options)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                Converters =
                {
                    new DefaultTimeSpanConverter()
                }
            };

            switch (options.CaseMapping)
            {
                case DynamicCaseMapping.PascalToCamel:
                    serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    break;
                case DynamicCaseMapping.None:
                default:
                    break;
            }

            switch (options.DateTimeHandling)
            {
                case DynamicDateTimeHandling.UnixTime:
                    serializerOptions.Converters.Add(new UnixTimeDateTimeConverter());
                    serializerOptions.Converters.Add(new UnixTimeDateTimeOffsetConverter());
                    break;
                case DynamicDateTimeHandling.Rfc3339:
                default:
                    serializerOptions.Converters.Add(new Rfc3339DateTimeConverter());
                    serializerOptions.Converters.Add(new Rfc3339DateTimeOffsetConverter());
                    break;
            }

            return serializerOptions;
        }

        internal void WriteTo(Stream stream)
        {
            using Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer);
        }

        private object? GetProperty(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_element.ValueKind == JsonValueKind.Array && name == "Length")
            {
                return _element.GetArrayLength();
            }

            if (_element.TryGetProperty(name, out MutableJsonElement element))
            {
                if (element.ValueKind == JsonValueKind.Null)
                {
                    return null;
                }

                return new DynamicData(element, _options);
            }

            // If we're using the PascalToCamel mapping and the strict name lookup
            // failed, do a second lookup with a camelCase name as well.
            if (_options.CaseMapping == DynamicCaseMapping.PascalToCamel && char.IsUpper(name[0]))
            {
                if (_element.TryGetProperty(ConvertToCamelCase(name), out element))
                {
                    if (element.ValueKind == JsonValueKind.Null)
                    {
                        return null;
                    }

                    return new DynamicData(element, _options);
                }
            }

            // Mimic Azure SDK model behavior for optional properties.
            return null;
        }

        private static string ConvertToCamelCase(string value) => JsonNamingPolicy.CamelCase.ConvertName(value);

        private object? GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    if (_element.TryGetProperty(propertyName, out MutableJsonElement element))
                    {
                        if (element.ValueKind == JsonValueKind.Null)
                        {
                            return null;
                        }

                        return new DynamicData(element, _options);
                    }

                    throw new KeyNotFoundException($"Could not find JSON member with name '{propertyName}'.");

                case int arrayIndex:
                    MutableJsonElement arrayElement = _element.GetIndexElement(arrayIndex);

                    if (arrayElement.ValueKind == JsonValueKind.Null)
                    {
                        return null;
                    }

                    return new DynamicData(arrayElement, _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private IEnumerable GetEnumerable()
        {
            return _element.ValueKind switch
            {
                JsonValueKind.Array => new ArrayEnumerator(_element.EnumerateArray(), _options),
                JsonValueKind.Object => new ObjectEnumerator(_element.EnumerateObject(), _options),
                _ => throw new InvalidCastException($"Unable to enumerate JSON element of kind '{_element.ValueKind}'.  Cannot cast value to IEnumerable."),
            };
        }

        private object? SetProperty(string name, object value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (HasTypeConverter(value))
            {
                value = ConvertType(value);
            }

            if (_options.CaseMapping == DynamicCaseMapping.PascalToCamel)
            {
                name = ConvertToCamelCase(name);
            }

            _element = _element.SetProperty(name, value);

            // Binding machinery expects the call site signature to return an object
            return null;
        }

        private static bool HasTypeConverter(object value) => value switch
        {
            DateTime => true,
            DateTimeOffset => true,
            TimeSpan => true,
            _ => false
        };

        private object ConvertType(object value)
        {
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(value, _serializerOptions);
            return JsonDocument.Parse(bytes);
        }

        private object? SetViaIndexer(object index, object value)
        {
            switch (index)
            {
                case string propertyName:
                    _element = _element.SetProperty(propertyName, value);
                    return null;
                case int arrayIndex:
                    MutableJsonElement element = _element.GetIndexElement(arrayIndex);
                    element.Set(value);
                    return new DynamicData(element, _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T? ConvertTo<T>()
        {
            JsonElement element = _element.GetJsonElement();

            try
            {
#if NET6_0_OR_GREATER
                return JsonSerializer.Deserialize<T>(element, _serializerOptions);
#else
                Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(element);
                return JsonSerializer.Deserialize<T>(ref reader, _serializerOptions);
#endif
            }
            catch (JsonException e)
            {
                throw new InvalidCastException($"Unable to convert value of kind '{element.ValueKind}' to type '{typeof(T)}'.", e);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return _element.ValueKind == JsonValueKind.Null;
            }

            if (_element.ValueKind == JsonValueKind.Null)
            {
                return obj is DynamicData d && Equals(d);
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

                byte b =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetByte(out byte ob) && b == ob,

                sbyte s =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetSByte(out sbyte os) && s == os,

                short s =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetInt16(out short os) && s == os,

                ushort us =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetUInt16(out ushort ous) && us == ous,

                int i =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetInt32(out int oi) && i == oi,

                uint ui =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetUInt32(out uint oui) && ui == oui,

                long l =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetInt64(out long ol) && l == ol,

                ulong ul =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetUInt64(out ulong oul) && ul == oul,

                float f =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetSingle(out float of) && f == of,

                double d =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetDouble(out double od) && d == od,

                decimal d =>
                    _element.ValueKind == JsonValueKind.Number &&
                    _element.TryGetDecimal(out decimal od) && d == od,

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
                return other._element.TryGetDouble(out double od) && d == od;
            }

            if (_element.TryGetInt64(out long l))
            {
                return other._element.TryGetInt64(out long ol) && l == ol;
            }

            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                JsonDocument document = JsonDocument.ParseValue(ref reader);
                return new DynamicData(new MutableJsonDocument(document, options).RootElement, DynamicDataOptions.Default);
            }

            public override void Write(Utf8JsonWriter writer, DynamicData value, JsonSerializerOptions options)
            {
                value._element.WriteTo(writer);
            }
        }
    }
}
