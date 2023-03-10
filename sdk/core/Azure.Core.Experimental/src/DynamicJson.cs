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
    /// Dynamic layer over MutableJsonDocument.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [JsonConverter(typeof(JsonConverter))]
    public sealed partial class DynamicJson : DynamicData, IDisposable
    {
        private static readonly MethodInfo GetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetPropertyMethod = typeof(DynamicJson).GetMethod(nameof(SetProperty), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetEnumerableMethod = typeof(DynamicJson).GetMethod(nameof(GetEnumerable), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo GetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;
        private static readonly MethodInfo SetViaIndexerMethod = typeof(DynamicJson).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance)!;

        private MutableJsonElement _element;
        private DynamicJsonOptions _options;

        internal DynamicJson(MutableJsonElement element, DynamicJsonOptions options = default)
        {
            _element = element;
            _options = options;
        }

        internal override void WriteTo(Stream stream)
        {
            Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer);
            writer.Flush();
        }

        private object? GetProperty(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_element.TryGetProperty(name, out MutableJsonElement element))
            {
                return new DynamicJson(element, _options);
            }

            if (PascalCaseGetters() && char.IsUpper(name[0]))
            {
                if (_element.TryGetProperty(GetAsCamelCase(name), out element))
                {
                    return new DynamicJson(element, _options);
                }
            }

            return null;
        }

        private bool PascalCaseGetters()
        {
            return
                _options.PropertyNameCasing == DynamicJsonNameMapping.PascalCaseGetters ||
                _options.PropertyNameCasing == DynamicJsonNameMapping.PascalCaseGettersCamelCaseSetters;
        }

        private bool CamelCaseSetters()
        {
            return _options.PropertyNameCasing == DynamicJsonNameMapping.PascalCaseGettersCamelCaseSetters;
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
                    return new DynamicJson(_element.GetIndexElement(arrayIndex), _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private IEnumerable GetEnumerable()
        {
            return _element.ValueKind switch
            {
                JsonValueKind.Array => new ArrayEnumerator(_element.EnumerateArray()),
                JsonValueKind.Object => new ObjectEnumerator(_element.EnumerateObject()),
                _ => throw new InvalidOperationException($"Unable to enumerate JSON element."),
            };
        }

        private object? SetProperty(string name, object value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_options.PropertyNameCasing == DynamicJsonNameMapping.None)
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
                    return new DynamicJson(element, _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T ConvertTo<T>()
        {
#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(_element.GetJsonElement(), MutableJsonDocument.DefaultJsonSerializerOptions)!;
#else
            Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(_element.GetJsonElement());
            return JsonSerializer.Deserialize<T>(ref reader, MutableJsonDocument.DefaultJsonSerializerOptions);
#endif
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => _element.DebuggerDisplay;

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
