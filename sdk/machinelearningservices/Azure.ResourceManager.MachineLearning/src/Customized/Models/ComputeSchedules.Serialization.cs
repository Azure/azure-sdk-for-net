// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("ComputeSchedules")]
namespace Azure.ResourceManager.MachineLearning.Models
{
    internal partial class ComputeSchedules : IUtf8JsonSerializable, IJsonModel<ComputeSchedules>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ComputeSchedules>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ComputeSchedules>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSchedules>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeSchedules)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsCollectionDefined(ComputeStartStop))
            {
                if (ComputeStartStop != null)
                {
                    writer.WritePropertyName("computeStartStop"u8);
                    writer.WriteStartArray();
                    foreach (var item in ComputeStartStop)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("computeStartStop");
                }
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        ComputeSchedules IJsonModel<ComputeSchedules>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSchedules>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeSchedules)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComputeSchedules(document.RootElement, options);
        }

        internal static ComputeSchedules DeserializeComputeSchedules(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<MachineLearningComputeStartStopSchedule> computeStartStop = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computeStartStop"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MachineLearningComputeStartStopSchedule> array = new List<MachineLearningComputeStartStopSchedule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MachineLearningComputeStartStopSchedule.DeserializeMachineLearningComputeStartStopSchedule(item));
                    }
                    computeStartStop = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ComputeSchedules(computeStartStop ?? new ChangeTrackingList<MachineLearningComputeStartStopSchedule>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ComputeSchedules>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSchedules>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMachineLearningContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ComputeSchedules)} does not support '{options.Format}' format.");
            }
        }

        ComputeSchedules IPersistableModel<ComputeSchedules>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSchedules>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeComputeSchedules(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ComputeSchedules)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComputeSchedules>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
