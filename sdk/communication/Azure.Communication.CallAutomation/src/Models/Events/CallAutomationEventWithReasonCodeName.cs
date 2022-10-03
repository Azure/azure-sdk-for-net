// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// CallAutomation Event with a Reason Code Name.
    /// </summary>
    public abstract class CallAutomationEventWithReasonCodeName : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code name.
        /// </summary>
        public ReasonCode ReasonCodeName { get; internal set; }
    }
}
