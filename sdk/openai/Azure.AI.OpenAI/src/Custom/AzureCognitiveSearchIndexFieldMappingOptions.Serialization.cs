// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class AzureCognitiveSearchIndexFieldMappingOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(TitleFieldName))
            {
                writer.WritePropertyName("titleField"u8);
                writer.WriteStringValue(TitleFieldName);
            }
            if (Optional.IsDefined(UrlFieldName))
            {
                writer.WritePropertyName("urlField"u8);
                writer.WriteStringValue(UrlFieldName);
            }
            if (Optional.IsDefined(FilepathFieldName))
            {
                writer.WritePropertyName("filepathField"u8);
                writer.WriteStringValue(FilepathFieldName);
            }
            if (Optional.IsCollectionDefined(ContentFieldNames))
            {
                writer.WritePropertyName("contentFieldNames"u8);
                writer.WriteStartArray();
                foreach (var item in ContentFieldNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ContentFieldSeparator))
            {
                writer.WritePropertyName("contentFieldSeparator"u8);
                writer.WriteStringValue(ContentFieldSeparator);
            }
            if (Optional.IsCollectionDefined(VectorFieldNames))
            {
                writer.WritePropertyName("vectorFields"u8);
                writer.WriteStartArray();
                foreach (var item in VectorFieldNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
