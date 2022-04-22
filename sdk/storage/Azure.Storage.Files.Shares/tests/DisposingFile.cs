// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DisposingFile : IAsyncDisposable
    {
        private DisposingDirectory _test;

        public ShareClient Share => _test.Share;
        public ShareDirectoryClient Directory => _test.Directory;
        public ShareFileClient File { get; }

        public static async Task<DisposingFile> CreateAsync(DisposingDirectory test, ShareFileClient file)
        {
            await file.CreateAsync(maxSize: Constants.MB);
            return new DisposingFile(test, file);
        }

        private DisposingFile(DisposingDirectory test, ShareFileClient file)
        {
            _test = test;
            File = file;
        }

        public async ValueTask DisposeAsync()
        {
            await _test.DisposeAsync();
        }
    }
}
