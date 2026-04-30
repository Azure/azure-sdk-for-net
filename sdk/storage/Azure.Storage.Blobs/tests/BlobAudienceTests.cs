// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobAudienceTests : StorageAudienceTestBase
    {
        protected override string GetDefaultAudienceValue()
            => BlobAudience.DefaultAudience.ToString();

        protected override string GetAccountAudienceValue(string accountName)
            => BlobAudience.CreateBlobServiceAccountAudience(accountName).ToString();

        protected override string CreateDefaultScope(string audienceValue)
            => new BlobAudience(audienceValue).CreateDefaultScope();
    }
}
