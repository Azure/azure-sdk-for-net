// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This is a short-term workaround for an observed parity issue with Azure OpenAI's treatment of 'bytes' on files as
 * a nullable integer.
 */

[CodeGenSerialization(nameof(Size), DeserializationValueHook = nameof(DeserializeNullableSize))]
public partial class PersistentAgentFileInfo
{
    /*
    * CUSTOM CODE DESCRIPTION: This change allows us to complete the customization of hiding an unnecessary "Object" discriminator.
    */
    internal string Object { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
