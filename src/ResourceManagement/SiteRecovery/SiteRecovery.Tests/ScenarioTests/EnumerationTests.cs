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

using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery.Models;


namespace SiteRecovery.Tests
{
    public class EnumerationTests : SiteRecoveryTestsBase
    {
        private const string RecoveryservicePrefix = "RecoveryServices";

        [Fact]
        public void EnumerateServersTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Fabrics.List(RequestHeaders);

                Assert.True(response.Fabrics.Count > 0, "Servers count can't be less than 1");
                Assert.True(
                    response.Fabrics.All(
                    server => !string.IsNullOrEmpty(server.Name)),
                    "Server name can't be null or empty");
                Assert.True(
                    response.Fabrics.All(
                    server => !string.IsNullOrEmpty(server.Id)),
                    "Server Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateProtectedContainerTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMM");
                Assert.NotNull(vmWareFabric);

                //var vmWareDetails =
                //   vmWareFabric.Properties.CustomDetails as VMwareFabricDetails;
                //Assert.NotNull(vmWareDetails);

                var response = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);

                Assert.True(
                    response.ProtectionContainers.Count > 0,
                    "Protection containers count can't be less than 1");
                Assert.True(
                    response.ProtectionContainers.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)),
                    "Protection Container name can't be null or empty");
                Assert.True(
                    response.ProtectionContainers.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Id)),
                    "Protection Container Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateJobsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Jobs.List(RequestHeaders);

                Assert.True(response.Jobs.Count > 0, "Jobs count can't be less than 1");
                Assert.True(response.Jobs.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)),
                    "Job name can't be null or empty");
                Assert.True(response.Jobs.All(
                    protectedContainer => !string.IsNullOrEmpty(protectedContainer.Id)),
                    "Job Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        
        
        public void EnumerateProtectableItems()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "6adf9420-b02f-4377-8ab7-ff384e6d792f";
                //string containerId = "4f94127d-2eb3-449d-a708-250752e93cb4";
                string containerId = "8cc5a958-d437-41d0-9411-fad0841c0445";

                var response = client.ProtectableItem.List(fabricId, containerId, "All", RequestHeaders);
            }
        }

        
        public void EnumerateNetworksUnderFabricTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                var response = client.Network.List(fabricName, RequestHeaders);
            }
        }

        [Fact]
        public void EnumerateAllNetworksInSubscriptionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Network.GetAll(RequestHeaders);
            }
        }

        
        public void EnumerateNetworkMappingsUnderNetworkTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                const string networkName = "399137cc-f0de-4a3f-b961-fd0892d8ebc4";
                var response = client.NetworkMapping.List(fabricName, networkName, RequestHeaders);
            }
        }

        [Fact]
        public void EnumerateAllNetworkMappingsInSubscriptionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.NetworkMapping.GetAll(RequestHeaders);
            }
        }

        [Fact]
        public void EnumeratePoliciesTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Policies.List(RequestHeaders);
                Assert.NotNull(response);
                Assert.NotEmpty(response.Policies);
            }
        }
    }
}
