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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net;

namespace Compute.Tests
{
    public static class ComputeManagementTestUtilities
    {
        public static string DefaultLocation = "SoutheastAsia";

        public static ComputeManagementClient GetComputeManagementClient(RecordedDelegatingHandler handler = null)
        {
            return GetComputeManagementClient(new CSMTestEnvironmentFactory(), 
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ComputeManagementClient GetComputeManagementClient(TestEnvironmentFactory factory, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = TestBase.GetServiceClient<ComputeManagementClient>(factory, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            client.SubscriptionId = factory.GetTestEnvironment().SubscriptionId;
            return client;
        }

        public static ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var factory = new CSMTestEnvironmentFactory();
            var client = TestBase.GetServiceClient<ResourceManagementClient>(factory, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            client.SubscriptionId = factory.GetTestEnvironment().SubscriptionId;
            return client;
        }

        public static NetworkResourceProviderClient GetNetworkResourceProviderClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var factory = new CSMTestEnvironmentFactory();
            var client = TestBase.GetServiceClient<NetworkResourceProviderClient>(factory, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            client.SubscriptionId = factory.GetTestEnvironment().SubscriptionId;
            return client;
        }

        public static StorageManagementClient GetStorageManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var factory = new CSMTestEnvironmentFactory();
            var client = TestBase.GetServiceClient<StorageManagementClient>(factory, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            client.SubscriptionId = factory.GetTestEnvironment().SubscriptionId;
            return client;
        }

        public static void WaitSeconds(double seconds)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
        }
    }
}