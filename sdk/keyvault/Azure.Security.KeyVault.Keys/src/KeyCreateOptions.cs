// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyCreateOptions
    {
        public IList<KeyOperations> KeyOperations { get; set; }
        public DateTimeOffset? NotBefore { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public bool? Enabled { get; set; }
        public IDictionary<string, string> Tags { get; set; }
    }
}
