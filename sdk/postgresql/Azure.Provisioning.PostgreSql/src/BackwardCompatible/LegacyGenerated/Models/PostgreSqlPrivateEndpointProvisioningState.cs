// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// State of the private endpoint connection.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is retained only for backward compatibility with the legacy PostgreSQL single-server API.")]
public enum PostgreSqlPrivateEndpointProvisioningState
{
    /// <summary>
    /// Approving.
    /// </summary>
    Approving,

    /// <summary>
    /// Ready.
    /// </summary>
    Ready,

    /// <summary>
    /// Dropping.
    /// </summary>
    Dropping,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,

    /// <summary>
    /// Rejecting.
    /// </summary>
    Rejecting,
}
