// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class ExecuteRuleStatus : IUtf8JsonSerializable, IJsonModel<ExecuteRuleStatus>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ExecuteRuleStatus>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ExecuteRuleStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExecuteRuleStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExecuteRuleStatus)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(OperationId))
            {
                writer.WritePropertyName("operationId"u8);
                writer.WriteStringValue(OperationId);
            }
            writer.WriteEndObject();
        }

        ExecuteRuleStatus IJsonModel<ExecuteRuleStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExecuteRuleStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExecuteRuleStatus)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExecuteRuleStatus(document.RootElement, options);
        }

        internal static ExecuteRuleStatus DeserializeExecuteRuleStatus(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> operationId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("operationId"u8))
                {
                    operationId = property.Value.GetString();
                    continue;
                }
            }
            return new ExecuteRuleStatus(operationId.Value);
        }

        BinaryData IPersistableModel<ExecuteRuleStatus>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExecuteRuleStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ExecuteRuleStatus)} does not support '{options.Format}' format.");
            }
        }

        ExecuteRuleStatus IPersistableModel<ExecuteRuleStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExecuteRuleStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeExecuteRuleStatus(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExecuteRuleStatus)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExecuteRuleStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
