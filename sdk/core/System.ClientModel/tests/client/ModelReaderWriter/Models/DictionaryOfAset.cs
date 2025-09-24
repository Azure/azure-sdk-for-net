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
        [Experimental("SCME0001")]
        private JsonPatch _patch;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Experimental("SCME0001")]
        public ref JsonPatch Patch => ref _patch;

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
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        internal DictionaryOfAset(IDictionary<string, AvailabilitySetData> items, JsonPatch patch)
        {
            Items = items ?? new Dictionary<string, AvailabilitySetData>();
            _patch = patch;
            _patch.SetPropagators(PropagateSet, PropagateGet);
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
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
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            //TODO: 12% perf hit to call this helper
            //writer.WriteDictionaryWithPatch(
            //    options,
            //    ref Patch,
            //    ReadOnlySpan<byte>.Empty,
            //    "$"u8,
            //    Items,
            //    static (writer, item, options) => ((IJsonModel<AvailabilitySetData>)item).Write(writer, options),
            //    static (item) => item.Patch);

            writer.WriteStartObject();
#if NET8_0_OR_GREATER
            Span<byte> buffer = stackalloc byte[256];
#endif
            foreach (var item in Items)
            {
                if (item.Value.Patch.TryGetJson("$"u8, out ReadOnlyMemory<byte> patchedJson))
                {
                    if (!patchedJson.IsEmpty)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteRawValue(patchedJson.Span);
                    }
                    continue;
                }

#if NET8_0_OR_GREATER
                int bytesWritten = Encoding.UTF8.GetBytes(item.Key.AsSpan(), buffer);
                bool patchContains = bytesWritten == 256
                    ? Patch.Contains("$"u8, Encoding.UTF8.GetBytes(item.Key))
                    : Patch.Contains("$"u8, buffer.Slice(0, bytesWritten));
#else
                bool patchContains = Patch.Contains("$"u8, Encoding.UTF8.GetBytes(item.Key));
#endif
                if (!patchContains)
                {
                    writer.WritePropertyName(item.Key);
                    ((IJsonModel<AvailabilitySetData>)item.Value).Write(writer, options);
                }
            }

            Patch.WriteTo(writer, "$"u8);
            writer.WriteEndObject();

#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
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
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            JsonPatch additionalProperties = new(data is null ? ReadOnlyMemory<byte>.Empty : data.ToMemory());
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

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

#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        private bool PropagateGet(ReadOnlySpan<byte> jsonPath, out JsonPatch.EncodedValue value)
        {
            string key = jsonPath.GetFirstPropertyName(out int i);
            value = default;

            if (!Items.TryGetValue(key, out var aset))
                return false;

            return aset.Patch.TryGetEncodedValue([.. "$"u8, .. SerializationHelpers.GetRemainder(jsonPath, i)], out value);
        }

        private bool PropagateSet(ReadOnlySpan<byte> jsonPath, JsonPatch.EncodedValue value)
        {
            string key = jsonPath.GetFirstPropertyName(out int i);

            if (!Items.TryGetValue(key, out var aset))
                return false;

            aset.Patch.Set([.. "$"u8, .. SerializationHelpers.GetRemainder(jsonPath, i)], value);
            return true;
        }
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }
}
