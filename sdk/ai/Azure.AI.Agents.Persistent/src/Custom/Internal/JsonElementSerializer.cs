// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Agents.Persistent;

[JsonSerializable(typeof(List<JsonElement>))]
internal partial class JsonElementSerializer : JsonSerializerContext
{
}
