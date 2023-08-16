// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class ParentPatchModel : IModelJsonSerializable<ParentPatchModel>, IUtf8JsonSerializable
    {
        ParentPatchModel IModelJsonSerializable<ParentPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(ref reader, options);
        }

        private static ParentPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(ref reader);
            return new ParentPatchModel(mdoc.RootElement);
        }

        ParentPatchModel IModelSerializable<ParentPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(data, options);
        }

        private static ParentPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(data);
            return new ParentPatchModel(mdoc.RootElement);
        }

        void IModelJsonSerializable<ParentPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            switch (options.Format.ToString())
            {
                case "J":
                case "W":
                    _element.WriteTo(writer, "J");
                    break;
                case "P":
                    _element.WriteTo(writer, "P");
                    break;
                default:
                    // Exception was thrown by ValidateFormat.
                    break;
            }
        }

        BinaryData IModelSerializable<ParentPatchModel>.Serialize(ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(ParentPatchModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator ParentPatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SimplePatchModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
