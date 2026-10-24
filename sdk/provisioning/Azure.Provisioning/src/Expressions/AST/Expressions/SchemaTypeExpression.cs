// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Provisioning.Expressions;

// Retain schema type annotations that cannot be represented by a System.Type.
// Validate and render them when read, so unsupported shapes never become opaque Bicep.
internal sealed class SchemaTypeExpression : BicepExpression, IJsonModel<BicepExpression>
{
    private readonly JsonElement _node;
    private readonly string _bicep;

    private SchemaTypeExpression(JsonElement node)
    {
        _bicep = WriteType(new BicepWriter(), node).ToString();
        _node = node.Clone();
    }

    internal static bool IsTypeKind(string kind) => kind is
        "primitive-type" or "type-reference" or
        "string-type-literal" or "integer-type-literal" or "boolean-type-literal" or "null-type-literal" or
        "array-type" or "object-type" or "object-type-property" or "object-type-additional-properties" or
        "union-type" or "union-type-member" or "nullable-type" or
        "parameterized-type-instantiation" or "parameterized-type-argument";

    internal static BicepExpression Deserialize(JsonElement node)
    {
        if (GetString(node, "kind") == "primitive-type")
        {
            Type? type = GetString(node, "name") switch
            {
                "bool" => typeof(bool),
                "int" => typeof(int),
                "string" => typeof(string),
                "object" => typeof(object),
                "array" => typeof(Array),
                "any" => null,
                var name => throw new FormatException($"Unknown primitive type '{name}'.")
            };
            if (type != null)
                return new TypeExpression(type);
        }
        return new SchemaTypeExpression(node);
    }

    internal static BicepExpression DeserializeDeclarationType(JsonElement node) =>
        GetString(node, "kind") == "type-reference"
            ? new IdentifierExpression(GetString(node, "name"))
            : Deserialize(node);

    internal static void WriteTypeNode(Utf8JsonWriter writer, BicepExpression type, ModelReaderWriterOptions options)
    {
        if (type is IdentifierExpression identifier)
        {
            writer.WriteStartObject();
            writer.WriteString("kind", "type-reference");
            writer.WriteString("name", identifier.Name);
            writer.WriteEndObject();
        }
        else if (type is TypeExpression or SchemaTypeExpression)
        {
            ((IJsonModel<BicepExpression>)type).Write(writer, options);
        }
        else
        {
            throw new NotSupportedException($"Expression '{type.GetType().Name}' cannot be serialized as a TypeNode.");
        }
    }

    void IJsonModel<BicepExpression>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, _node);
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(_bicep);
    public override bool Equals(BicepExpression? other) => other is SchemaTypeExpression type &&
        GetString(_node, "kind") == GetString(type._node, "kind") && _bicep == type._bicep;
    public override int GetHashCode() => typeof(SchemaTypeExpression).GetHashCode() ^ GetString(_node, "kind").GetHashCode() ^ _bicep.GetHashCode();

    private static void WriteJson(Utf8JsonWriter writer, JsonElement node)
    {
        writer.WriteStartObject();
        foreach (JsonProperty property in node.EnumerateObject())
        {
            if (property.Name == "decorators")
            {
                List<DecoratorExpression> decorators = new();
                DecoratorsNodeSerializer.ReadDecoratorsNode(node, decorators);
                DecoratorsNodeSerializer.WriteDecoratorsNode(writer, decorators);
                continue;
            }
            writer.WritePropertyName(property.Name);
            switch (property.Name)
            {
                case "item":
                case "base":
                case "valueType":
                case "additionalProperties":
                    WriteJson(writer, property.Value);
                    break;
                case "properties":
                case "members":
                case "args":
                    writer.WriteStartArray();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                        WriteJson(writer, item);
                    writer.WriteEndArray();
                    break;
                default:
                    property.Value.WriteTo(writer);
                    break;
            }
        }
        writer.WriteEndObject();
    }

    private static string GetString(JsonElement node, string name) =>
        node.GetProperty(name).GetString() ?? throw new FormatException($"TypeNode '{name}' must be a string.");

    private static BicepWriter WriteType(BicepWriter writer, JsonElement node)
    {
        string kind = GetString(node, "kind");
        switch (kind)
        {
            case "primitive-type":
                string name = GetString(node, "name");
                if (name is not ("any" or "array" or "bool" or "int" or "object" or "string"))
                    throw new FormatException($"Unknown primitive type '{name}'.");
                return writer.Append(name);
            case "type-reference":
                return writer.Append(GetString(node, "name"));
            case "string-type-literal":
                return writer.Append(new StringLiteralExpression(GetString(node, "value")));
            case "integer-type-literal":
                return writer.Append(long.Parse(GetString(node, "value"), NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture)
                    .ToString(CultureInfo.InvariantCulture));
            case "boolean-type-literal":
                return writer.Append(node.GetProperty("value").GetBoolean() ? "true" : "false");
            case "null-type-literal":
                if (node.GetProperty("value").ValueKind != JsonValueKind.Null)
                    throw new FormatException("A null type literal must have a null value.");
                return writer.Append("null");
            case "array-type":
                return WriteWrappedType(writer, node.GetProperty("item")).Append("[]");
            case "nullable-type":
                return WriteWrappedType(writer, node.GetProperty("base")).Append('?');
            case "union-type-member":
            case "parameterized-type-argument":
                return WriteType(writer, node.GetProperty("valueType"));
            case "union-type":
                return WriteItems(writer, node.GetProperty("members"), "union-type-member", " | ");
            case "parameterized-type-instantiation":
                WriteType(writer, node.GetProperty("base")).Append('<');
                return WriteItems(writer, node.GetProperty("args"), "parameterized-type-argument", ", ").Append('>');
            case "object-type-property":
                WriteDecorators(writer, node);
                writer.Append(new StringLiteralExpression(GetString(node, "key")));
                JsonElement propertyType = node.GetProperty("valueType");
                writer.Append(": ");
                if (node.TryGetProperty("optional", out JsonElement optional) && optional.GetBoolean() &&
                    GetString(propertyType, "kind") != "nullable-type")
                {
                    return WriteWrappedType(writer, propertyType).Append('?');
                }
                return WriteType(writer, propertyType);
            case "object-type-additional-properties":
                WriteDecorators(writer, node);
                return WriteType(writer.Append("*: "), node.GetProperty("valueType"));
            case "object-type":
                writer.Append('{').Indent(w =>
                {
                    foreach (JsonElement property in node.GetProperty("properties").EnumerateArray())
                    {
                        RequireKind(property, "object-type-property");
                        WriteType(w.AppendLine(), property);
                    }
                    if (node.TryGetProperty("additionalProperties", out JsonElement additional))
                    {
                        RequireKind(additional, "object-type-additional-properties");
                        WriteType(w.AppendLine(), additional);
                    }
                    return w;
                });
                return writer.AppendLine().Append('}');
            default:
                throw new NotSupportedException($"Type kind '{kind}' is not defined by the provisioning JSON schema.");
        }
    }

    private static BicepWriter WriteWrappedType(BicepWriter writer, JsonElement node)
    {
        bool wrap = GetString(node, "kind") == "union-type";
        if (wrap)
            writer.Append('(');
        WriteType(writer, node);
        return wrap ? writer.Append(')') : writer;
    }

    private static BicepWriter WriteItems(BicepWriter writer, JsonElement items, string kind, string separator)
    {
        bool first = true;
        foreach (JsonElement item in items.EnumerateArray())
        {
            RequireKind(item, kind);
            if (!first)
                writer.Append(separator);
            WriteType(writer, item);
            first = false;
        }
        return writer;
    }

    private static void RequireKind(JsonElement node, string kind)
    {
        if (GetString(node, "kind") != kind)
            throw new FormatException($"Expected type kind '{kind}'.");
    }

    private static void WriteDecorators(BicepWriter writer, JsonElement node)
    {
        List<DecoratorExpression> decorators = new();
        DecoratorsNodeSerializer.ReadDecoratorsNode(node, decorators);
        foreach (DecoratorExpression decorator in decorators)
            writer.Append(decorator).AppendLine();
    }
}
