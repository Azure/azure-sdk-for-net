// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The add participants succeeded event.
    /// </summary>
    [CodeGenModel("AddParticipantsSucceededEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class AddParticipantsSucceededEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="AddParticipantsSucceededEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantsSucceededEvent"/> object.</returns>
        public static AddParticipantsSucceededEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeAddParticipantsSucceededEvent(element);
        }
    }
}
