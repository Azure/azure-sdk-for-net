// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Current order status. </summary>
    [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CertificateOrderStatus
    {
        /// <summary> Pendingissuance. </summary>
        Pendingissuance,
        /// <summary> Issued. </summary>
        Issued,
        /// <summary> Revoked. </summary>
        Revoked,
        /// <summary> Canceled. </summary>
        Canceled,
        /// <summary> Denied. </summary>
        Denied,
        /// <summary> Pendingrevocation. </summary>
        Pendingrevocation,
        /// <summary> PendingRekey. </summary>
        PendingRekey,
        /// <summary> Unused. </summary>
        Unused,
        /// <summary> Expired. </summary>
        Expired,
        /// <summary> NotSubmitted. </summary>
        NotSubmitted
    }
}
