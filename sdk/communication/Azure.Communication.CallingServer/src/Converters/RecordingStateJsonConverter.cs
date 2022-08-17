// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallingServer.Converters
{
    /// <summary>
    /// Converts the RecordingState object into json correctly.
    /// </summary>
    internal class RecordingStateJsonConverter : JsonConverter<RecordingState>
    {
        public override RecordingState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new RecordingState(reader.GetString());

        public override void Write(Utf8JsonWriter writer, RecordingState value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}
