// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateOperation
    {
        public string IssuerName { get; set; }
        public bool CancellationRequest { get; set; }
        public string CertificateRequest { get; set; }
        public string RequestId { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }
        public string Target { get; set; }
        public ErrorModel Error { get; set; }
    }
}
