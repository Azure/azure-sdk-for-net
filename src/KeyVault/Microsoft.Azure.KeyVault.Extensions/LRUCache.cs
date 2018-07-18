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
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// A simple Least Recently Used Cache
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    internal class LRUCache<K, V> : IDisposable, IEnumerable<V> where K : class where V : class
    {
        private int                  _capacity;
        private Dictionary<K, V>     _cache = new Dictionary<K, V>();
        private LinkedList<K>        _list  = new LinkedList<K>();
        private ReaderWriterLockSlim _lock  = new ReaderWriterLockSlim();
        private bool                 _isDisposed;
 
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="capacity">The maximum capacity of the cache</param>
        public LRUCache( int capacity )
        {
            if ( capacity <= 0 )
                throw new ArgumentException( "Capacity must be a positive non-zero value" );

            _capacity = capacity;
        }

        /// <summary>
        /// Adds a key and value to the cache.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void Add( K key, V value )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( "LRUCache" );

            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( value == null )
                throw new ArgumentNullException( "value" );

            try
            {
                _lock.EnterWriteLock();

                if ( !_cache.ContainsKey( key ) )
                {
                    // Cache before List as the cache may throw an exception
                    _cache.Add(key, value);
                    _list.AddLast( key );

                    if ( _list.Count > _capacity )
                    {
                        LinkedListNode<K> lruKey = _list.First;

                        _cache.Remove( lruKey.Value );
                        _list.RemoveFirst();
                    }
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Gets a value from the cache.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The value for the key or null</returns>
        public V Get( K key )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( "LRUCache" );

            if ( key == null )
                throw new ArgumentNullException( "key" );

            V value = null;

            try
            {
                _lock.EnterUpgradeableReadLock();

                if ( _cache.TryGetValue( key, out value ) )
                {
                    try
                    {
                        _lock.EnterWriteLock();

                        // Move the key to the tail of the LRU list
                        _list.Remove( key );
                        _list.AddLast( key );
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }

            return value;
        }

        /// <summary>
        /// Removes a key and its value from the cache
        /// </summary>
        /// <param name="key">The key to remove</param>
        public void Remove( K key )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( "LRUCache" );

            if ( key == null )
                throw new ArgumentNullException( "key" );

            try
            {
                _lock.EnterUpgradeableReadLock();

                if ( _cache.ContainsKey( key ) )
                {
                    _cache.Remove( key );
                    _list.Remove( key );
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Resets the content of the cache.
        /// </summary>
        public void Reset()
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( "LRUCache" );

            try
            {
                _lock.EnterWriteLock();

                _cache.Clear();
                _list.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
 
        /// <summary>
        /// Get enumerator on the cached values
        /// </summary>
        /// <returns></returns>
        public IEnumerator<V> GetEnumerator()
        {
            return _cache.Values.GetEnumerator();
        }
 
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
                    _lock.Dispose();
                    _lock = null;
                }
            }
        }
    }
}
