// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorSimple8000Series.Tests
{
    class StorSimple8000SeriesTestBase : TestBase
    {
        private const string SubIdKey = "SubId";
        public string subscriptionId { get; set; }

        public StorSimple8000SeriesManagementClient client { get; set; }
        public Dictionary<string, string> tags { get; internal set; }

        public StorSimple8000SeriesTestBase(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            
            this.client = context.GetServiceClient<StorSimple8000SeriesManagementClient>();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.subscriptionId = testEnv.SubscriptionId;
                HttpMockServer.Variables[SubIdKey] = subscriptionId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                subscriptionId = HttpMockServer.Variables[SubIdKey];
            } 

            Initialize();
        }

        private void Initialize()
        {
        }
    }
}