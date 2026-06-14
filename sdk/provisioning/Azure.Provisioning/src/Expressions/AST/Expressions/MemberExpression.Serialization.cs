// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class MemberExpression : IJsonModel<BicepExpression>
{
    private static readonly string[] ContextualFunctions = ["subscription", "resourceGroup", "tenant", "managementGroup", "deployment"];

    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // Detect contextual-variable pattern: MemberExpr(FunctionCall(Identifier(ctx), []), prop)
        if (Value is FunctionCallExpression funcCall &&
            funcCall.Arguments.Length == 0 &&
            funcCall.Function is IdentifierExpression funcId &&
            IsContextualFunction(funcId.Name))
        {
            writer.WriteStartObject();
            writer.WriteString("kind", "contextual-variable");
            writer.WriteString("context", funcId.Name);
            writer.WriteString("property", Member);
            writer.WriteEndObject();
            return;
        }

        writer.WriteStartObject();
        writer.WriteString("kind", "property-access");
        writer.WritePropertyName("base");
        ((IJsonModel<BicepExpression>)Value).Write(writer, options);
        writer.WriteString("property", Member);
        writer.WriteBoolean("nullish", false);
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return UnknownBicepExpression.DeserializeBicepExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(MemberExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return UnknownBicepExpression.DeserializeBicepExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is MemberExpression m && Value.Equals(m.Value) && Member == m.Member;
    public override int GetHashCode() => typeof(MemberExpression).GetHashCode() ^ (Value?.GetHashCode() ?? 0) ^ (Member?.GetHashCode() ?? 0);

    private static bool IsContextualFunction(string name)
    {
        foreach (string ctx in ContextualFunctions)
        {
            if (ctx == name) return true;
        }
        return false;
    }
}
