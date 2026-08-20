// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// The AppServiceCertificateNotRenewableReason.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public enum AppServiceCertificateNotRenewableReason
{
    /// <summary>
    /// RegistrationStatusNotSupportedForRenewal.
    /// </summary>
    RegistrationStatusNotSupportedForRenewal,

    /// <summary>
    /// ExpirationNotInRenewalTimeRange.
    /// </summary>
    ExpirationNotInRenewalTimeRange,

    /// <summary>
    /// SubscriptionNotActive.
    /// </summary>
    SubscriptionNotActive,
}
