// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Provisioning.Generator;

namespace Azure.Provisioning.Generator.Model;

public abstract partial class Specification
{
    private void GenerateSchema()
    {
        string? generationPath = GetGenerationPath();
        if (generationPath == null)
        {
            return;
        }

        string path = Path.Combine(generationPath, "schema.log");

        IndentWriter writer = new();
        writer.IndentText = "  ";
        foreach (Resource resource in Resources)
        {
            using (writer.Scope($"resource {resource.Name} \"{resource.ResourceType}@{resource.DefaultResourceVersion}\" = {{", "}"))
            {
                var root = BuildSchemaTree(resource.Properties);
                WriteSchemaObject(writer, root);
            }
            writer.WriteLine();
        }
        File.WriteAllText(path, writer.ToString());
    }

    private SchemaObject BuildSchemaTree(IList<Property> properties)
    {
        var root = new SchemaObject();
        foreach (Property property in properties)
        {
            if (property.IsReadOnly) continue;

            // If path is null, use Name (camelCase)
            IList<string> path = property.Path ?? [property.Name.ToCamelCase()!];

            SchemaObject current = root;
            for (int i = 0; i < path.Count; i++)
            {
                string segment = path[i];
                if (i == path.Count - 1)
                {
                    current.Properties[segment] = new SchemaProperty(property);
                }
                else
                {
                    if (!current.Properties.TryGetValue(segment, out var node))
                    {
                        node = new SchemaObject();
                        current.Properties[segment] = node;
                    }

                    if (node is SchemaObject obj)
                    {
                        current = obj;
                    }
                    else
                    {
                        // Conflict: path segment is already a leaf property.
                        // This implies invalid path structure in the model.
                        // We'll ignore this property to avoid crash.
                        break;
                    }
                }
            }
        }
        return root;
    }

    private void WriteSchemaObject(IndentWriter writer, SchemaObject obj)
    {
        foreach (var kvp in obj.Properties)
        {
            string name = kvp.Key;
            SchemaNode node = kvp.Value;

            if (node is SchemaObject childObj)
            {
                writer.WriteLine($"{name}: {{");
                using (writer.Scope())
                {
                    WriteSchemaObject(writer, childObj);
                }
                writer.WriteLine("}");
            }
            else if (node is SchemaProperty prop)
            {
                WritePropertySchema(writer, prop.Property, name);
            }
        }
    }

    private void WritePropertySchema(IndentWriter writer, Property property, string name)
    {
        switch (property.PropertyType)
        {
            case TypeModel complexType:
                writer.WriteLine($"{name}: {{");
                using (writer.Scope())
                {
                    var root = BuildSchemaTree(complexType.Properties);
                    WriteSchemaObject(writer, root);
                }
                writer.WriteLine("}");
                break;

            case ListModel list when list.ElementType is TypeModel elementComplex:
                writer.WriteLine($"{name}: [");
                using (writer.Scope())
                {
                    writer.WriteLine("{");
                    using (writer.Scope())
                    {
                        var root = BuildSchemaTree(elementComplex.Properties);
                        WriteSchemaObject(writer, root);
                    }
                    writer.WriteLine("}");
                }
                writer.WriteLine("]");
                break;

            case ListModel listSimple:
                writer.WriteLine($"{name}: [");
                using (writer.Scope())
                {
                    writer.WriteLine(GetSchemaType(listSimple.ElementType));
                }
                writer.WriteLine("]");
                break;

            case DictionaryModel dictionary:
                writer.WriteLine($"{name}: {{");
                using (writer.Scope())
                {
                    if (dictionary.ElementType is TypeModel dictComplexType)
                    {
                        writer.WriteLine("{customized property}: {");
                        using (writer.Scope())
                        {
                            var root = BuildSchemaTree(dictComplexType.Properties);
                            WriteSchemaObject(writer, root);
                        }
                        writer.WriteLine("}");
                    }
                    else
                    {
                        writer.WriteLine($"{{customized property}}: {GetSchemaType(dictionary.ElementType)}");
                    }
                }
                writer.WriteLine("}");
                break;

            default:
                writer.WriteLine($"{name}: {GetSchemaType(property.PropertyType)}");
                break;
        }
    }

    private string GetSchemaType(ModelBase? type)
    {
        if (type is ExternalModel external)
        {
             string refName = external.GetTypeReference();
             return refName switch
             {
                 "AzureLocation" => "'string'",
                 "ETag" => "'string'",
                 "Guid" => "'string'",
                 "Uri" => "'string'",
                 "DateTimeOffset" => "'string'",
                 "ResourceIdentifier" => "'string'",
                 "ResourceType" => "'string'",
                 "object" => "any",
                 "string" => "'string'",
                 _ => refName
             };
        }
        if (type is EnumModel) return "'string'";
        if (type is SimpleModel || type is TypeModel) return "object";
        if (type is ListModel list) return $"{GetSchemaType(list.ElementType)}[]";
        if (type is DictionaryModel) return "object";
        if (type is Resource) return "object"; // Should not happen as property type usually
        return "any";
    }

    private abstract class SchemaNode { }

    private class SchemaObject : SchemaNode
    {
        public Dictionary<string, SchemaNode> Properties { get; } = [];
    }

    private class SchemaProperty(Property property) : SchemaNode
    {
        public Property Property { get; } = property;
    }
}
