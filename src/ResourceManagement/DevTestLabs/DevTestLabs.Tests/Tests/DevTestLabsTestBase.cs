//
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

using Microsoft.Azure.Management.DevTestLabs;
using Microsoft.Azure.Management.DevTestLabs.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Threading;

namespace DevTestLabs.Tests
{
    public class TestEnvironmentInfo
    {
        public TestEnvironmentInfo()
        {
        }

        public TestEnvironmentInfo(string s)
        {
            SubscriptionId = s;
        }

        public string SubscriptionId { get; set; }
    }

    public class DevTestLabsTestBase : TestBase
    {
        public const string SubscriptionIdKey = "SubscriptionId";

        public TestEnvironmentInfo GetEnvironmentInfo()
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            TestEnvironmentInfo result = new TestEnvironmentInfo();
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                result.SubscriptionId = environment.SubscriptionId;

                HttpMockServer.Variables[SubscriptionIdKey] = result.SubscriptionId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                result.SubscriptionId = HttpMockServer.Variables[SubscriptionIdKey];
            }
            return result;
        }

        public DevTestLabsClient GetDevTestLabsClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }
            var client = handler == null ?
                context.GetServiceClient<DevTestLabsClient>() :
                context.GetServiceClient<DevTestLabsClient>(handlers: handler);

            client.SubscriptionId = GetEnvironmentInfo().SubscriptionId;

            return client;
        }

        public Lab CreateKeyCredential()
        {
            var lab = new Lab
            {
                Location = "westus",
            };

            return lab;
        }
    }
}
