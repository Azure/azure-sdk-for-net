// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class ChildPatchModel : IModelJsonSerializable<ChildPatchModel>, IUtf8JsonSerializable
    {
        internal static ChildPatchModel Deserialize(ChangeListElement changes, JsonElement element)
        {
            string a = default;
            string b = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("a"))
                {
                    a = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("b"))
                {
                    b = property.Value.GetString();
                    continue;
                }
            }

            return new ChildPatchModel(changes, a, b);
        }

        internal static ChildPatchModel Deserialize(JsonElement element)
        {
            // If we deserialize outside the context of a parent model with a
            // change list to connect to, we can assume the child model
            // is not nested in a parent model, so it has an independent change
            // tracking mechanism.

            return Deserialize(new ChangeList().RootElement, element);
        }

        ChildPatchModel IModelJsonSerializable<ChildPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(ref reader, options);
        }

        private static ChildPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.ParseValue(ref reader).RootElement;
            return Deserialize(element);
        }

        ChildPatchModel IModelSerializable<ChildPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(data, options);
        }

        private static ChildPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.Parse(data).RootElement;
            return Deserialize(element);
        }

        internal void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("a");
            writer.WriteStringValue(A);

            writer.WritePropertyName("b");
            writer.WriteStringValue(B);

            writer.WriteEndObject();
        }

        internal void SerializePatch(Utf8JsonWriter writer)
        {
            throw new NotImplementedException();
        }

        void IModelJsonSerializable<ChildPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            switch (options.Format.ToString())
            {
                case "J":
                case "W":
                    SerializeFull(writer);
                    break;
                case "P":
                    SerializePatch(writer);
                    break;
                default:
                    // Exception was thrown by ValidateFormat.
                    break;
            }
        }

        BinaryData IModelSerializable<ChildPatchModel>.Serialize(ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(ChildPatchModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator ChildPatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SimplePatchModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
