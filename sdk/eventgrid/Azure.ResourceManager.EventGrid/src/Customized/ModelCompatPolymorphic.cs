#pragma warning disable CS1591
#pragma warning disable SA1402

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("AdvancedFilter")]
[assembly: CodeGenSuppressType("DeadLetterDestination")]
[assembly: CodeGenSuppressType("DeliveryAttributeMapping")]
[assembly: CodeGenSuppressType("EventGridFilter")]
[assembly: CodeGenSuppressType("EventGridInputSchemaMapping")]
[assembly: CodeGenSuppressType("EventSubscriptionDestination")]
[assembly: CodeGenSuppressType("StaticRoutingEnrichment")]

namespace Azure.ResourceManager.EventGrid.Models
{
    public abstract partial class AdvancedFilter : IJsonModel<AdvancedFilter>, IPersistableModel<AdvancedFilter>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected AdvancedFilter()
        {
        }

        private protected AdvancedFilter(AdvancedFilterOperatorType operatorType)
        {
            OperatorType = operatorType;
        }

        internal AdvancedFilter(AdvancedFilterOperatorType operatorType, string key, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            OperatorType = operatorType;
            Key = key;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("operatorType")]
        internal AdvancedFilterOperatorType OperatorType { get; set; }

        [WirePath("key")]
        public string Key { get; set; }

        protected virtual AdvancedFilter PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AdvancedFilter>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeAdvancedFilter(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(AdvancedFilter)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AdvancedFilter>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(AdvancedFilter)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<AdvancedFilter>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        AdvancedFilter IPersistableModel<AdvancedFilter>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<AdvancedFilter>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<AdvancedFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AdvancedFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AdvancedFilter)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("operatorType"u8);
            writer.WriteStringValue(OperatorType.ToString());
            if (Optional.IsDefined(Key))
            {
                writer.WritePropertyName("key"u8);
                writer.WriteStringValue(Key);
            }
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        AdvancedFilter IJsonModel<AdvancedFilter>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual AdvancedFilter JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AdvancedFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AdvancedFilter)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAdvancedFilter(document.RootElement, options);
        }

        internal static AdvancedFilter DeserializeAdvancedFilter(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("operatorType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "NumberIn":
                        return NumberInAdvancedFilter.DeserializeNumberInAdvancedFilter(element, options);
                    case "NumberNotIn":
                        return NumberNotInAdvancedFilter.DeserializeNumberNotInAdvancedFilter(element, options);
                    case "NumberLessThan":
                        return NumberLessThanAdvancedFilter.DeserializeNumberLessThanAdvancedFilter(element, options);
                    case "NumberGreaterThan":
                        return NumberGreaterThanAdvancedFilter.DeserializeNumberGreaterThanAdvancedFilter(element, options);
                    case "NumberLessThanOrEquals":
                        return NumberLessThanOrEqualsAdvancedFilter.DeserializeNumberLessThanOrEqualsAdvancedFilter(element, options);
                    case "NumberGreaterThanOrEquals":
                        return NumberGreaterThanOrEqualsAdvancedFilter.DeserializeNumberGreaterThanOrEqualsAdvancedFilter(element, options);
                    case "BoolEquals":
                        return BoolEqualsAdvancedFilter.DeserializeBoolEqualsAdvancedFilter(element, options);
                    case "StringIn":
                        return StringInAdvancedFilter.DeserializeStringInAdvancedFilter(element, options);
                    case "StringNotIn":
                        return StringNotInAdvancedFilter.DeserializeStringNotInAdvancedFilter(element, options);
                    case "StringBeginsWith":
                        return StringBeginsWithAdvancedFilter.DeserializeStringBeginsWithAdvancedFilter(element, options);
                    case "StringEndsWith":
                        return StringEndsWithAdvancedFilter.DeserializeStringEndsWithAdvancedFilter(element, options);
                    case "StringContains":
                        return StringContainsAdvancedFilter.DeserializeStringContainsAdvancedFilter(element, options);
                    case "NumberInRange":
                        return NumberInRangeAdvancedFilter.DeserializeNumberInRangeAdvancedFilter(element, options);
                    case "NumberNotInRange":
                        return NumberNotInRangeAdvancedFilter.DeserializeNumberNotInRangeAdvancedFilter(element, options);
                    case "StringNotBeginsWith":
                        return StringNotBeginsWithAdvancedFilter.DeserializeStringNotBeginsWithAdvancedFilter(element, options);
                    case "StringNotEndsWith":
                        return StringNotEndsWithAdvancedFilter.DeserializeStringNotEndsWithAdvancedFilter(element, options);
                    case "StringNotContains":
                        return StringNotContainsAdvancedFilter.DeserializeStringNotContainsAdvancedFilter(element, options);
                    case "IsNullOrUndefined":
                        return IsNullOrUndefinedAdvancedFilter.DeserializeIsNullOrUndefinedAdvancedFilter(element, options);
                    case "IsNotNull":
                        return IsNotNullAdvancedFilter.DeserializeIsNotNullAdvancedFilter(element, options);
                }
            }
            return UnknownAdvancedFilter.DeserializeUnknownAdvancedFilter(element, options);
        }
    }

    public abstract partial class DeadLetterDestination : IJsonModel<DeadLetterDestination>, IPersistableModel<DeadLetterDestination>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected DeadLetterDestination()
        {
        }

        private protected DeadLetterDestination(DeadLetterEndPointType endpointType)
        {
            EndpointType = endpointType;
        }

        internal DeadLetterDestination(DeadLetterEndPointType endpointType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            EndpointType = endpointType;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("endpointType")]
        internal DeadLetterEndPointType EndpointType { get; set; }

        protected virtual DeadLetterDestination PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeadLetterDestination>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeDeadLetterDestination(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(DeadLetterDestination)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeadLetterDestination>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(DeadLetterDestination)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<DeadLetterDestination>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        DeadLetterDestination IPersistableModel<DeadLetterDestination>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<DeadLetterDestination>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<DeadLetterDestination>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeadLetterDestination>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeadLetterDestination)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("endpointType"u8);
            writer.WriteStringValue(EndpointType.ToString());
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        DeadLetterDestination IJsonModel<DeadLetterDestination>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual DeadLetterDestination JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeadLetterDestination>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeadLetterDestination)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeadLetterDestination(document.RootElement, options);
        }

        internal static DeadLetterDestination DeserializeDeadLetterDestination(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("endpointType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "StorageBlob":
                        return StorageBlobDeadLetterDestination.DeserializeStorageBlobDeadLetterDestination(element, options);
                }
            }
            return UnknownDeadLetterDestination.DeserializeUnknownDeadLetterDestination(element, options);
        }
    }

    public abstract partial class DeliveryAttributeMapping : IJsonModel<DeliveryAttributeMapping>, IPersistableModel<DeliveryAttributeMapping>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected DeliveryAttributeMapping()
        {
        }

        private protected DeliveryAttributeMapping(DeliveryAttributeMappingType type)
        {
            Type = type;
        }

        internal DeliveryAttributeMapping(string name, DeliveryAttributeMappingType type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Type = type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("name")]
        public string Name { get; set; }

        [WirePath("type")]
        internal DeliveryAttributeMappingType Type { get; set; }

        protected virtual DeliveryAttributeMapping PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeliveryAttributeMapping>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeDeliveryAttributeMapping(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(DeliveryAttributeMapping)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeliveryAttributeMapping>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(DeliveryAttributeMapping)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<DeliveryAttributeMapping>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        DeliveryAttributeMapping IPersistableModel<DeliveryAttributeMapping>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<DeliveryAttributeMapping>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<DeliveryAttributeMapping>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeliveryAttributeMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryAttributeMapping)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        DeliveryAttributeMapping IJsonModel<DeliveryAttributeMapping>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual DeliveryAttributeMapping JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DeliveryAttributeMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeliveryAttributeMapping)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryAttributeMapping(document.RootElement, options);
        }

        internal static DeliveryAttributeMapping DeserializeDeliveryAttributeMapping(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Static":
                        return StaticDeliveryAttributeMapping.DeserializeStaticDeliveryAttributeMapping(element, options);
                    case "Dynamic":
                        return DynamicDeliveryAttributeMapping.DeserializeDynamicDeliveryAttributeMapping(element, options);
                }
            }
            return UnknownDeliveryAttributeMapping.DeserializeUnknownDeliveryAttributeMapping(element, options);
        }
    }

    public abstract partial class EventGridFilter : IJsonModel<EventGridFilter>, IPersistableModel<EventGridFilter>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected EventGridFilter()
        {
        }

        private protected EventGridFilter(FilterOperatorType operatorType)
        {
            OperatorType = operatorType;
        }

        internal EventGridFilter(FilterOperatorType operatorType, string key, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            OperatorType = operatorType;
            Key = key;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("operatorType")]
        internal FilterOperatorType OperatorType { get; set; }

        [WirePath("key")]
        public string Key { get; set; }

        protected virtual EventGridFilter PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridFilter>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeEventGridFilter(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(EventGridFilter)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridFilter>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(EventGridFilter)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<EventGridFilter>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        EventGridFilter IPersistableModel<EventGridFilter>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<EventGridFilter>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<EventGridFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventGridFilter)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("operatorType"u8);
            writer.WriteStringValue(OperatorType.ToString());
            if (Optional.IsDefined(Key))
            {
                writer.WritePropertyName("key"u8);
                writer.WriteStringValue(Key);
            }
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        EventGridFilter IJsonModel<EventGridFilter>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual EventGridFilter JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventGridFilter)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEventGridFilter(document.RootElement, options);
        }

        internal static EventGridFilter DeserializeEventGridFilter(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("operatorType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "NumberIn":
                        return NumberInFilter.DeserializeNumberInFilter(element, options);
                    case "NumberNotIn":
                        return NumberNotInFilter.DeserializeNumberNotInFilter(element, options);
                    case "NumberLessThan":
                        return NumberLessThanFilter.DeserializeNumberLessThanFilter(element, options);
                    case "NumberGreaterThan":
                        return NumberGreaterThanFilter.DeserializeNumberGreaterThanFilter(element, options);
                    case "NumberLessThanOrEquals":
                        return NumberLessThanOrEqualsFilter.DeserializeNumberLessThanOrEqualsFilter(element, options);
                    case "NumberGreaterThanOrEquals":
                        return NumberGreaterThanOrEqualsFilter.DeserializeNumberGreaterThanOrEqualsFilter(element, options);
                    case "BoolEquals":
                        return BoolEqualsFilter.DeserializeBoolEqualsFilter(element, options);
                    case "StringIn":
                        return StringInFilter.DeserializeStringInFilter(element, options);
                    case "StringNotIn":
                        return StringNotInFilter.DeserializeStringNotInFilter(element, options);
                    case "StringBeginsWith":
                        return StringBeginsWithFilter.DeserializeStringBeginsWithFilter(element, options);
                    case "StringEndsWith":
                        return StringEndsWithFilter.DeserializeStringEndsWithFilter(element, options);
                    case "StringContains":
                        return StringContainsFilter.DeserializeStringContainsFilter(element, options);
                    case "NumberInRange":
                        return NumberInRangeFilter.DeserializeNumberInRangeFilter(element, options);
                    case "NumberNotInRange":
                        return NumberNotInRangeFilter.DeserializeNumberNotInRangeFilter(element, options);
                    case "StringNotBeginsWith":
                        return StringNotBeginsWithFilter.DeserializeStringNotBeginsWithFilter(element, options);
                    case "StringNotEndsWith":
                        return StringNotEndsWithFilter.DeserializeStringNotEndsWithFilter(element, options);
                    case "StringNotContains":
                        return StringNotContainsFilter.DeserializeStringNotContainsFilter(element, options);
                    case "IsNullOrUndefined":
                        return IsNullOrUndefinedFilter.DeserializeIsNullOrUndefinedFilter(element, options);
                    case "IsNotNull":
                        return IsNotNullFilter.DeserializeIsNotNullFilter(element, options);
                }
            }
            return UnknownFilter.DeserializeUnknownFilter(element, options);
        }
    }

    public abstract partial class EventGridInputSchemaMapping : IJsonModel<EventGridInputSchemaMapping>, IPersistableModel<EventGridInputSchemaMapping>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected EventGridInputSchemaMapping()
        {
        }

        private protected EventGridInputSchemaMapping(InputSchemaMappingType inputSchemaMappingType)
        {
            InputSchemaMappingType = inputSchemaMappingType;
        }

        internal EventGridInputSchemaMapping(InputSchemaMappingType inputSchemaMappingType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            InputSchemaMappingType = inputSchemaMappingType;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("inputSchemaMappingType")]
        internal InputSchemaMappingType InputSchemaMappingType { get; set; }

        protected virtual EventGridInputSchemaMapping PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridInputSchemaMapping>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeEventGridInputSchemaMapping(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(EventGridInputSchemaMapping)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridInputSchemaMapping>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(EventGridInputSchemaMapping)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<EventGridInputSchemaMapping>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        EventGridInputSchemaMapping IPersistableModel<EventGridInputSchemaMapping>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<EventGridInputSchemaMapping>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<EventGridInputSchemaMapping>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridInputSchemaMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventGridInputSchemaMapping)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("inputSchemaMappingType"u8);
            writer.WriteStringValue(InputSchemaMappingType.ToString());
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        EventGridInputSchemaMapping IJsonModel<EventGridInputSchemaMapping>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual EventGridInputSchemaMapping JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridInputSchemaMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventGridInputSchemaMapping)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEventGridInputSchemaMapping(document.RootElement, options);
        }

        internal static EventGridInputSchemaMapping DeserializeEventGridInputSchemaMapping(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("inputSchemaMappingType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Json":
                        return EventGridJsonInputSchemaMapping.DeserializeEventGridJsonInputSchemaMapping(element, options);
                }
            }
            return UnknownInputSchemaMapping.DeserializeUnknownInputSchemaMapping(element, options);
        }
    }

    public abstract partial class EventSubscriptionDestination : IJsonModel<EventSubscriptionDestination>, IPersistableModel<EventSubscriptionDestination>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected EventSubscriptionDestination()
        {
        }

        private protected EventSubscriptionDestination(EndpointType endpointType)
        {
            EndpointType = endpointType;
        }

        internal EventSubscriptionDestination(EndpointType endpointType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            EndpointType = endpointType;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("endpointType")]
        internal EndpointType EndpointType { get; set; }

        protected virtual EventSubscriptionDestination PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventSubscriptionDestination>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeEventSubscriptionDestination(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(EventSubscriptionDestination)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventSubscriptionDestination>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(EventSubscriptionDestination)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<EventSubscriptionDestination>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        EventSubscriptionDestination IPersistableModel<EventSubscriptionDestination>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<EventSubscriptionDestination>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<EventSubscriptionDestination>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventSubscriptionDestination>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventSubscriptionDestination)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("endpointType"u8);
            writer.WriteStringValue(EndpointType.ToString());
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        EventSubscriptionDestination IJsonModel<EventSubscriptionDestination>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual EventSubscriptionDestination JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventSubscriptionDestination>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventSubscriptionDestination)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEventSubscriptionDestination(document.RootElement, options);
        }

        internal static EventSubscriptionDestination DeserializeEventSubscriptionDestination(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("endpointType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "WebHook":
                        return WebHookEventSubscriptionDestination.DeserializeWebHookEventSubscriptionDestination(element, options);
                    case "EventHub":
                        return EventHubEventSubscriptionDestination.DeserializeEventHubEventSubscriptionDestination(element, options);
                    case "StorageQueue":
                        return StorageQueueEventSubscriptionDestination.DeserializeStorageQueueEventSubscriptionDestination(element, options);
                    case "HybridConnection":
                        return HybridConnectionEventSubscriptionDestination.DeserializeHybridConnectionEventSubscriptionDestination(element, options);
                    case "ServiceBusQueue":
                        return ServiceBusQueueEventSubscriptionDestination.DeserializeServiceBusQueueEventSubscriptionDestination(element, options);
                    case "ServiceBusTopic":
                        return ServiceBusTopicEventSubscriptionDestination.DeserializeServiceBusTopicEventSubscriptionDestination(element, options);
                    case "AzureFunction":
                        return AzureFunctionEventSubscriptionDestination.DeserializeAzureFunctionEventSubscriptionDestination(element, options);
                    case "PartnerDestination":
                        return PartnerEventSubscriptionDestination.DeserializePartnerEventSubscriptionDestination(element, options);
                    case "MonitorAlert":
                        return MonitorAlertEventSubscriptionDestination.DeserializeMonitorAlertEventSubscriptionDestination(element, options);
                    case "NamespaceTopic":
                        return NamespaceTopicEventSubscriptionDestination.DeserializeNamespaceTopicEventSubscriptionDestination(element, options);
                }
            }
            return UnknownEventSubscriptionDestination.DeserializeUnknownEventSubscriptionDestination(element, options);
        }
    }

    public abstract partial class StaticRoutingEnrichment : IJsonModel<StaticRoutingEnrichment>, IPersistableModel<StaticRoutingEnrichment>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        protected StaticRoutingEnrichment()
        {
        }

        private protected StaticRoutingEnrichment(StaticRoutingEnrichmentType valueType)
        {
            ValueType = valueType;
        }

        internal StaticRoutingEnrichment(string key, StaticRoutingEnrichmentType valueType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Key = key;
            ValueType = valueType;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        [WirePath("key")]
        public string Key { get; set; }

        [WirePath("valueType")]
        internal StaticRoutingEnrichmentType ValueType { get; set; }

        protected virtual StaticRoutingEnrichment PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticRoutingEnrichment>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeStaticRoutingEnrichment(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(StaticRoutingEnrichment)} does not support reading '{options.Format}' format."),
            };
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticRoutingEnrichment>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(StaticRoutingEnrichment)} does not support writing '{options.Format}' format."),
            };
        }

        BinaryData IPersistableModel<StaticRoutingEnrichment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        StaticRoutingEnrichment IPersistableModel<StaticRoutingEnrichment>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<StaticRoutingEnrichment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<StaticRoutingEnrichment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticRoutingEnrichment>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StaticRoutingEnrichment)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Key))
            {
                writer.WritePropertyName("key"u8);
                writer.WriteStringValue(Key);
            }
            writer.WritePropertyName("valueType"u8);
            writer.WriteStringValue(ValueType.ToString());
            CompatModelSerializationHelpers.WriteAdditionalProperties(writer, options, _additionalBinaryDataProperties);
        }

        StaticRoutingEnrichment IJsonModel<StaticRoutingEnrichment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual StaticRoutingEnrichment JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticRoutingEnrichment>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StaticRoutingEnrichment)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStaticRoutingEnrichment(document.RootElement, options);
        }

        internal static StaticRoutingEnrichment DeserializeStaticRoutingEnrichment(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("valueType"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "String":
                        return StaticStringRoutingEnrichment.DeserializeStaticStringRoutingEnrichment(element, options);
                }
            }
            return UnknownStaticRoutingEnrichment.DeserializeUnknownStaticRoutingEnrichment(element, options);
        }
    }

    internal sealed class UnknownFilter : EventGridFilter
    {
        internal UnknownFilter()
        {
        }

        internal UnknownFilter(FilterOperatorType operatorType, string key, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(operatorType != default ? operatorType : "unknown", key, additionalBinaryDataProperties)
        {
        }

        internal static UnknownFilter DeserializeUnknownFilter(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FilterOperatorType operatorType = default;
            string key = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("operatorType"u8))
                {
                    operatorType = new FilterOperatorType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("key"u8))
                {
                    key = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UnknownFilter(operatorType, key, additionalBinaryDataProperties);
        }
    }

    internal sealed class UnknownInputSchemaMapping : EventGridInputSchemaMapping
    {
        internal UnknownInputSchemaMapping()
        {
        }

        internal UnknownInputSchemaMapping(InputSchemaMappingType inputSchemaMappingType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(inputSchemaMappingType != default ? inputSchemaMappingType : "unknown", additionalBinaryDataProperties)
        {
        }

        internal static UnknownInputSchemaMapping DeserializeUnknownInputSchemaMapping(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InputSchemaMappingType inputSchemaMappingType = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("inputSchemaMappingType"u8))
                {
                    inputSchemaMappingType = new InputSchemaMappingType(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UnknownInputSchemaMapping(inputSchemaMappingType, additionalBinaryDataProperties);
        }
    }

    internal static class CompatModelSerializationHelpers
    {
        internal static void WriteAdditionalProperties(Utf8JsonWriter writer, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (options.Format == "W" || additionalBinaryDataProperties == null)
            {
                return;
            }

            foreach (KeyValuePair<string, BinaryData> item in additionalBinaryDataProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using JsonDocument document = JsonDocument.Parse(item.Value);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
        }
    }
}
