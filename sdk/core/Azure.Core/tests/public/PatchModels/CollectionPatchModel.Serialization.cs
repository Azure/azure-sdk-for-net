// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Core.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class CollectionPatchModel : IModelJsonSerializable<CollectionPatchModel>, IUtf8JsonSerializable
    {
        internal static CollectionPatchModel Deserialize(JsonElement element)
        {
            string id = default;

            IDictionary<string, string> values;
            Dictionary<string, string> valuesDictionary = new();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("values"))
                {
                    foreach (JsonProperty value in property.Value.EnumerateObject())
                    {
                        valuesDictionary.Add(value.Name, value.Value.GetString());
                    }
                }
            }

            values = valuesDictionary;

            return new CollectionPatchModel(id, values);
        }

        CollectionPatchModel IModelJsonSerializable<CollectionPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(ref reader, options);
        }

        private static CollectionPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.ParseValue(ref reader).RootElement;
            return Deserialize(element);
        }

        CollectionPatchModel IModelSerializable<CollectionPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return Deserialize(data, options);
        }

        private static CollectionPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.Parse(data).RootElement;
            return Deserialize(element);
        }

        private void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);

            writer.WritePropertyName("values");

            // TODO
            //Child.SerializeFull(writer);

            writer.WriteEndObject();
        }

        private void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            //TODO

            writer.WriteEndObject();
        }

        void IModelJsonSerializable<CollectionPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        BinaryData IModelSerializable<CollectionPatchModel>.Serialize(ModelSerializerOptions options)
        {
            PatchModelHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(CollectionPatchModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator CollectionPatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SimplePatchModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
