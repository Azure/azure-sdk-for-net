// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;

[CodeGenSerialization(nameof(IncomingCallUrl),
    SerializationValueHook = nameof(SerializeIncomingCallUrl),
    DeserializationValueHook = nameof(DeserializeIncomingCallUrl))]
public partial class TelephonyBinding
{
    private void SerializeIncomingCallUrl(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => writer.WriteStringValue(IncomingCallUrl?.AbsoluteUri);

    private protected static void DeserializeIncomingCallUrl(JsonProperty property, ref Uri value)
        => value = property.Value.ValueKind == JsonValueKind.Null ? null : new Uri(property.Value.GetString(), UriKind.RelativeOrAbsolute);
}
