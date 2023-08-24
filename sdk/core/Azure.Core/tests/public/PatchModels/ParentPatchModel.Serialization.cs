// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class ParentPatchModel : IModelJsonSerializable<ParentPatchModel>, IUtf8JsonSerializable
    {
        internal static ParentPatchModel Deserialize(JsonElement element)
        {
            string id = default;
            ChildPatchModel child = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("child"))
                {
                    child = ChildPatchModel.Deserialize(property.Value);
                    continue;
                }
            }

            return new ParentPatchModel(id, child);
        }

        ParentPatchModel IModelJsonSerializable<ParentPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);
            return Deserialize(ref reader, options);
        }

        private static ParentPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.ParseValue(ref reader).RootElement;
            return Deserialize(element);
        }

        ParentPatchModel IModelSerializable<ParentPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);
            return Deserialize(data, options);
        }

        private static ParentPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.Parse(data).RootElement;
            return Deserialize(element);
        }

        private void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);

            writer.WritePropertyName("child");
            Child.SerializeFull(writer);

            writer.WriteEndObject();
        }

        private void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            if (_changes.HasChanged(IdProperty))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }

            if (_changes.HasChanged(ChildProperty))
            {
                writer.WritePropertyName("child");
                if (Child == null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    Child.SerializeFull(writer);
                }
            }
            else if (_child.HasChanges)
            {
                writer.WritePropertyName("child");
                Child.SerializePatch(writer);
            }

            writer.WriteEndObject();
        }

        void IModelJsonSerializable<ParentPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
