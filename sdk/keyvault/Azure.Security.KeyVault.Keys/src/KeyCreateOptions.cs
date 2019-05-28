// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyCreateOptions
    {
        public string Name { get; }
        public string KeyType { get; set; }
        public IList<string> KeyOps { get; set; }
        public DateTime? NotBefore { get; set; }
        public DateTime? Expires { get; set; }
        public IDictionary<string, string> Tags { get; set; }

        public KeyCreateOptions(string name)
        {
            Name = name;
        }
    }
}
