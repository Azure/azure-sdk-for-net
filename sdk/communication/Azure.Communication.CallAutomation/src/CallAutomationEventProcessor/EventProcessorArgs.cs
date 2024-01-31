// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    internal class EventProcessorArgs : EventArgs
    {
        internal string EventArgsId { get; set; }

        internal CallAutomationEventBase CallAutomationEvent { get; set; }
    }
}
