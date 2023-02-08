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
        /// <param name="target"></param>
        public RedirectCallOptions(string incomingCallContext, CommunicationIdentifier target)
        {
            IncomingCallContext = incomingCallContext;
            Target = target;
        }

        /// <summary>
        /// The context associated with the call.
        /// </summary>
        public string IncomingCallContext { get; }

        /// <summary>
        /// The target identity.
        /// </summary>
        public CommunicationIdentifier Target { get; }
    }
}
