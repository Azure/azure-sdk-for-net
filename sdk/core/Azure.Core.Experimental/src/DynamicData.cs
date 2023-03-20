// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Dynamic layer over MutableJsonDocument.
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

        private ObjectDocument _document;
        private ObjectElement _element;
        private DynamicDataOptions _options;

        internal DynamicData(ObjectElement element, DynamicDataOptions options = default)
        {
            _element = element;
            _document = _element.GetDocument();
            _options = options;
        }

        public ObjectDocument Document { get { return _document; } }

        internal void WriteTo(Stream stream) => _element.WriteTo(stream);

        private object? GetProperty(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            if (_element.TryGetProperty(name, out ObjectElement element))
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
            if (_element.ValueKind == ObjectValueKind.Array)
            {
                return new ArrayEnumerator(_element, _options);
            }

            if (_element.ValueKind == ObjectValueKind.Object)
            {
                return new ObjectEnumerator(_element, _options);
            }

            throw new InvalidOperationException($"Unable to enumerate this element.");
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
            if (_element.TryGetProperty(name, out ObjectElement element))
            {
                if (!element.TrySet(value))
                {
                    throw new InvalidOperationException($"Unable to set property \"{name}\" to {value}.");
                }

                return null;
            }

            if (_element.TryGetProperty(GetAsCamelCase(name), out element))
            {
                if (!element.TrySet(value))
                {
                    throw new InvalidOperationException($"Unable to set property \"{name}\" to {value}.");
                }

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
                    ObjectElement element = _element.GetIndexElement(arrayIndex);

                    if (!element.TrySet(value))
                    {
                        throw new InvalidOperationException($"Unable to set index {arrayIndex} to {value}.");
                    }

                    return new DynamicData(element, _options);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private T ConvertTo<T>() => _element.As<T>();

        /// <inheritdoc/>
        public override string? ToString() => _element.ToString();

        /// <inheritdoc/>
        public void Dispose()
        {
            _element.DisposeRoot();
        }

        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string DebuggerDisplay => _element.DebuggerDisplay;

        //private class JsonConverter : JsonConverter<DynamicJson>
        //{
        //    public override DynamicJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //    {
        //        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        //        return new DynamicJson(new MutableJsonDocument(document).RootElement);
        //    }

        //    public override void Write(Utf8JsonWriter writer, DynamicJson value, JsonSerializerOptions options)
        //    {
        //        value._element.WriteTo(writer);
        //    }
        //}
    }
}
