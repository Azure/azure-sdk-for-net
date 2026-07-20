// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareAudienceTests : StorageAudienceTestBase
    {
        protected override string GetDefaultAudienceValue()
            => ShareAudience.DefaultAudience.ToString();

        protected override string GetAccountAudienceValue(string accountName)
            => ShareAudience.CreateShareServiceAccountAudience(accountName).ToString();

        protected override string CreateDefaultScope(string audienceValue)
            => new ShareAudience(audienceValue).CreateDefaultScope();
    }
}
