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

        public static ComputeManagementClient GetComputeManagementClientWithSpn(RecordedDelegatingHandler handler = null)
        {
            return GetComputeManagementClient(new ServicePrincipalNameFactory(),
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ComputeManagementClient GetComputeManagementClient(TestEnvironmentFactory factory, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ComputeManagementClient>(factory).WithHandler(handler);
        }

        public static ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            return GetResourceManagementClient(new CSMTestEnvironmentFactory(), handler);
        }

        public static ResourceManagementClient GetResourceManagementClientWithSpn(RecordedDelegatingHandler handler)
        {
            return GetResourceManagementClient(new ServicePrincipalNameFactory(), handler);
        }

        public static ResourceManagementClient GetResourceManagementClient(TestEnvironmentFactory factory, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ResourceManagementClient>(factory).WithHandler(handler);
        }

        public static NetworkResourceProviderClient GetNetworkResourceProviderClient(RecordedDelegatingHandler handler)
        {
            return GetNetworkResourceProviderClient(new CSMTestEnvironmentFactory(), handler);
        }

        public static NetworkResourceProviderClient GetNetworkResourceProviderClientSpn(RecordedDelegatingHandler handler)
        {
            return GetNetworkResourceProviderClient(new ServicePrincipalNameFactory(), handler);
        }

        public static NetworkResourceProviderClient GetNetworkResourceProviderClient(TestEnvironmentFactory factory, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<NetworkResourceProviderClient>(factory).WithHandler(handler);
        }

        public static StorageManagementClient GetStorageManagementClient(RecordedDelegatingHandler handler)
        {
            return GetStorageManagementClient(new CSMTestEnvironmentFactory(), handler);
        }

        public static StorageManagementClient GetStorageManagementClientSpn(RecordedDelegatingHandler handler)
        {
            return GetStorageManagementClient(new ServicePrincipalNameFactory(), handler);
        }

        public static StorageManagementClient GetStorageManagementClient(TestEnvironmentFactory factory, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<StorageManagementClient>(factory).WithHandler(handler);
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