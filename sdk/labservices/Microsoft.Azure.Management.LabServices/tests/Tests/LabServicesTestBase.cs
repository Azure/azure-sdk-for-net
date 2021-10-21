// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.LabServices;
using Microsoft.Azure.Management.LabServices.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Threading;

namespace LabServices.Tests
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

    public class LabServicesTestBase : TestBase
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

        public LabServicesClient GetManagedLabsClient(MockContext context)
        {
            var client = context.GetServiceClient<LabServicesClient>();

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

