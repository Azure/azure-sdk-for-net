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
        /// <param name="hostName"> The fully qualified host name of the EKM proxy. Only allowed characters are a-z, A-Z, 0-9, hyphen (-), dot (.), and colon (:). </param>
        /// <param name="serverCaCertificates"> The root CA certificate chain that issued the proxy server's certificate, as an ordered collection of DER-encoded certificates. </param>
        /// <exception cref="ArgumentNullException"><paramref name="hostName"/> or <paramref name="serverCaCertificates"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hostName"/> is an empty string.</exception>
        public KeyVaultEkmConnection(string hostName, IEnumerable<byte[]> serverCaCertificates)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));
            Argument.AssertNotNull(serverCaCertificates, nameof(serverCaCertificates));

            HostName = hostName;
            ServerCaCertificates = serverCaCertificates
                .Select(BinaryData.FromBytes)
                .ToList();
        }

        /// <summary> The fully qualified host name of the EKM proxy (for example, <c>ekm.contoso.com</c>). Only allowed characters are a-z, A-Z, 0-9, hyphen (-), dot (.), and colon (:). </summary>
        [CodeGenMember("Host")]
        public string HostName { get; set; }
    }
}