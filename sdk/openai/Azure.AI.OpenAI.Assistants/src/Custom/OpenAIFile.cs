// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This is a short-term workaround for an observed parity issue with Azure OpenAI's treatment of 'bytes' on files as
 * a nullable integer.
 */

public partial class OpenAIFile
{
    /// <summary> The size of the file, in bytes. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableSize))]
    public int Size { get; }

    private static void DeserializeNullableSize(JsonProperty property, ref int size)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            size = 0;
        }
        else
        {
            size = property.Value.GetInt32();
        }
    }
}
