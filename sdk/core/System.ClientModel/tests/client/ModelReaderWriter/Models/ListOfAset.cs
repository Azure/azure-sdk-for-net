// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public partial class ListOfAset : IJsonModel<ListOfAset>
    {
        [Experimental("SCME0001")]
        private JsonPatch _patch;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Experimental("SCME0001")]
        public ref JsonPatch Patch => ref _patch;

        public List<AvailabilitySetData> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of ListOfAset.
        /// </summary>
        public ListOfAset()
        {
            Items = new List<AvailabilitySetData>();
        }

        /// <summary>
        /// Initializes a new instance of ListOfAset.
        /// </summary>
        /// <param name="items">The list of availability set data items.</param>
        /// <param name="patch">Additional properties for patching.</param>
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        internal ListOfAset(IList<AvailabilitySetData> items, JsonPatch patch)
        {
            Items = items?.ToList() ?? new();
            _patch = patch;
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        void IJsonModel<ListOfAset>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListOfAset>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListOfAset)} does not support writing '{format}' format.");
            }

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            if (Patch.Contains("$"u8))
            {
                writer.WriteRawValue(Patch.GetJson("$"u8));
            }
            else if (OptionalProperty.IsCollectionDefined(Items))
            {
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    ((IJsonModel<AvailabilitySetData>)item).Write(writer, options);
                }
                Patch.WriteTo(writer, "$"u8);
                writer.WriteEndArray();
            }

            Patch.WriteTo(writer);
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }

        ListOfAset IJsonModel<ListOfAset>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListOfAset>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ListOfAset)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeListOfAset(document.RootElement, options, null!);
        }

        ListOfAset IPersistableModel<ListOfAset>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListOfAset>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeListOfAset(document.RootElement, options, data);
                    }
                default:
                    throw new FormatException($"The model {nameof(ListOfAset)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ListOfAset>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static ListOfAset DeserializeListOfAset(JsonElement element, ModelReaderWriterOptions options, BinaryData data)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null!;
            }

            if (element.ValueKind != JsonValueKind.Array)
            {
                throw new FormatException($"Expected array for {nameof(ListOfAset)}, got {element.ValueKind}");
            }

            List<AvailabilitySetData> items = new List<AvailabilitySetData>();
#pragma warning disable SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            JsonPatch additionalProperties = new(data is null ? ReadOnlyMemory<byte>.Empty : data.ToMemory());
#pragma warning restore SCME0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

            foreach (var arrayItem in element.EnumerateArray())
            {
                if (arrayItem.ValueKind == JsonValueKind.Null)
                {
                    items.Add(null!);
                }
                else if (arrayItem.ValueKind == JsonValueKind.Object)
                {
                    items.Add(AvailabilitySetData.DeserializeAvailabilitySetData(arrayItem, options, arrayItem.GetUtf8Bytes()));
                }
            }

            return new ListOfAset(items, additionalProperties);
        }

        BinaryData IPersistableModel<ListOfAset>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ListOfAset>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ListOfAset)} does not support writing '{options.Format}' format.");
            }
        }
    }
}
