// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The version of a server.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is retained only for backward compatibility with the legacy PostgreSQL single-server API.")]
public enum PostgreSqlServerVersion
{
    /// <summary>
    /// 9.5.
    /// </summary>
    [DataMember(Name = "9.5")]
    Ver9_5,

    /// <summary>
    /// 9.6.
    /// </summary>
    [DataMember(Name = "9.6")]
    Ver9_6,

    /// <summary>
    /// 10.
    /// </summary>
    [DataMember(Name = "10")]
    Ver10,

    /// <summary>
    /// 10.0.
    /// </summary>
    [DataMember(Name = "10.0")]
    Ver10_0,

    /// <summary>
    /// 10.2.
    /// </summary>
    [DataMember(Name = "10.2")]
    Ver10_2,

    /// <summary>
    /// 11.
    /// </summary>
    [DataMember(Name = "11")]
    Ver11,
}
