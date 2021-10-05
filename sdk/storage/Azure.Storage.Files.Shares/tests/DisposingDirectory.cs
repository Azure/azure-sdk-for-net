// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DisposingDirectory : IAsyncDisposable
    {
        private DisposingShare _test;

        public ShareClient Share => _test.Share;
        public ShareDirectoryClient Directory { get; }

        public static async Task<DisposingDirectory> CreateAsync(DisposingShare test, ShareDirectoryClient directory)
        {
            await directory.CreateIfNotExistsAsync();
            return new DisposingDirectory(test, directory);
        }

        private DisposingDirectory(DisposingShare test, ShareDirectoryClient directory)
        {
            _test = test;
            Directory = directory;
        }

        public async ValueTask DisposeAsync()
        {
            await _test.DisposeAsync();
        }
    }
}
