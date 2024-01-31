// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> DDoS custom policy properties. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ProtocolCustomSettings
    {
        /// <summary> Initializes a new instance of ProtocolCustomSettings. </summary>
        public ProtocolCustomSettings()
        {
        }

        /// <summary> Initializes a new instance of ProtocolCustomSettings. </summary>
        /// <param name="protocol"> The protocol for which the DDoS protection policy is being customized. </param>
        /// <param name="triggerRateOverride"> The customized DDoS protection trigger rate. </param>
        /// <param name="sourceRateOverride"> The customized DDoS protection source rate. </param>
        /// <param name="triggerSensitivityOverride"> The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic. </param>
        internal ProtocolCustomSettings(DdosCustomPolicyProtocol? protocol, string triggerRateOverride, string sourceRateOverride, DdosCustomPolicyTriggerSensitivityOverride? triggerSensitivityOverride)
        {
            Protocol = protocol;
            TriggerRateOverride = triggerRateOverride;
            SourceRateOverride = sourceRateOverride;
            TriggerSensitivityOverride = triggerSensitivityOverride;
        }

        /// <summary> The protocol for which the DDoS protection policy is being customized. </summary>
        public DdosCustomPolicyProtocol? Protocol { get; set; }
        /// <summary> The customized DDoS protection trigger rate. </summary>
        public string TriggerRateOverride { get; set; }
        /// <summary> The customized DDoS protection source rate. </summary>
        public string SourceRateOverride { get; set; }
        /// <summary> The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic. </summary>
        public DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }
    }
}
