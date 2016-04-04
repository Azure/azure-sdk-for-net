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
using System.Linq;
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
        private bool                   _isDisposed;
 
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
            if ( _isDisposed )
                throw new ObjectDisposedException( "CachingKeyResolver" );

            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            IKey result = _cache.Get( kid );

            if ( result == null )
            {
                result = await _inner.ResolveKeyAsync( kid, token ).ConfigureAwait( false );
                if ( result != null )
                {
                    // Cache the resolved key using the result's Kid.
                    // This is especially for the case when the resolved key contains information about the key version
                    var cacheKid = string.IsNullOrWhiteSpace( result.Kid ) ? kid : result.Kid;
 
                    var cachedKey = new CacheKey(result);
                    _cache.Add( cacheKid, cachedKey );
                    return cachedKey;
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
                if ( !_isDisposed )
                {
                   _isDisposed = true;
 
                    foreach (var cacheKey in _cache.OfType<CacheKey>())
                    {
                        cacheKey.Dispose(true);
                    }
 
                    _cache.Dispose();
                    _cache = null;
                }
            }
        }
 
        # region CacheKey class
 
        /// <summary>
        /// This class wraps the key that is cached using <see cref="CachingKeyResolver"/>
        /// The main purpose of <see cref="CacheKey"/> is to evict disposing cached key from the cache.
        /// </summary>
        class CacheKey : IKey
        {
            private readonly IKey _key;
 
            public CacheKey(IKey key)
            {
                _key = key;
            }
 
            public string Kid
            {
                get { return _key.Kid; }
            }
 
            public string DefaultEncryptionAlgorithm
            {
                get { return _key.DefaultEncryptionAlgorithm; }
            }
 
            public string DefaultKeyWrapAlgorithm
            {
                get { return _key.DefaultKeyWrapAlgorithm; }
            }
 
            public string DefaultSignatureAlgorithm
            {
                get { return _key.DefaultSignatureAlgorithm; }
            }
 
            public Task<byte[]> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.DecryptAsync(ciphertext, iv, authenticationData, authenticationTag, algorithm, token);
            }
 
            public Task<Tuple<byte[], byte[], string>> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData = null, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.EncryptAsync(plaintext, iv, authenticationData, algorithm, token);
            }
 
            public Task<Tuple<byte[], string>> WrapKeyAsync(byte[] key, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.WrapKeyAsync(key, algorithm, token);
            }
 
            public Task<byte[]> UnwrapKeyAsync(byte[] encryptedKey, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.UnwrapKeyAsync(encryptedKey, algorithm, token);
            }
 
            public Task<Tuple<byte[], string>> SignAsync(byte[] digest, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.SignAsync(digest, algorithm, token);
            }
 
            public Task<bool> VerifyAsync(byte[] digest, byte[] signature, string algorithm = null, CancellationToken token = default(CancellationToken))
            {
                return _key.VerifyAsync(digest, signature, algorithm, token);
            }
 
            public void Dispose()
            {
                // do not dispose because there may be multiple references to the cached object
            }
 
            /// <summary>
            /// Disposes the cached key only when cache is disposing
            /// </summary>
            /// <param name="force"> whether to force dispose </param>
            internal void Dispose(bool force)
            {
                Dispose(true, force);
                GC.SuppressFinalize(this);
            }
 
            private void Dispose(bool disposing, bool force)
            {
                if (disposing & force)
                {
                    _key.Dispose();
                }
            }
        }
 
        # endregion CacheKey class
    }
}
