// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The hold group audio failed event.
    /// </summary>
    [CodeGenModel("HoldGroupAudioFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class HoldGroupAudioFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HoldGroupAudioFailed"/>.
        /// </summary>
        /// <param name="callConnectionId">Call connection ID.</param>
        /// <param name="serverCallId">Server call ID.</param>
        /// <param name="correlationId">Correlation ID for event to call correlation.</param>
        /// <param name="operationContext">Used by customers when calling mid-call actions to correlate the request to the response event.</param>
        /// <param name="resultInformation">Contains the resulting SIP code, sub-code and message.</param>
        internal HoldGroupAudioFailed(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="HoldGroupAudioFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldGroupAudioFailed"/> object.</returns>
        public static HoldGroupAudioFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldGroupAudioFailed(element);
        }
    }
}
