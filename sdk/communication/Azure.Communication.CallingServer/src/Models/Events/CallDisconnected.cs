// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call disconnected event.
    /// </summary>
    [CodeGenModel("CallDisconnectedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallDisconnected : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallDisconnected"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallDisconnected"/> object.</returns>
        public static CallDisconnected Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallDisconnected(element);
        }
    }
}
