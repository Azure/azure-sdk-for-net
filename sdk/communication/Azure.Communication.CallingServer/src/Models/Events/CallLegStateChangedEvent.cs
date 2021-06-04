// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call leg state change event.
    /// </summary>
    [CodeGenModel("CallLegStateChangedEvent", Usage = new string[] { "input, output" }, Formats = new string[] { "json" })]
    public partial class CallLegStateChangedEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallLegStateChangedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallLegStateChangedEvent"/> object.</returns>
        public static CallLegStateChangedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallLegStateChangedEvent(element);
        }
    }
}
