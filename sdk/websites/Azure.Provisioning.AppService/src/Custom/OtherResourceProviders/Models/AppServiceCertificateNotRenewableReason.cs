// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// The AppServiceCertificateNotRenewableReason.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
// TODO: Redirect to Azure.Provisioning.CertificateRegistration when that package is available.
[System.Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
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
