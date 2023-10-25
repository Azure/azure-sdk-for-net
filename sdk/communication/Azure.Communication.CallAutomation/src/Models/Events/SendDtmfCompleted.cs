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
    public partial class SendDtmfCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfCompleted"/> object.</returns>
        public static SendDtmfCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfCompleted(element);
        }
    }
}
