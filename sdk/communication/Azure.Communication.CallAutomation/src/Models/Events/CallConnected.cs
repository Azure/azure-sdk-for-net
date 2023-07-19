// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The call connected event.
    /// </summary>
    [CodeGenModel("CallConnected", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallConnected: CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallConnected"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallConnected"/> object.</returns>
        public static CallConnected Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallConnected(element);
        }
    }
}
