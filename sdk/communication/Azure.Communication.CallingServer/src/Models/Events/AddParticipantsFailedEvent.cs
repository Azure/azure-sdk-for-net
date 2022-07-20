// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The add participant failed event.
    /// </summary>
    [CodeGenModel("AddParticipantsFailedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class AddParticipantsFailedEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="AddParticipantsFailedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantsFailedEvent"/> object.</returns>
        public static AddParticipantsFailedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeAddParticipantsFailedEvent(element);
        }
    }
}
