// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    [JsonConverter(typeof(NotebookMetadataConverter))]
    public partial class NotebookMetadata : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Kernelspec))
            {
                writer.WritePropertyName("kernelspec"u8);
                writer.WriteObjectValue(Kernelspec);
            }
            if (Optional.IsDefined(LanguageInfo))
            {
                if (LanguageInfo != null)
                {
                    writer.WritePropertyName("language_info"u8);
                    writer.WriteObjectValue(LanguageInfo);
                }
                else
                {
                    writer.WriteNull("language_info");
                }
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue<object>(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static NotebookMetadata DeserializeNotebookMetadata(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            NotebookKernelSpec kernelspec = default;
            NotebookLanguageInfo languageInfo = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kernelspec"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    kernelspec = NotebookKernelSpec.DeserializeNotebookKernelSpec(property.Value);
                    continue;
                }
                if (property.NameEquals("language_info"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        languageInfo = null;
                        continue;
                    }
                    languageInfo = NotebookLanguageInfo.DeserializeNotebookLanguageInfo(property.Value);
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new NotebookMetadata(kernelspec, languageInfo, additionalProperties);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static NotebookMetadata FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNotebookMetadata(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal partial class NotebookMetadataConverter : JsonConverter<NotebookMetadata>
        {
            public override void Write(Utf8JsonWriter writer, NotebookMetadata model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }

            public override NotebookMetadata Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeNotebookMetadata(document.RootElement);
            }
        }
    }
}
