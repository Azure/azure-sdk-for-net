// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The HoldAudioCompleted event.
    /// </summary>
    [CodeGenModel("HoldAudioCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class HoldAudioCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary>
        /// Deserialize <see cref="HoldAudioCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldAudioCompleted"/> object.</returns>
        public static HoldAudioCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldAudioCompleted(element);
        }
    }
}
