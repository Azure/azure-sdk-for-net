// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
public partial class AudioSpeechOptions : IUtf8JsonSerializable
{
    // CUSTOM CODE NOTE:
    //   We manipulate the object model of this type relative to the wire format in several places; currently, this is
    //   best facilitated by performing a complete customization of the serialization.

    void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("model"u8);
        writer.WriteStringValue(DeploymentName);
        writer.WritePropertyName("input"u8);
        writer.WriteStringValue(Input);
        writer.WritePropertyName("voice"u8);
        writer.WriteStringValue(Voice.ToString());
        if (Optional.IsDefined(ResponseFormat))
        {
            writer.WritePropertyName("response_format"u8);
            writer.WriteStringValue(ResponseFormat.Value.ToString());
        }
        if (Optional.IsDefined(Speed))
        {
            writer.WritePropertyName("speed"u8);
            writer.WriteNumberValue(Speed.Value);
        }
        writer.WriteEndObject();
    }
}
