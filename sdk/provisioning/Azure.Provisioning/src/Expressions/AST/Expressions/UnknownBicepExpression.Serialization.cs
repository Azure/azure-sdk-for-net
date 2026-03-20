// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Serialization for the UnknownBicepExpression proxy. MRW routes abstract
/// BicepExpression reads through this type, so the kind-based dispatch lives here.
/// </summary>
internal partial class UnknownBicepExpression : IJsonModel<BicepExpression>
{
    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
        throw new InvalidOperationException("UnknownBicepExpression cannot be written.");

    BicepExpression IJsonModel<BicepExpression>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return DeserializeBicepExpression(doc.RootElement);
    }

    BinaryData IPersistableModel<BicepExpression>.Write(ModelReaderWriterOptions options) =>
        throw new InvalidOperationException("UnknownBicepExpression cannot be written.");

    BicepExpression IPersistableModel<BicepExpression>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(data);
        return DeserializeBicepExpression(doc.RootElement);
    }

    string IPersistableModel<BicepExpression>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static BicepExpression DeserializeBicepExpression(JsonElement element)
    {
        string kind = element.GetProperty("kind").GetString()!;
        return kind switch
        {
            "string" => StringLiteralExpression.DeserializeStringLiteralExpression(element),
            "integer" => IntLiteralExpression.DeserializeIntLiteralExpression(element),
            "boolean" => BoolLiteralExpression.DeserializeBoolLiteralExpression(element),
            "null" => NullLiteralExpression.DeserializeNullLiteralExpression(element),
            "object" => ObjectExpression.DeserializeObjectExpression(element),
            "array" => ArrayExpression.DeserializeArrayExpression(element),
            "identifier" => IdentifierExpression.DeserializeIdentifierExpression(element),
            "function-call" => FunctionCallExpression.DeserializeFunctionCallExpression(element),
            "property-access" => DeserializePropertyAccess(element),
            "array-access" => DeserializeArrayAccess(element),
            "contextual-variable" => DeserializeContextualVariable(element),
            "primitive-type" => TypeExpression.DeserializeTypeExpression(element),
            "binary" => BinaryExpression.DeserializeBinaryExpression(element),
            "unary" => UnaryExpression.DeserializeUnaryExpression(element),
            "conditional" => ConditionalExpression.DeserializeConditionalExpression(element),
            "interpolated-string" => InterpolatedStringExpression.DeserializeInterpolatedStringExpression(element),
            "nested-access" => NestedExpression.DeserializeNestedExpression(element),
            "decorator" => DecoratorExpression.DeserializeDecoratorExpression(element),
            _ => throw new InvalidOperationException($"Unknown BicepExpression kind: {kind}")
        };
    }

    private static BicepExpression DeserializePropertyAccess(JsonElement element)
    {
        BicepExpression baseExpr = DeserializeBicepExpression(element.GetProperty("base"));
        string property = element.GetProperty("property").GetString()!;
        bool nullish = element.TryGetProperty("nullish", out JsonElement n) && n.GetBoolean();
        return nullish
            ? new SafeMemberExpression(baseExpr, property)
            : new MemberExpression(baseExpr, property);
    }

    private static BicepExpression DeserializeArrayAccess(JsonElement element)
    {
        BicepExpression baseExpr = DeserializeBicepExpression(element.GetProperty("base"));
        BicepExpression index = DeserializeBicepExpression(element.GetProperty("index"));
        bool nullish = element.TryGetProperty("nullish", out JsonElement n) && n.GetBoolean();
        return nullish
            ? new SafeIndexExpression(baseExpr, index)
            : new IndexExpression(baseExpr, index);
    }

    private static BicepExpression DeserializeContextualVariable(JsonElement element)
    {
        string context = element.GetProperty("context").GetString()!;
        string property = element.GetProperty("property").GetString()!;
        return new MemberExpression(
            new FunctionCallExpression(new IdentifierExpression(context)),
            property);
    }
}
