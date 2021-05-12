// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Calling.Server
{
    internal static partial class CallStateExtensions
    {
        public static CallState ToCallState(this string value)
        {
            if (string.Equals(value, "unknown", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Unknown;
            if (string.Equals(value, "idle", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Idle;
            if (string.Equals(value, "incoming", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Incoming;
            if (string.Equals(value, "establishing", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Establishing;
            if (string.Equals(value, "established", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Established;
            if (string.Equals(value, "hold", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Hold;
            if (string.Equals(value, "unhold", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Unhold;
            if (string.Equals(value, "transferring", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Transferring;
            if (string.Equals(value, "redirecting", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Redirecting;
            if (string.Equals(value, "terminating", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Terminating;
            if (string.Equals(value, "terminated", StringComparison.InvariantCultureIgnoreCase))
                return CallState.Terminated;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CallState value.");
        }
    }
}
