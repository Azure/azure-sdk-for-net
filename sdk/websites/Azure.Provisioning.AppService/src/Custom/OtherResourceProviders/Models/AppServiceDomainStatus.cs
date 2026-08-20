// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// Domain registration status.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public enum AppServiceDomainStatus
{
    /// <summary>
    /// Unknown.
    /// </summary>
    Unknown,

    /// <summary>
    /// Active.
    /// </summary>
    Active,

    /// <summary>
    /// Awaiting.
    /// </summary>
    Awaiting,

    /// <summary>
    /// Cancelled.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Confiscated.
    /// </summary>
    Confiscated,

    /// <summary>
    /// Disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// Excluded.
    /// </summary>
    Excluded,

    /// <summary>
    /// Expired.
    /// </summary>
    Expired,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,

    /// <summary>
    /// Held.
    /// </summary>
    Held,

    /// <summary>
    /// Locked.
    /// </summary>
    Locked,

    /// <summary>
    /// Parked.
    /// </summary>
    Parked,

    /// <summary>
    /// Pending.
    /// </summary>
    Pending,

    /// <summary>
    /// Reserved.
    /// </summary>
    Reserved,

    /// <summary>
    /// Reverted.
    /// </summary>
    Reverted,

    /// <summary>
    /// Suspended.
    /// </summary>
    Suspended,

    /// <summary>
    /// Transferred.
    /// </summary>
    Transferred,

    /// <summary>
    /// Unlocked.
    /// </summary>
    Unlocked,

    /// <summary>
    /// Unparked.
    /// </summary>
    Unparked,

    /// <summary>
    /// Updated.
    /// </summary>
    Updated,

    /// <summary>
    /// JsonConverterFailed.
    /// </summary>
    JsonConverterFailed,
}
