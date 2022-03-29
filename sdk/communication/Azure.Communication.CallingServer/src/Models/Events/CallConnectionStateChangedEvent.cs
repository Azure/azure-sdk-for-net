// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call connection state change event.
    /// </summary>
    [CodeGenModel("CallConnectionStateChangedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallConnectionStateChangedEvent : CallingServerEventBase
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

            return DeserializeCallConnectionStateChangedEvent(element);
        }
    }
}
