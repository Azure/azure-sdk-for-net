// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions
{
    public partial class IfConditionExpression : IJsonModel<BicepExpression>
    {
        void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("kind", "if-condition");
            writer.WritePropertyName("condition");
            ((IJsonModel<BicepExpression>)Condition).Write(writer, options);
            writer.WritePropertyName("body");
            ((IJsonModel<BicepExpression>)Body).Write(writer, options);
            writer.WriteEndObject();
        }

        BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeIfConditionExpression(doc.RootElement);
        }

        BinaryData IPersistableModel<BicepExpression>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BicepExpression>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureProvisioningContext.Default);
                case "bicep":
                    return new BinaryData(new BicepWriter().Append(this).ToString());
                default:
                    throw new FormatException($"The model {nameof(IfConditionExpression)} does not support writing '{format}' format.");
            }
        }

        BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.Parse(data);
            return DeserializeIfConditionExpression(doc.RootElement);
        }

        string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public override bool Equals(BicepExpression? other) => other is IfConditionExpression c && Condition.Equals(c.Condition) && Body.Equals(c.Body);
        public override int GetHashCode() => typeof(IfConditionExpression).GetHashCode() ^ (Condition?.GetHashCode() ?? 0) ^ (Body?.GetHashCode() ?? 0);

        internal static IfConditionExpression DeserializeIfConditionExpression(JsonElement element)
        {
            return new IfConditionExpression(
                UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("condition")),
                UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("body")));
        }
    }
}
