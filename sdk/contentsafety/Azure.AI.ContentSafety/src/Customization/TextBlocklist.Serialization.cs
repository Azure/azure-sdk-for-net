// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.ContentSafety
{
    public partial class TextBlocklist : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("blocklistName"u8);
            writer.WriteStringValue(BlocklistName); // Should we write this property?
            if (_isDiscriptionChanged)
            {
                writer.WritePropertyName("description"u8);
                if (_description != null) // This means we cannot use this model to put operation, we could add an option to tell if it is a patch model
                {
                    writer.WriteStringValue(Description);
                }
                else
                {
                    writer.WriteNullValue();
                }
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
