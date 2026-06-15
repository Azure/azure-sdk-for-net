// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A compatibility type for the former DDoS custom policy protocol settings model. </summary>
    [Obsolete]
    public partial class ProtocolCustomSettings
    {
        /// <summary> Initializes a new instance of <see cref="ProtocolCustomSettings"/>. </summary>
        public ProtocolCustomSettings()
        {
        }

        /// <summary> The protocol. </summary>
        public DdosCustomPolicyProtocol? Protocol { get; set; }

        /// <summary> The source rate override. </summary>
        public string SourceRateOverride { get; set; }

        /// <summary> The trigger rate override. </summary>
        public string TriggerRateOverride { get; set; }

        /// <summary> The trigger sensitivity override. </summary>
        public DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }
    }
}
