// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The hold group created event.
    /// </summary>
    [CodeGenModel("HoldGroupCreated", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class HoldGroupCreated : CallAutomationEventBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HoldGroupCreated"/>.
        /// </summary>
        /// <param name="callConnectionId">Call connection ID.</param>
        /// <param name="serverCallId">Server call ID.</param>
        /// <param name="correlationId">Correlation ID for event to call correlation.</param>
        /// <param name="operationContext">Used by customers when calling mid-call actions to correlate the request to the response event.</param>
        /// <param name="resultInformation">Contains the resulting SIP code, sub-code and message.</param>
        internal HoldGroupCreated(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="HoldGroupCreated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldGroupCreated"/> object.</returns>
        public static HoldGroupCreated Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldGroupCreated(element);
        }
    }
}
