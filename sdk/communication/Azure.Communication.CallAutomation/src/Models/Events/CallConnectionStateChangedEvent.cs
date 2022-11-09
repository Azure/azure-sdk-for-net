// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("CallConnectionStateChangedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial struct CallConnectionStateChangedEvent
    {
        /// <summary>
        /// Deserialize <see cref="CallConnectionStateChangedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallConnectionStateChangedEvent"/> object.</returns>
        public static CallConnectionStateChangedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallConnectionStateChangedEvent.DeserializeCallConnectionStateChangedEventInternal(element);
            return new CallConnectionStateChangedEvent(internalEvent);
        }
    }
}
