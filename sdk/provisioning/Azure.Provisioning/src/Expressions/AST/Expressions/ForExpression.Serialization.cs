// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions
{
    public partial class ForExpression : IJsonModel<BicepExpression>
    {
        void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("kind", "for-expression");
            writer.WriteString("itemVariable", ItemVariable);
            if (IndexVariable != null)
                writer.WriteString("indexVariable", IndexVariable);
            writer.WritePropertyName("expression");
            ((IJsonModel<BicepExpression>)Collection).Write(writer, options);
            writer.WritePropertyName("body");
            ((IJsonModel<BicepExpression>)Body).Write(writer, options);
            if (Condition != null)
            {
                writer.WritePropertyName("condition");
                ((IJsonModel<BicepExpression>)Condition).Write(writer, options);
            }
            writer.WriteEndObject();
        }

        BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeForExpression(doc.RootElement);
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
                    throw new FormatException($"The model {nameof(ForExpression)} does not support writing '{format}' format.");
            }
        }

        BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.Parse(data);
            return DeserializeForExpression(doc.RootElement);
        }

        string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public override bool Equals(BicepExpression? other)
            => other is ForExpression f
                && ItemVariable == f.ItemVariable
                && IndexVariable == f.IndexVariable
                && Collection.Equals(f.Collection)
                && Body.Equals(f.Body)
                && Equals(Condition, f.Condition);

        public override int GetHashCode()
            => typeof(ForExpression).GetHashCode()
                ^ ItemVariable.GetHashCode()
                ^ (IndexVariable?.GetHashCode() ?? 0)
                ^ (Collection?.GetHashCode() ?? 0)
                ^ (Body?.GetHashCode() ?? 0)
                ^ (Condition?.GetHashCode() ?? 0);

        internal static ForExpression DeserializeForExpression(JsonElement element)
        {
            string itemVariable = element.GetProperty("itemVariable").GetString()!;
            string? indexVariable = element.TryGetProperty("indexVariable", out JsonElement idxElem) ? idxElem.GetString() : null;
            BicepExpression collection = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("expression"));
            BicepExpression body = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("body"));
            BicepExpression? condition = element.TryGetProperty("condition", out JsonElement condElem) ? UnknownBicepExpression.DeserializeBicepExpression(condElem) : null;
            return new ForExpression(itemVariable, indexVariable, collection, body, condition);
        }
    }
}
