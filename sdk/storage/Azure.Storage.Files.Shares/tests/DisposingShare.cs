﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DisposingShare : IDisposingContainer<ShareClient>
    {
        public ShareClient Share => Container;

        public ShareClient Container { get; private set; }

        public static async Task<DisposingShare> CreateAsync(ShareClient share, IDictionary<string, string> metadata)
        {
            await share.CreateIfNotExistsAsync(metadata: metadata);
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
