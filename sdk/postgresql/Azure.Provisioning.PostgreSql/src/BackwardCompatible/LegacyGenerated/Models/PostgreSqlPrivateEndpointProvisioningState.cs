// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// State of the private endpoint connection.
/// </summary>
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
