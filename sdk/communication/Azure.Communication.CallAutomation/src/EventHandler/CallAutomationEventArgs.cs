// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    internal class CallAutomationEventArgs : EventArgs
    {
        internal string eventArgsId { get; set; }

        internal CallAutomationEventBase callAutomationEvent { get; set; }
    }
}
