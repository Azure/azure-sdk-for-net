// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Configuration options for the attestation client.
    /// </summary>
    public class AttestationClientOptions : ClientOptions
    {
        internal string Version { get; }

        internal TokenValidationOptions TokenOptions { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="AttestationClientOptions"/>.</summary>
        public AttestationClientOptions(
            ServiceVersion version = ServiceVersion.V2020_10_01,
            TokenValidationOptions tokenOptions = default
            )
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

            // If the caller specified that they have token validation options, use them, otherwise
            // use the defaults.
            TokenOptions = tokenOptions ?? new TokenValidationOptions();
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
