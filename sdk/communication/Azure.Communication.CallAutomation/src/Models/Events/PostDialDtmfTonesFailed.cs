// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation.Models.Events
{
    /// <summary> The PostDialDtmfTonesFailed. </summary>
    [CodeGenModel("PostDialDtmfTonesFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PostDialDtmfTonesFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Initializes a new instance of <see cref="PostDialDtmfTonesFailed"/>. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"></param>
        public PostDialDtmfTonesFailed(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="PostDialDtmfTonesFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PostDialDtmfTonesFailed"/> object.</returns>
        public static PostDialDtmfTonesFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePostDialDtmfTonesFailed(element);
        }
    }
}
