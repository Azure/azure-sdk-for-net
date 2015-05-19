//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Models;

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
