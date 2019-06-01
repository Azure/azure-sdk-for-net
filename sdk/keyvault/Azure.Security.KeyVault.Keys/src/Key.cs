// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class Key : KeyBase
    {
        public JsonWebKey KeyMaterial { get; set; }

        public Key(string name) : base(name) { }

        internal override void ReadProperties(JsonElement json)
        {
            KeyMaterial = null;

            if (json.TryGetProperty("key", out JsonElement key))
            {
                KeyMaterial = new JsonWebKey();
                KeyMaterial.ReadProperties(key);
            }
            
            base.ReadProperties(json);
        }
    }
}
