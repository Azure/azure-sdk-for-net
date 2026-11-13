// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Certificate product type. </summary>
    [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CertificateProductType
    {
        /// <summary> StandardDomainValidatedSsl. </summary>
        StandardDomainValidatedSsl,
        /// <summary> StandardDomainValidatedWildCardSsl. </summary>
        StandardDomainValidatedWildCardSsl
    }
}
