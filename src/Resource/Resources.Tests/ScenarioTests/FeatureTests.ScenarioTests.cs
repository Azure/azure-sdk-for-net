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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Common.TransientFaultHandling;
using Microsoft.WindowsAzure.Testing;
using Xunit;
using Microsoft.Azure.Utilities.HttpRecorder;
using ResourceGroups.Tests;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure;


namespace Features.Tests
{
    public class LiveFeatureTests : TestBase
    {
        string baseUri = "https://management.azure.com/";

        public FeatureClient GetFeatureClient(RecordedDelegatingHandler handler)
        {
            //var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            //handler.IsPassThrough = false;
            ////FeatureClientDiscoveryExtensions.CreateCloudServiceManagementClient();
            //return new FeatureClient(token).WithHandler(handler);


            handler.IsPassThrough = true;
            var client = this.GetFeatureClient();
            client = client.WithHandler(handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        public FeatureClient GetFeatureClient()
        {
            return TestBase.GetServiceClient<FeatureClient>(new CSMTestEnvironmentFactory());
        }
        
        
    }
}
