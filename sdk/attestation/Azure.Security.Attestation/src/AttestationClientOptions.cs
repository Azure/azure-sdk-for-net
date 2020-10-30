// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using Azure.Core;
using Azure.Security.Attestation.Models;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Configuration options for the attestation client.
    /// </summary>
    public class AttestationClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Validation callback which allows customers to provide their own delegate to validate a returned MAA <see cref="AttestationToken{TBodyType}"/>.
        /// </summary>
        public Func<AttestationToken, AttestationSigner, bool> ValidationCallback { get; }

        /// <summary>Initializes a new instance of the <see cref="AttestationClientOptions"/>.</summary>
        public AttestationClientOptions(ServiceVersion version = ServiceVersion.V20201001, Func<AttestationToken, AttestationSigner, bool> validationCallback = null)
        {
            Version = version switch
            {
                ServiceVersion.V20201001 => "2020-10-01",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
            ValidationCallback = validationCallback;
        }

        /// <summary>
        /// The Microsoft Azure Attestation service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2020-10-01 of the Microsoft Azure Attestation Service - corresponds to the General Availability of the MAA service.
            /// </summary>
            V20201001 = 0,
        };
    }
}
