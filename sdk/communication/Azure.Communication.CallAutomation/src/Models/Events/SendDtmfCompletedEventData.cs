// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfCompleted event.
    /// </summary>

    [CodeGenModel("SendDtmfCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SendDtmfCompletedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfCompletedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfCompletedEventData"/> object.</returns>
        public static SendDtmfCompletedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfCompletedEventData(element);
        }
    }
}
