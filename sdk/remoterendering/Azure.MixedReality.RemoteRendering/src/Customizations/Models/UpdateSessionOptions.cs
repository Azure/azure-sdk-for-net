// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// This defines new values for session properties which can be adjusted.
    /// </summary>
    [CodeGenModel("UpdateSessionSettings")]
    public partial class UpdateSessionOptions
    {
        /// <summary> Initializes a new instance of UpdateSessionOptions. </summary>
        /// <param name="maxLeaseTimeMinutes"> Update to the time the session will run after it reached the &apos;Ready&apos; state.  It has to be bigger than the current value of maxLeaseTimeMinutes. </param>
        internal UpdateSessionOptions(int maxLeaseTimeMinutes)
        {
            MaxLeaseTimeMinutes = maxLeaseTimeMinutes;
        }

        /// <summary>
        /// Options requesting that the lease time should be set to the given value (which is rounded to minutes).
        /// </summary>
        /// <param name="maxLeaseTime">Update to the time the session will run after it reached the &apos;Ready&apos; state. It has to be bigger than the current value. </param>
        public UpdateSessionOptions(TimeSpan maxLeaseTime)
        {
            MaxLeaseTimeMinutes = (int)Math.Round(maxLeaseTime.TotalMinutes);
        }

        /// <summary> Update to the time the session will run after it reached the &apos;Ready&apos; state.  It has to be bigger than the current value of maxLeaseTimeMinutes. </summary>
        [CodeGenMember("MaxTimeSpanMinutes")]
        internal int MaxLeaseTimeMinutes { get; }

        /// <summary>
        /// The new lease time to use for the session.
        /// </summary>
        public TimeSpan MaxLeaseTime
        {
            get
            {
                return TimeSpan.FromMinutes(MaxLeaseTimeMinutes);
            }
        }
    }
}
