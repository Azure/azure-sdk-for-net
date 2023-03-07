// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Json;

// TODO: remove
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over MutableJsonDocument.
    /// </summary>
    [JsonConverter(typeof(JsonConverter))]
    public sealed partial class DynamicJson : DynamicData, IDisposable
    {
        private MutableJsonElement _element;
        private DynamicJsonOptions _options;

        internal DynamicJson(MutableJsonElement element, DynamicJsonOptions options = default)
        {
            _element = element;
            _options = options;
        }

        /// <inheritdoc/>
        public override void WriteTo(Stream stream)
        {
            Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer);
            writer.Flush();
        }

        public override object? GetProperty(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_element.TryGetProperty(name, out MutableJsonElement element))
            {
                return new DynamicJson(element);
            }

            if (PascalCaseGetters() && char.IsUpper(name[0]))
            {
                if (_element.TryGetProperty(GetAsCamelCase(name), out element))
                {
                    return new DynamicJson(element);
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

        public override object? GetElement(int index) => new DynamicJson(_element.GetIndexElement(index));

        public override IEnumerable GetEnumerable()
        {
            return _element.ValueKind switch
            {
                JsonValueKind.Array => new ArrayEnumerator(_element.EnumerateArray()),
                JsonValueKind.Object => new ObjectEnumerator(_element.EnumerateObject()),
                _ => throw new InvalidOperationException($"Unable to enumerate JSON element."),
            };
        }

        public override object? SetProperty(string name, object value)
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

        public override object? SetElement(int index, object value)
        {
            MutableJsonElement element = _element.GetIndexElement(index);
            element.Set(value);
            return new DynamicJson(element);
        }

        public override T ConvertTo<T>()
        {
            // TODO: is this better at the root?
            if (CastFromOperators.TryGetValue(typeof(T), out MethodInfo? method))
            {
                // TODO: don't use reflection
                return (T)method.Invoke(null, new object[] { this })!;
            }

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(_element.GetJsonElement(), MutableJsonDocument.DefaultJsonSerializerOptions)!;
#else
            Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(_element.GetJsonElement());
            return JsonSerializer.Deserialize<T>(ref reader, MutableJsonDocument.DefaultJsonSerializerOptions);
#endif
        }

        /// <inheritdoc/>
        public override string ToString() => _element.ToString();

        /// <inheritdoc/>
        public void Dispose() => _element.DisposeRoot();

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
