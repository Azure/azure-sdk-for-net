// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

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

        IndentWriter writer = new()
        {
            IndentText = "  "
        };
        foreach (Resource resource in Resources)
        {
            using (writer.Scope($"resource {resource.Name} \"{resource.ResourceType}@{resource.DefaultResourceVersion}\" = {{", "}"))
            {
                var root = BuildSchemaTree(resource.Properties);
                Dictionary<ModelBase, string> visitedTypes = new()
                {
                    [resource] = resource.Name
                };
                WriteSchemaObject(writer, root, resource.Name, visitedTypes);
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
                        throw new InvalidOperationException($"Conflict detected in schema generation. Path segment '{segment}' in property '{property.Name}' (Path: {string.Join(".", path)}) is already defined as a leaf property.");
                    }
                }
            }
        }
        return root;
    }

    private void WriteSchemaObject(IndentWriter writer, SchemaObject obj, string currentPath, Dictionary<ModelBase, string> visitedTypes)
    {
        foreach (var (name, node) in obj.Properties)
        {
            string childPath = $"{currentPath}.{name}";

            if (node is SchemaObject childObj)
            {
                using (writer.Scope($"{name}: {{", "}"))
                {
                    WriteSchemaObject(writer, childObj, childPath, visitedTypes);
                }
            }
            else if (node is SchemaProperty prop)
            {
                WritePropertySchema(writer, prop.Property, name, childPath, visitedTypes);
            }
            else
            {
                throw new InvalidOperationException($"Unknown schema node type: {node.GetType()}");
            }
        }
    }

    private void WritePropertySchema(IndentWriter writer, Property property, string name, string currentPath, Dictionary<ModelBase, string> visitedTypes)
    {
        writer.Write($"{name}: ");
        if (property.IsReadOnly)
        {
            writer.Write("readonly ");
        }

        switch (property.PropertyType)
        {
            case TypeModel complexType:
                if (visitedTypes.TryGetValue(complexType, out string? refPath))
                {
                    writer.WriteLine($"&{refPath}");
                }
                else
                {
                    visitedTypes[complexType] = currentPath;
                    using (writer.Scope("{", "}"))
                    {
                        var root = BuildSchemaTree(complexType.Properties);
                        WriteSchemaObject(writer, root, currentPath, visitedTypes);
                    }
                }
                break;

            case ListModel list when list.ElementType is TypeModel elementComplex:
                using (writer.Scope("[", "]"))
                {
                    if (visitedTypes.TryGetValue(elementComplex, out string? listRefPath))
                    {
                        writer.WriteLine($"&{listRefPath}");
                    }
                    else
                    {
                        visitedTypes[elementComplex] = $"{currentPath}[]";
                        using (writer.Scope("{", "}"))
                        {
                            var root = BuildSchemaTree(elementComplex.Properties);
                            string elementPath = $"{currentPath}[]";
                            WriteSchemaObject(writer, root, elementPath, visitedTypes);
                        }
                    }
                }
                break;

            case ListModel listSimple:
                using (writer.Scope("[", "]"))
                {
                    writer.WriteLine(GetSchemaType(listSimple.ElementType));
                }
                break;

            case DictionaryModel dictionary:
                using (writer.Scope("{", "}"))
                {
                    if (dictionary.ElementType is TypeModel dictComplexType)
                    {
                        if (visitedTypes.TryGetValue(dictComplexType, out string? dictRefPath))
                        {
                            writer.WriteLine($"{{customized property}}: &{dictRefPath}");
                        }
                        else
                        {
                            visitedTypes[dictComplexType] = $"{currentPath}.*";
                            writer.WriteLine("{customized property}: {");
                            using (writer.Scope())
                            {
                                var root = BuildSchemaTree(dictComplexType.Properties);
                                string elementPath = $"{currentPath}.*";
                                WriteSchemaObject(writer, root, elementPath, visitedTypes);
                            }
                            writer.WriteLine("}");
                        }
                    }
                    else
                    {
                        writer.WriteLine($"{{customized property}}: {GetSchemaType(dictionary.ElementType)}");
                    }
                }
                break;

            default:
                writer.WriteLine(GetSchemaType(property.PropertyType));
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
