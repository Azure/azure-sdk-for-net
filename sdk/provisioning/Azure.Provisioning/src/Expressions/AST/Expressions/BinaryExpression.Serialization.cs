// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class BinaryExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("kind", "binary");
        writer.WriteString("operator", OperatorToString(Operator));
        writer.WritePropertyName("left");
        ((IJsonModel<BicepExpression>)Left).Write(writer, options);
        writer.WritePropertyName("right");
        ((IJsonModel<BicepExpression>)Right).Write(writer, options);
        writer.WriteEndObject();
    }

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeBinaryExpression(doc.RootElement);
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
                throw new FormatException($"The model {nameof(BinaryExpression)} does not support writing '{format}' format.");
        }
    }

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeBinaryExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepExpression? other) => other is BinaryExpression b && Left.Equals(b.Left) && Operator == b.Operator && Right.Equals(b.Right);
    public override int GetHashCode() => typeof(BinaryExpression).GetHashCode() ^ (Left?.GetHashCode() ?? 0) ^ Operator.GetHashCode() ^ (Right?.GetHashCode() ?? 0);

    internal static BinaryExpression DeserializeBinaryExpression(JsonElement element)
    {
        BinaryBicepOperator op = StringToOperator(element.GetProperty("operator").GetString()!);
        BicepExpression left = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("left"));
        BicepExpression right = UnknownBicepExpression.DeserializeBicepExpression(element.GetProperty("right"));
        return new BinaryExpression(left, op, right);
    }

    private static string OperatorToString(BinaryBicepOperator op) => op switch
    {
        BinaryBicepOperator.And => "&&",
        BinaryBicepOperator.Or => "||",
        BinaryBicepOperator.Coalesce => "??",
        BinaryBicepOperator.Equal => "==",
        BinaryBicepOperator.EqualIgnoreCase => "=~",
        BinaryBicepOperator.NotEqual => "!=",
        BinaryBicepOperator.NotEqualIgnoreCase => "!~",
        BinaryBicepOperator.Greater => ">",
        BinaryBicepOperator.GreaterOrEqual => ">=",
        BinaryBicepOperator.Less => "<",
        BinaryBicepOperator.LessOrEqual => "<=",
        BinaryBicepOperator.Add => "+",
        BinaryBicepOperator.Subtract => "-",
        BinaryBicepOperator.Multiply => "*",
        BinaryBicepOperator.Divide => "/",
        BinaryBicepOperator.Modulo => "%",
        _ => throw new NotImplementedException($"Unknown operator: {op}")
    };

    private static BinaryBicepOperator StringToOperator(string op) => op switch
    {
        "&&" => BinaryBicepOperator.And,
        "||" => BinaryBicepOperator.Or,
        "??" => BinaryBicepOperator.Coalesce,
        "==" => BinaryBicepOperator.Equal,
        "=~" => BinaryBicepOperator.EqualIgnoreCase,
        "!=" => BinaryBicepOperator.NotEqual,
        "!~" => BinaryBicepOperator.NotEqualIgnoreCase,
        ">" => BinaryBicepOperator.Greater,
        ">=" => BinaryBicepOperator.GreaterOrEqual,
        "<" => BinaryBicepOperator.Less,
        "<=" => BinaryBicepOperator.LessOrEqual,
        "+" => BinaryBicepOperator.Add,
        "-" => BinaryBicepOperator.Subtract,
        "*" => BinaryBicepOperator.Multiply,
        "/" => BinaryBicepOperator.Divide,
        "%" => BinaryBicepOperator.Modulo,
        _ => throw new NotImplementedException($"Unknown operator string: {op}")
    };
}
