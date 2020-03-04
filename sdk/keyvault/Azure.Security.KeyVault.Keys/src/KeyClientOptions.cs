﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Options that allow you to configure the requests sent to Key Vault.
    /// </summary>
    public class KeyClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V7_1_Preview;

        /// <summary>
        /// The versions of Azure Key Vault supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Key Vault API version 7.0.
            /// </summary>
            V7_0 = 0,

            /// <summary>
            /// The Key Vault API version 7.1-preview.
            /// </summary>
            V7_1_Preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClientOptions"/> class.
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
#pragma warning disable AZC0010 // ClientOptions constructors should default ServiceVersion to latest supported service version
        public KeyClientOptions(ServiceVersion version = LatestVersion)
#pragma warning restore AZC0010 // ClientOptions constructors should default ServiceVersion to latest supported service version
        {
            Version = version;

            this.ConfigureLogging();
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V7_0 => "7.0",
                ServiceVersion.V7_1_Preview => "7.1-preview",

                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
