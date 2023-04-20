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
    public partial class SendDtmfFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfFailed"/> object.</returns>
        public static SendDtmfFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfFailed(element);
        }
    }
}
