//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// A simple caching Key Resolver using a LRU cache
    /// </summary>
    public class CachingKeyResolver : IKeyResolver, IDisposable
    {
        private LRUCache<string, IKey> _cache;
        private IKeyResolver           _inner;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="capacity">The maximim capacity for the cache</param>
        /// <param name="inner">The IKeyResolver to wrap</param>
        public CachingKeyResolver( int capacity, IKeyResolver inner )
        {
            if ( inner == null )
                throw new ArgumentNullException( "inner" );

            _cache = new LRUCache<string, IKey>( capacity );
            _inner = inner;
        }

        #region IKeyResolver

        public async Task<IKey> ResolveKeyAsync( string kid, CancellationToken token )
        {
            if ( _cache == null )
                throw new ObjectDisposedException( "CachingKeyResolver" );

            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            IKey result = _cache.Get( kid );

            if ( result == null )
            {
                result = await _inner.ResolveKeyAsync( kid, token ).ConfigureAwait( false );

                if ( result != null )
                {
                    _cache.Add( kid, result );
                }
            }

            return result;
        }

        #endregion

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( _cache != null )
                {
                    _cache.Dispose();
                    _cache = null;
                }
            }
        }
    }
}
