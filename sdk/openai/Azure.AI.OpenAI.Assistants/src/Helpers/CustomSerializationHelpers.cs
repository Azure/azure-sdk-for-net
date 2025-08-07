// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Azure.AI.OpenAI.Assistants;
internal static partial class CustomSerializationHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeNullableDateTimeOffset(JsonProperty property, ref DateTimeOffset? targetDateTimeOffset)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            targetDateTimeOffset = null;
        }
        else
        {
            targetDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
        }
    }
}
