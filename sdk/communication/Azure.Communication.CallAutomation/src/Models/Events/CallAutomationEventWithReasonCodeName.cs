// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// CallAutomation Event with a Reason Code.
    /// </summary>
    public abstract class CallAutomationEventWithReasonCodeName : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public ReasonCode ReasonCode { get; internal set; }
    }
}
