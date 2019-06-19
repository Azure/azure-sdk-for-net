// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class KeyOptions
    {
        public KeyType KeyType { get; set; }
        public bool ReuseKey { get; set; }
        public bool Exportable { get; set; }
        public string[] EnhancedKeyUsage { get; set; }
        public string[] KeyUsage { get; set; }
    }
}
