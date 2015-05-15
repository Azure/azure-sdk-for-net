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

using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;


namespace SiteRecovery.Tests
{
    public class GetTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void GetServerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Servers.List(RequestHeaders);

                var response = client.Servers.Get(responseServers.Servers[0].ID, RequestHeaders);

                Assert.NotNull(response.Server);
                Assert.NotNull(response.Server.Name);
                Assert.NotNull(response.Server.ID);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void GetProtectedContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var protectionContainerList = client.ProtectionContainer.List(RequestHeaders);
                var response = client.ProtectionContainer.Get(protectionContainerList.ProtectionContainers[0].ID, RequestHeaders);

                Assert.NotNull(response.ProtectionContainer);
                Assert.NotNull(response.ProtectionContainer.Name);
                Assert.NotNull(response.ProtectionContainer.ID);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void GetVirtualMachineTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                VirtualMachineResponse response = null;
                var protectionContainerList = client.ProtectionContainer.List(RequestHeaders);

                foreach (var pc in protectionContainerList.ProtectionContainers)
                {
                    if (pc.Role == "Primary")
                    {
                        var vmList = client.Vm.List(pc.ID, RequestHeaders);

                        if (vmList.Vms.Count != 0)
                        {
                            response = client.Vm.Get(vmList.Vms[0].ProtectionContainerId, vmList.Vms[0].ID, RequestHeaders);
                        }
                    }
                }

                Assert.NotNull(response);
                Assert.NotNull(response.Vm);
                Assert.NotNull(response.Vm.Name);
                Assert.NotNull(response.Vm.ID);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
