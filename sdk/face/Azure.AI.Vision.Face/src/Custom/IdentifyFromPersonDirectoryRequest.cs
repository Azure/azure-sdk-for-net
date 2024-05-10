// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    /// <summary> The IdentifyFromPersonDirectoryRequest. </summary>
    [CodeGenSerialization(nameof(PersonIds), SerializationValueHook = nameof(SerializePersonIdsValue))]
    internal partial class IdentifyFromPersonDirectoryRequest
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializePersonIdsValue(Utf8JsonWriter writer)
        {
            if (PersonIds == null)
            {
                writer.WriteStartArray();
                writer.WriteStringValue("*");
                writer.WriteEndArray();
                return;
            }

            writer.WriteStartArray();
            foreach (var item in PersonIds)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
        }
    }
}
