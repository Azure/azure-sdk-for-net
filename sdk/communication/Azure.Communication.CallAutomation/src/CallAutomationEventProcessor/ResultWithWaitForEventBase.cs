// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>Result with Wait for EventBase.</summary>
    public abstract class ResultWithWaitForEventBase
    {
        private protected CallAutomationEventProcessor _evHandler;
        private protected string _callConnectionId;
        private protected string _operationContext;

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }
    }
}
