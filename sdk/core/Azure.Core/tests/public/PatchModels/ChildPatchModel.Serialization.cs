// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class ChildPatchModel : IModelJsonSerializable<ChildPatchModel>
    {
        ChildPatchModel IModelJsonSerializable<ChildPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            MutableJsonDocument mdoc = new(doc, new JsonSerializerOptions());
            return new ChildPatchModel(mdoc.RootElement);
        }

        ChildPatchModel IModelSerializable<ChildPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            return new ChildPatchModel(mdoc.RootElement);
        }

        void IModelJsonSerializable<ChildPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            _element.WriteTo(writer, options.Format.ToString());
        }

        BinaryData IModelSerializable<ChildPatchModel>.Serialize(ModelSerializerOptions options)
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
