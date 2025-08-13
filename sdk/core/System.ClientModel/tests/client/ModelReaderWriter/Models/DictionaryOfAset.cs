// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public partial class DictionaryOfAset : IJsonModel<DictionaryOfAset>
    {
        [Experimental("SCM0001")]
        private AdditionalProperties _patch;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Experimental("SCM0001")]
        public ref AdditionalProperties Patch => ref _patch;

        public IDictionary<string, AvailabilitySetData> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of DictionaryOfAset.
        /// </summary>
        public DictionaryOfAset()
        {
            Items = new Dictionary<string, AvailabilitySetData>();
        }

        /// <summary>
        /// Initializes a new instance of DictionaryOfAset.
        /// </summary>
        /// <param name="items">The dictionary of availability set data items.</param>
        /// <param name="patch">Additional properties for patching.</param>
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        internal DictionaryOfAset(IDictionary<string, AvailabilitySetData> items, AdditionalProperties patch)
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        {
            Items = items ?? new Dictionary<string, AvailabilitySetData>();
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            _patch = patch;
            _patch.SetPropagators(PropagateSet, PropagateGet, IsFlattened);
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        void IJsonModel<DictionaryOfAset>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DictionaryOfAset>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DictionaryOfAset)} does not support writing '{format}' format.");
            }

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            writer.WriteStartObject();
            foreach (var item in Items)
            {
                if (item.Value.Patch.Contains("$"u8))
                {
                    if (item.Value.Patch.IsRemoved("$"u8))
                        continue;

                    writer.WritePropertyName(item.Key);
                    writer.WriteRawValue(item.Value.Patch.GetJson("$"u8));
                }
                else if (!Patch.ContainsChildOf("$"u8, Encoding.UTF8.GetBytes(item.Key)))
                {
                    writer.WritePropertyName(item.Key);
                    ((IJsonModel<AvailabilitySetData>)item.Value).Write(writer, options);
                }
            }
            Patch.Write(writer, "$"u8);
            writer.WriteEndObject();
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        DictionaryOfAset IJsonModel<DictionaryOfAset>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DictionaryOfAset>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DictionaryOfAset)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDictionaryOfAset(document.RootElement, options, null!);
        }

        DictionaryOfAset IPersistableModel<DictionaryOfAset>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DictionaryOfAset>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDictionaryOfAset(document.RootElement, options, data);
                    }
                default:
                    throw new FormatException($"The model {nameof(DictionaryOfAset)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DictionaryOfAset>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static DictionaryOfAset DeserializeDictionaryOfAset(JsonElement element, ModelReaderWriterOptions options, BinaryData data)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null!;
            }

            if (element.ValueKind != JsonValueKind.Object)
            {
                throw new FormatException($"Expected object for {nameof(DictionaryOfAset)}, got {element.ValueKind}");
            }

            Dictionary<string, AvailabilitySetData> items = new Dictionary<string, AvailabilitySetData>();
#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            AdditionalProperties additionalProperties = new(data is null ? ReadOnlyMemory<byte>.Empty : data.ToMemory());
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

            foreach (var property in element.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    items.Add(property.Name, null!);
                }
                else if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    items.Add(property.Name, AvailabilitySetData.DeserializeAvailabilitySetData(property.Value, options, property.Value.GetUtf8Bytes()));
                }
            }

            return new DictionaryOfAset(items, additionalProperties);
        }

        BinaryData IPersistableModel<DictionaryOfAset>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DictionaryOfAset>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DictionaryOfAset)} does not support writing '{options.Format}' format.");
            }
        }

        private bool PropagateGet(ReadOnlySpan<byte> jsonPath, out ReadOnlyMemory<byte> value)
        {
            string key = jsonPath.GetFirstPropertyName(out int i);
            value = ReadOnlyMemory<byte>.Empty;

            if (!Items.TryGetValue(key, out var aset))
                return false;

#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            return aset.Patch.TryGetJson([.. "$"u8, .. GetRemainder(jsonPath, i)], out value);
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        private bool PropagateSet(ReadOnlySpan<byte> jsonPath, AdditionalProperties.EncodedValue value)
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        {
            string key = jsonPath.GetFirstPropertyName(out int i);

            if (!Items.TryGetValue(key, out var aset))
                return false;

#pragma warning disable SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            aset.Patch.Set([.. "$"u8, .. GetRemainder(jsonPath, i)], value);
#pragma warning restore SCM0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            return true;
        }

        private bool IsFlattened(ReadOnlySpan<byte> jsonPath) => false;

        private static ReadOnlySpan<byte> GetRemainder(ReadOnlySpan<byte> jsonPath, int i)
        {
            return i >= jsonPath.Length
                ? ReadOnlySpan<byte>.Empty
                : jsonPath[i] == (byte)'.'
                    ? jsonPath.Slice(i)
                    : jsonPath.Slice(i + 2);
        }
    }
}
