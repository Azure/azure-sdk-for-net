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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net;

namespace Compute.Tests
{
    public static class ComputeManagementTestUtilities
    {
        public static string DefaultLocation = "SoutheastAsia";

        public static ComputeManagementClient GetComputeManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<ComputeManagementClient>(handlers: 
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }
        
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static NetworkManagementClient GetNetworkManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<NetworkManagementClient>(handlers: handler);
            return client;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            return client;
        }

        public static void WaitSeconds(double seconds)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
        }

        public static string GenerateName(string prefix = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="GenerateName_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }
    }
}