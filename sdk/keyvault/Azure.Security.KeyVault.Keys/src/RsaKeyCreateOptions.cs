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
        public int KeySize { get; set; }
        public KeyType KeyType { get; set; }

        public RsaKeyCreateOptions() 
        {
            KeyType = KeyType.Rsa;
        }

        public RsaKeyCreateOptions(int size, List<KeyOperations> keyOps, DateTimeOffset? notBefore, DateTimeOffset? expires, Dictionary<string, string> tags)
        {
            KeySize = size;
            KeyOperations = keyOps;
            KeyType = KeyType.Rsa;
            NotBefore = notBefore;
            Expires = expires;
            Tags = new Dictionary<string, string>(tags);
        }
    }
}
