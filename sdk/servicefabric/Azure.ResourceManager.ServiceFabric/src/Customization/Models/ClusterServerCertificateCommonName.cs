// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceFabric.Models
{
    /// <summary> Describes the server certificate details using common name. </summary>
    public partial class ClusterServerCertificateCommonName
    {
        /// <summary> Initializes a new instance of ClusterServerCertificateCommonName. </summary>
        /// <param name="certificateCommonName"> The common name of the server certificate. </param>
        /// <param name="certificateIssuerThumbprint"> The issuer thumbprint of the server certificate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateCommonName"/> or <paramref name="certificateIssuerThumbprint"/> is null. </exception>
        public ClusterServerCertificateCommonName(string certificateCommonName, BinaryData certificateIssuerThumbprint)
        {
            Argument.AssertNotNull(certificateCommonName, nameof(certificateCommonName));

            CertificateCommonName = certificateCommonName;
            CertificateIssuerThumbprint = certificateIssuerThumbprint;
        }
    }
}
