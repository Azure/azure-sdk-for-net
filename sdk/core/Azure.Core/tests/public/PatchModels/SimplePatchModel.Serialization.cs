// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Json;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary> Load test model. </summary>
    public partial class SimplePatchModel
    {
        public static object Deserialize(ref Utf8JsonReader reader, string format)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            MutableJsonDocument mdoc = new(doc, new JsonSerializerOptions());
            return new SimplePatchModel(mdoc.RootElement);
        }

        public static object Deserialize(BinaryData data)
        {
            MutableJsonDocument jsonDocument = MutableJsonDocument.Parse(data);
            return new SimplePatchModel(jsonDocument.RootElement);
        }

        public void Serialize(Utf8JsonWriter writer, string format)
        {
            _element.WriteTo(writer, format);
        }
    }
}
