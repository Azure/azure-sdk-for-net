// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeAudienceTests : StorageAudienceTestBase
    {
        protected override string GetDefaultAudienceValue()
            => DataLakeAudience.DefaultAudience.ToString();

        protected override string GetAccountAudienceValue(string accountName)
            => DataLakeAudience.CreateDataLakeServiceAccountAudience(accountName).ToString();

        protected override string CreateDefaultScope(string audienceValue)
            => new DataLakeAudience(audienceValue).CreateDefaultScope();
    }
}
