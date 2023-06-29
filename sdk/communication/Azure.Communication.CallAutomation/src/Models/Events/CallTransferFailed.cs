// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The call transfer failed event.
    /// </summary>
    [CodeGenModel("CallTransferFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallTransferFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallTransferFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferFailed"/> object.</returns>
        public static CallTransferFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallTransferFailed(element);
        }
    }
}
