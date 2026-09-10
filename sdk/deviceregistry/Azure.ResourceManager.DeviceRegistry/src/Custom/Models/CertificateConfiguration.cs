// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.DeviceRegistry.Models
{
    /// <summary> The certificate configuration. </summary>
    public partial class CertificateConfiguration
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CertificateConfiguration"/> for PATCH (update)
        /// operations where only the leaf certificate validity period needs to be changed.
        /// <para>
        /// This constructor does NOT include <c>certificateAuthorityConfiguration</c>, which
        /// contains immutable-after-creation properties (<c>keyType</c>, <c>bringYourOwnRoot</c>).
        /// The 2026-03-01-preview API rejects these properties on PATCH requests.
        /// </para>
        /// <para>
        /// For PUT (create) operations, use the full constructor:
        /// <see cref="CertificateConfiguration(CertificateAuthorityConfiguration, int)"/>.
        /// </para>
        /// </summary>
        /// <param name="leafCertificateValidityPeriodInDays">The validity period in days for leaf certificates.</param>
        public CertificateConfiguration(int leafCertificateValidityPeriodInDays)
        {
            LeafCertificateConfiguration = new LeafCertificateConfiguration(leafCertificateValidityPeriodInDays);
        }
    }
}
