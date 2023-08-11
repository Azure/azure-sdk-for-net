// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class SimplePatchModel : IModelJsonSerializable<SimplePatchModel>
    {
        SimplePatchModel IModelJsonSerializable<SimplePatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            MutableJsonDocument mdoc = new(doc, new JsonSerializerOptions());
            return new SimplePatchModel(mdoc.RootElement);
        }

        SimplePatchModel IModelSerializable<SimplePatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            MutableJsonDocument jsonDocument = MutableJsonDocument.Parse(data);
            return new SimplePatchModel(jsonDocument.RootElement);
        }

        void IModelJsonSerializable<SimplePatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            _element.WriteTo(writer, options.Format.ToString());
        }

        BinaryData IModelSerializable<SimplePatchModel>.Serialize(ModelSerializerOptions options)
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            _element.WriteTo(writer, options.Format.ToString());
            writer.Flush();
            stream.Position = 0;
            return BinaryData.FromStream(stream);
        }
    }
}
