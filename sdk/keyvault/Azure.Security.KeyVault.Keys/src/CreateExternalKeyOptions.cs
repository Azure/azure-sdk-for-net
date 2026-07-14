// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The properties needed to register a Managed HSM key that points at material managed by an external HSM
    /// using the <see cref="KeyClient"/>.
    /// </summary>
    public class CreateExternalKeyOptions : CreateKeyOptions
    {
        /// <summary>
        /// Gets the name of the key to create.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the reference identifying the external key material.
        /// </summary>
        public ExternalKey ExternalKey { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateExternalKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key to create.</param>
        /// <param name="externalKey">A reference identifying the external key material.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="externalKey"/> is null.</exception>
        public CreateExternalKeyOptions(string name, ExternalKey externalKey)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(externalKey, nameof(externalKey));

            Name = name;
            ExternalKey = externalKey;
        }
    }
}
