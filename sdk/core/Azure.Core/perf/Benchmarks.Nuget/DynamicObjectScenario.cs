// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Tests;

namespace Benchmarks.Nuget
{
    /// <summary>
    /// Provides scenarios for benchmarking dynamic object serialization and deserialization using different models.
    /// </summary>
    public class DynamicObjectScenario : IDisposable
    {
        private readonly string _fileName;
        private JsonDocument _jsonDocument;
        private ModelWithBinaryData _modelWithBinaryData;
        private ModelWithObject _modelWithObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicObjectScenario"/> class with the specified file name.
        /// </summary>
        /// <param name="fileName">The path to the JSON file to use for the scenario.</param>
        internal DynamicObjectScenario(string fileName)
        {
            _fileName = fileName;
            using var fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            _jsonDocument = JsonDocument.Parse(fs);

            var anon = new
            {
                a = "properties.a.value",
                innerProperties = new
                {
                    a = "properties.innerProperties.a.value"
                }
            };

            _modelWithBinaryData = new ModelWithBinaryData();
            _modelWithBinaryData.A = "a.value";
            _modelWithBinaryData.Properties = BinaryData.FromObjectAsJson(anon);

            _modelWithObject = new ModelWithObject();
            _modelWithObject.A = "a.value";
            _modelWithObject.Properties = new Dictionary<string, object>()
            {
                { "a", "a.value" },
                { "innerProperties", new Dictionary<string, object>()
                    {
                        {"a", "properties.innerProperties.a.value" }
                    }
                }
            };
        }

        /// <summary>
        /// Deserializes a <see cref="ModelWithObject"/> instance from the loaded JSON document.
        /// </summary>
        public void DeserializeWithObject()
        {
            var model = ModelWithObject.DeserializeModelWithObject(_jsonDocument.RootElement);
        }

        /// <summary>
        /// Deserializes a <see cref="ModelWithObject"/> instance from the loaded JSON document and accesses nested properties.
        /// </summary>
        public void DeserializeWithObjectAndAccess()
        {
            var model = ModelWithObject.DeserializeModelWithObject(_jsonDocument.RootElement);
            var properties = model.Properties as Dictionary<string, object>;
            var innerProperties = properties!["innerProperties"] as Dictionary<string, object>;
            var innerA = innerProperties!["a"] as string;
        }

        /// <summary>
        /// Serializes the <see cref="ModelWithObject"/> instance to JSON using a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        public void SerializeWithObject()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            _modelWithObject.Write(writer);
        }

        /// <summary>
        /// Deserializes a <see cref="ModelWithBinaryData"/> instance from the loaded JSON document.
        /// </summary>
        public void DeserializeWithBinaryData()
        {
            var model = ModelWithBinaryData.DeserializeModelWithBinaryData(_jsonDocument.RootElement);
        }

        /// <summary>
        /// Deserializes a <see cref="ModelWithBinaryData"/> instance from the loaded JSON document and accesses nested properties.
        /// </summary>
        public void DeserializeWithBinaryDataAndAccess()
        {
            var model = ModelWithBinaryData.DeserializeModelWithBinaryData(_jsonDocument.RootElement);
            var properties = model.Properties.ToObjectFromJson<Dictionary<string, object>>();
            if (properties!["innerProperties"] is JsonElement innerElement && innerElement.ValueKind == JsonValueKind.Object)
            {
                var innerProperties = JsonSerializer.Deserialize<Dictionary<string, object>>(innerElement.GetRawText());
                // Now you can access innerA
                var innerA = innerProperties!["a"] as string;
            }
        }

        /// <summary>
        /// Serializes the <see cref="ModelWithBinaryData"/> instance to JSON using a <see cref="Utf8JsonWriter"/>.
        /// </summary>
        public void SerializeWithBinaryData()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            _modelWithBinaryData.Write(writer);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="DynamicObjectScenario"/> instance.
        /// </summary>
        public void Dispose()
        {
            _jsonDocument?.Dispose();
        }
    }
}
