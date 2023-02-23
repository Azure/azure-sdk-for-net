// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The hang up call operation options.
    /// </summary>
    public class HangUpOptions
    {
        /// <summary>
        /// Creates a new HangUpOptions object.
        /// </summary>
        /// <param name="forEveryone"></param>
        public HangUpOptions(bool forEveryone)
        {
            ForEveryone = forEveryone;
        }

        /// <summary>
        /// If true, this will terminate the call and hang up on all participants in this call.
        /// </summary>
        public bool ForEveryone { get; }
    }
}
