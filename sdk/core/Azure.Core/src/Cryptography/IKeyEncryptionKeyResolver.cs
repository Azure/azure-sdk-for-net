// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Cryptography
{
    /// <summary>
    /// An object capable of retrieving key encryption keys from a provided key identifier.
    /// </summary>
    public interface IKeyEncryptionKeyResolver
    {
        /// <summary>
        /// Retrieves the key encryption key corresponding to the specified keyId.
        /// </summary>
        /// <param name="keyId">The key identifier of the key encryption key to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The key encryption key corresponding to the specified keyId.</returns>
        IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the key encryption key corresponding to the specified keyId.
        /// </summary>
        /// <param name="keyId">The key identifier of the key encryption key to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The key encryption key corresponding to the specified keyId.</returns>
        Task<IKeyEncryptionKey> ResolveAsync(string keyId, CancellationToken cancellationToken = default);
    }
}
