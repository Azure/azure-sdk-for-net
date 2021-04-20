// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The states of a call.
    /// </summary>
    public enum CallState
    {
        /// <summary>
        /// Unknown not recognized.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Initial State.
        /// </summary>
        Idle = 1,

        /// <summary>
        ///  The call has just been received.
        /// </summary>
        Incoming = 2,

        /// <summary>
        /// The call establishment is in progress after initiating or accepting the call.
        /// </summary>
        Establishing = 3,

        /// <summary>
        /// The call is established.
        /// </summary>
        Established = 4,

        /// <summary>
        /// The call is on Hold.
        /// </summary>
        Hold = 5,

        /// <summary>
        /// The call is Unhold.
        /// </summary>
        Unhold = 6,

        /// <summary>
        /// The call has initiated a transfer.
        /// </summary>
        Transferring = 7,

        /// <summary>
        /// The call has initiated a redirection.
        /// </summary>
        Redirecting = 8,

        /// <summary>
        /// The call is terminating.
        /// </summary>
        Terminating = 9,

        /// <summary>
        /// The call has terminated.
        /// </summary>
        Terminated = 10
    }
}
