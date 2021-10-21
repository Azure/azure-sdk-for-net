// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The subscribe to tone event
    /// </summary>
    [CodeGenModel("ToneReceivedEvent", Usage = new string[] { "model", "output" }, Formats = new string[] { "json" })]
    public partial class ToneReceivedEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="ToneReceivedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ToneReceivedEvent"/> object.</returns>
        public static ToneReceivedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeToneReceivedEvent(element);
        }
    }
}
