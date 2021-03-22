// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// The ModelQuery class is responsible for parsing DTDL v2 models to produce key metadata.
    /// In the current form ModelQuery is focused on determining model dependencies recursively
    /// via extends and component schemas.
    /// </summary>
    internal class ModelQuery
    {
        private readonly string _content;
        private readonly JsonDocumentOptions _parseOptions;

        public ModelQuery(string content)
        {
            _content = content;
            _parseOptions = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };
        }

        public ModelMetadata ParseModel()
        {
            using JsonDocument document = JsonDocument.Parse(_content, _parseOptions);
            return ParseInterface(document.RootElement);
        }

        private static ModelMetadata ParseInterface(JsonElement root)
        {
            string rootDtmi = ParseRootDtmi(root);
            IList<string> extends = ParseExtends(root);
            IList<string> contents = ParseContents(root);

            return new ModelMetadata(rootDtmi, extends, contents);
        }

        private static string ParseRootDtmi(JsonElement root)
        {
            if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Dtmi, out JsonElement id))
            {
                if (id.ValueKind == JsonValueKind.String)
                {
                    return id.GetString();
                }
            }

            return string.Empty;
        }

        private static IList<string> ParseExtends(JsonElement root)
        {
            var dependencies = new List<string>();

            if (root.ValueKind != JsonValueKind.Object)
            {
                return dependencies;
            }

            if (!root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Extends, out JsonElement extends))
            {
                return dependencies;
            }

            if (extends.ValueKind == JsonValueKind.String)
            {
                dependencies.Add(extends.GetString());
            }
            else if (IsInterfaceObject(extends))
            {
                ModelMetadata meta = ParseInterface(extends);
                dependencies.AddRange(meta.Dependencies);
            }
            else if (extends.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement extendElement in extends.EnumerateArray())
                {
                    if (extendElement.ValueKind == JsonValueKind.String)
                    {
                        dependencies.Add(extendElement.GetString());
                    }
                    // Extends can have multiple levels and contain inline interfaces.
                    else if (IsInterfaceObject(extendElement))
                    {
                        ModelMetadata meta = ParseInterface(extendElement);
                        dependencies.AddRange(meta.Dependencies);
                    }
                }
            }

            return dependencies;
        }

        private static IList<string> ParseContents(JsonElement root)
        {
            var dependencies = new List<string>();

            if (root.ValueKind != JsonValueKind.Object)
            {
                return dependencies;
            }

            if (!root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Contents, out JsonElement contents))
            {
                return dependencies;
            }

            if (contents.ValueKind != JsonValueKind.Array)
            {
                return dependencies;
            }

            foreach (JsonElement contentElement in contents.EnumerateArray())
            {
                if (IsComponentObject(contentElement))
                {
                    dependencies.AddRange(ParseComponent(contentElement));
                }
            }

            return dependencies;
        }

        private static IList<string> ParseComponent(JsonElement root)
        {
            // We already know root is an object of @type Component

            var dependencies = new List<string>();

            if (!root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Schema, out JsonElement componentSchema))
            {
                return dependencies;
            }

            if (componentSchema.ValueKind == JsonValueKind.String)
            {
                dependencies.Add(componentSchema.GetString());
            }
            else if (IsInterfaceObject(componentSchema))
            {
                ModelMetadata meta = ParseInterface(componentSchema);
                dependencies.AddRange(meta.Dependencies);
            }
            else if (componentSchema.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement componentSchemaElement in componentSchema.EnumerateArray())
                {
                    if (componentSchemaElement.ValueKind == JsonValueKind.String)
                    {
                        dependencies.Add(componentSchemaElement.GetString());
                    }
                    else if (IsInterfaceObject(componentSchemaElement))
                    {
                        ModelMetadata meta = ParseInterface(componentSchemaElement);
                        dependencies.AddRange(meta.Dependencies);
                    }
                }
            }

            return dependencies;
        }

        private static bool IsInterfaceObject(JsonElement root)
        {
            return root.ValueKind == JsonValueKind.Object &&
                root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Type, out JsonElement objectType) &&
                objectType.ValueKind == JsonValueKind.String &&
                objectType.GetString() == ModelsRepositoryConstants.ModelProperties.TypeValueInterface;
        }

        private static bool IsComponentObject(JsonElement root)
        {
            return root.ValueKind == JsonValueKind.Object &&
                root.TryGetProperty(ModelsRepositoryConstants.ModelProperties.Type, out JsonElement objectType) &&
                objectType.ValueKind == JsonValueKind.String &&
                objectType.GetString() == ModelsRepositoryConstants.ModelProperties.TypeValueComponent;
        }

        public Dictionary<string, string> ListToDict()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using JsonDocument document = JsonDocument.Parse(_content, _parseOptions);
            JsonElement _root = document.RootElement;

            if (_root.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in _root.EnumerateArray())
                {
                    if (element.ValueKind == JsonValueKind.Object)
                    {
                        using MemoryStream stream = WriteJsonElementToStream(element);

                        using StreamReader streamReader = new StreamReader(stream);
                        string serialized = streamReader.ReadToEnd();

                        string id = new ModelQuery(serialized).ParseModel().Id;
                        result.Add(id, serialized);
                    }
                }
            }

            return result;
        }

        private static MemoryStream WriteJsonElementToStream(JsonElement item)
        {
            var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            item.WriteTo(writer);
            writer.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
