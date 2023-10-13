// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfFailed event.
    /// </summary>

    [CodeGenModel("SendDtmfTonesFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SendDtmfTonesFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfTonesFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfTonesFailed"/> object.</returns>
        public static SendDtmfTonesFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfTonesFailed(element);
        }
    }
}
