// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// An immutable set of public receipt-verification keys. Key IDs are treated as case-sensitive and
    /// must be unique within the set.
    /// </summary>
    // A public constructor already enables mocking, so no model-factory method is required.
#pragma warning disable AZC0035
    public sealed class CodeTransparencyVerificationKeySet
#pragma warning restore AZC0035
    {
        private readonly IReadOnlyList<CodeTransparencyVerificationKey> _keys;
        private readonly Dictionary<string, CodeTransparencyVerificationKey> _keysById;

        /// <summary>
        /// Initializes a new instance of <see cref="CodeTransparencyVerificationKeySet"/>.
        /// </summary>
        /// <param name="keys">The verification keys. Every key must have a non-empty, unique key ID.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keys"/> is null.</exception>
        /// <exception cref="ArgumentException">A key is null, has a missing key ID, or duplicates another key ID.</exception>
        public CodeTransparencyVerificationKeySet(IEnumerable<CodeTransparencyVerificationKey> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            var list = new List<CodeTransparencyVerificationKey>();
            // Ordinal comparison keeps key IDs case-sensitive.
            var byId = new Dictionary<string, CodeTransparencyVerificationKey>(StringComparer.Ordinal);

            foreach (CodeTransparencyVerificationKey key in keys)
            {
                if (key == null)
                {
                    throw new ArgumentException("The key set must not contain a null key.", nameof(keys));
                }
                if (string.IsNullOrEmpty(key.KeyId))
                {
                    throw new ArgumentException("The key set must not contain a key with a missing key ID.", nameof(keys));
                }
                if (byId.ContainsKey(key.KeyId))
                {
                    throw new ArgumentException($"The key set contains a duplicate key ID '{key.KeyId}'.", nameof(keys));
                }

                byId.Add(key.KeyId, key);
                list.Add(key);
            }

            _keys = list;
            _keysById = byId;
        }

        /// <summary>
        /// Gets the verification keys in the set.
        /// </summary>
        public IReadOnlyList<CodeTransparencyVerificationKey> Keys => _keys;

        /// <summary>
        /// Performs an exact, case-sensitive lookup for the key with the specified key ID.
        /// </summary>
        /// <param name="keyId">The case-sensitive key ID to look up.</param>
        /// <param name="key">When this method returns, the matching key if found; otherwise null.</param>
        /// <returns><c>true</c> if a matching key was found; otherwise, <c>false</c>.</returns>
        public bool TryGetKey(string keyId, out CodeTransparencyVerificationKey key)
        {
            if (keyId == null)
            {
                key = null;
                return false;
            }

            return _keysById.TryGetValue(keyId, out key);
        }
    }
}
