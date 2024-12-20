// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The HoldAudioPaused event.
    /// </summary>
    [CodeGenModel("HoldAudioPaused", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class HoldAudioPaused : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Initializes a new instance of <see cref="HoldAudioPaused"/>. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code, sub-code and message. </param>
        internal HoldAudioPaused(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            ReasonCode = new MediaEventReasonCode(resultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="HoldAudioPaused"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldAudioPaused"/> object.</returns>
        public static HoldAudioPaused Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldAudioPaused(element);
        }
    }
}
