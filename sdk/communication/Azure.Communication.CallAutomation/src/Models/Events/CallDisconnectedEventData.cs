// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The call disconnected event.
    /// </summary>
    [CodeGenModel("CallDisconnected", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallDisconnectedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="CallDisconnectedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallDisconnectedEventData"/> object.</returns>
        public static CallDisconnectedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallDisconnectedEventData(element);
        }
    }
}
