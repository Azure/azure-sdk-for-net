// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
public partial class ChatCompletionsToolChoice : IUtf8JsonSerializable
{
    void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        if (Optional.IsDefined(Preset) && Preset.ToString() != null)
        {
            writer.WriteStringValue(Preset.ToString());
        }
        else if (Optional.IsDefined(Function))
        {
            writer.WriteStartObject();
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue("function"u8);
                writer.WritePropertyName("function"u8);
                writer.WriteStartObject();
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Function.Name);
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }
        }
    }
}
