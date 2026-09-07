// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// Certificate product type.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public enum CertificateProductType
{
    /// <summary>
    /// StandardDomainValidatedSsl.
    /// </summary>
    StandardDomainValidatedSsl,

    /// <summary>
    /// StandardDomainValidatedWildCardSsl.
    /// </summary>
    StandardDomainValidatedWildCardSsl,
}
