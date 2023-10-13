// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfTonesCompleted event.
    /// </summary>

    [CodeGenModel("SendDtmfTonesCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class SendDtmfTonesCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="SendDtmfTonesCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfTonesCompleted"/> object.</returns>
        public static SendDtmfTonesCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeSendDtmfTonesCompleted(element);
        }
    }
}
