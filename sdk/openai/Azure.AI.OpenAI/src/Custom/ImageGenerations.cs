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
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeDataProperty))]
        public IReadOnlyList<ImageLocation> Data { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeDataProperty(JsonProperty property, ref IReadOnlyList<ImageLocation> data)
        {
            // CUSTOM CODE NOTE: this hook for Data is needed pending improved codegen support for union types; it
            //                      otherwise generates with "property.Value.()"
            List<ImageLocation> array = new List<ImageLocation>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(ImageLocation.DeserializeImageLocation(item));
            }
            data = array;
        }
    }
}
