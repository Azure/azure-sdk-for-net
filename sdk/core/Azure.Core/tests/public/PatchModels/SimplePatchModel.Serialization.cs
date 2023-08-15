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
            => Deserialize(ref reader, options);

        private static SimplePatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(ref reader);
            return new SimplePatchModel(mdoc.RootElement);
        }

        SimplePatchModel IModelSerializable<SimplePatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
            => Deserialize(data, options);

        private static SimplePatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            return new SimplePatchModel(mdoc.RootElement);
        }

        void IModelJsonSerializable<SimplePatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            switch (options.Format.ToString())
            {
                case "J":
                case "W":
                    _element.WriteTo(writer, options.Format.ToString());
                    break;
                case "P":
                    _element.WriteTo(writer, options.Format.ToString());
                    break;
            }
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

        public static explicit operator SimplePatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
