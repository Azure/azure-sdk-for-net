// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The properties of a remote rendering session.
    /// </summary>
    [CodeGenModel("SessionProperties")]
    public partial class RenderingSession
    {
        /// <summary> The id of the session supplied when the session was created. </summary>
        [CodeGenMember("Id")]
        public string SessionId { get; }

        /// <summary> The host where the rendering session is reachable. </summary>
        [CodeGenMember("Hostname")]
        public string Host { get; }

        /// <summary> The time in minutes the session will run after reaching the &apos;Ready&apos; state. </summary>
        [CodeGenMember("MaxLeaseTimeMinutes")]
        internal int? MaxLeaseTimeMinutes { get; }

        /// <summary> The time the session will run after reaching the &apos;Ready&apos; state. </summary>
        public TimeSpan? MaxLeaseTime
        {
            get
            {
                if (MaxLeaseTimeMinutes.HasValue)
                {
                    return TimeSpan.FromMinutes(MaxLeaseTimeMinutes.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary> The time when the rendering session was created. Date and time in ISO 8601 format. </summary>
        [CodeGenMember("CreationTime")]
        public DateTimeOffset? CreatedOn { get; }
    }
}
