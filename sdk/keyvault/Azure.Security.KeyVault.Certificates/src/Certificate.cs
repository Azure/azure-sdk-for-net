// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class Certificate : CertificateBase
    {
        public CertificatePolicy Policy { get; set; }
        public string SecretId { get; set; }
        public string KeyId { get; set; }
        public string CER { get; set; }

        public Certificate(string name) : base(name) { }
    }
}
