// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Shared JsonSerializerContext for common types used across Custom implementations.
/// </summary>
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(List<JsonElement>))]
internal partial class CustomSharedJsonContext : JsonSerializerContext
{
}
