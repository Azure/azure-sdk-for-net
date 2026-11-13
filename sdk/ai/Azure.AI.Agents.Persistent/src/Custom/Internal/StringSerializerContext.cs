// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent;

[JsonSerializable(typeof(string))]
internal partial class StringSerializerContext : JsonSerializerContext
{
}
