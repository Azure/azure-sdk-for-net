using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Batch;
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
            return client;
        }
    }
}
