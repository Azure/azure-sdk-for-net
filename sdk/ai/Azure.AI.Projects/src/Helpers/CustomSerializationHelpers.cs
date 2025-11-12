// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.Projects.OpenAI;

namespace Azure.AI.Projects;
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

    public static T DeserializeProjectOpenAIType<T>(JsonElement element, ModelReaderWriterOptions options)
        => DeserializeExternalType<T>(element, options, AzureAIProjectsOpenAIContext.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T DeserializeExternalType<T>(JsonElement element, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        using MemoryStream stream = new();
        Utf8JsonWriter writer = new(stream);
        element.WriteTo(writer);
        writer.Flush();
        stream.Position = 0;

        BinaryData elementBytes = BinaryData.FromStream(stream);

        return ModelReaderWriter.Read<T>(elementBytes, options, context);
    }
}
