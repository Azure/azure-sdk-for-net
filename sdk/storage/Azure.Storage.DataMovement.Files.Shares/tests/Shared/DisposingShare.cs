// Copyright (c) Microsoft Corporation. All rights reserved.
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
            BaseShares::Azure.Storage.Files.Shares.Models.ShareCreateOptions options = new()
            {
                Metadata = metadata
            };
            await share.CreateIfNotExistsAsync(options);
            return new DisposingShare(share);
        }

        public static async Task<DisposingShare> CreateNfsAsync(ShareClient share, IDictionary<string, string> metadata)
        {
            BaseShares::Azure.Storage.Files.Shares.Models.ShareCreateOptions options = new()
            {
                Metadata = metadata,
                Protocols = ShareProtocols.Nfs
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
