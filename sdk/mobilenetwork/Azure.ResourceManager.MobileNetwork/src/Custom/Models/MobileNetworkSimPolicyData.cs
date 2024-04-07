// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.MobileNetwork.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MobileNetwork
{
    /// <summary>
    /// A class representing the MobileNetworkSimPolicy data model.
    /// SIM policy resource.
    /// </summary>
    public partial class MobileNetworkSimPolicyData : TrackedResourceData
    {
        /// <summary> Aggregate maximum bit rate across all non-GBR QoS flows of all PDU sessions of a given UE. See 3GPP TS23.501 section 5.7.2.6 for a full description of the UE-AMBR. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Ambr UeAmbr { get => UEAmbr; set => UEAmbr = value; }
    }
}
