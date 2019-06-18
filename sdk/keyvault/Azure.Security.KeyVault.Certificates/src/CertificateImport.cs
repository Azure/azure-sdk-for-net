// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateImport : CertificateBase
    {
        public string Value { get; set; }
        public string Password { get; set; }
        public CertificatePolicy Policy { get; set; }

        public CertificateImport (string name) : base(name) { }
    }
}
