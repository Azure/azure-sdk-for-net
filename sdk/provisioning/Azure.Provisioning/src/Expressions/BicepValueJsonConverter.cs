// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Converts JSON elements into Bicep expressions.
/// </summary>
internal static class BicepValueJsonConverter
{
    /// <summary>
    /// Converts an <see cref="IJsonModel{T}"/> into a <see cref="BicepExpression"/>
    /// by serializing to JSON and then converting the JSON to Bicep.
    /// </summary>
    public static BicepExpression ConvertFromJsonModel<T>(IJsonModel<T> model)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            model.Write(writer, ModelReaderWriterOptions.Json);
        }
        using JsonDocument doc = JsonDocument.Parse(stream.ToArray());
        return ConvertFromJson(doc.RootElement);
    }

    /// <summary>
    /// Converts a <see cref="JsonElement"/> into a <see cref="BicepExpression"/>.
    /// </summary>
    /// <param name="element">The JSON element to convert.</param>
    /// <returns>A Bicep expression representing the JSON value.</returns>
    public static BicepExpression ConvertFromJson(JsonElement element) => element.ValueKind switch
    {
        JsonValueKind.String => BicepSyntax.Value(element.GetString()!),
        JsonValueKind.Number when element.TryGetInt32(out int i) => BicepSyntax.Value(i),
        JsonValueKind.Number => BicepSyntax.Value(element.GetDouble()),
        JsonValueKind.True => BicepSyntax.Value(true),
        JsonValueKind.False => BicepSyntax.Value(false),
        JsonValueKind.Null => BicepSyntax.Null(),
        JsonValueKind.Object => ConvertObject(element),
        JsonValueKind.Array => ConvertArray(element),
        _ => throw new InvalidOperationException($"Unsupported JSON value kind: {element.ValueKind}")
    };

    private static BicepExpression ConvertObject(JsonElement element)
    {
        List<PropertyExpression> properties = [];
        foreach (JsonProperty prop in element.EnumerateObject())
        {
            properties.Add(new PropertyExpression(prop.Name, ConvertFromJson(prop.Value)));
        }
        return new ObjectExpression([.. properties]);
    }

    private static BicepExpression ConvertArray(JsonElement element)
    {
        List<BicepExpression> values = [];
        foreach (JsonElement item in element.EnumerateArray())
        {
            values.Add(ConvertFromJson(item));
        }
        return new ArrayExpression([.. values]);
    }
}
