// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class RsaKeyCreateOptions : KeyCreateOptions
    {
        public string Name { get; set; }
        public KeyType KeyType { get; set; }
        public int KeySize { get; set; }
        public bool Hsm { get; set; }

        public RsaKeyCreateOptions(bool hsm) 
        {
            Name = Name;

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
