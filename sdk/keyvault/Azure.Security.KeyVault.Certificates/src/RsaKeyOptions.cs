// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class RsaKeyOptions : KeyOptions
    {
        public int KeySize { get; set; }
        public bool HSM { get; set; }

        public RsaKeyOptions(bool hsm)
        {
            if(hsm)
            {
                KeyType = KeyType.RsaHsm;
            }
            else
            {
                KeyType = KeyType.Rsa;
            }
        }
    }
}
