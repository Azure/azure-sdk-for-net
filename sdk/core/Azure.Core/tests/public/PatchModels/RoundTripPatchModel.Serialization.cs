// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class RoundTripPatchModel : IModelJsonSerializable<RoundTripPatchModel>, IUtf8JsonSerializable
    {
        private static RoundTripPatchModel Deserialize(JsonElement element)
        {
            string id = default;
            int value = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("value"))
                {
                    value = property.Value.GetInt32();
                    continue;
                }
            }

            return new RoundTripPatchModel(id, value);
        }

        RoundTripPatchModel IModelJsonSerializable<RoundTripPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);

            return Deserialize(ref reader, options);
        }

        private static RoundTripPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.ParseValue(ref reader).RootElement;
            return Deserialize(element);
        }

        RoundTripPatchModel IModelSerializable<RoundTripPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);

            return Deserialize(data, options);
        }

        private static RoundTripPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.Parse(data).RootElement;
            return Deserialize(element);
        }

        private void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);

            writer.WritePropertyName("value");
            if (Value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteNumberValue(Value.Value);
            }

            writer.WriteEndObject();
        }

        private void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            // Id isn't modifiable.

            if (_valuePatchFlag)
            {
                writer.WritePropertyName("value");
                if (Value is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    writer.WriteNumberValue(Value.Value);
                }
            }

            writer.WriteEndObject();
        }

        void IModelJsonSerializable<RoundTripPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);

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

        BinaryData IModelSerializable<RoundTripPatchModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(RoundTripPatchModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator RoundTripPatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RoundTripPatchModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
