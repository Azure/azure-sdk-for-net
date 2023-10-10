// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceFabric.Models
{
    /// <summary> Describes the client certificate details using common name. </summary>
    public partial class ClusterClientCertificateCommonName
    {
        /// <summary> Initializes a new instance of ClusterClientCertificateCommonName. </summary>
        /// <param name="isAdmin"> Indicates if the client certificate has admin access to the cluster. Non admin clients can perform only read only operations on the cluster. </param>
        /// <param name="certificateCommonName"> The common name of the client certificate. </param>
        /// <param name="certificateIssuerThumbprint"> The issuer thumbprint of the client certificate. </param>
        public ClusterClientCertificateCommonName(bool isAdmin, string certificateCommonName, BinaryData certificateIssuerThumbprint)
        {
            IsAdmin = isAdmin;
            CertificateCommonName = certificateCommonName;
            CertificateIssuerThumbprint = certificateIssuerThumbprint;
        }
    }
}
