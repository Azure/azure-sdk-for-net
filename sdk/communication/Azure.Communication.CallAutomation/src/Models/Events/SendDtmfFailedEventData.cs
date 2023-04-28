// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfFailed event.
    /// </summary>

    [CodeGenModel("SendDtmfFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SendDtmfFailedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfFailedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfFailedEventData"/> object.</returns>
        public static SendDtmfFailedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfFailedEventData(element);
        }
    }
}
