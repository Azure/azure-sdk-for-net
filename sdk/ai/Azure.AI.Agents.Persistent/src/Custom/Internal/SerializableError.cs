// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent;

internal class SerializableError
{
    public string error { get; set; }
    public SerializableError(string message)
    {
        error = message;
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(SerializableError))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
