// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The redirect call operation options.
    /// </summary>
    public class RedirectCallOptions
    {
        /// <summary>
        /// Creates a new RedirectCallOptions object.
        /// </summary>
        /// <param name="incomingCallContext"></param>
        /// <param name="callInvite"></param>
        public RedirectCallOptions(string incomingCallContext, CallInvite callInvite)
        {
            IncomingCallContext = incomingCallContext;
            CallInvite = callInvite;
        }

        /// <summary>
        /// The context associated with the call.
        /// </summary>
        public string IncomingCallContext { get; }

        /// <summary>
        /// Call invitee information.
        /// </summary>
        public CallInvite CallInvite { get; }
    }
}
