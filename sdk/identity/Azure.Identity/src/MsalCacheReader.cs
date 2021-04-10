// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Azure.Identity
{
    internal class MsalCacheReader
    {
        private readonly string _cachePath;
        private readonly string _cacheLockPath;
        private readonly int _cacheRetryCount;
        private readonly TimeSpan _cacheRetryDelay;
        private DateTimeOffset _lastReadTime;

        public MsalCacheReader(ITokenCache cache, string cachePath, int cacheRetryCount, TimeSpan cacheRetryDelay)
        {
            _cachePath = cachePath;

            _cacheLockPath = cachePath + ".lockfile";

            _cacheRetryCount = cacheRetryCount;

            _cacheRetryDelay = cacheRetryDelay;

            cache.SetBeforeAccessAsync(OnBeforeAccessAsync);
        }

        private async Task OnBeforeAccessAsync(TokenCacheNotificationArgs args)
        {
            try
            {
                DateTime cacheTimestamp = File.GetLastWriteTimeUtc(_cachePath);

                if (File.Exists(_cachePath) && _lastReadTime < cacheTimestamp)
                {
                    using (SentinelFileLock cacheLock = await SentinelFileLock.AcquireAsync(_cacheLockPath, _cacheRetryCount, _cacheRetryDelay).ConfigureAwait(false))
                    {
                        byte[] cacheBytesFromDisk = await ReadCacheFromProtectedStorageAsync().ConfigureAwait(false);

                        // update the last read time before deserialization so if deserialization fails we won't continually read the invalid file
                        _lastReadTime = cacheTimestamp;

                        if (cacheBytesFromDisk != null)
                        {
                            args.TokenCache.DeserializeMsalV3(cacheBytesFromDisk, shouldClearExistingCache: false);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // log
            }
        }

        private async Task<byte[]> ReadCacheFromProtectedStorageAsync()
        {
            using (FileStream file = File.OpenRead(_cachePath))
            {
                byte[] protectedBytes = new byte[file.Length];

                await file.ReadAsync(protectedBytes, 0, protectedBytes.Length).ConfigureAwait(false);

                return ProtectedData.Unprotect(protectedBytes, optionalEntropy: null, scope: DataProtectionScope.CurrentUser);
            }
        }
    }
}
