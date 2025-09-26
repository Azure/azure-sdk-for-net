// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base interface for the different voice types supported by the VoiceLive service
    /// </summary>
    public abstract class VoiceProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal abstract BinaryData ToBinaryData();

        internal static VoiceProvider DeserializeVoiceProvider(JsonElement element, ModelReaderWriterOptions options)
        {
            return null;
        }
    }
}
