// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Network;

/// <summary> The protocol to which a DDoS custom policy applies. </summary>
public enum DdosCustomPolicyProtocol
{
    /// <summary> TCP. </summary>
    Tcp = 0,

    /// <summary> UDP. </summary>
    Udp = 1,

    /// <summary> TCP SYN. </summary>
    Syn = 2,
}
