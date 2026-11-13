// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: Properties like AgentVersion, LastHeartBeatOn, OSVersion, Sessions,
// Status, SxsStackVersion, UpdateErrorMessage, and UpdateState were previously flattened as
// top-level properties on SessionHostData. The new generated code nests them under a Properties
// sub-object. These shim properties preserve the old flat accessors by delegating to
// Properties.*, so existing callers are not broken.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing the SessionHost data model.
    /// Represents a SessionHost definition.
    /// </summary>
    public partial class SessionHostData
    {
        /// <summary> Version of agent on SessionHost. </summary>
        [WirePath("properties.agentVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AgentVersion
        {
            get => Properties is null ? default : Properties.AgentVersion;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.AgentVersion = value;
            }
        }

        /// <summary> Last heart beat from SessionHost. </summary>
        [WirePath("properties.lastHeartBeat")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastHeartBeatOn
        {
            get => Properties is null ? default : Properties.LastHeartBeatOn;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.LastHeartBeatOn = value;
            }
        }

        /// <summary> The version of the OS on the session host. </summary>
        [WirePath("properties.osVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSVersion
        {
            get => Properties is null ? default : Properties.OSVersion;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.OSVersion = value;
            }
        }

        /// <summary> Number of sessions on SessionHost. </summary>
        [WirePath("properties.sessions")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Sessions
        {
            get => Properties is null ? default : Properties.Sessions;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.Sessions = value;
            }
        }

        /// <summary> Status for a SessionHost. </summary>
        [WirePath("properties.status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SessionHostStatus? Status
        {
            get => Properties is null ? default : Properties.Status;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.Status = value;
            }
        }

        /// <summary> The version of the side by side stack on the session host. </summary>
        [WirePath("properties.sxSStackVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SxsStackVersion
        {
            get => Properties is null ? default : Properties.SxsStackVersion;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.SxsStackVersion = value;
            }
        }

        /// <summary> The error message. </summary>
        [WirePath("properties.updateErrorMessage")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateErrorMessage
        {
            get => Properties is null ? default : Properties.UpdateErrorMessage;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.UpdateErrorMessage = value;
            }
        }

        /// <summary> Update state of a SessionHost. </summary>
        [WirePath("properties.updateState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SessionHostUpdateState? UpdateState
        {
            get => Properties is null ? default : Properties.UpdateState;
            set
            {
                if (Properties is null)
                    Properties = new SessionHostProperties();
                Properties.UpdateState = value;
            }
        }
    }
}
