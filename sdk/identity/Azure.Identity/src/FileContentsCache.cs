// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal class FileContentsCache
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private SemaphoreSlim _lock= new SemaphoreSlim(1);
        private readonly string _tokenFilePath;
        private string _tokenFileContents;
        private DateTimeOffset _refreshOn = DateTimeOffset.MinValue;
        private readonly TimeSpan _refreshInterval;

        public FileContentsCache(string tokenFilePath, TimeSpan? refreshInterval = default)
        {
            _refreshInterval = refreshInterval ?? TimeSpan.FromMinutes(5);

            _tokenFilePath = tokenFilePath;
        }

        public async Task<string> GetTokenFileContentsAsync(CancellationToken cancellationToken)
        {
            if (_refreshOn <= DateTimeOffset.UtcNow)
            {
                await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    if (_refreshOn <= DateTimeOffset.UtcNow)
                    {
                        using (var reader = File.OpenText(_tokenFilePath))
                        {
                            _tokenFileContents = await reader.ReadToEndAsync().ConfigureAwait(false);

                            _refreshOn = DateTimeOffset.UtcNow + _refreshInterval;
                        }
                    }
                }
                finally
                {
                    _lock.Release();
                }
            }

            return _tokenFileContents;
        }
    }
}
