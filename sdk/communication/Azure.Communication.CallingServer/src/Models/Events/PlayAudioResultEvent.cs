// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The play audio result event.
    /// </summary>
    [CodeGenModel("PlayAudioResultEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayAudioResultEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayAudioResultEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayAudioResultEvent"/> object.</returns>
        public static PlayAudioResultEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayAudioResultEvent(element);
        }
    }
}
