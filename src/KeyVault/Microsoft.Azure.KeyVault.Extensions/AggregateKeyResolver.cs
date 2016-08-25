// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// The collection of key resolvers that would iterate on a key id to resolve to <see cref="IKey"/>.
    /// </summary>
    public class AggregateKeyResolver : IKeyResolver
    {
        private readonly ConcurrentBag<IKeyResolver> _resolvers = new ConcurrentBag<IKeyResolver>();

        /// <summary>
        /// Adds a key resolver to the collection of key resolvers.
        /// </summary>
        /// <param name="resolver">The key resolver to add to the collection</param>
        /// <returns></returns>
        public AggregateKeyResolver Add( IKeyResolver resolver )
        {
            if ( resolver == null )
                throw new ArgumentNullException( "resolver" );

            _resolvers.Add( resolver );

            return this;
        }

        #region IKeyResolver

        /// <summary>
        /// Resolve a key indicated by its ID to the corresponding <see cref="IKey"/>
        /// </summary>
        /// <param name="kid"> the key identifier </param>
        /// <param name="token"> the cancellation token </param>
        /// <returns> task result of the <see cref="IKey"/></returns>
        public async Task<IKey> ResolveKeyAsync( string kid, CancellationToken token )
        {
            foreach ( var resolver in _resolvers )
            {
                IKey resolved = await resolver.ResolveKeyAsync( kid, token ).ConfigureAwait( false );

                if ( resolved != null )
                {
                    return resolved;
                }
            }

            return null;
        }

        #endregion
    }
}
