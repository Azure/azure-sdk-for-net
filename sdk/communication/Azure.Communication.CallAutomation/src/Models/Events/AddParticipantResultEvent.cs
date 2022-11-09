// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("AddParticipantResultEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial struct AddParticipantResultEvent
    {
        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdated"/> object.</returns>
        public static AddParticipantResultEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantResultEvent.DeserializeParticipantsUpdatedInternal(element);
            return new AddParticipantResultEvent(internalEvent);
        }
    }
}
