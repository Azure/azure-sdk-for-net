// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ToolchainOrchestrator.Tests
{
    public static class JsonModelExtensions
    {
        public static T DeserializeJson<T>(this IJsonModel<T> jsonModel, string jsonString) where T : new()
        {
            var options = new ModelReaderWriterOptions("J");
            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
            var reader = new Utf8JsonReader(bytes);

            return jsonModel.Create(ref reader, options);
        }
    }
}
