// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificatePolicy
    {
        public KeyOptions KeyOptions { get; set; }
        public string SecretContentType { get; set; }
        public string SubjectName { get; set; }
        public string IssuerName { get; set; }
        public string CertificateType { get; set; }
        public bool CertificateTransparency { get; set; }
        public int ValidityInMonths { get; set; }
        public string SubjectAlternativeDNS { get; set; }
        public string SubjectAlternativeEmail { get; set; }
        public string SubjectAlternativeUPNs { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool Enabled { get; set; }
        public List<LifeTimeAction> LifeTimeActions { get; set; }
    }
}
