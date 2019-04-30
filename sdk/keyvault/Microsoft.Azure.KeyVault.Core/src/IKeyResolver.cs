// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Core
{
    /// <summary>
    /// Interface for key resolvers.
    /// </summary>
    public interface IKeyResolver
    {
        /// <summary>
        /// Provides an IKey implementation for the specified key identifier.
        /// </summary>
        /// <param name="kid">The key identifier to resolve</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The resolved IKey implementation or null</returns>
        /// <remarks>Implementations should check the format of the kid to ensure that it is recognized. Null, rather than 
        /// an exception, should be returned for unrecognized key identifiers to enable chaining of key resolvers.</remarks>
        Task<IKey> ResolveKeyAsync( string kid, CancellationToken token );
    }
}