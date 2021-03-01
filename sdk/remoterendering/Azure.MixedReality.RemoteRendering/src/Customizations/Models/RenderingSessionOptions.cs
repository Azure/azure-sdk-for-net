// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary> The Options requested when starting a session. </summary>
    [CodeGenModel("CreateSessionSettings")]
    public partial class RenderingSessionOptions
    {
        /// <summary> Initializes a new instance of RenderingSessionOptions. </summary>
        /// <param name="maxLeaseTime"> The time the session will run after reaching the &apos;Ready&apos; state. The provided values will be rounded to the nearest minute. </param>
        /// <param name="size"> Size of the server used for the rendering session. Remote Rendering with Standard size server has a maximum scene size of 20 million polygons. Remote Rendering with Premium size does not enforce a hard maximum, but performance may be degraded if your content exceeds the rendering capabilities of the service. </param>
        public RenderingSessionOptions(TimeSpan maxLeaseTime, RenderingServerSize size)
        {
            MaxLeaseTimeMinutes = (int)Math.Round(maxLeaseTime.TotalMinutes);
            Size = size;
        }

        /// <summary> Initializes a new instance of RenderingSessionOptions. </summary>
        /// <param name="maxLeaseTimeMinutes"> The time in minutes the session will run after reaching the &apos;Ready&apos; state. </param>
        /// <param name="size"> Size of the server used for the rendering session. Remote Rendering with Standard size server has a maximum scene size of 20 million polygons. Remote Rendering with Premium size does not enforce a hard maximum, but performance may be degraded if your content exceeds the rendering capabilities of the service. </param>
        internal RenderingSessionOptions(int maxLeaseTimeMinutes, RenderingServerSize size)
        {
            MaxLeaseTimeMinutes = maxLeaseTimeMinutes;
            Size = size;
        }

        /// <summary> The time in minutes the session will run after reaching the &apos;Ready&apos; state. </summary>
        [CodeGenMember("MaxLeaseTimeMinutes")]
        internal int MaxLeaseTimeMinutes { get; }

        /// <summary> The time the session will run after reaching the &apos;Ready&apos; state. </summary>
        public TimeSpan MaxLeaseTime
        {
            get
            {
                return TimeSpan.FromMinutes(MaxLeaseTimeMinutes);
            }
        }
    }
}