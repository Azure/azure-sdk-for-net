// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class CollectionPatchModel : IModelJsonSerializable<CollectionPatchModel>, IUtf8JsonSerializable
    {
        internal static CollectionPatchModel Deserialize(JsonElement element)
        {
            string id = default;
            Dictionary<string, string> variables = default;
            Dictionary<string, ChildPatchModel> children = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("variables"))
                {
                    variables = new();
                    foreach (JsonProperty value in property.Value.EnumerateObject())
                    {
                        variables.Add(value.Name, value.Value.GetString());
                    }
                }

                if (property.NameEquals("children"))
                {
                    children = new();
                    foreach (JsonProperty value in property.Value.EnumerateObject())
                    {
                        ChildPatchModel child = ChildPatchModel.Deserialize(value.Value);
                        children.Add(value.Name, child);
                    }
                }
            }

            return new CollectionPatchModel(id,
                MergePatchDictionary<string>.GetStringDictionary(variables),
                // TODO: consider this pattern for optional properties.
                children != null ?
                    new MergePatchDictionary<ChildPatchModel>(
                        children,
                        (w, n, m) => m.SerializePatchProperty(w, n),
                        c => c.HasChanges) :
                        null
                );
        }

        CollectionPatchModel IModelJsonSerializable<CollectionPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
            return Deserialize(ref reader, options);
        }

        private static CollectionPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            JsonElement element = JsonDocument.ParseValue(ref reader).RootElement;
            return Deserialize(element);
        }

        CollectionPatchModel IModelSerializable<CollectionPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
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

            writer.WritePropertyName("variables");
            writer.WriteStartObject();
            foreach (KeyValuePair<string, string> item in Variables)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();

            if (_children != null)
            {
                writer.WritePropertyName("children");
                writer.WriteStartObject();
                foreach (KeyValuePair<string, ChildPatchModel> item in Children)
                {
                    writer.WritePropertyName(item.Key);
                    item.Value.SerializeFull(writer);
                }
                writer.WriteEndObject();
            }

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

            if (_variables != null && _variables.HasChanges)
            {
                writer.WritePropertyName("variables");
                _variables.SerializePatch(writer);
            }

            if (_children != null && _children.HasChanges)
            {
                writer.WritePropertyName("children");
                _children.SerializePatch(writer);
            }

            writer.WriteEndObject();
        }

        void IModelJsonSerializable<CollectionPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        BinaryData IModelSerializable<CollectionPatchModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
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
