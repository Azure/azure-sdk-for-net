﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
