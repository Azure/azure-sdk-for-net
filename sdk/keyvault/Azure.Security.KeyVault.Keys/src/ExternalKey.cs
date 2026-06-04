// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A reference to a key whose material is held in an external HSM, used with
    /// <see cref="KeyClient.CreateExternalKey(CreateExternalKeyOptions, System.Threading.CancellationToken)"/>
    /// (and its async equivalent) to register a Managed HSM key that points at material managed by an external HSM.
    /// Only available with service version <c>2026-01-01-preview</c> and newer, and only supported on Managed HSM.
    /// </summary>
    public class ExternalKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalKey"/> class.
        /// </summary>
        /// <param name="id">
        /// The external key identifier. Must contain only characters in the set <c>[a-zA-Z0-9-]</c>
        /// and be at most 64 characters long.
        /// </param>
        /// <exception cref="System.ArgumentNullException"><paramref name="id"/> is null.</exception>
        public ExternalKey(string id)
        {
            Argument.AssertNotNull(id, nameof(id));
            Id = id;
        }

        /// <summary>
        /// Gets the external key identifier.
        /// </summary>
        public string Id { get; }
    }
}