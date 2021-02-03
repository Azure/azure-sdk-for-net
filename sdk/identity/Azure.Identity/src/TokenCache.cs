// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// A cache for Tokens.
    /// </summary>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    // SemaphoreSlim only needs to be disposed when AvailableWaitHandle is called.
    public class TokenCache
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private SemaphoreSlim _lock = new SemaphoreSlim(1,1);
        private byte[] _data;
        private DateTimeOffset _lastUpdated;
        private ConditionalWeakTable<object, CacheTimestamp> _cacheAccessMap;

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
        /// An event notifying the subscriber that the underlying <see cref="TokenCache"/> has been updated. This event can be handled to persist the updated cache data.
        /// </summary>
        public event Func<TokenCacheUpdatedArgs, Task> Updated;

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
                await stream.WriteAsync(_data, 0, _data.Length, cancellationToken).ConfigureAwait(false);
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
                await stream.ReadAsync(data, 0, data.Length, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.Read(data, 0, data.Length);
            }

            return new TokenCache(data);
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
            if (args.HasStateChanged)
            {
                await UpdateCacheDataAsync(args.TokenCache).ConfigureAwait(false);
            }
        }

        private async Task UpdateCacheDataAsync(ITokenCacheSerializer tokenCache)
        {
            await _lock.WaitAsync().ConfigureAwait(false);

            try
            {
                if (!_cacheAccessMap.TryGetValue(tokenCache, out CacheTimestamp lastRead) || lastRead.Value < _lastUpdated)
                {
                    _data = await MergeCacheData(_data, tokenCache.SerializeMsalV3()).ConfigureAwait(false);
                }
                else
                {
                    _data = tokenCache.SerializeMsalV3();
                }

                _cacheAccessMap.GetOrCreateValue(tokenCache).Update();

                _lastUpdated = DateTime.UtcNow;
            }
            finally
            {
                _lock.Release();
            }

            if (Updated != null)
            {
                foreach (Func<TokenCacheUpdatedArgs, Task> handler in Updated.GetInvocationList())
                {
                    await handler(new TokenCacheUpdatedArgs(this)).ConfigureAwait(false);
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
    }
}
