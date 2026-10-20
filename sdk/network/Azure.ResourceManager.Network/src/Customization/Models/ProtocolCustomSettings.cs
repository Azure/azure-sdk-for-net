// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A compatibility type for the former DDoS custom policy protocol settings model. </summary>
    // Retain the released type used by DdosCustomPolicyData.ProtocolCustomSettings.
    // It was already a compatibility stub in 1.15 and has no current TypeSpec serialization model.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and might be removed in a future version", false)]
    public partial class ProtocolCustomSettings
    {
        /// <summary> Initializes a new instance of <see cref="ProtocolCustomSettings"/>. </summary>
        public ProtocolCustomSettings()
        {
        }

        /// <summary> The protocol. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is not supported by the current DDoS API.")]
        public DdosCustomPolicyProtocol? Protocol { get; set; }

        /// <summary> The source rate override. </summary>
        public string SourceRateOverride { get; set; }

        /// <summary> The trigger rate override. </summary>
        public string TriggerRateOverride { get; set; }

        /// <summary> The trigger sensitivity override. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is not supported by the current DDoS API.")]
        public DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }
    }
}
