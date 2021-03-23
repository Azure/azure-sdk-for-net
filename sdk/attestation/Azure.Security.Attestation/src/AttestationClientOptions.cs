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

        internal bool ValidateAttestationTokens { get; }

        /// <summary>
        /// Validation callback which allows customers to provide their own delegate to validate a returned MAA <see cref="AttestationToken"/>.
        /// </summary>
        public Func<AttestationToken, AttestationSigner, bool> ValidationCallback { get; }

        /// <summary>Initializes a new instance of the <see cref="AttestationClientOptions"/>.</summary>
        public AttestationClientOptions(
            ServiceVersion version = ServiceVersion.V2020_10_01,
            Func<AttestationToken, AttestationSigner, bool> validationCallback = null,
            bool validateAttestationTokens = true)
        {
            if (version == default)
            {
                throw new ArgumentException("The service version {version} is not supported by this library");
            }

            Version = version switch
            {
                ServiceVersion.V2020_10_01 => "2020-10-01",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
            ValidationCallback = validationCallback;
            ValidateAttestationTokens = validateAttestationTokens;
        }

        /// <summary>
        /// The Microsoft Azure Attestation service version.
        /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2020-10-01 of the Microsoft Azure Attestation Service - corresponds to the General Availability of the MAA service.
            /// </summary>
            V2020_10_01 = 1,
        };
#pragma warning restore CA1707
    }
}
