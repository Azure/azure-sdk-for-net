// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The properties needed to register a Managed HSM key that points at material managed by an external HSM
    /// using the <see cref="KeyClient"/>.
    /// </summary>
    public class CreateExternalKeyOptions
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

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> indicating when the key will be valid.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> indicating when the key will expire.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the key will be enabled. If null, the service default is used.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the policy rules under which the key can be exported.
        /// </summary>
        public KeyReleasePolicy ReleasePolicy { get; set; }

        /// <summary>
        /// Gets a dictionary of tags with specific metadata about the key. Although this collection cannot be set, it can be modified
        ///  or initialized with a <see href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer">collection initializer</see>.
        /// </summary>
        public IDictionary<string, string> Tags { get; } = new Dictionary<string, string>();
    }
}
