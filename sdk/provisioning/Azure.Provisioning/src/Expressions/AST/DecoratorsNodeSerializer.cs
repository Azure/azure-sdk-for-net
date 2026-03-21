// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Shared helpers for writing and reading the structured DecoratorsNode
/// defined in the TypeSpec schema (declarations.tsp).
/// </summary>
internal static class DecoratorsNodeSerializer
{
    /// <summary>
    /// Writes a structured "decorators" object from a list of DecoratorExpressions.
    /// Per schema: DecoratorsNode { description?, secure?, minValue?, maxValue?, ... }
    /// </summary>
    internal static void WriteDecoratorsNode(Utf8JsonWriter writer, IList<DecoratorExpression> decorators)
    {
        if (decorators.Count == 0)
            return;

        writer.WritePropertyName("decorators");
        writer.WriteStartObject();
        foreach (DecoratorExpression decorator in decorators)
        {
            if (decorator.Value is FunctionCallExpression funcCall &&
                funcCall.Function is IdentifierExpression id)
            {
                string name = id.Name;
                if (funcCall.Arguments.Length == 0)
                {
                    // @secure() → "secure": true
                    writer.WriteBoolean(name, true);
                }
                else if (funcCall.Arguments.Length == 1)
                {
                    BicepExpression arg = funcCall.Arguments[0];
                    if (arg is StringLiteralExpression strLit)
                        writer.WriteString(name, strLit.Value);
                    else if (arg is IntLiteralExpression intLit)
                        writer.WriteNumber(name, intLit.Value);
                    else if (arg is BoolLiteralExpression boolLit)
                        writer.WriteBoolean(name, boolLit.Value);
                    else
                    {
                        writer.WritePropertyName(name);
                        ((IJsonModel<BicepExpression>)arg).Write(writer, ModelReaderWriterOptions.Json);
                    }
                }
                else
                {
                    // Multiple args — write as array
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();
                    foreach (var arg in funcCall.Arguments)
                        ((IJsonModel<BicepExpression>)arg).Write(writer, ModelReaderWriterOptions.Json);
                    writer.WriteEndArray();
                }
            }
        }
        writer.WriteEndObject();
    }

    /// <summary>
    /// Reads a structured "decorators" object and populates the statement's Decorators list.
    /// </summary>
    internal static void ReadDecoratorsNode(JsonElement element, IList<DecoratorExpression> decorators)
    {
        if (!element.TryGetProperty("decorators", out JsonElement decsElement))
            return;

        foreach (JsonProperty prop in decsElement.EnumerateObject())
        {
            string name = prop.Name;
            BicepExpression[] args;
            if (prop.Value.ValueKind == JsonValueKind.True)
            {
                args = []; // e.g. @secure()
            }
            else if (prop.Value.ValueKind == JsonValueKind.String)
            {
                args = [new StringLiteralExpression(prop.Value.GetString()!)];
            }
            else if (prop.Value.ValueKind == JsonValueKind.Number)
            {
                long rawValue = prop.Value.GetInt64();
                if (rawValue < int.MinValue || rawValue > int.MaxValue)
                {
                    throw new FormatException(
                        $"Decorator '{name}' numeric value '{rawValue}' is outside the supported Int32 range.");
                }
                args = [new IntLiteralExpression((int)rawValue)];
            }
            else if (prop.Value.ValueKind == JsonValueKind.False)
            {
                args = [new BoolLiteralExpression(false)];
            }
            else if (prop.Value.ValueKind == JsonValueKind.Array)
            {
                var list = new List<BicepExpression>();
                foreach (JsonElement item in prop.Value.EnumerateArray())
                    list.Add(UnknownBicepExpression.DeserializeBicepExpression(item));
                args = list.ToArray();
            }
            else
            {
                args = [UnknownBicepExpression.DeserializeBicepExpression(prop.Value)];
            }
            decorators.Add(new DecoratorExpression(
                new FunctionCallExpression(new IdentifierExpression(name), args)));
        }
    }
}
