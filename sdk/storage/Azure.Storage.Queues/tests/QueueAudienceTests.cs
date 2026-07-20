// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.Queues.Tests
{
    public class QueueAudienceTests : StorageAudienceTestBase
    {
        protected override string GetDefaultAudienceValue()
            => QueueAudience.PublicAudience.ToString();

        protected override string GetAccountAudienceValue(string accountName)
            => QueueAudience.CreateQueueServiceAccountAudience(accountName).ToString();

        protected override string CreateDefaultScope(string audienceValue)
            => new QueueAudience(audienceValue).CreateDefaultScope();
    }
}
