// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The properties within SessionHostProperties (AgentVersion, LastHeartBeatOn, OSVersion, etc.)
// are defined with @visibility(Lifecycle.Read) in the TypeSpec side, so the generated code only
// produces getters. However, the existing API contract exposes setters on these properties,
// so this customization redeclares them with both getters and setters to maintain backward
// compatibility.

#nullable disable

using System;
using Azure.ResourceManager.DesktopVirtualization;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Schema for SessionHost properties. </summary>
    internal partial class SessionHostProperties
    {
        /// <summary> Version of agent on SessionHost. </summary>
        public string AgentVersion { get; set; }

        /// <summary> Last heart beat from SessionHost. </summary>
        public DateTimeOffset? LastHeartBeatOn { get; set; }

        /// <summary> The version of the OS on the session host. </summary>
        public string OSVersion { get; set; }

        /// <summary> Number of sessions on SessionHost. </summary>
        public int? Sessions { get; set; }

        /// <summary> Status for a SessionHost. </summary>
        public SessionHostStatus? Status { get; set; }

        /// <summary> The version of the side by side stack on the session host. </summary>
        public string SxsStackVersion { get; set; }

        /// <summary> The error message. </summary>
        public string UpdateErrorMessage { get; set; }

        /// <summary> Update state of a SessionHost. </summary>
        public SessionHostUpdateState? UpdateState { get; set; }
    }
}
