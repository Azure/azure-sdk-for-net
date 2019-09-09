// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

