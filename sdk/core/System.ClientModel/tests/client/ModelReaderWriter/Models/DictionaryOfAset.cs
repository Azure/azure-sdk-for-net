// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public partial class DictionaryOfAset : IJsonModel<DictionaryOfAset>
    {
        private AdditionalProperties _patch;

        [EditorBrowsable(EditorBrowsableState.Never)]
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
        internal DictionaryOfAset(IDictionary<string, AvailabilitySetData> items, AdditionalProperties patch)
        {
            Items = items ?? new Dictionary<string, AvailabilitySetData>();
            _patch = patch;
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
            AdditionalProperties ap = new();
            Patch.PropagateTo(ref ap, "$"u8);
            writer.WriteStartObject();
            foreach (var item in Items)
            {
                byte[] itemBytes = [.. "$."u8, .. Encoding.UTF8.GetBytes(item.Key)];
                if (!ap.Contains(itemBytes))
                {
                    if (ap.ContainsStartsWith(itemBytes))
                    {
                        ap.PropagateTo(ref item.Value.Patch, itemBytes);
                    }
                    writer.WritePropertyName(item.Key);
                    ((IJsonModel<AvailabilitySetData>)item.Value).Write(writer, options);
                }
            }
            ap.Write(writer);
            writer.WriteEndObject();
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
            AdditionalProperties additionalProperties = new(data is null ? ReadOnlyMemory<byte>.Empty : data.ToMemory());

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
    }
}
