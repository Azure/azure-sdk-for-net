// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Azure.Storage.Test
{
    public class KeyVaultConfiguration
    {
        public string VaultName { get; private set; }
        public string VaultEndpoint { get; private set; }

        /// <summary>
        /// Parse an XML representation into a TenantConfiguration value.
        /// </summary>
        /// <param name="tenant">The XML element to parse.</param>
        /// <returns>A TenantConfiguration value.</returns>
        public static KeyVaultConfiguration Parse(XElement tenant)
        {
            string Get(string name) => (string)tenant.Element(name);

            return new KeyVaultConfiguration
            {
                VaultName = Get("VaultName"),
                VaultEndpoint = Get("VaultEndpoint"),
            };
        }
    }
}
