// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>Action taking place when <see cref="ExceptionReceivedEventArgs"/> is raised.</summary>
    public static class ExceptionReceivedEventArgsAction
    {
        /// <summary>Message completion operation.</summary>
        public const string Complete = "Complete";

        /// <summary>Message abandon operation.</summary>
        public const string Abandon = "Abandon";

        /// <summary>User message handler invocation.</summary>
        public const string UserCallback = "UserCallback";

        /// <summary>Message receive operation.</summary>
        public const string Receive = "Receive";

        /// <summary>Message lock renewal operation.</summary>
        public const string RenewLock = "RenewLock";

        /// <summary>Session start operation.</summary>
        public const string AcceptMessageSession = "AcceptMessageSession";

        /// <summary>Session close operation.</summary>
        public const string CloseMessageSession = "CloseMessageSession";
    }
}