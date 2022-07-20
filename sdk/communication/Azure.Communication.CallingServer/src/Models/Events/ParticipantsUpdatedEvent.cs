// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The participants updated event.
    /// </summary>
    [CodeGenModel("ParticipantsUpdatedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ParticipantsUpdatedEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdatedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdatedEvent"/> object.</returns>
        public static ParticipantsUpdatedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeParticipantsUpdatedEvent(element);
        }
    }
}
