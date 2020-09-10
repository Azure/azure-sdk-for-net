// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    /// <summary>
    /// A cache for Tokens.
    /// </summary>
    public class TokenCache : IDisposable
    {
        private SemaphoreSlim _lock = new SemaphoreSlim(1,1);
        private byte[] _data;
        private DateTimeOffset _lastUpdated;
        private ConditionalWeakTable<object, CacheTimestamp> _cacheAccessMap;
        private bool _disposedValue;

        private static Lazy<TokenCache> s_SharedCache = new Lazy<TokenCache>(() => new PersistentTokenCache(true), LazyThreadSafetyMode.ExecutionAndPublication);

        private class CacheTimestamp
        {
            private DateTimeOffset _timestamp;

            public CacheTimestamp()
            {
                Update();
            }

            public void Update()
            {
                _timestamp = DateTimeOffset.UtcNow;
            }

            public DateTimeOffset Value { get { return _timestamp; } }
        }

        /// <summary>
        /// Instantiates a new <see cref="TokenCache"/>.
        /// </summary>
        public TokenCache()
            : this(Array.Empty<byte>())
        {
        }

        internal TokenCache(byte[] data)
        {
            _data = data;
            _lastUpdated = DateTimeOffset.UtcNow;
            _cacheAccessMap = new ConditionalWeakTable<object, CacheTimestamp>();
        }

        /// <summary>
        /// The shared token cache.
        /// </summary>
        public static TokenCache SharedCache => s_SharedCache.Value;


        /// <summary>
        /// Serializes the <see cref="TokenCache"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> which the serialized <see cref="TokenCache"/> will be written to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public void Serialize(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            SerializeAsync(stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Serializes the <see cref="TokenCache"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to which the serialized <see cref="TokenCache"/> will be written.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public async Task SerializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            await SerializeAsync(stream, true, cancellationToken).ConfigureAwait(false);
        }


        /// <summary>
        /// Deserializes the <see cref="TokenCache"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="TokenCache"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static TokenCache Deserialize(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            return DeserializeAsync(stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Deserializes the <see cref="TokenCache"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="TokenCache"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static async Task<TokenCache> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            return await DeserializeAsync(stream, true, cancellationToken).ConfigureAwait(false);
        }

        private async Task SerializeAsync(Stream stream, bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await stream.WriteAsync(_data, 0, _data.Length).ConfigureAwait(false);
            }
            else
            {
                stream.Write(_data, 0, _data.Length);
            }
        }

        private static async Task<TokenCache> DeserializeAsync(Stream stream, bool async, CancellationToken cancellationToken)
        {
            var data = new byte[stream.Length - stream.Position];

            if (async)
            {
                await stream.ReadAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            else
            {
                stream.Read(data, 0, data.Length);
            }

            return new TokenCache(data);
        }

        private static AccountId BuildAccountIdFromString(string homeAccountId)
        {
            //For the Microsoft identity platform (formerly named Azure AD v2.0), the identifier is the concatenation of
            // Microsoft.Identity.Client.AccountId.ObjectId and Microsoft.Identity.Client.AccountId.TenantId separated by a dot.
            var homeAccountSegments = homeAccountId.Split('.');
            AccountId accountId;
            if (homeAccountSegments.Length == 2)
            {
                accountId = new AccountId(homeAccountId, homeAccountSegments[0], homeAccountSegments[1]);
            }
            else
            {
                accountId = new AccountId(homeAccountId);
            }
            return accountId;
        }

        internal virtual async Task RegisterCache(bool async, ITokenCache tokenCache, CancellationToken cancellationToken)
        {
            if (async)
            {
                await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _lock.Wait(cancellationToken);
            }

            try
            {
                if (!_cacheAccessMap.TryGetValue(tokenCache, out _))
                {
                    tokenCache.SetBeforeAccessAsync(OnBeforeCacheAccessAsync);

                    tokenCache.SetAfterAccessAsync(OnAfterCacheAccessAsync);

                    _cacheAccessMap.Add(tokenCache, new CacheTimestamp());
                }
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnBeforeCacheAccessAsync(TokenCacheNotificationArgs args)
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(nameof(TokenCache));
            }

            await _lock.WaitAsync().ConfigureAwait(false);

            try
            {
                args.TokenCache.DeserializeMsalV3(_data, true);

                _cacheAccessMap.GetOrCreateValue(args.TokenCache).Update();
            }
            finally
            {
                _lock.Release();
            }
        }


        private async Task OnAfterCacheAccessAsync(TokenCacheNotificationArgs args)
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(nameof(TokenCache));
            }

            if (args.HasStateChanged)
            {
                await _lock.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (!_cacheAccessMap.TryGetValue(args.TokenCache, out CacheTimestamp lastRead) || lastRead.Value < _lastUpdated)
                    {
                        _data = await MergeCacheData(_data, args.TokenCache.SerializeMsalV3()).ConfigureAwait(false);
                    }
                    else
                    {
                        _data = args.TokenCache.SerializeMsalV3();
                    }

                    _lastUpdated = DateTime.UtcNow;
                }
                finally
                {
                    _lock.Release();
                }
            }
        }

        private static async Task<byte[]> MergeCacheData(byte[] cacheA, byte[] cacheB)
        {
            byte[] merged = null;

            var client = PublicClientApplicationBuilder.Create(Guid.NewGuid().ToString()).Build();

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheA));

            await client.GetAccountsAsync().ConfigureAwait(false);

            client.UserTokenCache.SetBeforeAccess(args => args.TokenCache.DeserializeMsalV3(cacheB, shouldClearExistingCache: false));

            client.UserTokenCache.SetAfterAccess(args => merged = args.TokenCache.SerializeMsalV3());

            await client.GetAccountsAsync().ConfigureAwait(false);

            return merged;
        }

        /// <summary>
        /// Disposes of the <see cref="TokenCache"/>.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources should be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _lock.Dispose();
                }

                var registeredCacheEntries = ((object)_cacheAccessMap) as IEnumerable<KeyValuePair<object, CacheTimestamp>>;

                if (registeredCacheEntries != null)
                {
                    foreach (ITokenCache registeredCache in registeredCacheEntries.Select(kvp => kvp.Key))
                    {
                        registeredCache.SetBeforeAccessAsync(null);

                        registeredCache.SetAfterAccessAsync(null);
                    }
                }

                _cacheAccessMap = null;

                _data = null;

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes of the <see cref="TokenCache"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
