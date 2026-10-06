// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The hold group audio started event.
    /// </summary>
    [CodeGenModel("HoldGroupAudioStarted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class HoldGroupAudioStarted : CallAutomationEventBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HoldGroupAudioStarted"/>.
        /// </summary>
        /// <param name="callConnectionId">Call connection ID.</param>
        /// <param name="serverCallId">Server call ID.</param>
        /// <param name="correlationId">Correlation ID for event to call correlation.</param>
        /// <param name="operationContext">Used by customers when calling mid-call actions to correlate the request to the response event.</param>
        /// <param name="resultInformation">Contains the resulting SIP code, sub-code and message.</param>
        internal HoldGroupAudioStarted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="HoldGroupAudioStarted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldGroupAudioStarted"/> object.</returns>
        public static HoldGroupAudioStarted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldGroupAudioStarted(element);
        }
    }
}
