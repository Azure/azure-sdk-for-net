// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Add a second layer of encryption for your data using new encryption
/// algorithm which gives additional data protection. Value is optional but if
/// passed in, must be &apos;Disabled&apos; or &apos;Enabled&apos;.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use the PostgreSqlFlexibleServer.DataEncryption property for flexible-server encryption settings instead.")]
public enum PostgreSqlInfrastructureEncryption
{
    /// <summary>
    /// Default value for single layer of encryption for data at rest.
    /// </summary>
    Enabled,

    /// <summary>
    /// Additional (2nd) layer of encryption for data at rest.
    /// </summary>
    Disabled,
}
