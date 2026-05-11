// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// Represents an EKM (External Key Management) proxy connection.
    /// </summary>
    [CodeGenType("EkmConnection")]
    [CodeGenSuppress(nameof(KeyVaultEkmConnection), typeof(string), typeof(IEnumerable<BinaryData>))]
    public partial class KeyVaultEkmConnection
    {
        /// <summary> Initializes a new instance of the <see cref="KeyVaultEkmConnection"/> class. </summary>
        /// <param name="host"> EKM proxy FQDN (Fully Qualified Domain Name). Only allowed characters are a-z, A-Z, 0-9, hyphen (-), dot (.), and colon (:). </param>
        /// <param name="serverCaCertificates"> The root CA certificate chain that issued the proxy server's certificate, as an ordered collection of DER-encoded certificates. </param>
        /// <exception cref="ArgumentNullException"><paramref name="host"/> or <paramref name="serverCaCertificates"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="host"/> is an empty string.</exception>
        public KeyVaultEkmConnection(string host, IEnumerable<byte[]> serverCaCertificates)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNull(serverCaCertificates, nameof(serverCaCertificates));

            Host = host;
            ServerCaCertificates = serverCaCertificates
                .Select(BinaryData.FromBytes)
                .ToList();
        }
    }
}