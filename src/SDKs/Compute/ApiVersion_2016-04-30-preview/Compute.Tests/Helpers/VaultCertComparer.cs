// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Compute.Tests
{
    class VaultCertComparer : IEqualityComparer<VaultCertificate>
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
