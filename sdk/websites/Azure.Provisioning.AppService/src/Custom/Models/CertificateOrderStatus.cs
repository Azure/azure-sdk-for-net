// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// Current order status.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public enum CertificateOrderStatus
{
    /// <summary>
    /// Pendingissuance.
    /// </summary>
    Pendingissuance,

    /// <summary>
    /// Issued.
    /// </summary>
    Issued,

    /// <summary>
    /// Revoked.
    /// </summary>
    Revoked,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// Denied.
    /// </summary>
    Denied,

    /// <summary>
    /// Pendingrevocation.
    /// </summary>
    Pendingrevocation,

    /// <summary>
    /// PendingRekey.
    /// </summary>
    PendingRekey,

    /// <summary>
    /// Unused.
    /// </summary>
    Unused,

    /// <summary>
    /// Expired.
    /// </summary>
    Expired,

    /// <summary>
    /// NotSubmitted.
    /// </summary>
    NotSubmitted,
}
