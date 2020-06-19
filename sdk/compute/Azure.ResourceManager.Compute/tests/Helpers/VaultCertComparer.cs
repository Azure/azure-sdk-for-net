// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute.Tests
{
    internal class VaultCertComparer : IEqualityComparer<VaultCertificate>
    {
        public bool Equals(VaultCertificate cert1, VaultCertificate cert2)
        {
            if (cert1.CertificateStore == cert2.CertificateStore && cert1.CertificateUrl == cert2.CertificateUrl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(VaultCertificate Cert)
        {
            return Cert.CertificateUrl.ToLower().GetHashCode();
        }
    }
}
