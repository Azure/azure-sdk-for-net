// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The added participants result event.
    /// </summary>
    [CodeGenModel("AddParticipantResultEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class AddParticipantResultEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="AddParticipantResultEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantResultEvent"/> object.</returns>
        public static AddParticipantResultEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeAddParticipantResultEvent(element);
        }
    }
}
