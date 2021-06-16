// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The invited participants result event.
    /// </summary>
    [CodeGenModel("InviteParticipantsResultEvent", Usage = new string[] { "input, output" }, Formats = new string[] { "json" })]
    public partial class InviteParticipantsResultEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="InviteParticipantsResultEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="InviteParticipantsResultEvent"/> object.</returns>
        public static InviteParticipantsResultEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeInviteParticipantsResultEvent(element);
        }
    }
}
