// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>The source of the error when <see cref="ProcessErrorEventArgs"/> is raised.</summary>
    public enum ServiceBusErrorSource
    {
        /// <summary>Message completion operation</summary>
        Complete,

        /// <summary>Message abandon operation</summary>
        Abandon,

        /// <summary>User message handler invocation</summary>
        UserCallback,

        /// <summary>Message receive operation</summary>
        Receive,

        /// <summary>Lock renewal operation</summary>
        RenewLock,

        /// <summary>Session start operation</summary>
        AcceptMessageSession,

        /// <summary>Session close operation</summary>
        CloseMessageSession
    }
}
