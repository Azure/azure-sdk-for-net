// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> The result of an image generation operation. </summary>
    public partial class ImageGenerations
    {
        /// <summary>
        ///     Gets a list of generated image items in the format specified for the request.
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(SerializeDataProperty), DeserializationValueHook = nameof(DeserializeDataProperty))]
        public IReadOnlyList<ImageLocation> Data { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeDataProperty(Utf8JsonWriter writer)
        {
            // CUSTOM CODE NOTE: we always need to specify the serialization code explicitly when we change the type of a property
            writer.WriteStartArray();
            foreach (var item in Data)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeDataProperty(JsonProperty property, ref IReadOnlyList<ImageLocation> data)
        {
            // CUSTOM CODE NOTE: we always need to specify the serialization code explicitly when we change the type of a property
            List<ImageLocation> array = new List<ImageLocation>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ImageLocation.DeserializeImageLocation(item));
            }
            data = array;
        }
    }
}
