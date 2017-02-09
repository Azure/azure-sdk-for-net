// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;

namespace Batch.Tests.Helpers
{
    public static class BatchTestHelper
    {
        public static BatchManagementClient GetBatchManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var client = new BatchManagementClient(new TokenCredentials("xyz"), handler);
            client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
            if (HttpMockServer.Mode != HttpRecorderMode.Record)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }
    }
}
