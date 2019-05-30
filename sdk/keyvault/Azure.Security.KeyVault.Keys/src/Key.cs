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
    public class Key : KeyBase
    {
        public JsonWebKey KeyMaterial { get; set; }

        public Key(string name) : base(name) { }
        
        public Key(string name, string keyId, string keyType, IList<string> keyOperations)
            :base(name)
        {
            KeyMaterial = new JsonWebKey(keyId, keyType, keyOperations);
        }
    }
}
