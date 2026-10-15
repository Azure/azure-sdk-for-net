// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Shared helpers for writing and reading the structured DecoratorsNode
/// defined in the TypeSpec schema (declarations.tsp).
/// </summary>
internal static class DecoratorsNodeSerializer
{
    private const long MaxSafeInteger = 9007199254740991;

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
        HashSet<string> names = new(StringComparer.Ordinal);
        foreach (DecoratorExpression decorator in decorators)
        {
            if (decorator.Value is not FunctionCallExpression funcCall ||
                funcCall.Function is not IdentifierExpression id)
            {
                throw new NotSupportedException("Only named decorator calls can be serialized as DecoratorsNode.");
            }
            string name = id.Name;
            if (!names.Add(name))
            {
                throw new NotSupportedException($"Duplicate decorator '{name}' cannot be represented by DecoratorsNode.");
            }
            BicepExpression[] args = funcCall.Arguments;
            switch (name)
            {
                case "secure":
                case "sealed":
                case "export":
                    RequireArguments(name, args, 0);
                    writer.WriteBoolean(name, true);
                    break;
                case "description":
                case "discriminator":
                    RequireArguments(name, args, 1);
                    if (args[0] is not StringLiteralExpression text)
                    {
                        throw new NotSupportedException($"Decorator '{name}' requires a string literal.");
                    }
                    writer.WriteString(name, text.Value);
                    break;
                case "minValue":
                case "maxValue":
                case "minLength":
                case "maxLength":
                case "batchSize":
                    RequireArguments(name, args, 1);
                    long value = args[0] switch
                    {
                        IntLiteralExpression integer => integer.Value,
                        LongLiteralExpression integer => integer.Value,
                        _ => throw new NotSupportedException($"Decorator '{name}' requires an integer literal.")
                    };
                    ValidateSafeInteger(name, value);
                    writer.WriteNumber(name, value);
                    break;
                case "allowed":
                    RequireArguments(name, args, 1);
                    if (args[0] is not ArrayExpression array)
                    {
                        throw new NotSupportedException("Decorator 'allowed' requires an array expression.");
                    }
                    writer.WritePropertyName(name);
                    writer.WriteStartArray();
                    foreach (BicepExpression item in array.Values)
                        ((IJsonModel<BicepExpression>)item).Write(writer, ModelReaderWriterOptions.Json);
                    writer.WriteEndArray();
                    break;
                case "metadata":
                    RequireArguments(name, args, 1);
                    if (args[0] is not ObjectExpression metadata)
                    {
                        throw new NotSupportedException("Decorator 'metadata' requires an object expression.");
                    }
                    writer.WritePropertyName(name);
                    writer.WriteStartObject();
                    foreach (PropertyExpression property in metadata.Properties)
                        ((IJsonModel<BicepExpression>)property).Write(writer, ModelReaderWriterOptions.Json);
                    writer.WriteEndObject();
                    break;
                default:
                    throw new NotSupportedException($"Decorator '{name}' is not defined by the provisioning JSON schema.");
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
            switch (name)
            {
                case "secure":
                case "sealed":
                case "export":
                    if (prop.Value.ValueKind != JsonValueKind.True)
                    {
                        throw new FormatException($"Decorator '{name}' must be true when present.");
                    }
                    args = [];
                    break;
                case "description":
                case "discriminator":
                    args = [new StringLiteralExpression(prop.Value.GetString()
                        ?? throw new FormatException($"Decorator '{name}' must be a string."))];
                    break;
                case "minValue":
                case "maxValue":
                case "minLength":
                case "maxLength":
                case "batchSize":
                    // Accept the numeric strings used by the previous schema for bounds.
                    long value = prop.Value.ValueKind == JsonValueKind.String && name != "batchSize"
                        ? long.Parse(prop.Value.GetString()!, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture)
                        : prop.Value.GetInt64();
                    ValidateSafeInteger(name, value);
                    args = [IntLiteralExpression.Create(value)];
                    break;
                case "allowed":
                    List<BicepExpression> items = new();
                    foreach (JsonElement item in prop.Value.EnumerateArray())
                        items.Add(UnknownBicepExpression.DeserializeBicepExpression(item));
                    args = [new ArrayExpression(items.ToArray())];
                    break;
                case "metadata":
                    List<PropertyExpression> properties = new();
                    foreach (JsonProperty property in prop.Value.EnumerateObject())
                        properties.Add(PropertyExpression.DeserializePropertyExpression(property.Name, property.Value));
                    args = [new ObjectExpression(properties.ToArray())];
                    break;
                default:
                    throw new NotSupportedException($"Decorator '{name}' is not defined by the provisioning JSON schema.");
            }
            decorators.Add(new DecoratorExpression(
                new FunctionCallExpression(new IdentifierExpression(name), args)));
        }
    }

    private static void RequireArguments(string name, BicepExpression[] arguments, int count)
    {
        if (arguments.Length != count)
        {
            throw new NotSupportedException($"Decorator '{name}' requires {count} argument(s) in the provisioning JSON schema.");
        }
    }

    private static void ValidateSafeInteger(string name, long value)
    {
        if (value < -MaxSafeInteger || value > MaxSafeInteger)
        {
            throw new FormatException($"Decorator '{name}' value '{value}' is outside the TypeSpec safeint range.");
        }
    }
}
