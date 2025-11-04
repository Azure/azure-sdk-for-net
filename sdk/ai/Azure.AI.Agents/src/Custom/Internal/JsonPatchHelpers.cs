// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;

#pragma warning disable SCME0001

namespace Azure.AI.Agents;

internal static partial class JsonPatchHelpers
{
    public static void SetAgentValue<T>(ref JsonPatch patch, ReadOnlySpan<byte> path, T value)
        where T : IJsonModel<T>
    {
        if (value is null)
        {
            patch.Remove(path);
        }
        else
        {
            BinaryData serialized = ModelReaderWriter.Write(
                value,
                ModelSerializationExtensions.WireOptions,
                AzureAIAgentsContext.Default);
            patch.Set(path, serialized);
        }
    }

    public static T GetAgentValue<T>(ref JsonPatch patch, ReadOnlySpan<byte> path)
        where T : class, IJsonModel<T>
    {
        if (patch.IsRemoved(path) || patch.TryGetJson(path, out ReadOnlyMemory<byte> valueBytes) == false)
        {
            return null;
        }
        return ModelReaderWriter.Read<T>(
            BinaryData.FromBytes(valueBytes),
            ModelSerializationExtensions.WireOptions,
            AzureAIAgentsContext.Default);
    }
}
