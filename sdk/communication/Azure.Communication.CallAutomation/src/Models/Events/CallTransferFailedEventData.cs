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
    public partial class CallTransferFailedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="CallTransferFailedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferFailedEventData"/> object.</returns>
        public static CallTransferFailedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallTransferFailedEventData(element);
        }
    }
}
