﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;

using System.Collections.Generic;
using System.Threading.Tasks;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class DisposingShare : IDisposingContainer<ShareClient>
    {
        public ShareClient Share => Container;

        public ShareClient Container { get; private set; }

        public static async Task<DisposingShare> CreateAsync(ShareClient share, IDictionary<string, string> metadata)
        {
            ShareCreateOptions options = new ShareCreateOptions
            {
                Metadata = metadata
            };
            await share.CreateIfNotExistsAsync(options);
            return new DisposingShare(share);
        }

        public DisposingShare(ShareClient share)
        {
            Container = share;
        }

        public async ValueTask DisposeAsync()
        {
            if (Share != null)
            {
                try
                {
                    await Share.DeleteIfExistsAsync();
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
