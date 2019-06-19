// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    public class IssuerBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public bool Enabled { get; set; }
        
    }
}
