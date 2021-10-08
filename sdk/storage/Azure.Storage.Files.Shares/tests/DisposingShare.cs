// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DisposingShare : IAsyncDisposable
    {
        public ShareClient Share { get; private set; }

        public static async Task<DisposingShare> CreateAsync(ShareClient share, IDictionary<string, string> metadata)
        {
            await share.CreateIfNotExistsAsync(metadata: metadata);
            return new DisposingShare(share);
        }

        public DisposingShare(ShareClient share)
        {
            Share = share;
        }

        public async ValueTask DisposeAsync()
        {
            if (Share != null)
            {
                try
                {
                    await Share.DeleteIfExistsAsync();
                    Share = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
