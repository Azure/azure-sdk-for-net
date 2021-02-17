// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository
{
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

        public ModelMetadata GetMetadata()
        {
            return new ModelMetadata(GetId(), GetExtends(), GetComponentSchemas());
        }

        public string GetId()
        {
            using (JsonDocument document = JsonDocument.Parse(_content, _parseOptions))
            {
                JsonElement _root = document.RootElement;

                if (_root.ValueKind == JsonValueKind.Object && _root.TryGetProperty("@id", out JsonElement id))
                {
                    if (id.ValueKind == JsonValueKind.String)
                    {
                        return id.GetString();
                    }
                }
            }

            return string.Empty;
        }

        public IList<string> GetExtends()
        {
            List<string> dependencies = new List<string>();

            using (JsonDocument document = JsonDocument.Parse(_content, _parseOptions))
            {
                JsonElement _root = document.RootElement;

                if (_root.ValueKind == JsonValueKind.Object && _root.TryGetProperty("extends", out JsonElement extends))
                {
                    if (extends.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement extendElement in extends.EnumerateArray())
                        {
                            if (extendElement.ValueKind == JsonValueKind.String)
                            {
                                dependencies.Add(extendElement.GetString());
                            }
                            else if (extendElement.ValueKind == JsonValueKind.Object)
                            {
                                // extends can have multiple levels and can contain components.
                                // TODO: Support object ctor - inefficient serialize.
                                ModelMetadata nested_interface = new ModelQuery(JsonSerializer.Serialize(extendElement)).GetMetadata();
                                dependencies.AddRange(nested_interface.Dependencies);
                            }
                        }
                    }
                    else if (extends.ValueKind == JsonValueKind.String)
                    {
                        dependencies.Add(extends.GetString());
                    }
                }
            }

            return dependencies;
        }

        // TODO: Consider refactor to an object type based processing.
        public IList<string> GetComponentSchemas()
        {
            List<string> componentSchemas = new List<string>();

            using (JsonDocument document = JsonDocument.Parse(_content, _parseOptions))
            {
                JsonElement _root = document.RootElement;

                if (_root.ValueKind == JsonValueKind.Object && _root.TryGetProperty("contents", out JsonElement contents))
                {
                    if (contents.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement element in contents.EnumerateArray())
                        {
                            if (element.TryGetProperty("@type", out JsonElement type))
                            {
                                if (type.ValueKind == JsonValueKind.String && type.GetString() == "Component")
                                {
                                    if (element.TryGetProperty("schema", out JsonElement schema))
                                    {
                                        if (schema.ValueKind == JsonValueKind.String)
                                        {
                                            componentSchemas.Add(schema.GetString());
                                        }
                                        else if (schema.ValueKind == JsonValueKind.Array)
                                        {
                                            foreach (JsonElement schemaElement in schema.EnumerateArray())
                                            {
                                                if (schemaElement.ValueKind == JsonValueKind.String)
                                                {
                                                    componentSchemas.Add(schemaElement.GetString());
                                                }
                                            }
                                        }
                                        else if (schema.ValueKind == JsonValueKind.Object)
                                        {
                                            if (schema.TryGetProperty("extends", out JsonElement schemaObjExtends))
                                            {
                                                if (schemaObjExtends.ValueKind == JsonValueKind.String)
                                                {
                                                    componentSchemas.Add(schemaObjExtends.GetString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return componentSchemas;
        }

        public Dictionary<string, string> ListToDict()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using (JsonDocument document = JsonDocument.Parse(_content, _parseOptions))
            {
                JsonElement _root = document.RootElement;

                if (_root.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement element in _root.EnumerateArray())
                    {
                        if (element.ValueKind == JsonValueKind.Object)
                        {
                            using MemoryStream stream = WriteJsonElementToStream(element);

                            using (StreamReader streamReader = new StreamReader(stream))
                            {
                                string serialized = streamReader.ReadToEnd();

                                string id = new ModelQuery(serialized).GetId();
                                result.Add(id, serialized);
                            }
                        }
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
