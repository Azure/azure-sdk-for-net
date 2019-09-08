using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Azure.Identity
{
    internal class MsalCacheReader
    {
        private string _cachePath;
        private string _cacheLockPath;
        private int _cacheRetryCount;
        private int _cacheRetryDelay;
        private DateTimeOffset _lastReadTime;

        public MsalCacheReader(ITokenCache cache, string cachePath, int cacheRetryCount, int cacheRetryDelay)
        {
            _cachePath = cachePath;

            _cacheLockPath = cachePath + ".lock";

            _cacheRetryCount = cacheRetryCount;

            _cacheRetryDelay = cacheRetryDelay;

            cache.SetBeforeAccessAsync(OnBeforeAccessAsync);
        } 

        private async Task OnBeforeAccessAsync(TokenCacheNotificationArgs args)
        {
            try
            {
                if (File.Exists(_cachePath) && _lastReadTime < File.GetLastWriteTimeUtc(_cachePath))
                {
                    using (var cacheLock = await SentinalFileLock.AquireAsync(_cacheLockPath, _cacheRetryCount, _cacheRetryDelay).ConfigureAwait(false))
                    {
                        byte[] cacheBytesFromDisk = await ReadCacheFromProtectedStorageAsync().ConfigureAwait(false);

                        // update the last read time before deserialization so if deserialization fails we won't continually read the invalid file
                        _lastReadTime = DateTimeOffset.UtcNow;

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
