// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class SimpleStandardModel : IModelJsonSerializable<SimpleStandardModel>, IUtf8JsonSerializable
    {
        public static SimpleStandardModel DeserializeSimpleStandardModel(JsonElement element, ModelSerializerOptions options)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<int> count = default;
            Optional<DateTimeOffset> updatedOn = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"u8))
                {
                    count = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("updatedOn"u8))
                {
                    updatedOn = property.Value.GetDateTimeOffset();
                    continue;
                }
            }
            return new SimpleStandardModel(name, count, updatedOn);
        }

        SimpleStandardModel IModelJsonSerializable<SimpleStandardModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSimpleStandardModel(doc.RootElement, options);
        }

        SimpleStandardModel IModelSerializable<SimpleStandardModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            JsonDocument doc = JsonDocument.Parse(data);
            return DeserializeSimpleStandardModel(doc.RootElement, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Count))
            {
                writer.WritePropertyName("count"u8);
                writer.WriteNumberValue(Count.Value);
            }
            if (Optional.IsDefined(UpdatedOn))
            {
                writer.WritePropertyName("updatedOn"u8);
                writer.WriteStringValue(UpdatedOn.Value.UtcDateTime.ToString("O"));
            }
            writer.WriteEndObject();
        }

        void IModelJsonSerializable<SimpleStandardModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        BinaryData IModelSerializable<SimpleStandardModel>.Serialize(ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(SimpleStandardModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator SimpleStandardModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeSimpleStandardModel(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SimpleStandardModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        // TODO: Temp for pef tests
        public void Serialize(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer);
    }
}
