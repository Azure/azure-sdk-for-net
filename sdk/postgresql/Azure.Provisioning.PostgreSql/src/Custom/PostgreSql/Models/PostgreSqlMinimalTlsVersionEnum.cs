// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Enforce a minimal Tls version for the server.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServerConfiguration for the ssl_min_protocol_version server parameter instead.")]
public enum PostgreSqlMinimalTlsVersionEnum
{
    /// <summary>
    /// TLS1_0.
    /// </summary>
    [DataMember(Name = "TLS1_0")]
    Tls1_0,

    /// <summary>
    /// TLS1_1.
    /// </summary>
    [DataMember(Name = "TLS1_1")]
    Tls1_1,

    /// <summary>
    /// TLS1_2.
    /// </summary>
    [DataMember(Name = "TLS1_2")]
    Tls1_2,

    /// <summary>
    /// TLSEnforcementDisabled.
    /// </summary>
    TLSEnforcementDisabled,
}
