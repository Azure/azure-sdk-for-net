// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
     /// The CallAutomation Event Base.
     /// </summary>
    public abstract class CallAutomationEventBase
    {
        /// <summary> Call connection ID. </summary>
        public string CallConnectionId { get; internal set; }

        /// <summary> Server call ID. </summary>
        public string ServerCallId { get; internal set; }

        /// <summary> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </summary>
        public string CorrelationId { get; internal set; }
#nullable enable
        /// <summary> Operation context. </summary>
        public string? OperationContext { get; internal set; }
        /// <summary> Gets the result info. </summary>
        public ResultInformation? ResultInformation { get; internal set; }
    }
}
