// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class ParentPatchModel : IModelJsonSerializable<ParentPatchModel>
    {
        ParentPatchModel IModelJsonSerializable<ParentPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(ref reader);
            return new ParentPatchModel(mdoc.RootElement);
        }

        ParentPatchModel IModelSerializable<ParentPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            return new ParentPatchModel(mdoc.RootElement);
        }

        void IModelJsonSerializable<ParentPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            _element.WriteTo(writer, options.Format.ToString());
        }

        BinaryData IModelSerializable<ParentPatchModel>.Serialize(ModelSerializerOptions options)
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
