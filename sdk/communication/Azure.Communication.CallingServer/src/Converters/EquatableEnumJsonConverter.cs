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
    internal class EquatableEnumJsonConverter<T> : JsonConverter<T> where T : struct
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => (T)Activator.CreateInstance(typeof(T), reader.GetString());

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}
